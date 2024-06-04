using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static RetroSlice.Program;

namespace RetroSlice
{
    internal class Program
    {
        // Custom Class for storing Applicant Details
        public class Customer
        {
            public int age { get; set; }
            public int highScoreRank { get; set; }
            public int noOfPizzasConsumed { get; set; }
            public int bowlingHighScore { get; set; }
            public int slushPuppiesConsumed { get; set; }
            public bool isEmployed { get; set; }
            public string name { get; set; }
            public string slushPuppyFlavor { get; set; }
            public DateTime startDate { get; set; }
        }

        // Creates a list with the custom class properties for users to populate, the list is called customers
        private static List<Customer> customers = new List<Customer>();

        // Storing applicant's details in a collection method and displaying it
        public static void ApplicantDetails()
        {
            bool continueAddingCustomers = true;

            while (continueAddingCustomers)
            {
                Customer newCustomer = new Customer();

                Console.Write("\nEnter your name:" + " ");
                newCustomer.name = Console.ReadLine();

                Console.Write("Enter your age:" + " ");
                newCustomer.age = int.Parse(Console.ReadLine());

                Console.Write("Enter your highest rank score:" + " ");
                newCustomer.highScoreRank = int.Parse(Console.ReadLine());

                Console.Write("Enter the number of pizzas consumed since the first visit:" + " ");
                newCustomer.noOfPizzasConsumed = int.Parse(Console.ReadLine());

                Console.Write("Enter your bowling high score:" + " ");
                newCustomer.bowlingHighScore = int.Parse(Console.ReadLine());

                Console.Write("Enter your favourite slush puppy flavor:" + " ");
                newCustomer.slushPuppyFlavor = Console.ReadLine();

                Console.Write("Enter the number of slush puppies consumed since the first visit:" + " ");
                newCustomer.slushPuppiesConsumed = int.Parse(Console.ReadLine());

                Console.Write("Are you employed? (true/false):" + " ");
                newCustomer.isEmployed = bool.Parse(Console.ReadLine());

                Console.Write("Enter the start date as a loyal customer (yyyy-MM-dd):" + " ");
                newCustomer.startDate = DateTime.Parse(Console.ReadLine());

                customers.Add(newCustomer);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nCustomer added successfully!\n");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nList of Customers:");

                // Print table header
                string header = string.Format(
                    "| {0,-20} | {1,-5} | {2,-15} | {3,-12} | {4,-18} | {5,-18} | {6,-10} | {7,-15} | {8,-25} |",
                    "Name", "Age", "High Score", "Start Date", "Pizzas Consumed", "Bowling High Score",
                    "Employed", "Slush Puppy Flavor", "Slush Puppies Consumed"
                );

                Console.WriteLine(header);
                Console.WriteLine(new string('-', header.Length));

                // Print table rows for all customers in the list
                foreach (var applicant in customers)
                {
                    string row = string.Format(
                        "| {0,-20} | {1,-5} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-18} | {5,-18} | {6,-10} | {7,-15} | {8,-25} |",
                        applicant.name, applicant.age, applicant.highScoreRank, applicant.startDate,
                        applicant.noOfPizzasConsumed, applicant.bowlingHighScore, applicant.isEmployed,
                        applicant.slushPuppyFlavor, applicant.slushPuppiesConsumed);

                    Console.WriteLine(row);
                }

                Console.Write("\nDo you want to add another customer? (Y/N): ");
                string response = Console.ReadLine().ToUpper();

                if (response != "Y")
                {
                    continueAddingCustomers = false;
                }

                Console.Clear();
                ShowArcadeHeader();
            }
        }

        // Method for the menu
        public enum Menu
        {
            AddCustomerDetails = 1,
            CreditQualification = 2,
            CurrentBowlingAndArcadeStats = 3,
            Exit = 4,
        }

        public static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ============================================");
            Console.WriteLine("||                                          ||");
            Console.WriteLine("||1. Add Customer Details                   ||");
            Console.WriteLine("||2. Credit Qualification                   ||");
            Console.WriteLine("||3. Current Bowling and Arcade Stats       ||");
            Console.WriteLine("||4. Exit                                   ||");
            Console.WriteLine("||                                          ||");
            Console.WriteLine(" ============================================");
            Console.ResetColor();
            Console.Write("\nEnter your choice:" + " ");
        }

        public static void MenuOption()
        {
            while (true)
            {
                DisplayMenu();
                if (Enum.TryParse(Console.ReadLine(), out Menu choice))
                {
                    switch (choice)
                    {
                        case Menu.AddCustomerDetails:
                            ApplicantDetails();
                            break;
                        case Menu.CreditQualification:
                            Console.Clear();
                            ShowArcadeHeader();
                            CreditQualification();
                            break;
                        case Menu.CurrentBowlingAndArcadeStats:
                            Console.Clear();
                            ShowArcadeHeader();
                            CurrentBowlingAndArcadeStats();
                            break;
                        case Menu.Exit:
                            Console.Clear();
                            ShowArcadeHeader();
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine("Thank you for using RetroSlice Arcade Management System! Goodbye!");
                            return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid choice, please try again.");
                            Console.ResetColor();
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input, please enter a valid menu option.");
                    Console.ResetColor();
                }
            }
        }

        private static void CreditQualification()
        {
            // Placeholder for CreditQualification logic
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nCredit Qualification feature coming soon!\n");
            Console.ResetColor();
        }

        private static void CurrentBowlingAndArcadeStats()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nCurrent Bowling and Arcade Stats:");

            Console.Write("Enter the name of the customer:" + " ");
            string customerName = Console.ReadLine();

            // Find the customer in the list
            Customer customer = customers.FirstOrDefault(c => c.name.Equals(customerName, StringComparison.OrdinalIgnoreCase));

            if (customer != null)
            {
                // Print table header
                string header = string.Format(
                 "| {0,-20} | {1,-15} | {2,-18} |",
                 "\n Name", "High Score Rank", "Bowling High Scores"
                 );

                 Console.WriteLine(header);
                 Console.WriteLine(new string('-', header.Length));

                 // Print table row for the customer
                 string row = string.Format(
                 "| {0,-20} | {1,-15} | {2,-18} |",
                 customer.name, customer.highScoreRank, customer.bowlingHighScore
                 );
    
                 Console.WriteLine(row);
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
                Console.ResetColor();
        }

        private static void SetConsoleTheme()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
        }

        private static void ShowArcadeHeader()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
    _____        _                 _____  _  _             
   | ___ \      | |               /  ___|| |(_)            
   | |_/ /  ___ | |_  _ __   ___  \ `--. | | _   ___   ___ 
   |    /  / _ \| __|| '__| / _ \  `--. \| || | / __| / _ \
   | |\ \ |  __/| |_ | |   | (_) |/\__/ /| || || (__ |  __/
   \_| \_| \___| \__||_|    \___/ \____/ |_||_| \___| \___|

            ");
            Console.ResetColor();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.Title = "RetroSlice Arcade Management System";
            SetConsoleTheme();
            ShowArcadeHeader();

            // Calling the menu option
            MenuOption();

            Console.ReadLine();
        }
    }
}



