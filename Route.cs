using System;

public class Route
{
    private string _startPoint;
    private string _destination;
    private int _distanceKm;

    static Route() { }
    public Route() : this("Default Start", "Default Destination", 10) { }
    public Route(string start, string dest, int dist)
    {
        _startPoint = start; _destination = dest; _distanceKm = dist;
    }
    public Route(Route other)
    {
        this._startPoint = other._startPoint; this._destination = other._destination; this._distanceKm = other._distanceKm;
    }

    public string StartPoint { get => _startPoint; set => _startPoint = value; }
    public string Destination { get => _destination; set => _destination = value; }
    public int DistanceKm { get => _distanceKm; set { if (value > 0) _distanceKm = value; } }

    public bool IsLongDistance() => _distanceKm >= 100;

    // ВЕРСІЯ 4: Перевантаження бінарного оператора '+'
    // Дозволяє логічно зшивати два суміжні маршрути (A->B і B->C в один маршрут A->C)
    public static Route operator +(Route left, Route right)
    {
        int combinedDistance = left.DistanceKm + right.DistanceKm;
        return new Route(left.StartPoint, right.Destination, combinedDistance);
    }
}
