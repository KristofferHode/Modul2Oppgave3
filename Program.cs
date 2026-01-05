
namespace Modul2Oppgave3;

class Program
{
    static async Task Main(string[] args)
    {
        var drones = new List<DroneModel>
        {
            new DroneModel{Name="Pegasus",MaxCheckpoints=5,DelayMs=500},
            new DroneModel{Name="Hermes",MaxCheckpoints=3,DelayMs=800},
            new DroneModel{Name="Prometheus",MaxCheckpoints=4,DelayMs=600},
            new DroneModel{Name="FlashGordon",MaxCheckpoints=7,DelayMs=1100},
        };

        var httpClient= new HttpClient();
        var controlTower= new ControlTowerClientAPI(httpClient);

        try
        {
            var weather = await controlTower.GetWeatherAsync();
            Console.WriteLine($"Weather condition: {weather}");
        

        foreach (var drone in drones)
        {
            if (weather == "wind")drone.DelayMs+=300;
            if (weather == "storm") drone.DelayMs += 700;
        }

        var tasks =drones.Select(DroneAsyncRunner.RunDroneAsync);
        await Task.WhenAll(tasks);

        Console.WriteLine("all drones completed");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Control tower error: {ex.Message}");
        }
    }
}
