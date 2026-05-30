using System;

public class Engine
{
    // Автоматичні властивості (Аксесори)
    public bool IsRunning { get; private set; }
    public int CurrentSpeed { get; set; }

    static Engine() => Console.WriteLine("[Static] Engine ECU firmware mapped.");

    // Закритий конструктор
    private Engine(bool state)
    {
        IsRunning = state;
        CurrentSpeed = 0;
    }

    // Конструктор без параметрів (Ланцюжок)
    public Engine() : this(false)
    {
        Console.WriteLine("[Constructor] Default physical Engine built.");
    }

    // Конструктор копії
    public Engine(Engine other)
    {
        this.IsRunning = other.IsRunning;
        this.CurrentSpeed = other.CurrentSpeed;
        Console.WriteLine("[Copy Constructor] Engine hardware blueprint cloned.");
    }

    // Збережені функції керування двигуном
    public void Start()
    {
        IsRunning = true;
        Console.WriteLine("[Engine] System ON. Power plant is idling.");
    }

    public void SetSpeed(int speed)
    {
        if (IsRunning)
        {
            CurrentSpeed = speed;
            Console.WriteLine($"[Engine] Speed altered. Current kinetic velocity: {CurrentSpeed} km/h.");
        }
        else
        {
            Console.WriteLine("[Engine] ERROR: Ignition is OFF. Acceleration denied.");
        }
    }
}
