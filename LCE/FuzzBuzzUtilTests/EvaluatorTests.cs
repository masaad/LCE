using FuzzBuzzUtil;
using FuzzBuzzUtil.Data;
using NUnit.Framework;

namespace FuzzBuzzUtilTests
{
    [TestFixture]
    public class EvaluatorTests
    {
       [Test]
       public void EvaluateNumberFromOneToTenForFuzz_SucceedsTest()
       {
           var range = new IntegersRange(1, 10);
           var results = FuzzBuzzEvaluator.GetEvaluationFor(range); 
            
           Assert.AreEqual("Fuzz", results[2], "Fuzz result is incorrect.");
           Assert.AreEqual("Fuzz", results[8], "Fuzz result is incorrect.");
           Assert.AreNotEqual("Fuzz", results[4], "Fuzz result is incorrect.");
           Assert.AreNotEqual("Fuzz", results[9], "Fuzz result is incorrect.");
       }

       [Test]
       public void EvaluateNumberFromOneToTenForBuzz_SucceedsTest()
       {
           var range = new IntegersRange(1, 10);
           var results = FuzzBuzzEvaluator.GetEvaluationFor(range);
           Assert.AreEqual("Buzz", results[4], "Buzz result is incorrect.");
           Assert.AreEqual("Buzz", results[9], "Buzz result is incorrect.");
           Assert.AreNotEqual("Buzz", results[2], "Buzz result is incorrect.");
           Assert.AreNotEqual("Buzz", results[8], "Buzz result is incorrect.");          
       }


      [Test]
      public void EvaluateNumberFromOneToThrityForFuzzBuzz_SucceedsTest()
      {
          var range = new IntegersRange(1, 30);
          var results = FuzzBuzzEvaluator.GetEvaluationFor(range);
          Assert.AreEqual("FuzzBuzz", results[14], "FuzzBuzz result is incorrect.");
          Assert.AreEqual("FuzzBuzz", results[29], "FuzzBuzz result is incorrect.");
          Assert.AreNotEqual("FuzzBuzz", results[2], "FuzzBuzz result is incorrect.");
          Assert.AreNotEqual("FuzzBuzz", results[9], "FuzzBuzz result is incorrect.");     
      }

    }
}
