using System;

// Успадковує базовий класичний двигун Engine
public class ElectricEngine : Engine
{
    // Нова власна унікальна властивість
    public int BatteryLevel { get; private set; }

    // Конструктор викликає конструктор базового класу Engine за замовчуванням
    public ElectricEngine() : base()
    {
        BatteryLevel = 100; // Повна батарея при виїзді з заводу
        Console.WriteLine("[Derived ElectricEngine Constructor] Eco-friendly Battery module attached.");
    }

    // Перевизначення (override) віртуального методу базового класу
    public override void Start()
    {
        IsRunning = true;
        Temperature = 35; // Електродвигуни значно холодніші за ДВЗ
        Console.WriteLine("[ElectricEngine] Silent power system active. Temp: 35°C.");
    }

    public override void Stop()
    {
        base.Stop(); // Виклик базової логіки зупинки
        Console.WriteLine("[ElectricEngine] Regeneration system disabled.");
    }
}