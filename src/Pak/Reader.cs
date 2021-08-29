using System.IO;
using System.Collections.Generic;
using System.Text;
using System;
namespace Wyvern.Pak
{
    public class Reader
    {
        private Stream stream;
        private long position;
        stream = new Stream(stream);
        private long length;
        
        public Reader(Stream stream)
        {
            stream = new Stream(stream);
            this.stream = stream;
            this.position = 0;
            this.length = stream.Length;
        }
        public PakData Read()
        {
            PakData data = new PakData();
            data.Metadata = ReadHeader();
            foreach (string line in ReadNonEmptyLines(stream))
            {
                string[] parts = line.Split(new char[] { ':' }, 2);
                if (parts.Length >= 2)
                {
                    data.Entries.Add(parts[0], Concat(parts));
                }
            }
            this.data=data;
            return data;
        }
        private PakMetadata ReadHeader()
        {
            PakMetadata metadata = new PakMetadata();
            foreach (string line in ReadHeaderLines(stream))
            {
                string[] parts = line.Split(new char[] { ':' }, 2);
                if (parts.Length >= 2)
                {
                    metadata.Entries.Add(parts[0], Concat(parts));
                }
            }
            return metadata;
        }
        private string Concat(string[] parts)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < parts.Length; i++)
            {
                sb.Append(parts[i]);
            }
            return sb.ToString().Trim();
        }
        private IEnumerable<string> ReadHeaderLines(Stream stream)
        {
            stream = new Stream(stream);
            string line;
            bool IN_HEADER = false;
            while ((line = ReadLine(stream)) != null)
            {
                if (line.IndexOf("\\") != -1)
                {
                    line = line.Substring(0, line.IndexOf("\\"));
                }
                if (line.Trim().Length == 0)
                {
                    continue;
                }
                if (line.Trim() == "{")
                {
                    IN_HEADER = true;
                }
                else if (line.Trim() == "}")
                {
                    IN_HEADER = false;
                    break;
                }
                else if (IN_HEADER)
                {
                    yield return line;
                }
            }
        }
        private IEnumerable<string> ReadNonEmptyLines(Stream stream)
        {
            stream = new Stream(stream);
            string line;
            bool IN_HEADER = false;
            while ((line = ReadLine(stream)) != null)
            {
                if (line.IndexOf("\\") != -1)
                {
                    line = line.Substring(0, line.IndexOf("\\"));
                }
                if (line.Trim().Length == 0)
                {
                    continue;
                }
                if (line.Trim() == "{")
                {
                    IN_HEADER = true;
                }
                else if (line.Trim() == "}")
                {
                    IN_HEADER = false;
                    break;
                }
                else if (IN_HEADER)
                {
                    continue;
                }
                else
                {
                    yield return line;
                }
            }
        }
        private string ReadLine(Stream stream)
        {
            stream = new Stream(stream);
            StringBuilder sb = new StringBuilder();
            int c;
            while ((c = stream.ReadByte()) != -1)
            {
                if (c == '\n')
                {
                    break;
                }
                sb.Append((char)c);
            }
            return sb.ToString();
        }
    }
}
