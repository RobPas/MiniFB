using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MiniFB.Models.Entities;
using MiniFB.Models.Repositories;
using WebMatrix.WebData;
using System.Web.Security;


namespace MiniFB.Models
{
    public class CustomMembershipProvider : ExtendedMembershipProvider
    {
        public override MembershipUser CreateUser(string username, string password,
               string email, string passwordQuestion, string passwordAnswer,
               bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            ValidatePasswordEventArgs args =
               new ValidatePasswordEventArgs(username, password, true);
            OnValidatingPassword(args);

            if (args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            if (RequiresUniqueEmail && GetUserNameByEmail(email) != string.Empty)
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }

            MembershipUser user = GetUser(username, true);

            if (user == null)
            {
                User appUser = new User();
                appUser.UserName = username;
                appUser.Salt = BCrypt.Net.BCrypt.GenerateSalt();
                appUser.PasswordHash = GetBcryptHash(password, appUser.Salt);
                appUser.Email = email;

                IAppUserRepository userRepo = new AppUserRepository();
                userRepo.RegisterUser(appUser);

                status = MembershipCreateStatus.Success;

                return GetUser(username, true);
            }
            else
            {
                status = MembershipCreateStatus.DuplicateUserName;
            }

            return null;
        }
        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            IAppUserRepository userRepo = new AppUserRepository();
            var user = userRepo.FindAll(u => u.UserName == username)
                .FirstOrDefault();
            if (user != null)
            {
                MembershipUser memUser = new MembershipUser(
                        "CustomMembershipProvider",
                                               username, user.ID,
                    user.Email,
                                               string.Empty, string.Empty,
                                               true, false, DateTime.MinValue,
                                               DateTime.MinValue,
                                               DateTime.MinValue,
                                               DateTime.Now, DateTime.Now);
                return memUser;
            }
            return null;

        }

        public override bool ValidateUser(string username, string password)
        {
            IAppUserRepository userRepo = new AppUserRepository();
            var user = userRepo.FindAll(u => u.UserName == username)
            .FirstOrDefault();
            if (user == null || string.IsNullOrEmpty(user.Salt))
                return false;
            string bcryptHash = GetBcryptHash(password, user.Salt);
            if (bcryptHash == user.PasswordHash)
                return true;
            return false;

        }

        public override int MinRequiredPasswordLength
        {
            get { return 6; }
        }

        public override bool RequiresUniqueEmail
        {
            // In a real application, you will essentially have to return true
            // and implement the GetUserNameByEmail method to identify duplicates
            get { return false; }
        }

        public static string GetBcryptHash(string value, string salt)
        {
            return BCrypt.Net.BCrypt.HashPassword(value, salt);
        }

        // Change these?
        public override MembershipPasswordFormat PasswordFormat
        { get { return MembershipPasswordFormat.Hashed; } }
        public override string ApplicationName { get; set; }
        public override bool EnablePasswordReset { get { return false; } }
        public override bool EnablePasswordRetrieval { get { return false; } }
        public override int MaxInvalidPasswordAttempts { get { return 15; } }
        public override int MinRequiredNonAlphanumericCharacters
        { get { return 0; } }
        public override int PasswordAttemptWindow { get { return 15; } }
        public override bool RequiresQuestionAndAnswer { get { return false; } }
        public override bool DeleteUser(string username,
                    bool deleteAllRelatedData)
        {
            IAppUserRepository userRepo = new AppUserRepository();
            try
            {
                userRepo.DeleteUserByUserName(username);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override string GetUserNameByEmail(string email)
        {
            IAppUserRepository userRepo = new AppUserRepository();
            return userRepo.FindAll(u => u.Email == email)
                .Select(u => u.UserName).FirstOrDefault();
        }

        // Not Implemented:

        public override string PasswordStrengthRegularExpression
        { get { throw new NotImplementedException(); } }

        public override MembershipUserCollection GetAllUsers(int pageIndex,
                    int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
            //IAppUserRepository userRepo = new AppUserRepository();
            //return userRepo.FindAll().Select(u => new MembershipUser("CustomMembershipProvider",
            //                                   u.UserName, u.ID, u.UserEmailAddress,
            //                                   string.Empty, string.Empty,
            //                                   true, false, DateTime.MinValue,
            //                                   DateTime.MinValue,
            //                                   DateTime.MinValue,
            //                                   DateTime.Now, DateTime.Now));
        }
        public override MembershipUserCollection FindUsersByEmail(
    string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
        public override MembershipUserCollection FindUsersByName(
    string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username,
                string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username,
    string password, string newPasswordQuestion, string newPasswordAnswer)
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
        public override MembershipUser GetUser(object providerUserKey
                        , bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetLastPasswordFailureDate(string userName)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetPasswordChangedDate(string userName)
        {
            throw new NotImplementedException();
        }
        public override DateTime GetCreateDate(string userName)
        {
            throw new NotImplementedException();
        }
        public override bool ResetPasswordWithToken(string token, string newPassword)
        {
            throw new NotImplementedException();
        }
        public override bool IsConfirmed(string userName)
        {
            throw new NotImplementedException();
        }

        public override int GetPasswordFailuresSinceLastSuccess(string userName)
        {
            throw new NotImplementedException();
        }
        public override ICollection<OAuthAccountData> GetAccountsForUser(string userName)
        {
           throw new NotImplementedException();
        }
        public override string CreateAccount(string userName, string password)
        {
            return base.CreateAccount(userName, password);
        }

        public override string CreateUserAndAccount(string userName, string password)
        {
            return base.CreateUserAndAccount(userName, password);
        }
        public override int GetUserIdFromOAuth(string provider, string providerUserId)
        {
            return base.GetUserIdFromOAuth(provider, providerUserId);
        }
        public override bool DeleteAccount(string userName)
        {
            throw new NotImplementedException();
        }
        public override string GeneratePasswordResetToken(string userName)
        {
            return base.GeneratePasswordResetToken(userName);
        }
        public override int GetUserIdFromPasswordResetToken(string token)
        {
            throw new NotImplementedException();
        }
        public override bool ConfirmAccount(string accountConfirmationToken)
        {
            throw new NotImplementedException();
        }

        public override bool ConfirmAccount(string userName, string accountConfirmationToken)
        {
            throw new NotImplementedException();
        }
        public override string CreateUserAndAccount(string userName, string password, bool requireConfirmation)
        {
            return base.CreateUserAndAccount(userName, password, requireConfirmation);
        }

        public override string CreateAccount(string userName, string password, bool requireConfirmationToken)
        {
            throw new NotImplementedException();
        }

        public override string GeneratePasswordResetToken(string userName, int tokenExpirationInMinutesFromNow)
        {
            throw new NotImplementedException();
        }

        public override string CreateUserAndAccount(string userName, string password, bool requireConfirmation, IDictionary<string, object> values)
        {
            throw new NotImplementedException();
        }

        // Not Used:

        //protected virtual byte[] DecryptPassword(byte[] encodedPassword);

        //[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        //protected virtual byte[] EncryptPassword(byte[] password);

        //protected virtual byte[] EncryptPassword(byte[] password, MembershipPasswordCompatibilityMode legacyPasswordCompatibilityMode);

    }
}