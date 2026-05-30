using System;

public class Engine
{
    public bool IsRunning { get; private set; }
    public int CurrentSpeed { get; set; }
    public int Temperature { get; private set; } // Новий змінюваний атрибут стану

    static Engine() => Console.WriteLine("[Static] Engine ECU firmware loaded.");

    public Engine()
    {
        IsRunning = false;
        CurrentSpeed = 0;
        Temperature = 20; // Кімнатна температура при старті
    }

    public Engine(Engine other)
    {
        this.IsRunning = other.IsRunning;
        this.CurrentSpeed = other.CurrentSpeed;
        this.Temperature = other.Temperature;
    }

    public void Start()
    {
        IsRunning = true;
        Temperature = 90; // Робоча температура двигуна
        Console.WriteLine("[Engine] Ignition ON. Temperature stable at 90°C.");
    }

    public void SetSpeed(int speed)
    {
        if (IsRunning)
        {
            CurrentSpeed = speed;
            // Швидкість збільшує нагрів двигуна
            Temperature = 90 + (speed / 5);
            Console.WriteLine($"[Engine] Speed updated: {CurrentSpeed} km/h. Temperature: {Temperature}°C");
        }
    }

    public void Stop()
    {
        IsRunning = false;
        CurrentSpeed = 0;
        Temperature = 40;
        Console.WriteLine("[Engine] Engine shut down.");
    }

    // ВЕРСІЯ 3: Предикатні функції стану двигуна
    public bool IsSystemHealthy()
    {
        // Система справна, якщо немає перегріву та критичних помилок
        return Temperature < 115;
    }

    public bool IsOverheated()
    {
        return Temperature >= 110; // Перегрів при високих швидкостях
    }
}
