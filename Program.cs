using System;

public class Program
{
    public static void Main(string[] args)
    {
        // 1. Обов'язковий вивід інформації про студента та завдання
        Console.WriteLine("Student: Sopizhenko Denys Leonidovych, IPZ, 11 group 2");
        Console.WriteLine("Task Variant: Modeling the operation processes of a smart car");
        Console.WriteLine("Version 1 (Interactive Edition)");
        Console.WriteLine("Simulation started...\n");

        Console.WriteLine("=== SYSTEM INITIALIZATION ===");

        // Введення даних пасажира
        Console.Write("Enter passenger name: ");
        string passengerName = Console.ReadLine();
        Passenger userPassenger = new Passenger(passengerName);

        // Інтерактивний вибір: пристебнути пасок чи ні
        Console.Write($"Does {passengerName} want to fasten the seatbelt? (yes/no): ");
        string seatbeltChoice = Console.ReadLine().Trim().ToLower();
        if (seatbeltChoice == "yes" || seatbeltChoice == "y")
        {
            userPassenger.ToggleSeatbelt();
        }

        // Введення даних маршруту
        Console.Write("\nEnter destination point: ");
        string destination = Console.ReadLine();

        Console.Write("Enter route distance (in km): ");
        int distance;
        // Безпечне конвертування рядка в число
        while (!int.TryParse(Console.ReadLine(), out distance) || distance <= 0)
        {
            Console.Write("Invalid input. Please enter a positive number for distance: ");
        }

        Route userRoute = new Route("Current Location", destination, distance);

        // 2. Створення автомобіля та посадка пасажира
        SmartCar myCar = new SmartCar();
        myCar.BoardPassenger(userPassenger);

        // 3. Спроба розпочати поїздку
        myCar.Drive(userRoute);

        // 4. Зміна параметрів у реальному часі за бажанням користувача
        Console.WriteLine("\n=== REAL-TIME CONTROL ===");
        Console.Write("Enter target speed for the cruise control (km/h): ");
        int targetSpeed;
        while (!int.TryParse(Console.ReadLine(), out targetSpeed) || targetSpeed < 0)
        {
            Console.Write("Invalid speed. Please enter a valid speed number: ");
        }

        myCar.AdjustSpeed(targetSpeed);
        myCar.CheckSurroundings();

        // 5. Обов'язковий фініш імітації
        Console.WriteLine("\nSimulation finished.");
        Console.ReadLine();
    }
}