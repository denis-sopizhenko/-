using System;
using System.Collections.Generic;

// Успадковує абстрактний Vehicle та реалізує інтерфейси IAutopilot, IDiagnosable
public class SmartCar : Vehicle, IAutopilot, IDiagnosable
{
    // Композиція (тепер використовує більш просунутий ElectricEngine)
    private Engine _engine;
    private SensorArray _sensors;
    private List<Passenger> _passengers;
    private Route _activeRoute;

    public int DistanceTraveled { get; private set; }
    public Engine CarEngine => _engine;
    public SensorArray CarSensors => _sensors;

    // Конструктор викликає базовий конструктор абстрактного класу Vehicle
    public SmartCar() : base()
    {
        _engine = new ElectricEngine(); // Підстановка підтипу (Поліморфізм)
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

    // Реалізація обов'язкового абстрактного методу класу Vehicle
    public override void StartVehicle()
    {
        _isStarted = true;
        Console.WriteLine("[Vehicle Override] SmartCar electronic systems awakened.");
    }

    // Реалізація методу інтерфейсу IAutopilot
    public void Navigate(Route route)
    {
        _activeRoute = route;
        Console.WriteLine($"[Interface IAutopilot] Loading GPS path coordinates to: {_activeRoute.Destination}");
        Drive(_activeRoute);
    }

    // Реалізація методу інтерфейсу IDiagnosable
    public void PrintDiagnosticReport()
    {
        Console.WriteLine("\n==== INTERFACE DIAGNOSTIC REPORT ====");
        Console.WriteLine($"* Vehicle System Base Started: {_isStarted}");
        Console.WriteLine($"* Core Predicate [Is Moving]: {IsMoving()}");
        Console.WriteLine($"* Core Predicate [Engine Healthy]: {_engine.IsSystemHealthy()}");
        Console.WriteLine($"* Core Predicate [Path Clear]: {_sensors.IsPathClear()}");
        Console.WriteLine("=====================================");
    }

    public void BoardPassenger(Passenger passenger) => _passengers.Add(passenger);
    
    public void Drive(Route route) 
    { 
        _activeRoute = route; 
        if (_passengers.Count > 0 && _passengers[0].IsSafe()) 
        {
            StartVehicle();
            _engine.Start(); 
        }
        else
        {
            Console.WriteLine("[SmartCar] DRIVE BLOCKED. Passenger not found or not secured.");
        }
    }
    
    public void AdjustSpeed(int speed) => _engine.SetSpeed(speed);
    public void CheckSurroundings() { if (!_sensors.IsPathClear()) _engine.SetSpeed(0); }
    public void SimulateDistanceTraveled(int km) { if (_engine.IsRunning && _engine.CurrentSpeed > 0) DistanceTraveled += km; }
    public bool IsMoving() => _engine.IsRunning && _engine.CurrentSpeed > 0;

    public void AccelerateWithIncrement() { _engine++; Console.WriteLine($"[SmartCar] Cruise velocity ++: {_engine.CurrentSpeed} km/h"); }
    public void DecelerateWithDecrement() { _engine--; Console.WriteLine($"[SmartCar] Cruise velocity --: {_engine.CurrentSpeed} km/h"); }

    public static bool operator >(SmartCar left, SmartCar right) => left.CarEngine.CurrentSpeed > right.CarEngine.CurrentSpeed;
    public static bool operator <(SmartCar left, SmartCar right) => left.CarEngine.CurrentSpeed < right.CarEngine.CurrentSpeed;
    public static bool operator ==(SmartCar left, SmartCar right) => left.CarEngine.CurrentSpeed == right.CarEngine.CurrentSpeed;
    public static bool operator !=(SmartCar left, SmartCar right) => left.CarEngine.CurrentSpeed != right.CarEngine.CurrentSpeed;

    public override bool Equals(object obj) => obj is SmartCar car && _engine.CurrentSpeed == car._engine.CurrentSpeed;
    public override int GetHashCode() => _engine.CurrentSpeed.GetHashCode();
}
