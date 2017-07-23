/*
    Copyright 2008,2009 Luigi Auriemma

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation; either version 2 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307 USA

    http://www.gnu.org/licenses/gpl-2.0.txt
*/

#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <time.h>
#include "ip2.h"

#if defined ACPDUMP_LOCK && WIN32
    #include <windows.h>
    #define ACPDUMP_LOCK_VAR    static LONG is_writing = 0;
    #define ACPDUMP_LOCK_START  while(InterlockedExchange(&is_writing, 1)) Sleep(0);
    #define ACPDUMP_LOCK_END    InterlockedExchange(&is_writing, 0);
#else
    #define ACPDUMP_LOCK_VAR
    #define ACPDUMP_LOCK_START
    #define ACPDUMP_LOCK_END
#endif



#define ACPDUMP_VER     "0.2c"



#ifdef ACPDUMP_ADDR_STRUCT      // define this one if you don't have the following struct

struct in_addr {
    union {
        struct { uint8_t s_b1,s_b2,s_b3,s_b4; } S_un_b;
        struct { uint16_t s_w1,s_w2; } S_un_w;
        uint32_t S_addr;
    } S_un;
#define s_addr  S_un.S_addr
#define s_host  S_un.S_un_b.s_b2
#define s_net   S_un.S_un_b.s_b1
#define s_imp   S_un.S_un_w.s_w2
#define s_impno S_un.S_un_b.s_b4
#define s_lh    S_un.S_un_b.s_b3
};

struct sockaddr_in {
    int16_t     sin_family;
    uint16_t    sin_port;
    struct      in_addr sin_addr;
    char        sin_zero[8];
};

struct sockaddr {
    uint16_t    sa_family;
    char        sa_data[14];
};

#endif

struct timevalx {
    int32_t     tv_sec;
    int32_t     tv_usec;
};



uint32_t str2ip(uint8_t *data) {
    unsigned    a, b, c, d;

    if(!data[0]) return(0);
    sscanf((char *)data, "%u.%u.%u.%u", &a, &b, &c, &d);
    return((a & 0xff) | ((b & 0xff) << 8) | ((c & 0xff) << 16) | ((d & 0xff) << 24));
}



uint8_t *ip2str(uint32_t ip) {
    static uint8_t  data[16];

    sprintf((char *)data, "%u.%u.%u.%u",
        (ip & 0xff), ((ip >> 8) & 0xff), ((ip >> 16) & 0xff), ((ip >> 24) & 0xff));
    return(data);
}


uint16_t net16(uint16_t num) {
    int         endian = 1; // big endian

    if(!*(char *)&endian) return(num);
    return((num << 8) | (num >> 8));
}



uint32_t net32(uint32_t num) {
    int         endian = 1; // big endian

    if(!*(char *)&endian) return(num);
    return(((num & 0xff000000) >> 24) |
           ((num & 0x00ff0000) >>  8) |
           ((num & 0x0000ff00) <<  8) |
           ((num & 0x000000ff) << 24));
}



uint16_t in_cksum(void *data, int len, uint32_t *ret_sum) {
    uint32_t    sum    = 0;
    int         i      = len >> 1,
                endian = 1; // big endian
    uint16_t    crc,
                *p     = (uint16_t *)data;

    if(*(char *)&endian) endian = 0;
    if(ret_sum) sum = *ret_sum;
    while(i--) sum += *p++;
    if(len & 1) sum += *p & (endian ? 0xff00 : 0xff);
    if(ret_sum) *ret_sum = sum;
    crc = sum = (sum >> 16) + (sum & 0xffff);
    if(sum >>= 16) crc += sum;
    if(!endian) crc = (crc >> 8) | (crc << 8);
    return(~crc);
}



void putxx(FILE *fd, uint32_t num, int bits) {
    int         i,
                bytes;

    bytes = bits >> 3;
    for(i = 0; i < bytes; i++) {
        fputc(num >> (i << 3), fd);
    }
}



