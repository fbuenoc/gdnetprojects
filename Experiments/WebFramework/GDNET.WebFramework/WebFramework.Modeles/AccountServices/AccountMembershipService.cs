using System;
using System.Collections.Generic;
using System.Web.Security;
using WebFramework.Models.Framework.AccountModeles;

namespace WebFramework.Models.AccountServices
{
    public class AccountMembershipService : IMembershipService
    {
        private readonly MembershipProvider provider;

        public AccountMembershipService()
            : this(null)
        {
        }

        public AccountMembershipService(MembershipProvider provider)
        {
            this.provider = provider ?? Membership.Provider;
        }

        public int MinPasswordLength
        {
            get
            {
                return this.provider.MinRequiredPasswordLength;
            }
        }

        public bool ValidateUser(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("Value cannot be null or empty.", "password");

            return this.provider.ValidateUser(userName, password);
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("Value cannot be null or empty.", "password");
            if (String.IsNullOrEmpty(email)) throw new ArgumentException("Value cannot be null or empty.", "email");

            MembershipCreateStatus status;
            this.provider.CreateUser(userName, password, email, null, null, true, null, out status);
            return status;
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(oldPassword)) throw new ArgumentException("Value cannot be null or empty.", "oldPassword");
            if (String.IsNullOrEmpty(newPassword)) throw new ArgumentException("Value cannot be null or empty.", "newPassword");

            // The underlying ChangePassword() will throw an exception rather
            // than return false in certain failure scenarios.
            try
            {
                MembershipUser currentUser = this.provider.GetUser(userName, true /* userIsOnline */);
                return currentUser.ChangePassword(oldPassword, newPassword);
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (MembershipPasswordException)
            {
                return false;
            }
        }


        public bool DeleteUser(string userName, bool deleteAllRelatedData)
        {
            if (String.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Value cannot be null or empty.", "userName");
            }
            return this.provider.DeleteUser(userName, deleteAllRelatedData);
        }

        public void UpdateUser(AccountModel account)
        {
            this.provider.UpdateUser(account.User);
        }

        public AccountModel GetUser(string claimedIdentifier)
        {
            if (String.IsNullOrEmpty(claimedIdentifier))
            {
                throw new ArgumentException("Value cannot be null or empty.", "claimedIdentifier");
            }
            return this.GetUser(claimedIdentifier, false);
        }

        public AccountModel GetUser(string userName, bool userIsOnline)
        {
            if (String.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Value cannot be null or empty.", "userName");
            }

            var user = this.provider.GetUser(userName, true);
            return new AccountModel(user);
        }

        public AccountModel GetUserByKey(object providerUserKey, bool userIsOnline)
        {
            if (providerUserKey == null)
            {
                throw new ArgumentException("Value cannot be null or empty.", "providerUserKey");
            }
            var user = this.provider.GetUser(providerUserKey, userIsOnline);
            return new AccountModel(user);
        }

        public int CountTotal()
        {
            int totalUsers;
            this.provider.GetAllUsers(0, 1, out totalUsers);

            return totalUsers;
        }

        public IList<AccountModel> GetList(int pageIndex, int pageSize)
        {
            List<AccountModel> listOfAccounts = new List<AccountModel>();

            int totalUsers = 0;
            MembershipUserCollection allMembers = this.provider.GetAllUsers(pageIndex, pageSize, out totalUsers);

            foreach (MembershipUser user in allMembers)
            {
                listOfAccounts.Add(new AccountModel(user));
            }

            return listOfAccounts;
        }

        public IList<AccountModel> GetAll()
        {
            int pageIndex = 0;
            int pageSize = 20;
            List<AccountModel> allUsers = new List<AccountModel>();

            // Get first page of users
            var listOfUsers = this.GetList(pageIndex, pageSize);
            allUsers.AddRange(listOfUsers);

            while (listOfUsers.Count == pageSize)
            {
                pageIndex += 1;
                listOfUsers = this.GetList(pageIndex, pageSize);
                allUsers.AddRange(listOfUsers);
            }

            return allUsers;
        }
    }
}
