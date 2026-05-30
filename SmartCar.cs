using System;
using System.Collections.Generic;

public class SmartCar
{
    private Engine _engine;
    private SensorArray _sensors;
    private List<Passenger> _passengers;
    private Route _activeRoute;

    public int DistanceTraveled { get; private set; }
    public Engine CarEngine => _engine;
    public SensorArray CarSensors => _sensors;

    public SmartCar() { _engine = new Engine(); _sensors = new SensorArray(); _passengers = new List<Passenger>(); }
    public SmartCar(SmartCar other) { this._engine = new Engine(other._engine); this._sensors = new SensorArray(other._sensors); this._passengers = new List<Passenger>(other._passengers); }

    public void BoardPassenger(Passenger passenger) => _passengers.Add(passenger);
    public void Drive(Route route) { _activeRoute = route; if (_passengers[0].IsSafe()) _engine.Start(); }
    public void AdjustSpeed(int speed) => _engine.SetSpeed(speed);
    public void CheckSurroundings() { if (!_sensors.IsPathClear()) _engine.SetSpeed(0); }
    public void SimulateDistanceTraveled(int km) { if (_engine.IsRunning && _engine.CurrentSpeed > 0) DistanceTraveled += km; }
    public bool IsMoving() => _engine.IsRunning && _engine.CurrentSpeed > 0;

    // ВЕРСІЯ 4: Задачі другого пріоритету - використання операторів інкременту/декременту
    public void AccelerateWithIncrement()
    {
        _engine++; // Виклик перевантаженого оператора ++
        Console.WriteLine($"[SmartCar] Incremented cruise speed via ++. New speed: {_engine.CurrentSpeed} km/h");
    }

    public void DecelerateWithDecrement()
    {
        _engine--; // Виклик перевантаженого оператора --
        Console.WriteLine($"[SmartCar] Decremented cruise speed via --. New speed: {_engine.CurrentSpeed} km/h");
    }

    // ВЕРСІЯ 4: Перевантаження операторів порівняння (==, !=, <, >, <=, >=) за швидкістю
    public static bool operator >(SmartCar left, SmartCar right) => left.CarEngine.CurrentSpeed > right.CarEngine.CurrentSpeed;
    public static bool operator <(SmartCar left, SmartCar right) => left.CarEngine.CurrentSpeed < right.CarEngine.CurrentSpeed;
    public static bool operator ==(SmartCar left, SmartCar right) => left.CarEngine.CurrentSpeed == right.CarEngine.CurrentSpeed;
    public static bool operator !=(SmartCar left, SmartCar right) => left.CarEngine.CurrentSpeed != right.CarEngine.CurrentSpeed;
    public static bool operator >=(SmartCar left, SmartCar right) => left.CarEngine.CurrentSpeed >= right.CarEngine.CurrentSpeed;
    public static bool operator <=(SmartCar left, SmartCar right) => left.CarEngine.CurrentSpeed <= right.CarEngine.CurrentSpeed;

    public override bool Equals(object obj) => obj is SmartCar car && _engine.CurrentSpeed == car._engine.CurrentSpeed;
    public override int GetHashCode() => _engine.CurrentSpeed.GetHashCode();
}
