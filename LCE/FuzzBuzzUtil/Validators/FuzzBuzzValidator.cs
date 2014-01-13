using System.Collections.Generic;
using FuzzBuzzUtil.ValidationsEngine;

namespace FuzzBuzzUtil.Validators
{
    internal class FuzzBuzzValidator
    {
        public IList<BrokenRule> BrokenRules { private set; get; } 

        public FuzzBuzzValidator()
        {
            BrokenRules = new List<BrokenRule>();          
        }
    }
}
