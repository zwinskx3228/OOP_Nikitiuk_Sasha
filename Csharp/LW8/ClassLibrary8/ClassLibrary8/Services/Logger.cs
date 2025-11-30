using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary8.Services
{
    public class Logger
    {
        private readonly string filePath = "log.txt";

        public void Log(string message)
        {
            File.AppendAllText(filePath, $"{DateTime.Now}: {message}\n");
        }
    }
}
