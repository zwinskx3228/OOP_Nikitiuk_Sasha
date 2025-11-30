using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary8.Interfaces
{
    public interface IRoomInfo
    {
        int Seats { get; }
        double Area { get; }
        int Beds { get; }
        string BedType { get; }
        string Furniture { get; }
        string RoomType { get; }
    }
}
