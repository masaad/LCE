namespace FuzzBuzzUtil.ValidationsEngine
{
    public class RuleArgs
    {
        public string PropertyName {private  set; get; }
        public string PropertyFriendlyName { private set; get; }
        public string Description { internal set; get; }

        public RuleArgs(string propertyName)
        {
            PropertyName = propertyName; 
        }

        public RuleArgs(string propertyName, string friendlyName) : this(propertyName)
        {
            PropertyFriendlyName = friendlyName; 
        }       

        public override string ToString()
        {
            return PropertyName; 
        }
    
    }
}
