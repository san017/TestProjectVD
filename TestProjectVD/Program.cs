using System;

namespace TestProjectVD
{
    /// <summary>
    /// Стартовая точка программы.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var exitProgramm = true;

            Console.WriteLine("Добро пожаловать в это замечательное консольное приложение :)");
            ConsoleDemo.ConsoleMenu();
            
            while (exitProgramm)
            {
                var userInput = Console.ReadLine();
                Console.WriteLine();
                switch (userInput)
                {
                    case "1":
                        {
                            ConsoleDemo.PrintAmountContract();
                        }
                        break;

                    case "2":
                        {
                            ConsoleDemo.PrintAmountContractForEachContractor();
                        }
                        break;

                    case "3":
                        {
                            ConsoleDemo.PrintListMailInvidualPerson();
                        }
                        break;
                    case "4":
                        {
                            ConsoleDemo.PrintChangeStatusContract();
                        }
                        break;
                    case "5":
                        {
                            ConsoleDemo.JsonReportIndividualPerson();
                        }
                        break;
                    case "6":
                        {
                            exitProgramm = !exitProgramm;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("\nНеизвестная команда!");
                        }
                        break;
                }

                ConsoleDemo.ConsoleMenu();
            }
        }

    }
}


