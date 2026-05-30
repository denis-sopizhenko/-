using System;

public class Engine
{
    public bool IsRunning { get; private set; }
    public int CurrentSpeed { get; set; }
    public int Temperature { get; private set; }

    public Engine() { IsRunning = false; CurrentSpeed = 0; Temperature = 20; }
    public Engine(Engine other) { this.IsRunning = other.IsRunning; this.CurrentSpeed = other.CurrentSpeed; this.Temperature = other.Temperature; }

    public void Start() { IsRunning = true; Temperature = 90; }
    public void SetSpeed(int speed) { if (IsRunning) { CurrentSpeed = speed; Temperature = 90 + (speed / 5); } }
    public void Stop() { IsRunning = false; CurrentSpeed = 0; Temperature = 40; }
    public bool IsSystemHealthy() => Temperature < 115;
    public bool IsOverheated() => Temperature >= 110;

    // ВЕРСІЯ 4: Перевантаження унарних операторів '++' та '--'
    public static Engine operator ++(Engine e)
    {
        if (e.IsRunning)
        {
            e.CurrentSpeed += 10; // Крок круїз-контролю +10 км/год
            e.Temperature = 90 + (e.CurrentSpeed / 5);
        }
        return e;
    }

    public static Engine operator --(Engine e)
    {
        if (e.IsRunning && e.CurrentSpeed >= 10)
        {
            e.CurrentSpeed -= 10; // Крок круїз-контролю -10 км/год
            e.Temperature = 90 + (e.CurrentSpeed / 5);
        }
        return e;
    }

    // ВЕРСІЯ 4: Перевантаження унарного оператора '!'
    public static bool operator !(Engine e)
    {
        return !e.IsRunning;
    }

    // ВЕРСІЯ 4: Перевантаження операторів true та false (для умовних виразів)
    public static bool operator true(Engine e)
    {
        return e.IsRunning && e.IsSystemHealthy();
    }

    public static bool operator false(Engine e)
    {
        return !e.IsRunning || e.IsOverheated();
    }
}
