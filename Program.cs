using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Student: Sopizhenko Denys Leonidovych, IPZ, 11 group 2");
        Console.WriteLine("Task Variant: Modeling the operation processes of a smart car");
        Console.WriteLine("Version 4 (Operator Overloading & Priority 2 Tasks)");
        Console.WriteLine("Simulation started...\n");

        // ==================================================================
        // ЧАСТИНА 1: ПРОТОКОЛ ПЕРЕВАНТАЖЕННЯ ОПЕРАТОРІВ (Застосування на практиці)
        // ==================================================================
        Console.WriteLine("=== [STAGE 1: OPERATOR OVERLOADING PROTOCOL] ===");

        // 1. Бінарний оператор '+' (Об'єднання маршрутів)
        Route routeHomeToShop = new Route("Home", "Supermarket", 5);
        Route routeShopToUni = new Route("Supermarket", "University", 10);
        Route combinedRoute = routeHomeToShop + routeShopToUni; // Застосування +
        Console.WriteLine($"[Operator +] Combined Route Distance: {combinedRoute.DistanceKm} km ({combinedRoute.StartPoint} -> {combinedRoute.Destination})");

        // 2. Унарні оператори '++', '--' та '!' для Engine
        Engine testEngine = new Engine();
        testEngine.Start();
        testEngine++; // Збільшення швидкості через ++
        testEngine++; 
        Console.WriteLine($"[Operator ++] Engine speed after double increment: {testEngine.CurrentSpeed} km/h");
        testEngine--; // Зменшення через --
        Console.WriteLine($"[Operator --] Engine speed after decrement: {testEngine.CurrentSpeed} km/h");

        if (!testEngine) // Застосування оператора !
        {
            Console.WriteLine("[Operator !] Engine is NOT running.");
        }
        else
        {
            Console.WriteLine("[Operator !] Engine IS currently running.");
        }

        // 3. Оператори true / false
        if (testEngine) // Використання об'єкта як булевого виразу завдяки операторам true/false
        {
            Console.WriteLine("[Operator true/false] Condition evaluated to TRUE: Engine is online and safe.");
        }

        // 4. Оператори порівняння '==', '!=', '<', '>'
        SmartCar car1 = new SmartCar();
        SmartCar car2 = new SmartCar();
        car1.CarEngine.SetSpeed(80);
        car2.CarEngine.SetSpeed(50);

        Console.WriteLine($"[Operator >] Is Car 1 faster than Car 2? -> {car1 > car2}");
        Console.WriteLine($"[Operator ==] Are Car 1 and Car 2 driving at the same speed? -> {car1 == car2}");

        Console.WriteLine("=== [STAGE 1 COMPLETED] ===\n");

        // ==================================================================
        // ЧАСТИНА 2: ІНТЕРАКТИВНА СИМУЛЯЦІЯ (Збережений та розширений функціонал)
        // ==================================================================
        Console.WriteLine("=== [STAGE 2: INTERACTIVE SIMULATION WITH OPERATORS] ===");
        SmartCar myCar = new SmartCar();

        Console.Write("Enter passenger name: ");
        string passengerName = Console.ReadLine();
        Passenger userPassenger = new Passenger(passengerName);

        Console.Write($"Does {userPassenger.Name} want to fasten the seatbelt? (yes/no): ");
        string seatbeltChoice = Console.ReadLine().Trim().ToLower();
        if (seatbeltChoice == "yes" || seatbeltChoice == "y") userPassenger.ToggleSeatbelt();
        myCar.BoardPassenger(userPassenger);

        // Використовуємо об'єднаний раніше маршрут для поїздки
        myCar.Drive(combinedRoute);

        if (myCar.CarEngine) // Використання оператора true для перевірки працездатності системи
        {
            bool tripActive = true;
            while (tripActive)
            {
                Console.WriteLine("\n--- Control Panel (Enhanced with Operators) ---");
                Console.WriteLine("1. Speed UP (Operator ++)");
                Console.WriteLine("2. Speed DOWN (Operator --)");
                Console.WriteLine("3. Simulate Obstacle (Sensors & Auto-Brake)");
                Console.WriteLine("4. Drive 10 km forward");
                Console.WriteLine("5. Finish Trip");
                Console.Write("Select action (1-5): ");
                
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        myCar.AccelerateWithIncrement(); // Виклик логіки ++ всередині класу
                        break;
                    case "2":
                        myCar.DecelerateWithDecrement(); // Виклик логіки -- всередині класу
                        break;
                    case "3":
                        Console.Write("Enter distance to obstacle (meters): ");
                        if (int.TryParse(Console.ReadLine(), out int obsDist))
                        {
                            myCar.CarSensors.UpdateObstacleDistance(obsDist);
                            myCar.CheckSurroundings();
                        }
                        break;
                    case "4":
                        myCar.SimulateDistanceTraveled(10);
                        if (myCar.DistanceTraveled >= combinedRoute.DistanceKm)
                        {
                            Console.WriteLine($"\n[Arrived] Destination reached!");
                            myCar.CarEngine.Stop();
                            tripActive = false;
                        }
                        break;
                    case "5":
                        myCar.CarEngine.Stop();
                        tripActive = false;
                        break;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }

        Console.WriteLine("\nSimulation finished.");
        Console.ReadLine();
    }
}
