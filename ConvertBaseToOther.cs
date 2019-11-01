using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_SERVICE_CLIENT_HOST.Models
{
    public class ConvertBaseToOther
    {
        public static Student BaseToStudent(BaseUser person)
        {
            Student result = new Student();
            try
            {
                result.ID = person.ID;             
                result.Name = person.Name;
                result.Surname = person.Surname;
                result.Gender = person.Gender;
                result.Email = person.Email;
                result.ContactNumber = person.ContactNumber;
                result.Password = person.Password;
                result.AuthenticationLevel = person.AuthenticationLevel;
                result.Title = person.Title;
            }
            catch (Exception)
            {
                return null;
            }   
            return result;
        }

        public static Officer BaseToOfficer(BaseUser person)
        {
            Officer result = new Officer();
            try
            {
                result.ID = person.ID;
                result.Name = person.Name;
                result.Surname = person.Surname;
                result.Gender = person.Gender;
                result.Email = person.Email;
                result.ContactNumber = person.ContactNumber;
                result.Password = person.Password;
                result.AuthenticationLevel = person.AuthenticationLevel;
                result.Title = person.Title;
            }
            catch (Exception)
            {
                return null;
            }
            return result;
        }

        public static Owner BaseToOwner(BaseUser person)
        {
            Owner result = new Owner();
            try
            {
                result.ID = person.ID;
                result.Name = person.Name;
                result.Surname = person.Surname;
                result.Gender = person.Gender;
                result.Email = person.Email;
                result.ContactNumber = person.ContactNumber;
                result.Password = person.Password;
                result.AuthenticationLevel = person.AuthenticationLevel;
                result.Title = person.Title;
            }
            catch (Exception)
            {
                return null;
            }
            return result;
        }
    }
}