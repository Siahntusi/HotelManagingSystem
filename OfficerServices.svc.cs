using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_SERVICE_CLIENT_HOST.Models;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OfficerServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OfficerServices.svc or OfficerServices.svc.cs at the Solution Explorer and start debugging.
    public class OfficerServices : IOfficerServices
    {
        public List<Manager> getAllOfficers()
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {

                    return db.HOTEL_MANAGERs.Select(off => new Manager
                    {
                        ID = off.MANAGER_ID,
                        CityID = off.CITY_ID,
                        EmployeeNumber = off.EMPLOYEE_NUM,
                        Name = off.FULL_NAMES,
                        Surname = off.SURNAME,
                        Gender = off.GENDER,
                        Email = off.EMAIL,
                        ContactNumber = off.CONTACT_NUM,
                        //Password = off.PASSWORD,
                        AuthenticationLevel = off.AUTHENTICATION_LEVEL,
                        Title = off.TITLE
                    }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Manager getOffficerById(string id)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    return db.HOTEL_MANAGERs.Where(person => person.MANAGER_ID == Convert.ToInt32(id)
                        ).Select(person => new Manager
                        {
                            ID = person.MANAGER_ID,
                            CityID = person.CITY_ID,
                            EmployeeNumber = person.EMPLOYEE_NUM,
                            Name = person.FULL_NAMES,
                            Surname = person.SURNAME,
                            Gender = person.GENDER,
                            Email = person.EMAIL,
                            ContactNumber = person.CONTACT_NUM,
                            //Password = person.PASSWORD,
                            AuthenticationLevel = person.AUTHENTICATION_LEVEL,
                            Title = person.TITLE
                        }).First();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public void deleteOfficer(string offId)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                   HOTEL_MANAGER ToDelete = (from s in db.HOTEL_MANAGERs where s.MANAGER_ID.Equals(Convert.ToInt32(offId)) select s).Single();
                    db.HOTEL_MANAGERs.DeleteOnSubmit(ToDelete);
                    db.SubmitChanges();
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
        }


        public Manager updateOfficer(string id, Manager off)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = (from acc in db.HOTEL_MANAGERs where acc.MANAGER_ID.Equals(Convert.ToInt32(id)) select acc);
                    if (query.Count() == 1)
                    {
                        HOTEL_MANAGER acc = query.Single();
                        off = new Manager()
                        {
                            EmployeeNumber = acc.EMPLOYEE_NUM,
                            CityID = acc.CITY_ID,
                            ContactNumber = acc.CONTACT_NUM,
                            Email = acc.EMAIL,
                            Gender = acc.GENDER,
                            Name = acc.FULL_NAMES,
                            Surname = acc.SURNAME,
                            Title = acc.TITLE,
                        };
                        db.SubmitChanges();
                        return off;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public string changePassword(string id, string oldPassword, string newPassword)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = (from acc in db.HOTEL_MANAGERs where acc.MANAGER_ID.Equals(Convert.ToInt32(id)) select acc);
                    if (query.Count() == 1)
                    {
                        HOTEL_MANAGER student = query.Single();

                        string oldHashed = Secrecy.HashPassword(oldPassword);
                        string passwordInDB = student.PASSWORD;

                        if (oldHashed == passwordInDB)
                        {
                            student.PASSWORD = Secrecy.HashPassword(newPassword);
                            db.SubmitChanges();

                            return "Password Changed";
                        }
                        else
                        {
                            return "Incorrect old password";
                        }
                    }
                    else
                    {
                        return "Failed to change password";
                    }
                }
            }



            catch (Exception)
            {
                return "Failed to change password";
            }
        }


        public List<Manager> getOfficersInCampus(string campusAbbreviation)
        {
            List<Manager> stList = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var innerJoinQuery =
                    from campus in db.CITies
                    where campus.ABBREV.Equals(campusAbbreviation.ToUpper())
                    join stud in db.HOTEL_MANAGERs on campus.CITY_ID equals stud.CITY_ID
                    select new Manager
                    {
                        EmployeeNumber = stud.EMPLOYEE_NUM,
                        CityID = stud.CITY_ID,
                        ContactNumber = stud.CONTACT_NUM,
                        Email = stud.EMAIL,
                        Gender = stud.GENDER,
                        Name = stud.FULL_NAMES,
                        Surname = stud.SURNAME,
                        Title = stud.TITLE,
                    };
                    stList = new List<Manager>();
                    foreach (Manager student in innerJoinQuery)
                    {

                        stList.Add(student);
                    }

                    return stList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public string makeAdmin(string id)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = (from acc in db.HOTEL_MANAGERs where acc.MANAGER_ID.Equals(Convert.ToInt32(id)) select acc);
                    if (query.Count() == 1)
                    {
                        HOTEL_MANAGER student = query.Single();

                        if (student.AUTHENTICATION_LEVEL == "S")
                        {
                            student.AUTHENTICATION_LEVEL = "A";
                            db.SubmitChanges();

                            return " Success Update Successful";
                        }
                        else
                        {
                            return "Failed";
                        }
                    }
                    else
                    {
                        return "Failed Error User Not Found";
                    }
                }
            }
            catch (Exception)
            {
                return "Update Failed";
            }
        }

        public string removeAdmin(string id)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = (from acc in db.HOTEL_MANAGERs where acc.MANAGER_ID.Equals(Convert.ToInt32(id)) select acc);
                    if (query.Count() == 1)
                    {
                        HOTEL_MANAGER student = query.Single();

                        if (student.AUTHENTICATION_LEVEL == "A")
                        {
                            student.AUTHENTICATION_LEVEL = "S";
                            db.SubmitChanges();

                            return "Success Update Successful";
                        }
                        else
                        {
                            return "Failed";
                        }
                    }
                    else
                    {
                        return "Failed Error User Not Found";
                    }
                }
            }
            catch (Exception)
            {
                return "Failed Update Failed";
            }
        }

        public string assignAccommodations(OfficerHandlesAccommo assignment)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    MANAGER_HANDLES_HOTEL insert = new MANAGER_HANDLES_HOTEL()
                    {
                        HOTEL_ID = assignment.AccommoID,
                        MANAGER_ID = assignment.OfficerID,
                        DATE_ASSIGNED = Convert.ToDateTime(assignment.AssignDate)
                    };

                    db.MANAGER_HANDLES_HOTELs.InsertOnSubmit(insert);
                    db.SubmitChanges();

                    return "Success";
                }
            }
            catch (Exception e)
            {
                return "Failed " + e.Message;
            }
        }
    }
}
