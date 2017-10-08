//
// Authors:
//   Lucas Ontivero lucasontivero@gmail.com 
//
// Copyright (C) 2014 Lucas Ontivero
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Open.Nat
{
    internal static class StreamExtensions
    {
        internal static string ReadAsMany(this StreamReader stream, int bytesToRead)
        {
            var buffer = new char[bytesToRead];
            stream.ReadBlock(buffer, 0, bytesToRead);
            return new string(buffer);
        }

        internal static string GetXmlElementText(this XmlNode node, string elementName)
        {
            XmlElement element = node[elementName];
            return element != null ? element.InnerText : string.Empty;
        }

        internal static bool ContainsIgnoreCase(this string s, string pattern)
        {
            return s.IndexOf(pattern, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        internal static void LogInfo(this TraceSource source, string format, params object[] args)
        {
            source.TraceEvent(TraceEventType.Information, 0, format, args);
        }

        internal static void LogWarn(this TraceSource source, string format, params object[] args)
        {
            source.TraceEvent(TraceEventType.Warning, 0, format, args);
        }

        internal static void LogError(this TraceSource source, string format, params object[] args)
        {
            source.TraceEvent(TraceEventType.Error, 0, format, args);
        }

        internal static string ToPrintableXml(this XmlDocument document)
        {
            using (var stream = new MemoryStream())
            {
                using (var writer = new XmlTextWriter(stream, Encoding.Unicode))
                {
                    try
                    {
                        writer.Formatting = Formatting.Indented;

                        document.WriteContentTo(writer);
                        writer.Flush();
                        stream.Flush();

                        // Have to rewind the MemoryStream in order to read
                        // its contents.
                        stream.Position = 0;

                        // Read MemoryStream contents into a StreamReader.
                        var reader = new StreamReader(stream);

                        // Extract the text from the StreamReader.
                        return reader.ReadToEnd();
                    }
                    catch (Exception)
                    {
                        return document.ToString();
                    }
                }
            }
        }

        public static async Task<TResult> TimeoutAfter<TResult>(this Task<TResult> task, TimeSpan timeout)
        {
#if DEBUG
            return await task;
#endif
            var timeoutCancellationTokenSource = new CancellationTokenSource();

            Task completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token));
            if (completedTask == task)
            {
                timeoutCancellationTokenSource.Cancel();
                return await task;
            }
            throw new TimeoutException(
                "The operation has timed out. The network is broken, router has gone or is too busy.");
        }
    }
}