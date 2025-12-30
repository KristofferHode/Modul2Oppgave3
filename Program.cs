namespace Modul2Oppgave3;

class Program
{
    static void Main(string[] args)
    {
        List<DroneModel> drones= new()
        {
            new DroneModel{Name="Pegasus",MaxCheckpoints=5,DelayMs=500},
            new DroneModel{Name="Hermes",MaxCheckpoints=3,DelayMs=800},
            new DroneModel{Name="Prometheus",MaxCheckpoints=4,DelayMs=600},
            new DroneModel{Name="FlashGordon",MaxCheckpoints=7,DelayMs=1100},
        };
        List<Thread> threads = new();
        foreach (var drone in drones)
        {
            Thread t =new Thread(DroneWorker.FlyDrone);
            threads.Add(t);
            t.Start(drone);

        }

        //foreach (var t in threads)
      //  {
      //      t.Join();
      //  }
        
       // Console.WriteLine("All drones completed");
    }
}
