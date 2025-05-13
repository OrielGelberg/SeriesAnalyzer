using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TheSeriesAnalyzer2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int size = Console.ReadLine();
            //int[] test = new int[size]();
            List<int> numbers = new List<int> {0};
            // Count how many arguments are positive numbers
            bool TryGetSeriesFromArgs(string[] args2)
            {
                bool hasAtLeastThreePositiveNumbers = false;
                int number, positiveNumberCount = 0;
                foreach (var arg in args2)
                {
                    
                    if (int.TryParse(arg, out number) && number > 0)
                    {
                        positiveNumberCount++;
                    }
                }
                if(positiveNumberCount >= 3)
                hasAtLeastThreePositiveNumbers = true;
                Console.WriteLine($"Args contain at least 3 positive numbers: {hasAtLeastThreePositiveNumbers}");
                return hasAtLeastThreePositiveNumbers;
            }

            // Get a series of positive numbers from the user
            int NumberofElements(List<int> Nlist)
            {
                int count = 0;
                foreach (var number in Nlist)
                {
                    count++;
                }
                return count;
            }

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
            
                Console.WriteLine(@"
                                                        Menu:

                                    a. Input a Series. (Replace the current series)
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
                    char choice = Console.ReadKey().KeyChar;
                    if (choice >= 'a' && choice <= 'j')
                    {
                        
                        return choice;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter a letter from a to j.");
                        Console.WriteLine("Please choose an option (a-j):");
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

            void ShowReversed(List <int> Rlist)
            {
                int arrayLength = Rlist.Count;

                for (int i = arrayLength - 1; i >= 0; i--)
                {
                    Console.WriteLine(Rlist[i]);
                }
            }

            void ShowSorted(List <int> sList)
            {
                int arryLength = sList.Count;
                for (int i = 0; i < arryLength; i++)
                {
                    for (int j = i + 1; j < arryLength; j++)
                    {
                        if (sList[j] > sList[i])
                        {
                            int temp = sList[i];
                            sList[i] = sList[j];
                            sList[j] = temp;
                        }
                    }
                }
                printTheList(sList);
            }

            void GetMax(List<int> mList)
            {
                int max = mList[0];
                foreach (var number in mList)
                {
                    if (number > max)
                    {
                        max = number;
                    }
                }
                Console.WriteLine($"The Max value of the series is: {max}");
            }

            void GetMin(List<int> mList)
            {
                int min = mList[0];
                foreach (var number in mList)
                {
                    if (number < min)
                    {
                        min = number;
                    }
                }
                Console.WriteLine($"The Min value of the series is: {min}");
            }

            int GetSum(List<int> Slist)
            {
                int sum = 0;
                foreach (var item in Slist)
                {
                    sum += item;
                }
                return sum;
            }

            void GetAverage(List<int> Avlist)
            {
                int Average = GetSum(Avlist) / NumberofElements(Avlist);
                Console.WriteLine($"The Average of the series is: {Average}");
            }




            bool GetArgs = TryGetSeriesFromArgs(args);
            if (GetArgs)
            {
                Console.WriteLine("Arguments contain at least 3 positive numbers.");
                foreach (var arg in args)
                {
                    if (int.TryParse(arg, out int number) && number > 0)
                    {
                        numbers.Add(number);
                    }
                }
            }
            else
            {
                Console.WriteLine("Arguments do not contain at least 3 positive numbers.");
                numbers = GetSeriesFromUser();
            }
            do
            {
                Console.WriteLine("Please choose one thing from the menu.");
                char yourChoice = ShowMenu();
                Console.WriteLine("\n");
                switch (yourChoice)
                {
                    case 'a':
                        numbers.Clear();
                        numbers = GetSeriesFromUser();
                        break;
                    case 'b':
                        printTheList(numbers);
                        break;
                    case 'c':
                        ShowReversed(numbers);
                        break;
                    case 'd':
                        ShowSorted(numbers);
                        break;
                    case 'e':
                        GetMax(numbers);
                        break;
                    case 'f':
                        GetMin(numbers);
                        break;
                    case 'g':
                        GetAverage(numbers);
                        break;
                    case 'h':
                        Console.WriteLine($"The Number of elements in the series is: {NumberofElements(numbers)}");
                        break;
                    case 'i':
                        Console.WriteLine($"The Sum of the series is: {GetSum(numbers)}");
                        break;
                    case 'j':
                        Console.WriteLine("Exiting...");
                        return;
                }
            } while (true);









        }
}
}
