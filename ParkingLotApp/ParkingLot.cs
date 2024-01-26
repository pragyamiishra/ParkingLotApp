using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ParkingLotApp
{
    internal class ParkingLot
    {
        public int LotNumber { get; set; }
        public string? LotType { get; set; }
        public bool IsOccupied { get; set; }
    }
    public enum VehicleType
    {
        Hatchback,
        SedanCompactSUV,
        SUVOrLarge
    }
}
