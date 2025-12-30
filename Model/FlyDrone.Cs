static void Flydrone(object? obj)
{
    DroneModel drone = (DroneModel)obj!;
    for(int i = 1; i <= drone.MaxCheckpoints; i++)
    {
        Console.WriteLine($"{drone.Name} arrived at checkpoint");
        Thread.Sleep(drone.DelayMs);

    }

    Console.WriteLine($"{drone.Name} completed delivery");
}