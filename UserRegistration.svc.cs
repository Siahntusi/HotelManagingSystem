using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;
using WCF_SERVICE_CLIENT_HOST.Models;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserRegistration" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserRegistration.svc or UserRegistration.svc.cs at the Solution Explorer and start debugging.
    public class UserRegistration : IUserRegistration
    {
        public string RegisterManager(Manager manager)
        {
            using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
            {
                HOTEL_MANAGER officerLinq = null;
             
                try
                {
                    
                    int officerLinqTest = (from uOfficer in db.HOTEL_MANAGERs where uOfficer.EMAIL.Equals(manager.Email) select uOfficer).Count();
                    if (officerLinqTest == 0)
                    {
                        officerLinq = ConvertToLinq.ConvertOfficerToLinqObject(manager);
                        db.HOTEL_MANAGERs.InsertOnSubmit(officerLinq);
                        db.SubmitChanges();
                        return "Success Regristration Successful";
                    }
                    else if (officerLinqTest != 0)
                    {
                        return "Failed Username already exists";
                    }
                }
                catch (Exception)
                {
                    return "Failed Registration failed, contact admin";
                }
            }
            return "Failed Registration failed, contact admin";
        }

        public string RegisterOwner(Owner owner)
        {
            using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
            {
                
                HOTEL_OWNER ownerLinq = null;
                
                try
                {
                    
                    int ownerLinqTest = (from uOwner in db.HOTEL_OWNERs where uOwner.EMAIL.Equals(owner.Email) select uOwner).Count();
                    if (ownerLinqTest == 0)
                    {
                        ownerLinq.OWNER_ID = Convert.ToInt32(owner.ID);
                        ownerLinq.SERVICE_PROVIDER_NUM = Convert.ToInt32(owner.ServiceProviderNumber);
                        ownerLinq.FULL_NAMES = owner.Name;
                        ownerLinq.SURNAME = owner.Surname;
                        ownerLinq.GENDER = owner.Gender;
                        ownerLinq.EMAIL = owner.Email;
                        ownerLinq.CONTACT_NUM = owner.ContactNumber;
                        ownerLinq.PASSWORD = owner.Password;
                        ownerLinq.AUTHENTICATION_LEVEL = Convert.ToString(owner.AuthenticationLevel);
                        ownerLinq.TITLE = Convert.ToString(owner.Title);
                        db.HOTEL_OWNERs.InsertOnSubmit(ownerLinq);
                        db.SubmitChanges();
                        return "Success Regristration Successful" + " Your Service Provider Number:" + owner.ServiceProviderNumber;
                    }
                    else if (ownerLinqTest != 0)
                    {
                        return "Failed Username already exists";
                    }
                }
                catch (Exception)
                {
                    return "Failed Registration failed, contact admin";
                }
            }
            return "Failed Registration failed, contact admin";
        }

        public void RegisterClientJason(string client)
        {
            var jsonSerializer = new JavaScriptSerializer();
            Client clientObject = jsonSerializer.Deserialize<Client>(client);

            Client clientToInsert = new Client()
            {
               
                AuthenticationLevel = clientObject.AuthenticationLevel,
                ContactNumber = clientObject.ContactNumber,
                Email = clientObject.Email,
                FundingType = clientObject.FundingType,
                Gender = clientObject.Gender,
                ID = clientObject.ID,
                Title = clientObject.Title,
                Name = clientObject.Name,
                Password = Secrecy.HashPassword(clientObject.Password),
                Surname = clientObject.Surname,
               
            };

            RegisterClient(clientToInsert);
        }

       
        public string RegisterClient(Client client)
        {
            //Using the using keyword ensures that the connection is closed automatically 
            using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
            {
                CLIENT clientLinq = null;

                try
                {
                    int clientLinqTest = (from uStud in db.CLIENTs where uStud.EMAIL.Equals(client.Email) select uStud).Count();
                    if (clientLinqTest == 0)
                    {
                        clientLinq = ConvertToLinq.ConvertStudentToLinqObject(client);
                        db.CLIENTs.InsertOnSubmit(clientLinq);
                        db.SubmitChanges();
                        return "Success Regristration Successful";
                    }
                    else if (clientLinqTest != 0)
                    {
                        return "Failed Username already exists";
                    }
                }
                catch (Exception e)
                {
                    return e.GetBaseException().ToString();//"Registration failed, contact admin";
                }
            }
            return "Why does this keeps happening???";
        }

        public void registerManagerJason(string manager)
        {
            var jsonSerializer = new JavaScriptSerializer();
            Manager managerObject = jsonSerializer.Deserialize<Manager>(manager);

            Manager managerToInsert= new Manager()
                {
                   
                    AuthenticationLevel = managerObject.AuthenticationLevel,
                    ContactNumber = managerObject.ContactNumber,
                    Email = managerObject.Email,
                    Gender = managerObject.Gender,
                    ID = managerObject.ID,
                    Name = managerObject.Name,
                    Password = Secrecy.HashPassword(managerObject.Password),
                    EmployeeNumber = managerObject.EmployeeNumber,
                    Surname = managerObject.Surname,
                    Title = managerObject.Title
            };

            RegisterManager(managerToInsert);
        }
    }
}
