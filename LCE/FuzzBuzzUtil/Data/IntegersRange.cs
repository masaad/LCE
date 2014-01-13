using FuzzBuzzUtil.ValidationsEngine;

namespace FuzzBuzzUtil.Data
{
    public class IntegersRange : BaseData
    {

        private int _startingInteger = int.MinValue;
        private int _endingInteger = int.MinValue;
        private int _size = int.MinValue;       
       
        public IntegersRange()
        {}
      
        public IntegersRange(int staringInteger, int endingInteger)
        {           
            StartingInteger = staringInteger;
            EndingInteger = endingInteger;  
            ValidationRules.CheckRules();         
        }

        protected override void AddRules()
        {
            AddValidationRules(); 
        }      

        public int StartingInteger
        {
            get { return _startingInteger; }
            set
            {
                if (_startingInteger == value) return;
                _startingInteger = value;
                PropertyHasChanged("StartingInteger");
                PropertyHasChanged("Size");
            }
        }
        public int EndingInteger
        {
            get { return _endingInteger; }
            set
            {
                if (_endingInteger == value) return;
                _endingInteger = value;
                PropertyHasChanged("EndingInteger");
                PropertyHasChanged("Size");
            }
        }

        public int Size
        {
            get { return _size; }              

        }

        #region [Validation Rules]

        private void AddValidationRules()
        {
            ValidationRules.Add<IntegersRange, RuleArgs>(IsStartingIntegerGreaterthenZero, new RuleArgs("StartingInteger", "Starting Integer"));
            ValidationRules.Add<IntegersRange, RuleArgs>(IsEndingIntegerGreaterThenStartingInteger, new RuleArgs("EndingInteger", "Ending Integer"));
            ValidationRules.Add<IntegersRange, RuleArgs>(IsRangeWithinAllowedLimit, new RuleArgs("Size", "Range"));
        }
       
        private static bool IsStartingIntegerGreaterthenZero<T>(T target, RuleArgs e) where T : IntegersRange
        {
            e.Description = "Starting Integer must be greater than zero."; 
            return target.StartingInteger >= 1; 
        }
     
        private static bool IsEndingIntegerGreaterThenStartingInteger<T>(T target, RuleArgs e) where T : IntegersRange
        {
            e.Description = "Ending Integer must be greater than the starting integer.";
            return target.EndingInteger > target.StartingInteger; 
        }

        private static bool IsRangeWithinAllowedLimit<T>(T target, RuleArgs e) where T : IntegersRange
        {
            e.Description = "Range is either invalid or greater then the allowed limit.";
            target._size = (target.EndingInteger - target.StartingInteger) + 1;

            return (target._size > 0 && target._size <= int.MaxValue);
        }

        #endregion 
               

    }
}
