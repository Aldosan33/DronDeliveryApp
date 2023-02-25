using DroneDeliveryApp.Console.Models;
using System;
using Xunit;

namespace DroneDeliveryApp.UnitTests.Models
{
    public class LocationTests
    {
        [Fact]
        public void Should_GetLocationData_ReturnsEmptyList_When_Null()
        {
            //Act
            var locations = Location.GetLocationData(null);

            //Asert
            Assert.Empty(locations);
        }

        [Fact]
        public void Should_GetLocationData_ReturnsEmptyList_When_Empty()
        {
            //Act
            var locations = Location.GetLocationData(Array.Empty<string>());

            //Asert
            Assert.Empty(locations);
        }

        [Fact]
        public void Should_GetLocationData_ReturnsEmptyList_When_LinesAreLessThanTwo()
        {
            //Act
            var locations = Location.GetLocationData(new string[] { "foo" });

            //Asert
            Assert.Empty(locations);
        }

        [Fact]
        public void Should_GetLocationData_ReturnsLocations_When_FormattedLines()
        {
            // Arrange
            string[] lines = new string[] {
                "[DroneA], [200], [DroneB], [250], [DroneC], [100]",
                "[LocationA], [200]",
                "[LocationB], [150]",
                "[LocationC], [50]"
            };

            //Act
            var locations = Location.GetLocationData(lines);

            //Asert
            Assert.NotEmpty(locations);
            Assert.True(locations.Count == 3);
            Assert.True(locations[0].Name == "[LocationA]");
            Assert.True(locations[0].Weight == 200);
        }
    }
}
