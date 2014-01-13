using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzBuzzUtil.ValidationsEngine
{
    internal class ValidationRulesManager
    {
        private Dictionary<string, RulesList> _rulesList; 

        internal Dictionary<string, RulesList> RulesDictionary
        {
            get
            {
                return _rulesList ?? (_rulesList = new Dictionary<string, RulesList>());
            }
        }

        internal RulesList GetRulesForProperty(string propertyName, bool createList)
        {           
            RulesList list = null;
            if (RulesDictionary.ContainsKey(propertyName))
                list = RulesDictionary[propertyName];

            if (createList && list == null)
            {               
                list = new RulesList();
                RulesDictionary.Add(propertyName, list);
            }
            return list;
        }

        public void AddRule<T, TR>(RuleHandler<T, TR> handler, TR args) where TR : RuleArgs
        {
            // get the list of rules for the property
            List<IRuleMethod> list = GetRulesForProperty(args.PropertyName, true).GetList();

            // we have the list, add out new rule
            list.Add(new RuleMethod<T, TR>(handler, args));
        }


    }
}
