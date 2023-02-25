using DroneDeliveryApp.Console.Models;
using DroneDeliveryApp.Console.Services;

Console.Write("Please enter the input file path, then press ENTER: ");

string filePath = Console.ReadLine();
string[] lines = System.IO.File.ReadAllLines(filePath);

var drones = Drone.GetDroneData(lines);
var locations = Location.GetLocationData(lines);

ProcessDeliveries(drones, locations);
PrintDeliveries(drones);


Console.WriteLine("\n\nClick any key to exit ...");
Console.ReadKey();

void ProcessDeliveries(List<Drone> drones, List<Location> locations)
{
	if (drones.Count > 0 && drones.Count <= 100 && locations.Count > 0)
	{
		var deliveryService = new DeliveryService(drones, locations);
		var availableLocations = locations.Count;

		while (availableLocations > 0)
		{
			deliveryService.Assign();
			availableLocations = deliveryService.GetAvailableLocations();
		}
	}
}

void PrintDeliveries(List<Drone> drones)
{
	Console.WriteLine();
	Console.WriteLine("-------------------------------------------------------------");
	Console.WriteLine();
	Console.WriteLine("These are the deliveries to do:");

    for (int i = 0; i < drones.Count; i++)
    {
		Console.WriteLine($"\t{drones[i].Name}");

		for (int j = 0; j < drones[i].Deliveries.Count; j++)
		{
			Console.WriteLine($"\tTrip #{j + 1}");
			
			var locationsText = "";

            for (int k = 0; k < drones[i].Deliveries[j].Locations.Count; k++)
            {
				locationsText += $"{drones[i].Deliveries[j].Locations[k].Name}, ";
			}

			Console.WriteLine($"\t{locationsText[0..^2]}");
			Console.WriteLine($"\b");
		}
	}
}