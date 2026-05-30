using System;
using System.Collections.Generic;

public class SmartCar
{
    // Композиція (Внутрішнє створення об'єктів)
    private Engine _engine;
    private SensorArray _sensors;

    // Агрегація (Зовнішні об'єкти)
    private List<Passenger> _passengers;

    // Асоціація (Використання об'єкта)
    private Route _activeRoute;

    // Відкриті аксесори для перевірки стану з Main()
    public Engine CarEngine => _engine;
    public SensorArray CarSensors => _sensors;

    static SmartCar() => Console.WriteLine("[Static] SmartCar Operating System loaded.");

    // Закритий конструктор
    private SmartCar(Engine eng, SensorArray sens)
    {
        _engine = eng;
        _sensors = sens;
        _passengers = new List<Passenger>();
    }

    // Конструктор без параметрів (Реалізує КОМПОЗИЦІЮ + Ланцюжок)
    public SmartCar() : this(new Engine(), new SensorArray())
    {
        Console.WriteLine("[Constructor] SmartCar chassis fully assembled with new Core Components.");
    }

    // Конструктор копії (Глибоке копіювання компонентів композиції)
    public SmartCar(SmartCar other)
    {
        this._engine = new Engine(other._engine);
        this._sensors = new SensorArray(other._sensors);
        this._passengers = new List<Passenger>(other._passengers); // Агреговані копіюються за посиланнями
        Console.WriteLine("[Copy Constructor] SmartCar system architecture fully cloned.");
    }

    // Збережена функція Агрегації
    public void BoardPassenger(Passenger passenger)
    {
        _passengers.Add(passenger);
        Console.WriteLine($"[SmartCar] Passenger '{passenger.Name}' successfully registered in cabin.");
    }

    // Збережена функція контролю безпеки sebelum рухом
    private bool RunPreDriveSafetyCheck()
    {
        Console.WriteLine("[SmartCar Safety] Running pre-flight cabin diagnostics...");
        foreach (var p in _passengers)
        {
            if (!p.IsSeatbeltFastened)
            {
                Console.WriteLine($"[SmartCar Safety] CRITICAL: Passenger '{p.Name}' has NOT fastened the seatbelt!");
                return false;
            }
        }
        Console.WriteLine("[SmartCar Safety] Diagnostics PASSED. All parameters secure.");
        return true;
    }

    // Збережена функція Асоціації руху
    public void Drive(Route route)
    {
        _activeRoute = route;
        Console.WriteLine($"\n[SmartCar] Planning trip to '{_activeRoute.Destination}' ({_activeRoute.DistanceKm} km)...");

        if (RunPreDriveSafetyCheck())
        {
            _engine.Start();
            Console.WriteLine("[SmartCar] Autopilot engaged. Starting cruise routine.");
        }
        else
        {
            Console.WriteLine("[SmartCar] INITIATION LOCKED. Engine start aborted due to safety violation.");
        }
    }

    // Збережена функція зміни швидкості
    public void AdjustSpeed(int speed)
    {
        _engine.SetSpeed(speed);
    }

    // Збережена функція аналізу сенсорів із системою захисту
    public void CheckSurroundings()
    {
        int currentDistance = _sensors.GetObstacleDistance();
        Console.WriteLine($"[Sensors] Nearest dynamic object tracked at: {currentDistance} meters.");

        if (currentDistance < 10)
        {
            Console.WriteLine("[SmartCar Emergency] Collision risk detected! Engaging automatic braking...");
            _engine.SetSpeed(0);
        }
    }
}
