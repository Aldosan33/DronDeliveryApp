namespace DroneDeliveryApp.Console.Models
{
    public class Location
    {
        public string Name { get; set; }

        public decimal Weight { get; set; }

		public static List<Location> GetLocationData(string[] lines)
		{
			var locations = new List<Location>();

			if (lines == null || lines.Length < 2) return locations;

			string[] locationLines = lines.Skip(1).ToArray();

			if(locationLines.Length > 0)
            {
                for (int i = 0; i < locationLines.Length; i++)
                {
					var locationData = locationLines[i].Split(',');

                    if (locationData.Length == 2)
                    {
						var weight = locationData[1].Replace("[", "").Replace("]", "");

						locations.Add(new Location
						{
							Name = locationData[0].Trim(),
							Weight = Convert.ToDecimal(weight)
						});
					}
				}
            }

			return locations;
		}
	}
}
