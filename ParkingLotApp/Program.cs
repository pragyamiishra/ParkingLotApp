using ParkingLotApp;
using System;

class Program
{
    static void Main(string[] args)
    {
        ParkingManager parkingManager = new ParkingManager();

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Park a vehicle");
            Console.WriteLine("2. Leave the parking");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter vehicle type (1: Hatchback, 2: Sedan/Compact SUV, 3: SUV/Large):");
                    int vehicleTypeInput;
                    if (!int.TryParse(Console.ReadLine(), out vehicleTypeInput) || vehicleTypeInput < 1 || vehicleTypeInput > 3)
                    {
                        Console.WriteLine("Invalid vehicle type.");
                        break;
                    }
                    VehicleType vehicleType = (VehicleType)(vehicleTypeInput - 1);
                    int parkedLot = parkingManager.ParkVehicle(vehicleType);
                    if (parkedLot != -1)
                    {
                        Console.WriteLine($"Vehicle parked at lot {parkedLot}.");
                    }
                    else
                    {
                        Console.WriteLine("No available lots.");
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter lot number to leave:");
                    int lotNumber;
                    if (!int.TryParse(Console.ReadLine(), out lotNumber))
                    {
                        Console.WriteLine("Invalid lot number.");
                        break;
                    }
                    if (parkingManager.LeaveParking(lotNumber))
                    {
                        Console.WriteLine($"Lot {lotNumber} left successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"Lot {lotNumber} not found or already empty.");
                    }
                    break;
                case 3:
                    Console.WriteLine("Exiting program.");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }
    }
}
