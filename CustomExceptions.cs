using System;

// Виняток: Спроба почати рух із непристебнутими пасажирами
public class UnsecuredPassengerException : Exception
{
    public string PassengerName { get; private set; }

    public UnsecuredPassengerException(string name, string message) : base(message)
    {
        PassengerName = name;
    }
}

// Виняток: Критичний перегрів або апаратне пошкодження двигуна
public class EngineOverheatException : Exception
{
    public int CurrentTemperature { get; private set; }

    public EngineOverheatException(int temp, string message) : base(message)
    {
        CurrentTemperature = temp;
    }
}