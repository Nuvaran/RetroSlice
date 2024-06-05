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

        // Creates list used to store cutomers with tokens
        private static List<Customer> customersWtokens = new List<Customer>();

        // Storing applicant's details in a collection method and displaying it
        public static void ApplicantDetails()
        {
            bool continueAddingCustomers = true;

            while (continueAddingCustomers)
            {
                Customer newCustomer = new Customer();

                /**Console.Write("\nEnter your name:" + " ");
                newCustomer.name = Console.ReadLine();*/

                //getting the name
                bool validName = false;
                String name;
                while (validName == false)
                {
                    Console.Write("Enter your name: ");
                    name = Console.ReadLine();
                    if ((!name.Equals("")))
                    {
                        newCustomer.name = name;
                        validName = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Answer! Please enter a name");
                        Console.ResetColor();
                    }
                }

                /**Console.Write("Enter your age:" + " ");
                newCustomer.age = int.Parse(Console.ReadLine());*/

                //getting the customer age
                bool validAge = false;
                while (validAge == false)
                {
                    Console.Write("Enter your age: ");
                    int age;
                    if (Int32.TryParse(Console.ReadLine(), out age) && (age >= 0) && age <= 120)
                    {
                        newCustomer.age = age;
                        validAge = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Answer! Please enter a valid age (0 -> 120)");
                        Console.ResetColor();
                    }
                }

                /**Console.Write("Enter your highest rank score:" + " ");
                newCustomer.highScoreRank = int.Parse(Console.ReadLine());*/

                //Getting the users high score
                bool validHighScoreRank = false;
                while (validHighScoreRank == false)
                {
                    Console.Write("Enter your highest rank score: ");
                    int highScoreRank;
                    if (Int32.TryParse(Console.ReadLine(), out highScoreRank) && (highScoreRank > 0))
                    {
                        newCustomer.highScoreRank = highScoreRank;
                        validHighScoreRank = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Answer! Please enter a score (0 -> 2000000)");
                        Console.ResetColor();
                    }
                }

                /**Console.Write("Enter the number of pizzas consumed since the first visit:" + " ");
                newCustomer.noOfPizzasConsumed = int.Parse(Console.ReadLine());*/

                //Getting the pizzas consumed
                bool validPizzasConsumed = false;
                while (validPizzasConsumed == false)
                {
                    Console.Write("Enter the number of pizzas consumed since the first visit: ");
                    int noOfPizzasConsumed;
                    if (Int32.TryParse(Console.ReadLine(), out noOfPizzasConsumed) && (noOfPizzasConsumed > 0))
                    {
                        newCustomer.noOfPizzasConsumed = noOfPizzasConsumed;
                        validPizzasConsumed = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Answer! Please enter a number (0 -> 2000000)");
                        Console.ResetColor();
                    }
                }

                /**Console.Write("Enter your bowling high score:" + " ");
                newCustomer.bowlingHighScore = int.Parse(Console.ReadLine());*/

                //Getting the users bowling highscore
                bool validBowlingHighScore = false;
                while (validBowlingHighScore == false)
                {
                    Console.Write("Enter your bowling high score: ");
                    int bowlingHighScore;
                    if (Int32.TryParse(Console.ReadLine(), out bowlingHighScore) && (bowlingHighScore > 0))
                    {
                        newCustomer.bowlingHighScore = bowlingHighScore;
                        validBowlingHighScore = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Answer! Please enter an number (0 -> 2000000)");
                        Console.ResetColor();
                    }
                }

                /**Console.Write("Enter your favourite slush puppy flavor:" + " ");
                newCustomer.slushPuppyFlavor = Console.ReadLine();*/

                //getting the users favourite slush puppy flavour
                bool validSlushPuppyFlavor = false;
                String slushPuppyFlavour;
                while (validSlushPuppyFlavor == false)
                {
                    Console.Write("Enter your favourite slush puppy flavor: ");
                    slushPuppyFlavour = Console.ReadLine();
                    if ((!slushPuppyFlavour.Equals("")))
                    {
                        newCustomer.slushPuppyFlavor = slushPuppyFlavour;
                        validSlushPuppyFlavor = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Answer! Please enter a valid flavour");
                        Console.ResetColor();
                    }
                }

                /**Console.Write("Enter the number of slush puppies consumed since the first visit:" + " ");
                newCustomer.slushPuppiesConsumed = int.Parse(Console.ReadLine());*/

                //getting the users amount of slush puppies consumed since first visit
                bool validSlushPuppiesConsumed = false;
                while (validSlushPuppiesConsumed == false)
                {
                    Console.Write("Enter the number of slush puppies consumed since the first visit: ");
                    int slushPuppiesConsumed;
                    if (Int32.TryParse(Console.ReadLine(), out slushPuppiesConsumed) && (slushPuppiesConsumed > 0))
                    {
                        newCustomer.slushPuppiesConsumed = slushPuppiesConsumed;
                        validSlushPuppiesConsumed = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Answer! Please enter a number (0 -> 2000000)");
                        Console.ResetColor();
                    }
                }

                /**Console.Write("Are you employed? (true/false):" + " ");
                newCustomer.isEmployed = bool.Parse(Console.ReadLine());*/

                //Changing message based on customers age, getting if their employed
                bool validEmployed = false;
                bool isEmployed;
                {
                    while (validEmployed == false)
                    {
                        if (newCustomer.age < 18)
                        {
                            Console.Write("Are your parents employed? (true/false): ");
                        }
                        else
                        if (newCustomer.age >= 18)
                        {
                            Console.Write("Are you employed? (true/false): ");
                        }
                        if (Boolean.TryParse(Console.ReadLine(), out isEmployed))
                        {
                            newCustomer.isEmployed = isEmployed;
                            validEmployed = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Answer! Please enter true or false");
                            Console.ResetColor();
                        }
                    }
                }

                /**Console.Write("Enter the start date as a loyal customer (yyyy-MM-dd):" + " ");
                newCustomer.startDate = DateTime.Parse(Console.ReadLine());*/

                //Validating date entered
                bool validDate = false;
                while (validDate == false)
                {
                    Console.Write("Enter the start date as a loyal customer (yyyy-MM-dd): ");
                    DateTime startDate;
                    if (DateTime.TryParse(Console.ReadLine(), out startDate) && (DateTime.Now.Year - startDate.Year < newCustomer.age && (startDate <= DateTime.Now)))
                    {
                        newCustomer.startDate = startDate;
                        validDate = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Date! Please see format for reference, and make sure the date is valid relevant to your age");
                        Console.ResetColor();
                    }
                }

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

                /**Console.Write("\nDo you want to add another customer? (Y/N): ");
                string response = Console.ReadLine().ToUpper();

                if (response != "Y")
                {
                    continueAddingCustomers = false;
                }*/

                bool validResponse = false;
                while (validResponse == false)
                {
                    Console.Write("\nDo you want to add another customer? (Y/N): ");
                    string response = Console.ReadLine().ToUpper();
                    if (response.Equals("Y"))
                    {
                        continueAddingCustomers = true;
                        validResponse = true;
                    }
                    else
                    if (response.Equals("N"))
                    {
                        continueAddingCustomers = false;
                        validResponse = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter Y or N");
                    }
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
            bool customerDetailsExist = false;
            while (true)
            {
                DisplayMenu();
                if (Enum.TryParse(Console.ReadLine(), out Menu choice))
                {
                    switch (choice)
                    {
                        case Menu.AddCustomerDetails:
                            Console.Clear();
                            ShowArcadeHeader();
                            ApplicantDetails();
                            customerDetailsExist = true;
                            break;
                        case Menu.CreditQualification:
                            Console.Clear();
                            ShowArcadeHeader();
                            if (customerDetailsExist == true)
                            {
                                CreditQualification();
                                DisplayCreditQualification();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Add customer details first!");
                                Console.ResetColor();

                            }
                            break;
                        case Menu.CurrentBowlingAndArcadeStats:
                            Console.Clear();
                            ShowArcadeHeader();
                            CurrentBowlingAndArcadeStats();
                            break;
                        case Menu.Exit:
                            Console.Clear();
                            ShowArcadeHeader();
                            Console.WriteLine("Thank you for using RetroSlice Arcade Management System! Goodbye!");
                            System.Threading.Thread.Sleep(2000);
                            System.Environment.Exit(0);
                            break;
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

        private static int applicantsAccepted = 0, applicantsDenied = 0;
        private static void CreditQualification()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            applicantsAccepted = 0;
            applicantsDenied = 0;
            for (int i = 0; i < customers.Count; i++)
            {
                int yearsLoyal = DateTime.Now.Year - customers[i].startDate.Year;
                int monthsLoyal = ((yearsLoyal * 12) + (DateTime.Now.Month - customers[i].startDate.Month));
                if (customers[i].isEmployed == true //Checking token qualification
                   && yearsLoyal >= 2
                   && (customers[i].highScoreRank > 2000 || customers[i].bowlingHighScore > 1200)
                   && customers[i].noOfPizzasConsumed / monthsLoyal >= 3
                   && customers[i].slushPuppiesConsumed / monthsLoyal >= 4
                   && (!(customers[i].slushPuppyFlavor.Equals("Gooey Gulp Galore"))))
                {
                    customersWtokens.Add(customers[i]);
                    applicantsAccepted = applicantsAccepted + 1;
                }
                else
                {
                    applicantsDenied = applicantsDenied + 1;
                }
            }
            Console.ResetColor();
        }

        private static void DisplayCreditQualification()
        {
            if (customersWtokens.Count == 0)
            {
                Console.WriteLine("No customers qualify for token credit!");
                Console.WriteLine("Amount of people that qualify for token credit: " + applicantsAccepted);
                Console.WriteLine("Amount of people that don't qualify for token credit: " + applicantsDenied);
            }
            else
            {
                for (int i = 0; i < customersWtokens.Count; i++)
                {
                    Console.WriteLine("Customer: " + customersWtokens[i].name + " qualifies for game token credit!");
                }
                Console.WriteLine("Amount of people that qualify for token credit: " + applicantsAccepted);
                Console.WriteLine("Amount of people that don't qualify for token credit: " + applicantsDenied);
            }
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
                Console.WriteLine("\nCustomer not found.");
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



