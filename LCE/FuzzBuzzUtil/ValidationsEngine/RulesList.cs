using System.Collections.Generic;

namespace FuzzBuzzUtil.ValidationsEngine
{
    internal class RulesList
    {
        private readonly List<IRuleMethod> _ruleMethodsList = new List<IRuleMethod>();
 
        public void Add(IRuleMethod item)
        {
            _ruleMethodsList.Add(item);
        }

        public List<IRuleMethod> GetList()
        {
            return _ruleMethodsList; 
        }
    }
}
