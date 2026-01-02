using System.Threading.Tasks;

namespace Modul2Oppgave3;

class Program
{
    static async Task Main(string[] args)
    {
        List<DroneModel> drones= new()
        {
            new DroneModel{Name="Pegasus",MaxCheckpoints=5,DelayMs=500},
            new DroneModel{Name="Hermes",MaxCheckpoints=3,DelayMs=800},
            new DroneModel{Name="Prometheus",MaxCheckpoints=4,DelayMs=600},
            new DroneModel{Name="FlashGordon",MaxCheckpoints=7,DelayMs=1100},
        };
        List<Task> tasks = new();
        foreach(var drone in drones)
        {
            tasks.Add(DroneRunner.RunDroneAsync(drone));

        }
        try
        {
            await Task.WhenAll(tasks);
            Console.WriteLine("all drones completed their delivery");
        }
        catch
        {
            Console.WriteLine("One or more drones failed");
            foreach (var task in tasks.Where(t=> t.IsFaulted))
            {
                Console.WriteLine(task.Exception!.InnerException!.Message);
            }
        }

    }
}
