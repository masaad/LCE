using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzBuzzUtil.ValidationsEngine
{
    internal class RuleMethod<T, TR> : IRuleMethod where TR : RuleArgs
    {
        public RuleHandler<T, TR> RuleHandler { get; private set; }
        public string RuleName { get; private set; }
        public RuleArgs RuleArgs { get; private set; }
       

        public RuleMethod(RuleHandler<T, TR> handler, TR args)
        {
            RuleHandler = handler;
            RuleArgs = args;
            RuleName = string.Format(@"rule://{0}/{1}", RuleHandler.Method.Name, RuleArgs);
        }


        public override string ToString()
        {
            return RuleName;
        }

        public bool Invoke(object target)
        {
            return Invoke((T) target); 
        }

        public bool Invoke(T target)
        {
            return RuleHandler.Invoke(target, (TR)RuleArgs);
        }
    }
    
}
