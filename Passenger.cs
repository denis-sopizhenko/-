using System;

// Успадковує базовий клас Person
public class Passenger : Person
{
    public bool IsSeatbeltFastened { get; private set; }

    // Конструктор похідного класу, що викликає конструктор базового через 'base'
    public Passenger(string name) : base(name)
    {
        IsSeatbeltFastened = false;
        Console.WriteLine($"[Derived Passenger Constructor] Passenger role attached to {Name}.");
    }

    public void ToggleSeatbelt() => IsSeatbeltFastened = !IsSeatbeltFastened;
    public bool IsSafe() => IsSeatbeltFastened;

    public static bool operator !(Passenger p) => !p.IsSeatbeltFastened;
}
