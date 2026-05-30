using System;
using System.Collections.Generic;

public class SmartCar : Vehicle, IAutopilot, IDiagnosable
{
    private Engine _engine;
    private SensorArray _sensors;
    private List<Passenger> _passengers;
    private Route _activeRoute;

    public int DistanceTraveled { get; private set; }
    public Engine CarEngine => _engine;
    public SensorArray CarSensors => _sensors;

    public SmartCar() : base()
    {
        _engine = new ElectricEngine();
        _sensors = new SensorArray();
        _passengers = new List<Passenger>();
        DistanceTraveled = 0;
    }

    public void BoardPassenger(Passenger passenger) => _passengers.Add(passenger);

    private void RunPreDriveSafetyCheck()
    {
        foreach (var p in _passengers)
        {
            // ВЕРСІЯ 6: Замість звичайного false, тепер генеруємо КОРИСТУВАЦЬКИЙ ВИНЯТОК
            if (!p.IsSafe()) 
            {
                throw new UnsecuredPassengerException(p.Name, $"Safety violation! Passenger '{p.Name}' has NOT fastened the seatbelt.");
            }
        }
    }

    public void Drive(Route route) 
    { 
        _activeRoute = route; 
        
        // Перевірка може викинути виняток UnsecuredPassengerException
        RunPreDriveSafetyCheck();

        StartVehicle();
        _engine.Start(); 
        Console.WriteLine($"[SmartCar] Mission started to {_activeRoute.Destination}.");
    }
    
    public void AdjustSpeed(int speed) 
    { 
        _engine.SetSpeed(speed); 
        
        // ВЕРСІЯ 6: Якщо двигун сигналізує про перегрів, SmartCar перехоплює і генерує виняток
        if (_engine.IsOverheated())
        {
            throw new EngineOverheatException(_engine.Temperature, $"CRITICAL FAILURE: Engine hardware overheated to {_engine.Temperature}°C!");
        }
    }

    // ВЕРСІЯ 6: Метод аналізу поїздки, який може спровокувати стандартний виняток ділення на нуль
    public int CalculateTimeToDestination()
    {
        if (_activeRoute == null) return 0;
        
        // Якщо швидкість дорівнює 0, цей рядок згенерує стандартний DivideByZeroException
        int remainingDistance = _activeRoute.DistanceKm - DistanceTraveled;
        return remainingDistance / _engine.CurrentSpeed; 
    }

    public void CheckSurroundings() { if (!_sensors.IsPathClear()) _engine.SetSpeed(0); }
    public void SimulateDistanceTraveled(int km) { if (_engine.IsRunning && _engine.CurrentSpeed > 0) DistanceTraveled += km; }
    public bool IsMoving() => _engine.IsRunning && _engine.CurrentSpeed > 0;
    public override void StartVehicle() => _isStarted = true;
    public void Navigate(Route route) { _activeRoute = route; Drive(_activeRoute); }
    public void PrintDiagnosticReport() { /* Збережений лог з версії 5 */ }
    public void AccelerateWithIncrement() { AdjustSpeed(_engine.CurrentSpeed + 10); }
    public void DecelerateWithDecrement() { AdjustSpeed(_engine.CurrentSpeed - 10); }
}
