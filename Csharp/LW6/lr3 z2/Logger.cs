using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr_1_3
{
    public class Logger
    {
        public event EventHandler<string>? LogUpdated;
        public List<string> Logs { get; } = new();

        public void Log(string message)
        {
            string entry = $"[{DateTime.Now:T}] {message}";
            Logs.Add(entry);
            LogUpdated?.Invoke(this, entry);
        }
    }
}
