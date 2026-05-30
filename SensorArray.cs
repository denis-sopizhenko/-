using System;

public class SensorArray
{
    private int _simulatedDistance;

    // Конструктор без параметрів (збережений з попередніх версій)
    public SensorArray()
    {
        _simulatedDistance = 150;
    }

    // ВІДПОВІДЬ НА ПОМИЛКУ: Додано конструктор копії, який очікував SmartCar
    public SensorArray(SensorArray other)
    {
        this._simulatedDistance = other._simulatedDistance;
    }

    // Збережені функції керування дистанцією
    public void UpdateObstacleDistance(int meters) => _simulatedDistance = meters;
    public int GetObstacleDistance() => _simulatedDistance;
    public bool IsPathClear() => _simulatedDistance >= 15;

    // ВЕРСІЯ 4: Унарний оператор '-' (імітація зашумлення)
    public static SensorArray operator -(SensorArray s)
    {
        s._simulatedDistance /= 2;
        return s;
    }
}
