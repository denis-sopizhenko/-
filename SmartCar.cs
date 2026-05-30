using System;
using System.Collections.Generic;

public class SmartCar
{
    private Engine _engine;
    private SensorArray _sensors;
    private List<Passenger> _passengers;

    public SmartCar()
    {
        _engine = new Engine();
        _sensors = new SensorArray();
        _passengers = new List<Passenger>();
        Console.WriteLine("[SmartCar] Vehicle systems initialized.");
    }

    public void BoardPassenger(Passenger passenger)
    {
        _passengers.Add(passenger);
        Console.WriteLine($"[SmartCar] Welcome, {passenger.Name}. Registered in cabin.");
    }

    private bool RunPreDriveSafetyCheck()
    {
        Console.WriteLine("[Safety] Running pre-drive diagnostics...");
        foreach (var p in _passengers)
        {
            if (!p.IsSeatbeltFastened)
            {
                Console.WriteLine($"[Safety] ALERT: Passenger {p.Name} is NOT secured!");
                return false;
            }
        }
        Console.WriteLine("[Safety] Diagnostics PASSED. All passengers secured.");
        return true;
    }

    public void Drive(Route route)
    {
        Console.WriteLine($"\n[SmartCar] Attempting to route to {route.Destination} ({route.DistanceKm} km)...");

        if (RunPreDriveSafetyCheck())
        {
            _engine.Start();
            Console.WriteLine($"[SmartCar] Autopilot activated. Heading to {route.Destination}.");
        }
        else
        {
            Console.WriteLine("[SmartCar] DRIVE LOCKED. Please resolve safety alerts first.");
        }
    }

    public void AdjustSpeed(int speed)
    {
        _engine.SetSpeed(speed);
    }

    public void CheckSurroundings()
    {
        int dist = _sensors.GetObstacleDistance();
        Console.WriteLine($"[Sensors] Laser scanner reports nearest obstacle at: {dist} meters.");
    }
}