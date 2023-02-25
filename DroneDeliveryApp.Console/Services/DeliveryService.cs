using DroneDeliveryApp.Console.Models;

namespace DroneDeliveryApp.Console.Services
{
    public class DeliveryService
    {
        private readonly List<Drone> _drones;
        private readonly List<Location> _locations;

        public DeliveryService(List<Drone> drones, List<Location> locations)
        {
            _drones = drones.OrderByDescending(drone => drone.Capacity).ToList();
            _locations = locations.OrderByDescending(location => location.Weight).ToList();
        }

        public void Assign()
        {
            foreach (var drone in _drones)
            {
                List<Location> locations = new();

                for (int i = 0; i < _locations.Count; i++)
                {
                    var currentCapacity = GetCurrentCapacity(drone, locations);

                    if (currentCapacity - _locations[i].Weight >= 0)
                    {
                        locations.Add(_locations[i]);
                        _locations.RemoveAt(i);
                    }
                }

                if (locations.Count > 0)
                {
                    drone.Deliveries.Add(new Delivery
                    {
                        Drone = drone,
                        Locations = locations
                    });
                }
            }
        }

        public int GetAvailableLocations() => _locations.Count;

        private decimal GetCurrentCapacity(Drone drone, List<Location> locations)
        {
            var usedCapacity = locations.Sum(l => l.Weight);

            return drone.Capacity - usedCapacity;
        }
    }
}
