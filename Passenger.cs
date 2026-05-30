using System;

public class Passenger
{
    // Властивості автоматичної реалізації
    public string Name { get; set; }
    public bool IsSeatbeltFastened { get; private set; }

    // Статичний конструктор
    static Passenger() => Console.WriteLine("[Static] Passenger subsystem driver initialized.");

    // Закритий конструктор
    private Passenger()
    {
        Name = "Anonymous";
        IsSeatbeltFastened = false;
    }

    // Конструктор з параметрами (Ланцюжок: викликає приватний)
    public Passenger(string name) : this()
    {
        if (!string.IsNullOrEmpty(name)) Name = name;
        Console.WriteLine($"[Constructor] Parameterized Passenger '{Name}' created.");
    }

    // Конструктор копії
    public Passenger(Passenger other)
    {
        this.Name = other.Name;
        this.IsSeatbeltFastened = other.IsSeatbeltFastened;
        Console.WriteLine($"[Copy Constructor] Passenger '{this.Name}' duplicated.");
    }

    // Збережена функція зміни стану безпеки
    public void ToggleSeatbelt()
    {
        IsSeatbeltFastened = !IsSeatbeltFastened;
        Console.WriteLine($"[Passenger] {Name} changed seatbelt status to: {IsSeatbeltFastened}");
    }
}
