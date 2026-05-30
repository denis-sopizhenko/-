using System;

public class SensorArray
{
    private int _simulatedDistance;

    static SensorArray() => Console.WriteLine("[Static] Sensor drivers active.");
    
    public SensorArray()
    {
        _simulatedDistance = 150; // Початкова безпечна відстань
    }

    public SensorArray(SensorArray other)
    {
        this._simulatedDistance = other._simulatedDistance;
    }

    // Функція з Версії 2 для зміни параметрів
    public void UpdateObstacleDistance(int meters)
    {
        _simulatedDistance = meters;
        Console.WriteLine($"[Sensors] Laser scanner updated manually to: {_simulatedDistance} meters.");
    }

    public int GetObstacleDistance()
    {
        return _simulatedDistance; 
    }

    // ВЕРСІЯ 3: Предикатна функція оцінки ситуації на дорозі
    public bool IsPathClear()
    {
        return _simulatedDistance >= 15; // Шлях чистий, якщо перешкода далі ніж за 15 метрів
    }
}
