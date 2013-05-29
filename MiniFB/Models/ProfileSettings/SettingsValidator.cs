using MiniFB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniFB.Models.ProfileSettings
{
    public class SettingsValidator
    {


        public bool isValidSex(string sex = null)
        {
            if (sex.ToLower() == "kvinna" || sex.ToLower() == "man")
            {
                return true;
            }
            return false;
        }

       


        /* Kollar om den inloggades username stämmer överens med User modellen. */
        public bool isCorrectUser(string username, User user)
        {
            if(user.UserName.Equals(username)){return true;} return false;
        }

        /* Compare new password */
        public bool isPasswordConfirmed(string newpw, string confirmpw)
        {
            if(String.IsNullOrEmpty(newpw) || String.IsNullOrEmpty(confirmpw))
                return false;
            
            if (newpw.Equals(confirmpw))
                return true;
            
            return false;
        }

        /* Kollar så det gamla lösenordet stämmer. */
        public bool isOldPasswordCorrect(string oldpw, User user)
        {
            if (String.IsNullOrEmpty(oldpw))
                return false;

            string hasholdpw = DevOne.Security.Cryptography.BCrypt.BCryptHelper.HashPassword(oldpw, user.Salt);

            if (hasholdpw.Equals(user.Password))
                return true;

            return false;
        }




    }
}