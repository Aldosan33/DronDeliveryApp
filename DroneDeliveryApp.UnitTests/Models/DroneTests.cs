using DroneDeliveryApp.Console.Models;
using System;
using Xunit;

namespace DroneDeliveryApp.UnitTests.Models
{
    public class DroneTests
    {
        [Fact]
        public void Should_GetDroneData_ReturnsEmptyList_When_Null()
        {
            //Act
            var drones = Drone.GetDroneData(null);

            //Asert
            Assert.Empty(drones);
        }

        [Fact]
        public void Should_GetDroneData_ReturnsEmptyList_When_Empty()
        {
            //Act
            var drones = Drone.GetDroneData(Array.Empty<string>());

            //Asert
            Assert.Empty(drones);
        }

        [Theory]
        [InlineData(new object[] { new string[] { "foo", "" } })]
        public void Should_GetDroneData_ReturnsEmptyList_When_NotFormattedLines(string[] lines)
        {
            //Act
            var drones = Drone.GetDroneData(lines);

            //Asert
            Assert.Empty(drones);
        }

        [Fact]
        public void Should_GetDroneData_ReturnsDrones_When_FormattedLines()
        {
            // Arrange
            string[] lines = new string[] {
                "[DroneA], [200], [DroneB], [250], [DroneC], [100]",
            };

            //Act
            var drones = Drone.GetDroneData(lines);

            //Asert
            Assert.NotEmpty(drones);
            Assert.True(drones.Count == 3);
            Assert.True(drones[0].Name == "[DroneA]");
            Assert.True(drones[0].Capacity == 200);
        }
    }
}
