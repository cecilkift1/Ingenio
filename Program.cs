using System;
using System.Linq;
using System.Collections.Generic;

namespace Ingenio
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainSelectionValidOptions = new List<string> {"1", "2"};

            while (true)
            {
                Console.WriteLine("Hello please make your selection:");
                Console.WriteLine(" Enter '1' for function 1");
                Console.WriteLine(" Enter '2' for function 2");
                Console.WriteLine(" Enter 'x' to exit");

                var input = GetValidInput(mainSelectionValidOptions);
                SetUpFunction(input);
            }
        }

        private static string GetValidInput(List<string> validOptions)
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input.Equals("x", StringComparison.OrdinalIgnoreCase))
                {
                    System.Environment.Exit(-1);
                }

                if (!validOptions.Contains(input))
                {
                    Console.WriteLine("Please select select a valid option");
                }

                return input;
            }  
        }

        private static void SetUpFunction(string value)
        {
            switch (value)
            {
                case "1" :
                    ProcessFunction1();
                    break;

                case "2" : 
                    ProcessFunction2();
                    break;
                
                default:
                break;
            }
        }

        private static void ProcessFunction2()
        {
            Console.WriteLine("Please enter the category level:");
            var dataSet = SampleDataSet.DataSet;
            var counterList = Enumerable.Range(1, dataSet.Count-1).ToList();
            var validOptionsList = counterList.Select(ds => ds.ToString()).ToList();

            Console.WriteLine($"Valid levels are: {string.Join(",", validOptionsList)}");

            var input = GetValidInput(validOptionsList); 

            if (int.TryParse(input, out int level))
            {
                Console.WriteLine(dataSet.PrintCategoryLevel(level));
            }
        }

        private static void ProcessFunction1()
        {
            Console.WriteLine("Please enter the categoryId:"); 
            
            var dataSet = SampleDataSet.DataSet;
            var dataSetCategoryIds = dataSet.Select(ds => ds.CategoryId).ToList();
            var validOptionsList = dataSet.Select(ds => ds.CategoryId.ToString()).ToList();

            Console.WriteLine($"Valid Categories are: {string.Join(",", dataSetCategoryIds)}");

            var input = GetValidInput(validOptionsList);

            if (int.TryParse(input, out int categoryId))
            {
                Console.WriteLine(dataSet.GetPrintOutPut(categoryId));
            }
        }
    }
}
