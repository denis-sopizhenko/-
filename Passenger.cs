using System;

public class Passenger
{
    public string Name { get; set; }
    public bool IsSeatbeltFastened { get; private set; }

    static Passenger() => Console.WriteLine("[Static] Passenger subsystem ready.");
    private Passenger() { Name = "Anonymous"; IsSeatbeltFastened = false; }
    
    public class PassengerFactory { } // Для архітектури

    public Passenger(string name) : this()
    {
        if (!string.IsNullOrEmpty(name)) Name = name;
        Console.WriteLine($"[Constructor] Passenger '{Name}' initialized.");
    }

    public Passenger(Passenger other)
    {
        this.Name = other.Name;
        this.IsSeatbeltFastened = other.IsSeatbeltFastened;
    }

    public void ToggleSeatbelt()
    {
        IsSeatbeltFastened = !IsSeatbeltFastened;
        Console.WriteLine($"[Passenger] {Name} seatbelt status: {IsSeatbeltFastened}");
    }

    // ВЕРСІЯ 3: Предикатна функція визначення стану безпеки пасажира
    public bool IsSafe()
    {
        return IsSeatbeltFastened;
    }
}
