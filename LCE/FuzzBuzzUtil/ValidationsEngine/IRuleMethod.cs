using FuzzBuzzUtil.Validators;

namespace FuzzBuzzUtil.ValidationsEngine
{
    internal interface IRuleMethod
    {
        string RuleName { get; }
        RuleArgs RuleArgs { get; }
        bool Invoke(object target);

    }
}
