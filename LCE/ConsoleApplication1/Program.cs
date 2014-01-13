using System;
using FuzzBuzzUtil;
using FuzzBuzzUtil.Data;
using FuzzBuzzUtil.ValidationsEngine;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer = "Y";          

            while (answer.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Clear();
                var range = new IntegersRange(); 

                Console.Write("\nEnter Starting Integer: ");
                string startingIntString = Console.ReadLine();

                int startingInt;
                if (!int.TryParse(startingIntString, out startingInt))
                {
                    Console.Write("\nStarting Integer is not a valid Integer. Would like to try again (Y | N)? ");
                    answer = Console.ReadLine();
                    if (answer == null || answer.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                        break;
                    continue;                  

                }

                range.StartingInteger = startingInt; 


                Console.Write("\nEnter Ending Integer: ");
                string endingIntString = Console.ReadLine();


                int endingInt;
                if (!int.TryParse(endingIntString, out endingInt))
                {                   
                    Console.Write("\nEnding Integer is not a valid Integer. Would like to try again (Y | N)? ");
                    answer = Console.ReadLine();
                    if (answer == null || answer.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                        break;
                    continue;      
                }

                range.EndingInteger = endingInt; 
 
                if (!range.IsValid)
                {
                    Console.WriteLine("\nValidation Errors:"); 
                    foreach (BrokenRule brokenRule in range.BrokenRulesCollection)
                    {
                        Console.WriteLine("* {0}: {1}", brokenRule.PropertyFriendlyName, brokenRule.Description);                                   
                    }
                    Console.Write("\nWould like to try again (Y | N)?");
                    answer = Console.ReadLine();  
                    if (answer == null || answer.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                        break;                        
                }
                else
                {

                    var fuzzBuzzEvalutionResults = FuzzBuzzEvaluator.GetEvaluationFor(range);

                    for (int i = 0; i < fuzzBuzzEvalutionResults.Length; i++)
                    {
                        Console.WriteLine(fuzzBuzzEvalutionResults[i]);
                    }                   

                    Console.Write("\nWould like to evaluate differnt integers (Y | N)?");
                    answer = Console.ReadLine();
                    if (answer == null || answer.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                        break;                                     
                }
               
            }

            Console.Clear();   
            Console.Write("\n\nThank you for using the FuzzBuzz evaluator.\n\nPlease press any key to exit.");
          
            Console.Read(); 
            
        }
    }
}
