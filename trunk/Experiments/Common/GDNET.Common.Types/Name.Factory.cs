namespace GDNET.Common.Types
{
    public partial class Name
    {
        public static NameFactory Factory
        {
            get { return new NameFactory(); }
        }

        public class NameFactory
        {
            public Name Create()
            {
                return new Name { };
            }

            public Name Create(string firstName, string lastName, string middleName, string displayName)
            {
                Name name = this.Create();
                name.FirstName = firstName;
                name.LastName = lastName;
                name.MiddleName = middleName;
                name.DisplayName = displayName;

                return name;
            }
        }
    }
}
