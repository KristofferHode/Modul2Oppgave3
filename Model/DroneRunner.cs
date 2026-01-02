namespace Modul2Oppgave3;
public static class DroneRunner
{
    public static Task RunDroneAsync(DroneModel drone)
    {
        var tcs=new TaskCompletionSource();
        Task.Run(async () =>
        {
            try
            {
                Console.WriteLine($"{drone.Name} Start");
                if (drone.DelayMs < 0)
                    throw new ArgumentException("DelayMs cannot be negative");
                for (int i = 0; i <= drone.MaxCheckpoints; i++)
                {
                    Console.WriteLine($"{drone.Name} -> checkpoint {i}");

                    //engine failiure
                    if (drone.Name == "Hermes" && i==2)
                    throw new InvalidOperationException("Engine failiure at checkpoint");
                    await Task.Delay(drone.DelayMs);
                }  

            Console.WriteLine($"{drone.Name} complete");
            tcs.SetResult(); 
            }
        
        catch(Exception ex)
            {
                Console.WriteLine($"{drone.Name}Error: {ex.Message}");
                tcs.SetException(ex);
            }

        });
    }







}