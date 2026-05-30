using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Student: Sopizhenko Denys Leonidovych, IPZ, 11 group 2");
        Console.WriteLine("Task Variant: Modeling the operation processes of a smart car");
        Console.WriteLine("Version 6 (Robust Exception Handling Ecosystem)");
        Console.WriteLine("Simulation started...\n");

        SmartCar myCar = new SmartCar();

        // 1. Інтерактивне введення (Збережено з попередніх версій)
        Console.Write("Enter passenger name: ");
        string passengerName = Console.ReadLine();
        Passenger userPassenger = new Passenger(passengerName);

        Console.Write($"Does {userPassenger.Name} want to fasten the seatbelt? (yes/no): ");
        string seatbeltChoice = Console.ReadLine().Trim().ToLower();
        if (seatbeltChoice == "yes" || seatbeltChoice == "y") userPassenger.ToggleSeatbelt();
        
        myCar.BoardPassenger(userPassenger);

        Route tripRoute = new Route("Kyiv Office", "Tech Park", 60);

        // ==================================================================
        // ВЕРСІЯ 6: ТЕСТ КРИТИЧНОЇ СИТУАЦІЇ 1 (Спроба старту руху під try-catch)
        // ==================================================================
        Console.WriteLine("\n=== [CRITICAL SCENARIO 1: STARTUP CHECK] ===");
        try
        {
            myCar.Drive(tripRoute);
            Console.WriteLine("[System Status] Startup successful. No exceptions thrown.");
        }
        catch (UnsecuredPassengerException ex)
        {
            Console.WriteLine($"[CATCH] Intercepted Custom Exception: {ex.Message}");
            Console.WriteLine($"[Action] SmartCar automatically engaged cabin protection locks for: {ex.PassengerName}");
            
            // Захисна дія: Примусово пристібаємо пасажира та пробуємо ще раз
            Console.WriteLine("[Fixing...] Autopilot is forcing seatbelt compliance...");
            userPassenger.ToggleSeatbelt();
            myCar.Drive(tripRoute); // Повторний безпечний старт
        }

        // ==================================================================
        // ТЕСТ КРИТИЧНОЇ СИТУАЦІЇ 2 (Ігровий цикл з обробкою відхилень та помилок)
        // ==================================================================
        if (myCar.CarEngine.IsRunning)
        {
            bool liveSession = true;
            while (liveSession)
            {
                Console.WriteLine("\n--- Smart Car Operating Console (V6 Fault-Tolerant) ---");
                Console.WriteLine("1. Accelerate Cruising Speed");
                Console.WriteLine("2. Calculate Time to Destination (Risk: Divide by Zero)");
                Console.WriteLine("3. Simulate High-Speed Overheat Test (Risk: Custom App Crash)");
                Console.WriteLine("4. Test Array Index Out of Bounds (Risk: Standard .NET Crash)");
                Console.WriteLine("5. Finish Trip Successfully");
                Console.Write("Choose operation (1-5): ");

                try
                {
                    string action = Console.ReadLine();
                    switch (action)
                    {
                        case "1":
                            myCar.AccelerateWithIncrement();
                            break;

                        case "2":
                            // Демонстрація стандартного DivideByZeroException
                            Console.WriteLine("[Calculation] Processing estimated time array...");
                            int eta = myCar.CalculateTimeToDestination();
                            Console.WriteLine($"[Result] Estimated arrival time: {eta} hours.");
                            break;

                        case "3":
                            // Провокування користувацького винятку перегріву двигуна
                            Console.WriteLine("[Warning] Simulating extreme overload on the motor...");
                            myCar.AdjustSpeed(250); // Швидкість 250 викликає перегрів > 110°C
                            break;

                        case "4":
                            // Демонстрація стандартного IndexOutOfRangeException
                            Console.WriteLine("[Array Test] Attempting to access unregistered backup camera sensor...");
                            int[] fakeSensorArray = { 1, 2, 3 };
                            int brokenRead = fakeSensorArray[99]; // Спроба зчитування 99-го елемента
                            break;

                        case "5":
                            liveSession = false;
                            break;

                        default:
                            // Демонстрація FormatException при некоректному командному виборі
                            throw new FormatException("Console routing parser failed: input string matches no system command indices.");
                    }
                }
                // ОБРОБКА СТАНДАРТНИХ ВИНЯТКІВ .NET
                catch (DivideByZeroException)
                {
                    Console.WriteLine("[CATCH: DivideByZero] ERROR: Car is stationary (Speed = 0). Cannot divide distance by zero speed!");
                    Console.WriteLine("[Action] Resetting calculation module. Please increase speed first.");
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"[CATCH: IndexOutOfBounds] SYSTEM ERROR: Hardware array overflow. {ex.Message}");
                    Console.WriteLine("[Action] Disconnecting corrupted sensor slot. Falling back to radar diagnostics.");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"[CATCH: FormatException] Data parsing error. Details: {ex.Message}");
                }
                // ОБРОБКА КОРИСТУВАЦЬКОГО ВИНЯТКУ ПЕРЕГРІВУ
                catch (EngineOverheatException ex)
                {
                    Console.WriteLine($"[CATCH: Custom Overheat] APPARATUS EMERGENCY: {ex.Message}");
                    Console.WriteLine($"[Action] Current Core Temperature is dangerously high: {ex.CurrentTemperature}°C.");
                    Console.WriteLine("[Action] Deploying automatic coolant fluid. Shutting down system loop.");
                    liveSession = false; // Вихід з циклу через поломку
                }
                // ГАРАНТОВАНИЙ БЛОК FINALLY
                finally
                {
                    Console.WriteLine("[Finally Block] Board network sanity routine completed. Keeping logs synced.");
                }
            }
        }

        Console.WriteLine("\nSimulation finished safely under exception monitoring.");
        Console.ReadLine();
    }
}
