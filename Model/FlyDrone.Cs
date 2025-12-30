namespace Modul2Oppgave3;

public static class DroneWorker
{


    public static void FlyDrone(object? obj)
    {
        DroneModel drone = (DroneModel)obj!;
        for(int i = 1; i <= drone.MaxCheckpoints; i++)
        {
            Console.WriteLine($"{drone.Name} arrived at checkpoint {i}");
            Thread.Sleep(drone.DelayMs);

        }

        Console.WriteLine($"{drone.Name} completed delivery");
    }
}