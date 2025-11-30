using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary8.Interfaces
{
    public interface IComfort
    {
        bool Wifi { get; }
        bool Food { get; }
        string Climate { get; }
        string Toilet { get; }
    }
}
