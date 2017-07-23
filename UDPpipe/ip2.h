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

#define TH_FIN  0x01
#define TH_SYN  0x02
#define TH_RST  0x04
#define TH_PSH  0x08
#define TH_ACK  0x10
#define TH_URG  0x20
#define TH_ECN  0x40
#define TH_CWR  0x80



#pragma pack(1)

typedef struct {
    uint8_t     ihl_ver;
    uint8_t     tos;
    uint16_t    tot_len;
    uint16_t    id;
    uint16_t    frag_off;
    uint8_t     ttl;
    uint8_t     protocol;
    uint16_t    check;
    uint32_t    saddr;
    uint32_t    daddr;
} iph;

typedef struct {
    uint16_t    source;
    uint16_t    dest;
    uint16_t    len;
    uint16_t    check;
} udph;

typedef struct {
    uint32_t    saddr;
    uint32_t    daddr;
    uint8_t     zero;
    uint8_t     protocol;
    uint16_t    length;
} udph_pseudo;

typedef struct {
    uint16_t    source;
    uint16_t    dest;
    uint32_t    seq;
    uint32_t    ack_seq;
    uint8_t     doff;
    uint8_t     flags;
    uint16_t    window;
    uint16_t    check;
    uint16_t    urg_ptr;
} tcph;

typedef struct {
    uint8_t     icmp_type;
    uint8_t     icmp_code;
    uint16_t    icmp_cksum;
    union {
        uint8_t     ih_pptr;
        uint32_t    ih_gwaddr;
        struct {
            uint16_t    icd_id;
            uint16_t    icd_seq;
        } ih_idseq;
        uint32_t    ih_void;
        struct {
            uint16_t    ipm_void;
            uint16_t    ipm_nextmtu;
        } ih_pmtu;
        struct {
            uint8_t     irt_num_addrs;
            uint8_t     irt_wpa;
            uint16_t    irt_lifetime;
        } ih_rtradv;
    } icmp_hun;
    #define	icmp_pptr       icmp_hun.ih_pptr
    #define	icmp_gwaddr     icmp_hun.ih_gwaddr
    #define	icmp_id         icmp_hun.ih_idseq.icd_id
    #define	icmp_seq        icmp_hun.ih_idseq.icd_seq
    #define	icmp_void       icmp_hun.ih_void
    #define	icmp_pmvoid     icmp_hun.ih_pmtu.ipm_void
    #define	icmp_nextmtu    icmp_hun.ih_pmtu.ipm_nextmtu
    #define	icmp_num_addrs  icmp_hun.ih_rtradv.irt_num_addrs
    #define	icmp_wpa        icmp_hun.ih_rtradv.irt_wpa
    #define	icmp_lifetime   icmp_hun.ih_rtradv.irt_lifetime
    union {
        struct {
            uint32_t    its_otime;
            uint32_t    its_rtime;
            uint32_t    its_ttime;
        } id_ts;
        struct {
            iph         idi_ip;
        } id_ip;
        struct {
            uint32_t    ira_addr;
            uint32_t    ira_preference;
        } id_radv;
        uint32_t   id_mask;
        uint8_t    id_data[1];
    } icmp_dun;
    #define	icmp_otime  icmp_dun.id_ts.its_otime
    #define	icmp_rtime  icmp_dun.id_ts.its_rtime
    #define	icmp_ttime  icmp_dun.id_ts.its_ttime
    #define	icmp_ip     icmp_dun.id_ip.idi_ip
    #define	icmp_radv   icmp_dun.id_radv
    #define	icmp_mask   icmp_dun.id_mask
    #define	icmp_data   icmp_dun.id_data
} icmph;

typedef struct {
    uint8_t     igmp_type;
    uint8_t     igmp_code;
    uint16_t    igmp_cksum;
    uint32_t    igmp_group;
} igmph;

#pragma pack()
