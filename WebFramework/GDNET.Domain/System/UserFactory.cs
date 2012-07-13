using GDNET.Domain.Base.Exceptions;

namespace GDNET.Domain.System
{
    public partial class User
    {
        public static UserFactory Factory
        {
            get { return new UserFactory(); }
        }

        public class UserFactory
        {
            public User Create(string email, string password)
            {
                ExceptionsManager.BusinessException.ThrowIfIsNullOrWhiteSpace(email, "");
                ExceptionsManager.BusinessException.ThrowIfTooShort(password, 4, "");

                return new User
                {
                    Email = email,
                    Password = password,
                };
            }
        }
    }
}
