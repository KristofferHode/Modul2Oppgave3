

using System.ComponentModel.DataAnnotations;

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
       
       var tasks = drones.Select(DroneAsyncRunner.RunDroneAsync).ToList();
        try
        {
            await Task.WhenAll(tasks);
            Console.WriteLine("All drones compledted successfully");
        }
        catch(Exception ex)
        {
            Console.WriteLine("One or more drones failed");
            Console.WriteLine(ex.Message);
        }

        

    }
}
