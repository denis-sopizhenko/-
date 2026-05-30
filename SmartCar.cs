using System;
using System.Collections.Generic;

public class SmartCar
{
    // Композиція
    private Engine _engine;
    private SensorArray _sensors;
    // Агрегація
    private List<Passenger> _passengers;
    // Асоціація
    private Route _activeRoute;

    // Властивість для збереження пройденого шляху (Версія 3)
    public int DistanceTraveled { get; private set; }

    public Engine CarEngine => _engine;
    public SensorArray CarSensors => _sensors;

    static SmartCar() => Console.WriteLine("[Static] SmartCar Operating System booted.");

    public SmartCar()
    {
        _engine = new Engine();
        _sensors = new SensorArray();
        _passengers = new List<Passenger>();
        DistanceTraveled = 0;
    }

    public SmartCar(SmartCar other)
    {
        this._engine = new Engine(other._engine);
        this._sensors = new SensorArray(other._sensors);
        this._passengers = new List<Passenger>(other._passengers);
        this.DistanceTraveled = other.DistanceTraveled;
    }

    public void BoardPassenger(Passenger passenger)
    {
        _passengers.Add(passenger);
        Console.WriteLine($"[SmartCar] '{passenger.Name}' entered the smart cabin.");
    }

    private bool RunPreDriveSafetyCheck()
    {
        foreach (var p in _passengers)
        {
            // Використання предикату пасажира
            if (!p.IsSafe()) 
            {
                Console.WriteLine($"[Safety Lock] ALERT: Passenger '{p.Name}' is unsafe!");
                return false;
            }
        }
        return true;
    }

    public void Drive(Route route)
    {
        _activeRoute = route;
        if (RunPreDriveSafetyCheck())
        {
            _engine.Start();
            Console.WriteLine($"[SmartCar] Mission started to {_activeRoute.Destination}.");
        }
        else
        {
            Console.WriteLine("[SmartCar] DRIVE BLOCKED. Pre-drive check failed.");
        }
    }

    public void AdjustSpeed(int speed)
    {
        _engine.SetSpeed(speed);
    }

    public void CheckSurroundings()
    {
        // Використання предикату сенсорів
        if (!_sensors.IsPathClear())
        {
            Console.WriteLine($"[SmartCar Auto-Brake] Proximity danger ({_sensors.GetObstacleDistance()}m)! Activating brakes...");
            _engine.SetSpeed(0);
        }
        else
        {
            Console.WriteLine($"[SmartCar] Road state: CLEAR. Distance: {_sensors.GetObstacleDistance()}m.");
        }
    }

    // Функція імітації прогресу їзди (Версія 3)
    public void SimulateDistanceTraveled(int km)
    {
        if (_engine.IsRunning && _engine.CurrentSpeed > 0)
        {
            DistanceTraveled += km;
            Console.WriteLine($"[Trip Progress] Drove +{km} km. Total traveled: {DistanceTraveled} km.");
        }
        else
        {
            Console.WriteLine("[Trip Progress] Car cannot move. Check speed or engine status.");
        }
    }

    // ВЕРСІЯ 3: Предикатна функція загального стану руху авто
    public bool IsMoving()
    {
        return _engine.IsRunning && _engine.CurrentSpeed > 0;
    }
}
