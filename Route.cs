using System;

public class Route
{
    // Приватні поля
    private string _startPoint;
    private string _destination;
    private int _distanceKm;

    // Статичний конструктор
    static Route() => Console.WriteLine("[Static] Route navigation maps loaded.");

    // Закритий конструктор
    private Route(string start, string dest, int dist, bool internalToken)
    {
        _startPoint = start;
        _destination = dest;
        _distanceKm = dist;
    }

    // Конструктор без параметрів (Ланцюжок: викликає основний)
    public Route() : this("Default Start", "Default Destination", 10, true)
    {
        Console.WriteLine("[Constructor] Parameterless Route initialized.");
    }

    // Конструктор з параметрами (Ланцюжок)
    public Route(string start, string dest, int dist) : this(start, dest, dist, true)
    {
        Console.WriteLine($"[Constructor] Parameterized Route created: {start} -> {dest} ({dist} km).");
    }

    // Конструктор копії
    public Route(Route other)
    {
        this._startPoint = other._startPoint;
        this._destination = other._destination;
        this._distanceKm = other._distanceKm;
        Console.WriteLine($"[Copy Constructor] Route tracking duplicated.");
    }

    // Відкриті властивості читання та запису (Аксесори)
    public string StartPoint { get => _startPoint; set => _startPoint = value; }
    public string Destination { get => _destination; set => _destination = value; }
    public int DistanceKm
    {
        get => _distanceKm;
        set { if (value > 0) _distanceKm = value; }
    }
}
