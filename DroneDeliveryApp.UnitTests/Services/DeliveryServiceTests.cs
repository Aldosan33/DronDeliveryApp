using DroneDeliveryApp.Console.Models;
using DroneDeliveryApp.Console.Services;
using System.Collections.Generic;
using Xunit;

namespace DroneDeliveryApp.UnitTests.Services
{
    public class DeliveryServiceTests
    {
        [Fact]
        public void Should_GetAvailableLocations_ReturnsAvailableLocations()
        {
            // Arrange
            var drones = new List<Drone>();
            drones.Add(new Drone() { Name = "DroneA", Capacity = 200, Deliveries = new List<Delivery>() });

            var locations = new List<Location>();
            locations.Add(new Location() { Name = "LocationA", Weight = 200 });

            var deliveryService = new DeliveryService(drones, locations);

            //Act
            deliveryService.GetAvailableLocations();

            //Asert
            Assert.True(deliveryService.GetAvailableLocations() == locations.Count);
        }

        [Fact]
        public void Should_Assign_ReturnDroneWithDeliveries()
        {
            // Arrange
            var drones = new List<Drone>();
            drones.Add(new Drone() { Name = "DroneA", Capacity = 200, Deliveries = new List<Delivery>() });

            var locations = new List<Location>();
            locations.Add(new Location() { Name = "LocationA", Weight = 200 });

            var deliveryService = new DeliveryService(drones, locations);

            //Act
            deliveryService.Assign();

            //Asert
            Assert.True(drones[0].Deliveries.Count > 0);
        }
    }
}
