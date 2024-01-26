using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp
{
    public class ParkingManager
    {
        private List<ParkingLot> parkingLots;

        public ParkingManager()
        {
            // Initialize parking Lots
            parkingLots = new List<ParkingLot>();
            InitializeParkingLots();
        }
        private void InitializeParkingLots()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i <= 50)
                {
                    parkingLots.Add(new ParkingLot { LotNumber = i, LotType = "Small" });
                }
                else if (i <= 80)
                {
                    parkingLots.Add(new ParkingLot { LotNumber = i, LotType = "Medium" }) ;
                }
                else
                {
                    parkingLots.Add(new ParkingLot { LotNumber = i, LotType = "Large" }); ;
                }
            }
        }
        public int ParkVehicle(VehicleType vehicleType)
        {
            foreach (var lot in parkingLots)
            {
                if (!lot.IsOccupied && CanFitInLot(vehicleType, lot.LotType))
                {
                    lot.IsOccupied = true;
                    return lot.LotNumber;
                }
            }
            return -1; // No available lot
        }
        public bool LeaveParking(int lotNumber)
        {
            var lot = parkingLots.FirstOrDefault(s => s.LotNumber == lotNumber) ;

            if (lot != null && lot.IsOccupied)
            {
                lot.IsOccupied = false;
                return true;
            }

            return false; // Lot not found or already empty
        }

        private bool CanFitInLot(VehicleType vehicleType, string lotType)
        {
            switch (vehicleType)
            {
                case VehicleType.Hatchback:
                    return true; // Hatchback can fit in any lot
                case VehicleType.SedanCompactSUV:
                    return lotType != "Small"; // Sedan/Compact SUV cannot fit in Small lot
                case VehicleType.SUVOrLarge:
                    return lotType == "Large"; // SUV or Large cars can fit in Large lot only
                default:
                    return false;
            }
        }

    }
}
