namespace DroneDeliveryApp.Console.Models
{
    public class Delivery
    {
        public Drone Drone { get; set; }

        public IList<Location> Locations { get; set; }
    }
}
