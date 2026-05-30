using System;

public abstract class Vehicle
{
    protected bool _isStarted;

    public Vehicle()
    {
        _isStarted = false;
        Console.WriteLine("[Abstract Vehicle Constructor] Base vehicle chassis memory allocated.");
    }

    // Абстрактний метод, який зобов'язані реалізувати всі спадкоємці
    public abstract void StartVehicle();
}