using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_SERVICE_CLIENT_HOST.Models;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LoginService.svc or LoginService.svc.cs at the Solution Explorer and start debugging.
    public class LoginService : ILoginService
    {
        public BaseUser Login(string email, string password)
        {
            CLIENT linqClient = null;
            HOTEL_MANAGER linqManager = null;
            HOTEL_OWNER linqOwner = null;

            using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
            {
                try
                {
                    //Search queries
                    var query = (from uClient in db.CLIENTs where uClient.EMAIL.Equals(email) && uClient.PASSWORD.Equals(Secrecy.HashPassword(password)) select uClient);
                    int linqClientCount = query.Count();
                    if (linqClientCount == 1)
                    {
                        
                            linqClient = query.Single();
                            BaseUser client = new BaseUser();
                            client.ID = linqClient.CLIENT_ID;
                            client.Title = linqClient.TITLE;
                            client.Surname = linqClient.SURNAME;
                            client.Name = linqClient.FULL_NAMES;
                            client.Gender = linqClient.GENDER;
                            client.Email = linqClient.EMAIL;
                            client.ContactNumber = linqClient.CONTACT_NUM;
                            client.AuthenticationLevel = linqClient.AUTHENTICATION_LEVEL;

                            return client;
                       
                    
                    }
                    else if(linqClientCount == 0)
                    {
                        var query2 = (from uOff in db.HOTEL_MANAGERs where uOff.EMAIL.Equals(email) && uOff.PASSWORD.Equals(Secrecy.HashPassword(password)) select uOff);
                        int linqOfficerCount = query2.Count();
                        if (linqOfficerCount == 1)
                        {
                            linqManager = query2.Single();
                            if(linqManager.AUTHENTICATION_LEVEL == "M")
                            {                        
                                BaseUser manager = new BaseUser();
                                manager.Title = linqManager.TITLE;
                                manager.Surname = linqManager.SURNAME;
                                manager.Name = linqManager.FULL_NAMES;
                                manager.Gender = linqManager.GENDER;
                                manager.Email = linqManager.EMAIL;
                                manager.ContactNumber = linqManager.CONTACT_NUM;
                                manager.AuthenticationLevel = linqManager.AUTHENTICATION_LEVEL;
                                manager.ID = linqManager.MANAGER_ID;

                                return manager;
                            }
                            else
                            {
                                return null;
                            }
                        }
                        else 
                        {
                            var query3 = (from uOwn in db.HOTEL_OWNERs where uOwn.EMAIL.Equals(email) && uOwn.PASSWORD.Equals(Secrecy.HashPassword(password)) select uOwn);
                            int linqOwnerCount = query3.Count();
                            if(linqOwnerCount == 1)
                            {
                                linqOwner = query3.Single();
                                BaseUser owner = new BaseUser();
                      
                                owner.Title = linqOwner.TITLE;
                                owner.Surname = linqOwner.SURNAME;
                                owner.Name = linqOwner.FULL_NAMES;
                                owner.Gender = linqOwner.GENDER;
                                owner.Email = linqOwner.EMAIL;
                                owner.ContactNumber = linqOwner.CONTACT_NUM;
                                owner.AuthenticationLevel = linqOwner.AUTHENTICATION_LEVEL;
                                owner.ID = linqOwner.OWNER_ID;

                                return owner;
                            }
                            else if(linqOwnerCount == 0)
                            {
                                return null;
                            }
                        }
                    }                                                                     
                }
                catch (Exception)
                {
                    return null;//Find another way
                }
                return null;//Find another way
            }
        }
    }
}
