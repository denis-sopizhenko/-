using System;

// Інтерфейс для систем автопілоту розумних автомобілів
public interface IAutopilot
{
    void Navigate(Route route);
}

// Інтерфейс для обов'язкової діагностики стану об'єкта
public interface IDiagnosable
{
    void PrintDiagnosticReport();
}