void create_acp(FILE *fd) {
    if(!fd) return;
    putxx(fd, 0xa1b2c3d4, 32);
    putxx(fd, 2,          16);
    putxx(fd, 4,          16);
    putxx(fd, 0,          32);
    putxx(fd, 0,          32);
    putxx(fd, 65535,      32);
    putxx(fd, 1,          32);
    fflush(fd);
}



void acp_dump(FILE *fd, int type, int protocol, uint32_t src_ip, uint16_t src_port, uint32_t dst_ip, uint16_t dst_port, uint8_t *data, int len, uint32_t *seq1, uint32_t *ack1, uint32_t *seq2, uint32_t *ack2) {
    ACPDUMP_LOCK_VAR
    struct {
        struct timevalx ts;
        uint32_t        caplen;
        uint32_t        len;
    } acp_pck;
    static const uint8_t ethdata[14] =
                    "\x00\x00\x00\x00\x00\x00"  /* dest   */
                    "\x00\x00\x00\x00\x00\x00"  /* source */
                    "\x08\x00";                 /* type   */
    udph_pseudo udp_ps;
    uint32_t    crc;
    iph     ip;
    udph    udp;
    tcph    tcp;
    icmph   icmp;
    igmph   igmp;
    int     size,
            tpsize,
            close_tcp;
    uint8_t *tp;

    if(!fd) return;
    if(!type && !protocol) {
        protocol = 6;
    } else if((type == 1) && !protocol) {
        protocol = 6;
    } else if((type == 2) && !protocol) {
        protocol = 17;
    } else if((type == 3) && !protocol) {
        protocol = 255;
    }
    tp     = NULL;
    tpsize = 0;
    if(type == 3) {
        // SOCK_RAW
    } else if(protocol == 6) {
        tp     = (uint8_t *)&tcp;
        tpsize = sizeof(tcph);
    } else if(protocol == 17) {
        tp     = (uint8_t *)&udp;
        tpsize = sizeof(udph);
    } else if(protocol == 1) {
        tp     = (uint8_t *)&icmp;
        tpsize = sizeof(icmph);
    } else if(protocol == 2) {
        tp     = (uint8_t *)&igmp;
        tpsize = sizeof(igmph);
    }

    close_tcp = 0;
    if(len < 0) {
        close_tcp = 1;
        len = 0;
    }

    if((type == 3) && (protocol == 255)) {
        // SOCK_RAW, IPPROTO_RAW
        size = len;
    } else {
        size = sizeof(iph) + tpsize + len;
    }

    if((sizeof(acp_pck) + sizeof(ethdata) + size) > 0xffff) { // divides the packet if it's too big
        size = len; // use size as new "len" so acp_dump can be called with the same arguments
        if((type == 3) && (protocol == 255)) {
            len = 0xffff - (sizeof(acp_pck) + sizeof(ethdata));
        } else {
            len = 0xffff - (sizeof(acp_pck) + sizeof(ethdata) + sizeof(iph) + tpsize);
        }
        while(size > 0) {
            if(size < len) len = size;
            acp_dump(fd, type, protocol, src_ip, src_port, dst_ip, dst_port, data, len, seq1, ack1, seq2, ack2);
            size -= len;
            data += len;
        }
        return;
    }

    // use the following if gettimeofday doesn't exist on Windows
    acp_pck.ts.tv_sec  = time(NULL);
    //acp_pck.ts.tv_usec = GetTickCount();

    acp_pck.caplen   = sizeof(ethdata) + size;
    acp_pck.len      = sizeof(ethdata) + size;

    ip.ihl_ver       = 0x45;
    ip.tos           = 0;
    ip.tot_len       = net16(size);
    ip.id            = net16(1);
    ip.frag_off      = net16(0);
    ip.ttl           = 128;
    ip.protocol      = protocol;
    ip.check         = net16(0);
    ip.saddr         = src_ip;
    ip.daddr         = dst_ip;
    ip.check         = net16(in_cksum((uint8_t *)&ip, sizeof(iph), NULL));

    if(!tp) {
        // SOCK_RAW
    } else if(protocol == 6) {
        tcp.source       = src_port;
        tcp.dest         = dst_port;
        tcp.seq          = net32(*seq1);
        tcp.ack_seq      = net32(*ack1);
        tcp.doff         = sizeof(tcph) << 2;
        if(close_tcp) {
            tcp.flags    = TH_RST | TH_FIN | TH_ACK;
        } else if((*seq1 == 1) && (*ack1 == 0)) {
            tcp.flags    = TH_SYN;
        } else if((*seq1 == 1) && (*ack1 == 2)) {
            tcp.flags    = TH_SYN | TH_ACK;
        } else if((*seq1 == 2) && (*ack1 == 2) && !data) {
            tcp.flags    = TH_ACK;
        } else {
            tcp.flags    = TH_PSH | TH_ACK;
            *ack2 = *seq1;
            (*seq1) += len;
        }
        tcp.window       = net16(65535);
        tcp.check        = net16(0);
        tcp.urg_ptr      = net16(0);

    } else if(protocol == 17) {
        udp.source       = src_port;
        udp.dest         = dst_port;
        udp.check        = net16(0);
        udp.len          = net16(sizeof(udph) + len);

        udp_ps.saddr     = ip.saddr;
        udp_ps.daddr     = ip.daddr;
        udp_ps.zero      = 0;
        udp_ps.protocol  = 17;
        udp_ps.length    = udp.len;
        crc = 0;                 in_cksum(&udp_ps, sizeof(udph_pseudo), &crc);
                                 in_cksum(&udp,    sizeof(udph), &crc);
        udp.check        = net16(in_cksum(data,    len, &crc));

    } else if(protocol == 1) {
        memset(&icmp, 0, sizeof(icmph));
        icmp.icmp_type  = 8;
        icmp.icmp_code  = 0;
        crc = 0;                in_cksum(&icmp, sizeof(udph_pseudo), &crc);
        icmp.icmp_cksum = net16(in_cksum(data,  len, &crc));

    } else if(protocol == 2) {
        igmp.igmp_type  = 0x11;
        igmp.igmp_code  = 0;
        igmp.igmp_cksum = net16(0);
        igmp.igmp_group = net32(0);
        crc = 0;                in_cksum(&igmp, sizeof(udph_pseudo), &crc);
        igmp.igmp_cksum = net16(in_cksum(data,  len, &crc));
    }

    ACPDUMP_LOCK_START
    fwrite(&acp_pck,  sizeof(acp_pck), 1, fd);
    fwrite(ethdata,   sizeof(ethdata), 1, fd);
    if(!((type == 3) && (protocol == 255))) {
        fwrite(&ip,   sizeof(iph),     1, fd);
    }
    if(tp) fwrite(tp, tpsize,          1, fd);
    fwrite(data,      len,             1, fd);
    fflush(fd);
    ACPDUMP_LOCK_END
}



