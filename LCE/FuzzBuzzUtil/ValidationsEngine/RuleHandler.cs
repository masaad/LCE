namespace FuzzBuzzUtil.ValidationsEngine
{   
    public delegate bool RuleHandler<T, R>(T target, R e) where R : RuleArgs;
}
