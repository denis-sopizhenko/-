using System;

public class SensorArray
{
    // Проста закрита властивість для внутрішніх тестів
    private int SimulatedDistance { get; set; }

    static SensorArray() => Console.WriteLine("[Static] Proximity sensor array calibrated.");

    public SensorArray()
    {
        SimulatedDistance = 150; // Стандартна безпечна відстань (можна змінити для тесту гальм)
        Console.WriteLine("[Constructor] SensorArray modules deployed.");
    }

    public SensorArray(SensorArray other)
    {
        this.SimulatedDistance = other.SimulatedDistance;
        Console.WriteLine("[Copy Constructor] Sensor layout replicated.");
    }

    // Збережена функція повернення дистанції
    public int GetObstacleDistance()
    {
        // Для демонстрації екстреного гальмування змініть повернене значення на < 10
        return SimulatedDistance;
    }
}