void acp_dump_handshake(FILE *fd, int type, int protocol, uint32_t src_ip, uint16_t src_port, uint32_t dst_ip, uint16_t dst_port, uint8_t *data, int len, uint32_t *seq1, uint32_t *ack1, uint32_t *seq2, uint32_t *ack2) {
    if(!fd) return;
    if(!seq1 || !ack1 || !seq2 || !ack2) return;

    *seq1 = 0;  // useless initialization
    *ack1 = 0;
    *seq2 = 0;
    *ack2 = 0;
    if(!((!type && !protocol) || ((type == 1) && !protocol) || (protocol == 6))) {
        return; // if it's not tcp don't make handshake
    }

    *seq1 = 1;
    *ack1 = 0;
    acp_dump(fd, type, protocol, src_ip, src_port, dst_ip, dst_port, NULL, 0, seq1, ack1, seq2, ack2);

    *ack2 = *seq1 + 1;
    *seq2 = 1;
    acp_dump(fd, type, protocol, dst_ip, dst_port, src_ip, src_port, NULL, 0, seq2, ack2, seq1, ack1);

    *ack1 = *seq2 + 1;
    (*seq1)++;
    acp_dump(fd, type, protocol, src_ip, src_port, dst_ip, dst_port, data, len, seq1, ack1, seq2, ack2);

    (*seq2)++;
}


