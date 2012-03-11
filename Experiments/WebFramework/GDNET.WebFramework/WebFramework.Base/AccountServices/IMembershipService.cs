using System.Collections.Generic;
using System.Web.Security;

using WebFramework.Base.Framework.AccountModeles;

namespace WebFramework.Base.AccountServices
{
    public interface IMembershipService
    {
        int MinPasswordLength { get; }

        bool ValidateUser(string userName, string password);

        MembershipCreateStatus CreateUser(string userName, string password, string email);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
        bool DeleteUser(string userName, bool deleteAllRelatedData);
        void UpdateUser(AccountModel account);

        /// <summary>
        /// Get a user information using its claimed identifier as user name
        /// </summary>
        /// <param name="claimedIdentifier">OpenID claimed ID</param>
        AccountModel GetUser(string claimedIdentifier);
        AccountModel GetUser(string userName, bool userIsOnline);
        /// <summary>
        /// Get user by his key
        /// </summary>
        AccountModel GetUserByKey(object providerUserKey, bool userIsOnline);

        /// <summary>
        /// Get number of users
        /// </summary>
        /// <returns></returns>
        int CountTotal();

        /// <summary>
        /// Get user paging
        /// </summary>
        IList<AccountModel> GetList(int pageIndex, int pageSize);
        /// <summary>
        /// Get all members
        /// </summary>
        IList<AccountModel> GetAll();
    }
}
