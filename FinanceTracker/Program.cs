/* Program name :   FinanceTracker
 * Author       :   Kordian Mankowski
 * Date Created :   Dec 2025
 * Purpose      :   To Track Finances */
using static System.Console;
namespace FinanceTracker
{
    internal class Program
    {
        //Class level variables
        static List<double> incomes = new List<double>();
        static List<double> expenses = new List<double>();
        static void Main(string[] args)
        {
            // Currency Code
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int input;

            do
            {
                input = DisplayMenu();

                switch (input)
                {
                    case 1:
                        AddIncome();
                        break;

                    case 2:
                        AddExpense();
                        break;

                    case 3:
                        ViewBalance();
                        break;

                    case 4:
                        ViewSummary();
                        break;

                    case 5:
                        WriteLine("Goodbye!");
                        break;

                    default:
                        WriteLine("Invalid option. Try again.");
                        break;
                }

            } while (input != 5);
        }



            static int DisplayMenu()
            {
                WriteLine("[1] Add Income");
                WriteLine("[2] Add Expense");
                WriteLine("[3] View Balance");
                WriteLine("[4] View Summary");
                WriteLine("[5] Exit");
                Write("\nEnter Option: ");
                if (int.TryParse(ReadLine(), out int input))
                {
                    if (input >= 1 && input <= 5)
                    {
                        return input;
                    }
                    else
                    {
                        WriteLine("Please enter a number between 1 and 5.");
                        return 0;
                    }
                }
                else
                {
                    WriteLine("Invalid input. Please enter a number.");
                    return 0;
                }
            }

            static void AddIncome()
            {
                Write("\n\nEnter income amount: ");
                if (double.TryParse(ReadLine(), out double amount))
                {
                    if (amount > 0)
                    {
                        incomes.Add(amount);
                        WriteLine($"Income of {amount:c} added successfully.\n");
                    }
                    else
                    {
                        WriteLine("Amount must be greater than zero.");
                    }
                }
                else
                {
                    WriteLine("Invalid input. Please enter a number.");
                }
            }

            static void AddExpense()
            {
                Write("\n\nEnter expense amount: ");
                if (double.TryParse(ReadLine(), out double amount))
                {
                    if (amount > 0)
                    {
                        expenses.Add(amount);
                        WriteLine($"Expense of {amount:c} added successfully.\n");
                    }
                    else
                    {
                        WriteLine("Amount must be greater than zero.");
                    }
                }
                else
                {
                    WriteLine("Invalid input. Please enter a number.");
                }
            }

            static void ViewBalance()
            {
                double totalIncome = 0;
                double totalExpense = 0;

                foreach (double amount in incomes)
                {
                    totalIncome += amount;
                }

                foreach (double amount in expenses)
                {
                    totalExpense += amount;
                }

                double balance = totalIncome - totalExpense;

                WriteLine($"\nTotal Income: {totalIncome:c}");
                WriteLine($"Total Expenses: {totalExpense:c}");
                WriteLine($"Current Balance: {balance:c}\n");
            }

            static void ViewSummary()
            {
                double totalIncome = 0;
                double totalExpense = 0;

                WriteLine("\n===== Income =====");
                for (int i = 0; i < incomes.Count; i++)
                {
                    WriteLine($"{i + 1}. {incomes[i]:c}");
                    totalIncome += incomes[i];
                }
                WriteLine($"Total Income: {totalIncome:c}\n");

                WriteLine("===== Expenses =====");
                for (int i = 0; i < expenses.Count; i++)
                {
                    WriteLine($"{i + 1}. {expenses[i]:c}");
                    totalExpense += expenses[i];
                }
                WriteLine($"Total Expenses: {totalExpense:c}\n");

                double balance = totalIncome - totalExpense;
                WriteLine($"Current Balance: {balance:c}\n");
            }
        
    }
}
