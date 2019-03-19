using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model.DTO
{

    public class B2BAccountDTO
    {
        public B2BAccountDTO(B2BAccount model)
        {

        }
    }
    public class EnrollmentDTO
    {
    }
    public enum GenderType
    {
        Male,
        Female
    }
    public enum RegistrationStatus
    {
        Registered,
        InviteSent,
        InviteNotSent
    }
    public enum UserType
    {
        Owner,
        PainGuest
    }
    public enum Status
    {
        None,
        Single,
        Married
    }
    public enum SpaceType
    {
        Room,
        Hall,

    }
    public enum UnitType
    {
        Centimeter,
        Foot,
        Meter,
        Inch
    }
}
