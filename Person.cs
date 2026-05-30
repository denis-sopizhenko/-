using System;

public class Person
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = string.IsNullOrEmpty(name) ? "Anonymous Person" : name;
        Console.WriteLine($"[Base Person Constructor] Profile for '{Name}' created.");
    }
}