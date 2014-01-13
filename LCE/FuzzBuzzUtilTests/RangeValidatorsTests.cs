using FuzzBuzzUtil.Data;
using NUnit.Framework;

namespace FuzzBuzzUtilTests
{
    [TestFixture]
    public class RangeValidatorsTests
    {
        [Test]
        public void RangeShouldBeInvalidWhenStartingIntegerIsGreaterThanEndingInteger()
        {
            var range = new IntegersRange();
            range.StartingInteger = 10;
            range.EndingInteger = 1; 

            Assert.IsFalse(range.IsValid, "range must be invalid when starting integer is greater that ending integer.");
            Assert.AreEqual(range.BrokenRulesCollection[0].PropertyName, "EndingInteger", "Unexpected broken property rule");
        }

        [Test]
        public void StartingIntegerMustBeGreaterThanZero()
        {
            var range = new IntegersRange();
            range.StartingInteger = 0;
            Assert.IsFalse(range.IsValid, "range must be invalid when starting integer is less than 1.");
            Assert.AreEqual(range.BrokenRulesCollection[0].PropertyName, "StartingInteger", "Unexpected broken property rule");
        }
    }
}
