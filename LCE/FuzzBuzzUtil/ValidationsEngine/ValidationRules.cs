using System;
using System.Collections.Generic;
using FuzzBuzzUtil.Exceptions;

namespace FuzzBuzzUtil.ValidationsEngine
{
    public class ValidationRules
    {
        private ValidationRulesManager _instanceRules;
        private ValidationRulesManager _rulesToCheck;
        private BrokenRulesCollection _brokenRulesList;
       
        private readonly object _target; 

        internal ValidationRules(object target)
        {
            _target = target; 

        }

        private BrokenRulesCollection BrokenRulesList
        {
            get
            { 
                return _brokenRulesList ?? 
                       (_brokenRulesList = new BrokenRulesCollection());
            }
        }

        private ValidationRulesManager GetInstanceRules(bool createObject)
        {
            if (_instanceRules == null)
                if (createObject)
                    _instanceRules = new ValidationRulesManager();
            return _instanceRules;
        }

        private ValidationRulesManager RulesToCheck
        {
            get
            {
                if (_rulesToCheck == null)
                {
                    ValidationRulesManager instanceRules = GetInstanceRules(true);                                                      
                     _rulesToCheck = instanceRules;
                    foreach (KeyValuePair<string, RulesList> rulesItem in instanceRules.RulesDictionary)
                    {
                        RulesList rules = instanceRules.GetRulesForProperty(rulesItem.Key, true);
                        List<IRuleMethod> instanceList = rules.GetList();
                        instanceList.AddRange(rulesItem.Value.GetList());        
                    }
                                
                }
                return _rulesToCheck;
            }
        }

        public void Add<T, TR>(RuleHandler<T, TR> handler, TR args) where TR : RuleArgs
        {
            ValidateHandler(handler);
            GetInstanceRules(true).AddRule(handler, args);

        }


        private bool ValidateHandler<T, TR>(RuleHandler<T, TR> handler) where TR : RuleArgs
        {
            return ValidateHandler(handler.Method);
        }

        private bool ValidateHandler(System.Reflection.MethodInfo method)
        {
            if (!method.IsStatic && method.DeclaringType.Equals(_target.GetType()))
                throw new InvalidOperationException(
                  string.Format("{0}: {1}","Invalid Rule Method", method.Name));
            return true;
        }

        public void CheckRules(string propertyName)
        {
            ValidationRulesManager rules = RulesToCheck;
            if (rules == null) return;

            RulesList rulesList = rules.GetRulesForProperty(propertyName, createList: false);
            if (rulesList == null) return;

            List<IRuleMethod> ruleMethodList = rulesList.GetList(); 
            if (ruleMethodList != null)
                CheckRules(ruleMethodList);
        }

        public void CheckRules()
        {
            ValidationRulesManager rules = RulesToCheck;
            if (rules == null) return;
            foreach (KeyValuePair<string, RulesList> rulesDicItem in rules.RulesDictionary)
                CheckRules(rulesDicItem.Value.GetList());
        }

        private void CheckRules(List<IRuleMethod> rulesList)
        {           
            for (int index = 0; index < rulesList.Count; index++)
            {
                IRuleMethod rule = rulesList[index];
                bool ruleResult;
                try
                {
                    ruleResult = rule.Invoke(_target);
                }
                catch (Exception ex)
                {
                    throw new FuzzBuzzException(
                        string.Format(
                            "An exception was thrown during validation rules check.\n PropertyName: {0}.\n Validation Rule: {1}",
                            rule.RuleArgs.PropertyName, rule.RuleName), ex);
                }

                if (ruleResult)
                    BrokenRulesList.Remove(rule);
                else
                {
                    BrokenRulesList.Add(rule);
                }
            }

        }

        public BrokenRulesCollection GetBrokenRules()
        {
            return BrokenRulesList;
        }


        internal bool IsValid
        {
            get  { return BrokenRulesList.ErrorCount == 0; }
        }

    }
}
