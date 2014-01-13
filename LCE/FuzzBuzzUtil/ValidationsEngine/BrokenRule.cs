using System;
using FuzzBuzzUtil.Validators;

namespace FuzzBuzzUtil.ValidationsEngine
{
    [Serializable]
    public class BrokenRule
    {        
        public string RuleName { private set; get; }
        public string Description { private set; get; }
        public string PropertyName { private set; get; }
        public string PropertyFriendlyName { private set; get; }

        internal BrokenRule(IRuleMethod rule)
        {
            RuleName = rule.RuleName;
            Description = rule.RuleArgs.Description;
            PropertyName = rule.RuleArgs.PropertyName;
            PropertyFriendlyName = rule.RuleArgs.PropertyFriendlyName; 

        }
       
        public BrokenRule(string ruleName, string propertyName, string description)
        {
            RuleName = ruleName;
            PropertyName = propertyName;  
            Description = description; 
       }


    }
}
