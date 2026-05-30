using System;

public class Passenger
{
    public string Name { get; set; }
    public bool IsSeatbeltFastened { get; private set; }

    public Passenger(string name)
    {
        // Якщо користувач нічого не ввів, даємо стандартне ім'я
        Name = string.IsNullOrEmpty(name) ? "Unknown Passenger" : name;
        IsSeatbeltFastened = false;
    }

    public void ToggleSeatbelt()
    {
        IsSeatbeltFastened = !IsSeatbeltFastened;
        Console.WriteLine($"[Passenger System] {Name} seatbelt status changed. Fastened: {IsSeatbeltFastened}");
    }
}