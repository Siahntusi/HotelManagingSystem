using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_SERVICE_CLIENT_HOST.Models;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OwnerServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OwnerServices.svc or OwnerServices.svc.cs at the Solution Explorer and start debugging.
    public class OwnerServices : IOwnerServices
    {
        public List<Owner> getAllOwners()
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {

                    return db.HOTEL_OWNERs.Select(off => new Owner
                    {
                        ID = off.OWNER_ID,
                        ServiceProviderNumber = off.SERVICE_PROVIDER_NUM,
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

        public Owner getOwnerById(string id)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    return db.HOTEL_OWNERs.Where(person => person.OWNER_ID == Convert.ToInt32(id)
                        ).Select(person => new Owner
                        {
                            ID = person.OWNER_ID,
                            ServiceProviderNumber = person.SERVICE_PROVIDER_NUM,
                            Name = person.FULL_NAMES,
                            Surname = person.SURNAME,
                            Gender = person.GENDER,
                            Email = person.EMAIL,
                            ContactNumber = person.CONTACT_NUM,
                         //   Password = person.PASSWORD,
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

        public List<OwnersCompany> getAllComp()
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    return db.OWNERS_COMPANies.Select(comp => new OwnersCompany
                    {
                        CompanyName = comp.NAME,
                        OwnerId = (Int32)comp.COMP_ID,
                        CompId = comp.COMP_ID,
                        ContactNum = comp.CONTACT_NUM,
                        Email = comp.EMAIL,
                        RegNum = comp.REG_NUM
                    }).ToList();    
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public OwnersCompany getCompById(string id)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    return db.OWNERS_COMPANies.Where(comp => comp.COMP_ID.Equals(Convert.ToInt32(id))).Select(comp => new OwnersCompany
                    {
                        CompanyName = comp.NAME,
                        CompId = comp.COMP_ID,
                        OwnerId = (Int32)comp.COMP_ID,
                        ContactNum = comp.CONTACT_NUM,
                        Email = comp.EMAIL,
                        RegNum = comp.REG_NUM
                    }).First();
                }
            }
            catch (Exception)
            {
                return null;
            }          
        }

        public List<OwnersCompany> getCompByOwnerId(string ownerId)
        {
            List<OwnersCompany> compList = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var innerJoinQuery =
                    from owner in db.HOTEL_OWNERs where owner.OWNER_ID.Equals(Convert.ToInt32(ownerId))
                    join comp in db.OWNERS_COMPANies on owner.OWNER_ID equals comp.COMP_ID
                    select new OwnersCompany
                    {
                        CompanyName = comp.NAME,
                        CompId = comp.COMP_ID,
                        OwnerId = comp.COMP_ID,
                        ContactNum = comp.CONTACT_NUM,
                        Email = comp.EMAIL,
                        RegNum = comp.REG_NUM
                    };   

                    compList = new List<OwnersCompany>();

                    foreach(OwnersCompany com in innerJoinQuery)
                    {
                        
                        compList.Add(com);
                    }
                    return compList;
                }
            }
            catch (Exception)
            {
                return null;
            }          
        }

        public void deleteOwner(string ownerId)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    HOTEL_OWNER ToDelete = (from s in db.HOTEL_OWNERs where s.OWNER_ID.Equals(Convert.ToInt32(ownerId)) select s).Single();
                    db.HOTEL_OWNERs.DeleteOnSubmit(ToDelete);
                    db.SubmitChanges();
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
        }

        public void deleteCompany(string compId)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    OWNERS_COMPANY ToDelete = (from s in db.OWNERS_COMPANies where s.COMP_ID.Equals(Convert.ToInt32(compId)) select s).Single();
                    db.OWNERS_COMPANies.DeleteOnSubmit(ToDelete);
                    db.SubmitChanges();
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
        }

        //Helper method
        public int getCurrentOwnerCount()
        {
            int countOfOwnerRecordsInDB = 0;

            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    countOfOwnerRecordsInDB = (from row in db.HOTEL_OWNERs select row).Count();
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return countOfOwnerRecordsInDB;
        }

        public int generateServiceProviderNumber()
        {
            int servProvNumber = 0;

            servProvNumber = Convert.ToInt32(DateTime.Now.Year) * 10000 + getCurrentOwnerCount();

            return servProvNumber;
        }


        public string insertCompany(OwnersCompany comp)
        {
            try
            {         
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    OWNERS_COMPANY companyLinq = ConvertToLinq.ConvertCompanyToLinq(comp);
                    db.OWNERS_COMPANies.InsertOnSubmit(companyLinq);
                    db.SubmitChanges();

                    return "Success Adding company was successful";                 
                }
            }
            catch (Exception)
            {
                return "Failed Adding company failed, contact admin";
            }
        }

        public Owner updateOwner(string id, Owner owner)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = (from acc in db.HOTEL_OWNERs where acc.OWNER_ID.Equals(Convert.ToInt32(id)) select acc);
                    if (query.Count() == 1)
                    {
                        HOTEL_OWNER acc = query.Single();
                        owner = new Owner()
                        {
                            ServiceProviderNumber = acc.SERVICE_PROVIDER_NUM,
                            ContactNumber = acc.CONTACT_NUM,
                            Email = acc.EMAIL,
                            Gender = acc.GENDER,
                            Name = acc.FULL_NAMES,
                            Surname = acc.SURNAME,
                            Title = acc.TITLE,
                        };
                        db.SubmitChanges();
                        return owner;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch(Exception)
            {
                return null;
            }
        }

        public OwnersCompany updateCompany(string id, OwnersCompany comp)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = (from acc in db.OWNERS_COMPANies where acc.COMP_ID.Equals(Convert.ToInt32(id)) select acc);
                    if (query.Count() == 1)
                    {
                        OWNERS_COMPANY acc = query.Single();
                        comp = new OwnersCompany()
                        {                           
                            ContactNum = acc.CONTACT_NUM,
                            Email = acc.EMAIL,
                            CompanyName = acc.NAME,
                            RegNum = acc.REG_NUM
                        };
                        db.SubmitChanges();
                        return comp;
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
                    var query = (from acc in db.HOTEL_OWNERs where acc.OWNER_ID.Equals(Convert.ToInt32(id)) select acc);
                    if (query.Count() == 1)
                    {
                        HOTEL_OWNER student = query.Single();

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

        public Owner getOwnerByAccommoId(string accId)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var innerJoinQuery =
                    from accommo in db.HOTELs
                    where accommo.HOTEL_ID.Equals(Convert.ToInt32(accId))
                    join bridingTbl in db.OWNER_HOTEL_OWNERSHIPs on accommo.HOTEL_ID equals bridingTbl.HOTEL_ID
                    join owner in db.HOTEL_OWNERs on bridingTbl.OWNER_ID equals owner.OWNER_ID
                    join comp in db.OWNERS_COMPANies on owner.OWNER_ID equals comp.COMP_ID
                    select new Owner
                    {
                        ID = owner.OWNER_ID,
                        ServiceProviderNumber = owner.SERVICE_PROVIDER_NUM,
                        Name = owner.FULL_NAMES,
                        Surname = owner.SURNAME,
                        Gender = owner.GENDER,
                        Email = owner.EMAIL,
                        ContactNumber = owner.CONTACT_NUM,
                       // Password = owner.PASSWORD,
                        AuthenticationLevel = owner.AUTHENTICATION_LEVEL,
                        Title = owner.TITLE,
                        Company = new OwnersCompany()
                        {
                            CompanyName = comp.NAME,
                            ContactNum = comp.CONTACT_NUM,
                            Email = comp.EMAIL,
                            OwnerId = (Int32)comp.COMP_ID,
                            RegNum = comp.REG_NUM
                        }
                    };

                    foreach (Owner o in innerJoinQuery)
                    {
                        return o;
                    }

                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }     
    }
}
