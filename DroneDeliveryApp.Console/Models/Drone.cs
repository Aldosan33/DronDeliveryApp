namespace DroneDeliveryApp.Console.Models
{
    public class Drone
    {
        public string Name { get; set; }

        public decimal Capacity { get; set; }

        public IList<Delivery> Deliveries { get; set; }

        public static List<Drone> GetDroneData(string[] lines)
        {
			var drones = new List<Drone>();

			if (lines == null || lines.Length == 0) return drones;

			string[] droneData = lines[0].Split(",");

			if (droneData.Length % 2 == 0 && droneData.Length > 0 && droneData.Length <= 100)
			{
				for (int i = 0; i < droneData.Length; i += 2)
				{
					droneData[i + 1] = droneData[i + 1].Replace("[", "").Replace("]", "");
					drones.Add(new Drone
					{
						Name = droneData[i].Trim(),
						Capacity = Convert.ToDecimal(droneData[i + 1]),
						Deliveries = new List<Delivery>()
					});
				}
			}

			return drones;
		}
    }
}
