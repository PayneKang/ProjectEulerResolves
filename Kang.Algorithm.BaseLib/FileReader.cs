using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Kang.Algorithm.BaseLib
{
    public class FileReader
    {
        private FileReader() { }
        private const int BUFFER_SIZE = 1024;
        public static string ReadFile(string filePath)
        {
            using (FileStream fs = System.IO.File.Open(filePath, FileMode.Open))
            {
                StringBuilder sb = new StringBuilder();
                byte[] buffer = new byte[BUFFER_SIZE];
                int readCount = 0;
                do
                {
                    readCount = fs.Read(buffer, 0, BUFFER_SIZE);
                    sb.Append(System.Text.Encoding.UTF8.GetString(buffer, 0, readCount));
                } while (readCount > 0);
                fs.Close();
                return sb.ToString();
            }
        }
    }
}
