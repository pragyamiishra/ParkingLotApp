using ParkingLotApp;

namespace ParkingLotAppTests
{
    [TestClass]
    public class ParkingManagerTests
    {
        [TestMethod]
        public void ParkVehicle_Success()
        {
            // Arrange
            var parkingManager = new ParkingManager();

            // Act
            var lotNumber = parkingManager.ParkVehicle(VehicleType.Hatchback);

            // Assert
            Assert.IsTrue(lotNumber > 0);
        }
        [TestMethod]
        public void ParkVehicle_Failure_NoAvailableLot()
        {
            // Arrange
            var parkingManager = new ParkingManager();
            OccupyAllParkingLots(parkingManager);

            // Act
            var lotNumber = parkingManager.ParkVehicle(VehicleType.Hatchback);

            // Assert
            Assert.IsTrue(lotNumber == -1);
        }
        [TestMethod]
        public void LeaveParking_Success()
        {
           // Arrange
           var parkingManager = new ParkingManager();
            var lotNumber = parkingManager.ParkVehicle(VehicleType.Hatchback);

           // Act
           var success = parkingManager.LeaveParking(lotNumber);
                Assert.AreEqual(true, success);
            
        }
        [TestMethod]
        public void LeaveParking_Failure_LotNotFound()
        {
            // Arrange
            var parkingManager = new ParkingManager();

            // Act
            var success = parkingManager.LeaveParking(101);
            // Assert
            Assert.AreEqual(false, success);
        }
        // Helper method to occupy all parking lots
        private void OccupyAllParkingLots(ParkingManager parkingManager)
        {
            for (int i = 0; i < 100; i++)
            {
                parkingManager.ParkVehicle(VehicleType.Hatchback);
            }
        }

    }
}

