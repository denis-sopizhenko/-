using System;

public class Engine
{
    public bool IsRunning { get; protected set; } // Змінено на protected для доступу нащадків
    public int CurrentSpeed { get; set; }
    public int Temperature { get; protected set; }

    public Engine() { IsRunning = false; CurrentSpeed = 0; Temperature = 20; }
    public Engine(Engine other) { this.IsRunning = other.IsRunning; this.CurrentSpeed = other.CurrentSpeed; this.Temperature = other.Temperature; }

    public virtual void Start() { IsRunning = true; Temperature = 90; }
    public void SetSpeed(int speed) { if (IsRunning) { CurrentSpeed = speed; Temperature = 90 + (speed / 5); } }
    public virtual void Stop() { IsRunning = false; CurrentSpeed = 0; Temperature = 40; }
    
    public bool IsSystemHealthy() => Temperature < 115;
    public bool IsOverheated() => Temperature >= 110;

    public static Engine operator ++(Engine e)
    {
        if (e.IsRunning) { e.CurrentSpeed += 10; e.Temperature = 90 + (e.CurrentSpeed / 5); }
        return e;
    }
    public static Engine operator --(Engine e)
    {
        if (e.IsRunning && e.CurrentSpeed >= 10) { e.CurrentSpeed -= 10; e.Temperature = 90 + (e.CurrentSpeed / 5); }
        return e;
    }
    public static bool operator !(Engine e) => !e.IsRunning;
    public static bool operator true(Engine e) => e.IsRunning && e.IsSystemHealthy();
    public static bool operator false(Engine e) => !e.IsRunning || e.IsOverheated();
}
