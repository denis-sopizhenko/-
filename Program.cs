using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Student: Sopizhenko Denys Leonidovych, IPZ, 11 group 2");
        Console.WriteLine("Task Variant: Modeling the operation processes of a smart car");
        Console.WriteLine("Version 5 (Inheritance, Abstract Classes & Interfaces)");
        Console.WriteLine("Simulation started...\n");

        // ==================================================================
        // ЧАСТИНА 1: ДЕМОНСТРАЦІЯ УСПАДКУВАННЯ ТА ПОЛІМОРФІЗМУ (STAGE 1)
        // ==================================================================
        Console.WriteLine("=== [STAGE 1: OOP INHERITANCE & INTERFACES DEMO] ===");

        // Використання поліморфізму: Абстрактний клас посилається на похідний
        Vehicle myRoboVehicle = new SmartCar();
        myRoboVehicle.StartVehicle(); // Виклик перевизначеного (override) методу

        // Використання інтерфейсів
        IDiagnosable diagnosticUnit = (IDiagnosable)myRoboVehicle;
        diagnosticUnit.PrintDiagnosticReport(); // Звіт через інтерфейс

        // Демонстрація базового класу Person та похідного Passenger
        Person plainPerson = new Person("Generic Citizen");
        Passenger vipPassenger = new Passenger("Denis Sopizhenko");
        Console.WriteLine($"[Inheritance] Person Name: {plainPerson.Name}");
        Console.WriteLine($"[Inheritance] Passenger Name (inherited): {vipPassenger.Name}");

        // Оператор '+' з Версії 4 (збережено)
        Route r1 = new Route("Home", "Hub", 4);
        Route r2 = new Route("Hub", "University", 11);
        Route finalRoute = r1 + r2;

        Console.WriteLine("=== [STAGE 1 COMPLETED] ===\n");

        // ==================================================================
        // ЧАСТИНА 2: ІНТЕРАКТИВНА СИМУЛЯЦІЯ (Збережений та розширений функціонал)
        // ==================================================================
        Console.WriteLine("=== [STAGE 2: INTERACTIVE SIMULATION (VERSION 5)] ===");
        SmartCar interactiveCar = new SmartCar();

        Console.Write("Enter passenger name: ");
        string passengerName = Console.ReadLine();
        Passenger userPassenger = new Passenger(passengerName);

        Console.Write($"Does {userPassenger.Name} want to fasten the seatbelt? (yes/no): ");
        string seatbeltChoice = Console.ReadLine().Trim().ToLower();
        if (seatbeltChoice == "yes" || seatbeltChoice == "y") userPassenger.ToggleSeatbelt();
        
        interactiveCar.BoardPassenger(userPassenger);
        
        // Виклик методу інтерфейсу IAutopilot
        interactiveCar.Navigate(finalRoute);

        if (interactiveCar.CarEngine)
        {
            bool simulationActive = true;
            while (simulationActive)
            {
                Console.WriteLine("\n--- Control Panel (V5: Inheritance & Interfaces) ---");
                Console.WriteLine("1. Speed UP (Cruising ++)");
                Console.WriteLine("2. Speed DOWN (Cruising --)");
                Console.WriteLine("3. Check Sensors & Distance");
                Console.WriteLine("4. Drive 10 km forward");
                Console.WriteLine("5. Print Interface Diagnostic Report (IDiagnosable)");
                Console.WriteLine("6. Exit Simulation");
                Console.Write("Select action (1-6): ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        interactiveCar.AccelerateWithIncrement();
                        break;
                    case "2":
                        interactiveCar.DecelerateWithDecrement();
                        break;
                    case "3":
                        Console.Write("Enter obstacle distance (meters): ");
                        if (int.TryParse(Console.ReadLine(), out int obsDist))
                        {
                            interactiveCar.CarSensors.UpdateObstacleDistance(obsDist);
                            interactiveCar.CheckSurroundings();
                        }
                        break;
                    case "4":
                        interactiveCar.SimulateDistanceTraveled(10);
                        // Робота з новим типом двигуна ElectricEngine
                        if (interactiveCar.CarEngine is ElectricEngine electric)
                        {
                            Console.WriteLine($"[Battery Status] Eco-Engine charge: {electric.BatteryLevel}%");
                        }

                        if (interactiveCar.DistanceTraveled >= finalRoute.DistanceKm)
                        {
                            Console.WriteLine("\n[Arrived] Destination successfully reached by autopilot!");
                            interactiveCar.CarEngine.Stop();
                            simulationActive = false;
                        }
                        break;
                    case "5":
                        // Інтерфейсний виклик звіту
                        interactiveCar.PrintDiagnosticReport();
                        break;
                    case "6":
                        interactiveCar.CarEngine.Stop();
                        simulationActive = false;
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
