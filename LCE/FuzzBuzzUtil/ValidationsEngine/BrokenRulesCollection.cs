using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FuzzBuzzUtil.Validators;

namespace FuzzBuzzUtil.ValidationsEngine
{
    [Serializable()]
    public class BrokenRulesCollection : List<BrokenRule>
    {
        internal int ErrorCount { private set; get; }

        internal BrokenRulesCollection()
        {            
        }

        internal void Add(IRuleMethod rule)
        {
            Remove(rule); 
            var item = new BrokenRule(rule);
            ErrorCount += 1; 
            Add(item);


        }

        internal void Remove(IRuleMethod rule)
        {
            for (int index = 0; index < ErrorCount; index++)
            {
                if (this[index].RuleName == rule.RuleName)
                {
                    ErrorCount -= 1; 
                    RemoveAt(index);
                    break; 
                }
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            bool first = true;
            foreach (BrokenRule item in this)
            {
                if (first)
                    first = false;
                else
                    result.Append(Environment.NewLine);
                result.Append(item.Description);
            }
            return result.ToString();
        }

        public bool Contains(string propertyName)
        {
            return this.Any(item => item.PropertyName == propertyName);
        }
    }
}
