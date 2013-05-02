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
            if (sex == "Kvinna" || sex == "Man")
            {
                return true;
            }
            return false;
        }


    }
}