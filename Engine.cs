using System;

public class Engine
{
    public bool IsRunning { get; private set; }
    public int CurrentSpeed { get; private set; }

    public void Start()
    {
        IsRunning = true;
        CurrentSpeed = 0;
        Console.WriteLine("[Engine] System ONLINE. Core running.");
    }

    public void SetSpeed(int speed)
    {
        if (IsRunning)
        {
            CurrentSpeed = speed;
            Console.WriteLine("[Engine] Throttle adjusted. Current speed: " + CurrentSpeed + " km/h.");
        }
        else
        {
            Console.WriteLine("[Engine] CRITICAL: Cannot accelerate. Engine is OFF.");
        }
    }
}