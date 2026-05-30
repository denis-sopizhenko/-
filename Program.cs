using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Обов'язкова інформація про студента та версію
        Console.WriteLine("Student: Sopizhenko Denys Leonidovych, IPZ, 11 group 2");
        Console.WriteLine("Task Variant: Modeling the operation processes of a smart car");
        Console.WriteLine("Version 2 (Merged: Advanced Constructors + Interactive Controls)");
        Console.WriteLine("Simulation started...\n");

        // ==================================================================
        // ЧАСТИНА 1: ТЕХНІЧНИЙ ПРОТОКОЛ (Демонстрація конструкторів та копіювання)
        // ==================================================================
        Console.WriteLine("=== [STAGE 1: TECHNICAL CONSTRUCTOR PROTOCOL] ===");

        // Створення копії об'єкта для демонстрації конструктора копій
        Route prototypeRoute = new Route("Factory", "Test Track", 10);
        Route testRoute = new Route(prototypeRoute); // Конструктор копії

        // Створення розумного автомобіля (викликає ланцюжок і композицію)
        SmartCar techCar = new SmartCar();
        SmartCar clonedCar = new SmartCar(techCar); // Глибоке копіювання машини

        Console.WriteLine("=== [STAGE 1 COMPLETED] ===\n");

        // ==================================================================
        // ЧАСТИНА 2: ІНТЕРАКТИВНА СИМУЛЯЦІЯ (Збережені функції введення-виведення)
        // ==================================================================
        Console.WriteLine("=== [STAGE 2: INTERACTIVE SIMULATION RUNTIME] ===");

        // Створення головного авто для поїздки
        SmartCar myCar = new SmartCar();

        // Введення користувача для створення Пасажира
        Console.Write("Enter passenger name: ");
        string passengerName = Console.ReadLine();
        Passenger userPassenger = new Passenger(passengerName); // Конструктор з параметрами

        // Інтерактивний вибір безпеки
        Console.Write($"Does {userPassenger.Name} want to fasten the seatbelt? (yes/no): ");
        string seatbeltChoice = Console.ReadLine().Trim().ToLower();
        if (seatbeltChoice == "yes" || seatbeltChoice == "y")
        {
            userPassenger.ToggleSeatbelt();
        }

        // Посадка пасажира (Агрегація)
        myCar.BoardPassenger(userPassenger);

        // Введення даних для Маршруту
        Console.Write("\nEnter destination point: ");
        string destination = Console.ReadLine();

        Console.Write("Enter route distance (in km): ");
        int distance;
        while (!int.TryParse(Console.ReadLine(), out distance) || distance <= 0)
        {
            Console.Write("Invalid input. Enter a positive number for distance: ");
        }

        // Створення об'єкта маршруту
        Route userRoute = new Route("Current Location", destination, distance);

        // Спроба почати рух (Асоціація + перевірка безпеки)
        myCar.Drive(userRoute);

        // Якщо двигун успішно завівся після перевірки безпеки
        if (myCar.CarEngine.IsRunning)
        {
            Console.WriteLine("\n=== REAL-TIME CRUISE CONTROL ===");
            Console.Write("Enter target speed (km/h): ");
            int targetSpeed;
            while (!int.TryParse(Console.ReadLine(), out targetSpeed) || targetSpeed < 0)
            {
                Console.Write("Invalid speed. Enter a valid number: ");
            }

            // Зміна швидкості та перевірка сенсорів на перешкоди
            myCar.AdjustSpeed(targetSpeed);
            myCar.CheckSurroundings();
        }

        // Кінцевий вивід поточних атрибутів об'єктів
        Console.WriteLine("\n=== FINAL ATTRIBUTE PROTOCOL ===");
        Console.WriteLine($"[Car] Speed: {myCar.CarEngine.CurrentSpeed} km/h | Engine: {myCar.CarEngine.IsRunning}");
        Console.WriteLine($"[Passenger] Name: {userPassenger.Name} | Fastened: {userPassenger.IsSeatbeltFastened}");
        Console.WriteLine($"[Route] Target: {userRoute.Destination} | Total: {userRoute.DistanceKm} km");

        Console.WriteLine("\nSimulation finished.");
        Console.ReadLine();
    }
}
