using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

            Customer newCustomer = new Customer(); // Creating an instance of the Applicants List called newApplicant

            Console.WriteLine("Enter your name:");
            newCustomer.name = Console.ReadLine();

            Console.WriteLine("Enter your age:");
            newCustomer.age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter your highest rank score");
            newCustomer.highScoreRank = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of pizza's consumed since the first visit");
            newCustomer.noOfPizzasConsumed = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter your bowling high score");
            newCustomer.bowlingHighScore = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter you favourite slush puppy flavor");
            newCustomer.slushPuppyFlavor = Console.ReadLine();

            Console.WriteLine("Enter the number of slush puppies consumed since the first visit");
            newCustomer.slushPuppiesConsumed = int.Parse(Console.ReadLine());

            Console.WriteLine("Are you employed, if yes enter true, if no enter false");
            newCustomer.isEmployed = bool.Parse(Console.ReadLine());

            Console.WriteLine("Enter the start date as a loyal customer (yyyy-MM-dd)");
            newCustomer.startDate = DateTime.Parse(Console.ReadLine());

            customers.Add(newCustomer);

            Console.WriteLine("Customer added successfully!\n");

            Console.WriteLine("\nList of Customers:");
            foreach (var applicants in customers)
            {
                Console.WriteLine($"Name: {newCustomer.name}, Age: {newCustomer.age}, High Score Rank: {newCustomer.highScoreRank}," +
                    $" Start Date: {newCustomer.startDate.ToShortDateString()}, Pizzas Consumed: {newCustomer.noOfPizzasConsumed}, Bowling High Score: {newCustomer.bowlingHighScore}, " +
                    $"Employed: {newCustomer.isEmployed}, Slush Puppy Flavor: {newCustomer.slushPuppyFlavor}, Slush Puppies Consumed: {newCustomer.slushPuppiesConsumed}");
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
            Console.WriteLine("1. Add Customer Details");
            Console.WriteLine("2. CreditQualification");
            Console.WriteLine("3. CurrentBowlingAndArcadeStats");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
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
                            continue;
                        case Menu.CreditQualification:
                            //CreditQualification();
                        case Menu.CurrentBowlingAndArcadeStats:
                            //CurrentBowlingAndArcadeStats(); 
                        case Menu.Exit:
                            return;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a valid menu option.");
                }
            }
        } 
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to RetroSlice!");

            // Calling the menu option
            MenuOption();

            Console.ReadLine();
        }
    }
}
