using FuzzBuzzUtil.ValidationsEngine;

namespace FuzzBuzzUtil.Data
{
    public abstract class BaseData
    {
        private ValidationRules _validationRules;

        protected BaseData()
        {
            AddRules();            
        }

        protected virtual void AddRules()
        {
        }

        protected ValidationRules ValidationRules
        {
            get
            {
                if (_validationRules == null)
                    _validationRules = new ValidationRules(this);
                return _validationRules;
            }
        }

        public virtual BrokenRulesCollection BrokenRulesCollection
        {
            get { return ValidationRules.GetBrokenRules(); }
        }

        public virtual bool IsValid
        {
            get { return ValidationRules.IsValid; }
        }


        protected void PropertyHasChanged(string propertyName)
        {
            ValidationRules.CheckRules(propertyName);           
        }
    }
}
