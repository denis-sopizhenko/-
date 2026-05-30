using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Обов'язкова інформація про студента
        Console.WriteLine("Student: Sopizhenko Denys Leonidovych, IPZ, 11 group 2");
        Console.WriteLine("Task Variant: Modeling the operation processes of a smart car");
        Console.WriteLine("Version 3 (Predicate Functions & Dynamic Ride Simulation)");
        Console.WriteLine("Simulation started...\n");

        // ДЕМОНСТРАЦІЯ З ВЕРСІЇ 2 (Технічний протокол конструкторів)
        Console.WriteLine("=== [STAGE 1: SYSTEM DIAGNOSTICS & COPIES] ===");
        SmartCar techCar = new SmartCar();
        SmartCar clonedCar = new SmartCar(techCar); 
        Console.WriteLine("=== [STAGE 1 COMPLETED] ===\n");

        // ІНТЕРФЕЙС ВВЕДЕННЯ З ВЕРСІЇ 2 + НОВІ ФУНКЦІЇ ВЕРСІЇ 3
        Console.WriteLine("=== [STAGE 2: INTERACTIVE INITIALIZATION] ===");
        SmartCar myCar = new SmartCar();

        Console.Write("Enter passenger name: ");
        string passengerName = Console.ReadLine();
        Passenger userPassenger = new Passenger(passengerName);

        Console.Write($"Does {userPassenger.Name} want to fasten the seatbelt? (yes/no): ");
        string seatbeltChoice = Console.ReadLine().Trim().ToLower();
        if (seatbeltChoice == "yes" || seatbeltChoice == "y")
        {
            userPassenger.ToggleSeatbelt();
        }
        myCar.BoardPassenger(userPassenger);

        Console.Write("\nEnter destination point: ");
        string destination = Console.ReadLine();
        
        Console.Write("Enter route distance (in km): ");
        int distance;
        while (!int.TryParse(Console.ReadLine(), out distance) || distance <= 0)
        {
            Console.Write("Invalid input. Enter positive number: ");
        }
        Route userRoute = new Route("Current Location", destination, distance);

        // ВЕРСІЯ 3: Визначення станів об'єктів через ПРЕДИКАТНІ ФУНКЦІЇ перед стартом
        Console.WriteLine("\n=== [STAGE 3: PRE-DRIVE PREDICATE CHECKS] ===");
        Console.WriteLine($"[Predicate] Is passenger safe? -> {userPassenger.IsSafe()}");
        Console.WriteLine($"[Predicate] Is route long-distance (over 100km)? -> {userRoute.IsLongDistance()}");
        Console.WriteLine($"[Predicate] Is engine system healthy? -> {myCar.CarEngine.IsSystemHealthy()}");

        // Спроба розпочати рух
        myCar.Drive(userRoute);

        // Якщо автомобіль пройшов перевірки безпеки і завівся — починається симуляція поїздки
        if (myCar.CarEngine.IsRunning)
        {
            Console.WriteLine("\n=== [STAGE 4: DYNAMIC RIDE SIMULATION (NEW)] ===");
            Console.WriteLine("The car has started moving. You can now control it during the trip.");
            
            bool tripActive = true;
            while (tripActive)
            {
                Console.WriteLine("\n--- Control Panel ---");
                Console.WriteLine("1. Adjust Cruise Speed");
                Console.WriteLine("2. Check Sensors & Road Surroundings");
                Console.WriteLine("3. View Car Diagnostics (Predicate States)");
                Console.WriteLine("4. Drive 10 km forward");
                Console.WriteLine("5. Finish Trip / Emergency Stop");
                Console.Write("Select action (1-5): ");
                
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter new speed (km/h): ");
                        if (int.TryParse(Console.ReadLine(), out int speed) && speed >= 0)
                            myCar.AdjustSpeed(speed);
                        else
                            Console.WriteLine("Invalid speed.");
                        break;
                    case "2":
                        // Перевірка сенсорів на перешкоди + зміна дистанції в реальному часі
                        Console.Write("Simulate distance to obstacle ahead (meters): ");
                        if (int.TryParse(Console.ReadLine(), out int obsDist) && obsDist >= 0)
                        {
                            myCar.CarSensors.UpdateObstacleDistance(obsDist);
                            myCar.CheckSurroundings();
                        }
                        break;
                    case "3":
                        // Демонстрація предикатів стану автомобіля у реальному часі
                        Console.WriteLine($"-> [Predicate] Is Car Moving?: {myCar.IsMoving()}");
                        Console.WriteLine($"-> [Predicate] Has Engine Overheated?: {myCar.CarEngine.IsOverheated()}");
                        Console.WriteLine($"-> [Predicate] Is Sensor Array Clear?: {myCar.CarSensors.IsPathClear()}");
                        break;
                    case "4":
                        // Логіка просування по маршруту
                        myCar.SimulateDistanceTraveled(10);
                        if (myCar.DistanceTraveled >= userRoute.DistanceKm)
                        {
                            Console.WriteLine($"\n[Arrived] Successfully reached {userRoute.Destination}!");
                            myCar.CarEngine.Stop();
                            tripActive = false;
                        }
                        break;
                    case "5":
                        Console.WriteLine("[Control] Stopping simulation...");
                        myCar.CarEngine.Stop();
                        tripActive = false;
                        break;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }

        // Фінальний вивід атрибутів з Версії 2
        Console.WriteLine("\n=== FINAL ATTRIBUTE PROTOCOL ===");
        Console.WriteLine($"[Car] Speed: {myCar.CarEngine.CurrentSpeed} km/h | Traveled: {myCar.DistanceTraveled}/{userRoute.DistanceKm} km");
        Console.WriteLine($"[Passenger] Name: {userPassenger.Name} | Secured: {userPassenger.IsSeatbeltFastened}");

        Console.WriteLine("\nSimulation finished.");
        Console.ReadLine();
    }
}
