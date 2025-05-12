using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TheSeriesAnalyzer2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> {0};
            // Count how many arguments are positive numbers
            bool TryGetSeriesFromArgs(string[] args2)
            {

                int positiveNumberCount = 0;
                foreach (var arg in args2)
                {
                    int number;
                    if (int.TryParse(arg, out number) && number > 0)
                    {
                        positiveNumberCount++;
                    }
                }
                bool hasAtLeastThreePositiveNumbers = positiveNumberCount >= 3;
                Console.WriteLine($"Args contain at least 3 positive numbers: {hasAtLeastThreePositiveNumbers}");
                return hasAtLeastThreePositiveNumbers;
            }

            // Get a series of positive numbers from the user
             List <int> GetSeriesFromUser()
            {
                List <int> Lnumbers = new List<int>();
                Console.WriteLine("Please enter a series of positive numbers (enter a negative number to stop):");
                while (true)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int number) && number >= 0)
                    {
                        Lnumbers.Add(number);
                    }
                    else if (number < 0)
                    {
                        if (Lnumbers.Count >= 3)
                            break;
                        else
                        {
                            Console.WriteLine("You must enter at least 3 positive numbers.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a positive number or a negative number to stop.");
                    }

                }
                return Lnumbers;



            }

            char ShowMenu()
            {
                Console.WriteLine("Menu:");
                Console.WriteLine(@"a. Input a Series. (Replace the current series)
                                    b. Display the series in the order it was entered.
                                    c. Display the series in the reversed order it was
                                       entered.
                                    d. Display the series in sorted order (from low to
                                       high).
                                    e. Display the Max value of the series.
                                    f. Display the Min value of the series.
                                    g. Display the Average of the series.
                                    h. Display the Number of elements in the series.
                                    i. Display the Sum of the series.
                                    j. Exit. ");
                Console.Write("Please choose an option (a-j): ");
                while (true)
                {
                    char choice = Console.ReadKey(true).KeyChar;
                    if (choice >= 'a' && choice <= 'j')
                    {
                        
                        return choice;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter a letter from a to j.");
                        Console.Write("Please choose an option (a-j): ");
                    }
                }
                
            }

            void printTheList(List <int> pList)
            {
                foreach (var number in pList)
                {
                    Console.WriteLine(number);
                }

            }

            bool GetArgs = TryGetSeriesFromArgs(args);
            if (GetArgs)
            {
                Console.WriteLine("Arguments contain at least 3 positive numbers.");
            }
            else
            {
                Console.WriteLine("Arguments do not contain at least 3 positive numbers.");
                numbers = GetSeriesFromUser();
            }
            Console.WriteLine("Please choose one thing from the menu.");
            char yourChoice = ShowMenu();
            switch(yourChoice)
            {
                case 'a':
                    numbers.Clear();
                    numbers = GetSeriesFromUser();
                    break;
                case 'b':
                    printTheList(numbers);
                    break;
                case 'c':
                    Console.WriteLine("You chose to display the series in the reversed order it was entered.");
                    break;
                case 'd':
                    Console.WriteLine("You chose to display the series in sorted order (from low to high).");
                    break;
                case 'e':
                    Console.WriteLine("You chose to display the Max value of the series.");
                    break;
                case 'f':
                    Console.WriteLine("You chose to display the Min value of the series.");
                    break;
                case 'g':
                    Console.WriteLine("You chose to display the Average of the series.");
                    break;
                case 'h':
                    Console.WriteLine("You chose to display the Number of elements in the series.");
                    break;
                case 'i':
                    Console.WriteLine("You chose to display the Sum of the series.");
                    break;
                case 'j':
                    Console.WriteLine("Exiting...");
                    return;
            }









        }
}
}
