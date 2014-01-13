using System.Globalization;
using FuzzBuzzUtil.Data;

namespace FuzzBuzzUtil
{
    public class FuzzBuzzEvaluator
    {


        public static string[] GetEvaluationForIntegersFromOneToOneHunderd()
        {
            var range = new IntegersRange(1, 100);
            return GetEvaluationFor(range); 
        }

        public static string[] GetEvaluationFor(IntegersRange range)
        {
            var fuzzBuzzArray = new string[range.Size];
            const string fuzz = "Fuzz";
            const string buzz = "Buzz";
            const string fuzzbuzz = "FuzzBuzz";
            int numberToEvaluate = range.StartingInteger; 

            for (int index = 0; index < range.Size; index++)
            {
               
                if (IsDividableBy3(numberToEvaluate) && IsDividableBy5(numberToEvaluate))
                {
                    fuzzBuzzArray[index] = fuzzbuzz;
                    numberToEvaluate += 1; 
                    continue;
                }

                if (IsDividableBy3(numberToEvaluate))
                {
                    fuzzBuzzArray[index] = fuzz;
                    numberToEvaluate += 1; 
                    continue;
                }

                if (IsDividableBy5(numberToEvaluate))
                {
                    fuzzBuzzArray[index] = buzz;
                    numberToEvaluate += 1; 
                    continue;
                }

                fuzzBuzzArray[index] = numberToEvaluate.ToString(CultureInfo.InvariantCulture);
                numberToEvaluate += 1; 
            }

            return fuzzBuzzArray;
        }
     
        private static bool IsDividableBy3(int number)
        {
            return (number % 3 == 0);
        }

        private static bool IsDividableBy5(int number)
        {
            return (number % 5 == 0);
        }
    }
}
