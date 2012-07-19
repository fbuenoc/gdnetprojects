using System;
using System.Web.Security;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories;
using GDNET.Domain.Services;

namespace GDNET.Web.Security
{
    public class NHibernateMembershipProvider : MembershipProvider
    {
        public override string ApplicationName
        {
            get;
            set;
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            status = MembershipCreateStatus.UserRejected;

            MembershipUser membershipUser = null;
            User newUser = User.Factory.Create(email, password);

            if (DomainRepositories.User.Save(newUser))
            {
                membershipUser = this.GetUser(email, true);
                status = MembershipCreateStatus.Success;
            }

            return membershipUser;
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { return true; }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            MembershipUser membershipUser = null;
            User user = DomainRepositories.User.FindByEmail(username);

            if (user != null)
            {
                DateTime creationDate = DateTime.Now;
                DateTime lastLoginDate = DateTime.Now;
                DateTime lastActivityDate = DateTime.Now;
                DateTime lastPasswordChanged = DateTime.Now;
                DateTime lastLockoutDate = DateTime.Now;
                membershipUser = new MembershipUser(this.GetType().Name, user.Email, user.Id, user.Email, string.Empty, string.Empty, true, false, creationDate, lastLoginDate, lastActivityDate, lastPasswordChanged, lastLockoutDate);
            }

            return membershipUser;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            User user = DomainRepositories.User.FindByEmail(email);
            return (user == null) ? string.Empty : user.Email;
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { return 6; }
        }

        public override int PasswordAttemptWindow
        {
            get { return 10; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return MembershipPasswordFormat.Clear; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            User user = DomainRepositories.User.FindByEmail(username);
            return (user == null) ? false : (DomainServices.Encryption.Decrypt(user.Password) == password);
        }
    }
}
