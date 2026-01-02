
using System.Reflection;

namespace Modul2Oppgave3;

public static class DroneAsyncRunner
{
    public static async Task RunDroneAsync(DroneModel drone)
    {
        Console.WriteLine($"{drone.Name}START");

        if (drone.DelayMs<0)
            throw new ArgumentException("Delay cannot be negative");
            
        for (int I = 0; I <=drone.MaxCheckpoints; I++)
        {
            Console.WriteLine($"{drone.Name} arrived at checkpoint {I}");


            if (drone.Name == "Hermes" && I ==2)
            throw new InvalidOperationException("Engine failiure at checkpoint");

            await Task.Delay(drone.DelayMs);
        }
        Console.WriteLine($"{drone.Name} Completed");
    }
}