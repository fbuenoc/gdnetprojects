namespace WebFrameworkDomain.DynamicInput
{
    /// <summary>
    /// Take care when changing value of any items there, because it can be use in LVH.ContentDataTypes
    /// </summary>
    public class AttributeInfo
    {
        public AttributeInfo(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        private string Name
        {
            get;
            set;
        }

        private string Value
        {
            get;
            set;
        }

        public bool IsMatched(string name)
        {
            return this.Name == name;
        }
    }
}
