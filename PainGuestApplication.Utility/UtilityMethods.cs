using System;

namespace PainGuestApplication.Utility
{
    public class UtilityMethods
    {
        public static int? CalculateAge(DateTime? dateOfBirth, DateTime? asOnDate)
        {
            if (dateOfBirth.HasValue && asOnDate.HasValue)
            {
                var age = asOnDate.Value.Year - dateOfBirth.Value.Year;
                if (dateOfBirth.Value > asOnDate.Value.AddYears(-age)) age--;
                return age;

            }
            return null;
        }


    }
}
