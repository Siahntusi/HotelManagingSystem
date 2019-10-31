using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_SERVICE_CLIENT_HOST.Models;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccreditationServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AccreditationServices.svc or AccreditationServices.svc.cs at the Solution Explorer and start debugging.
    public class AccreditationServices : IAccreditationServices
    { 
        public int applyForAccred(CycleApplications application)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    CYCLE_APPLICATION applicationToInsert = ConvertToLinq.ConvertAccredApplyToLinq(application);
                    db.CYCLE_APPLICATIONs.InsertOnSubmit(applicationToInsert);
                    db.SubmitChanges();

                    return applicationToInsert.APPLICATION_ID;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public string accreditAccommo(string accommoId)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    HOTEL updateAccred = (from accommo in db.HOTELs
                                          where accommo.HOTEL_ID.Equals(Convert.ToInt32(accommoId))
                                                  select accommo).Single();
                    updateAccred.ACCRED_STATUS = "ACCREDITED";
                    updateAccred.ACCRED_START_DATE = Convert.ToDateTime(DateTime.Now.AddYears(1).Year.ToString() + "-01-01");
                    updateAccred.ACCRED_EXPIRY_DATE = Convert.ToDateTime(AccreditationDuration.computeDuration());
                    db.SubmitChanges();

                    return "Success Accreditation made";
                }
            }
            catch (Exception)
            {
                return "Failed to perform accreditation";
            }
        }

        public string getAccreditStatus(string accommoId)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    HOTEL updateAccred = (from accommo in db.HOTELs
                                                  where accommo.HOTEL_ID.Equals(Convert.ToInt32(accommoId))
                                                  select accommo).Single();

                    return updateAccred.ACCRED_STATUS;
                }
            }
            catch (Exception)
            {
                return "Failed to get status";
            }
        }

        public 
            
            CycleApplications getAccreditDetails(string accommoId)
        {

            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var updateAccred = (from appl in db.CYCLE_APPLICATIONs
                                        where appl.HOTEL_ID.Equals(accommoId)
                                        join acc in db.HOTELs on appl.HOTEL_ID equals acc.HOTEL_ID
                                        select new CycleApplications
                                        {
                                            ApplicationId = appl.APPLICATION_ID,
                                            HotelId = appl.HOTEL_ID,
                                            ApplicationStatus = appl.APP_STATUS,
                                            ApplicationDate = appl.APPLICATION_DATE.ToString(),
                                            ReferenceNumber = appl.REF_NUM,

                                            hotel = new Hotel()
                                            {

                                                HotelName = acc.NAME,
                                                CycleStatus = acc.ACCRED_STATUS,
                                                Capacity = acc.CAPACITY,
                                                NearestCity = acc.NEAREST_TOWN,
                                                StartDate = acc.ACCRED_START_DATE.ToString(),
                                                EndDate = acc.ACCRED_EXPIRY_DATE.ToString()
                                            },
                                        });

                    foreach (CycleApplications acc in updateAccred)
                    {
                        return acc;
                    }


                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string cancelAccredit(string accommoId)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    HOTEL updateAccred = new HOTEL();
                    updateAccred = (from accommo in db.HOTELs
                                    where accommo.HOTEL_ID.Equals(Convert.ToInt32(accommoId))
                                                  select accommo).Single();
                    updateAccred.ACCRED_STATUS = "CANCELLED";
                    db.SubmitChanges();

                    return "Success Cancellation made";
                }
            }
            catch (Exception)
            {
                return "Failed to perform cancellation";
            }
        }

        public CycleApplications getApplicationDetailsByRefNum(string refNum)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var updateAccred = (from appl in db.CYCLE_APPLICATIONs
                                        where appl.REF_NUM.Equals(refNum)
                                        join acc in db.HOTELs on appl.HOTEL_ID equals acc.HOTEL_ID
                                        join address in db.ADDRESSes on acc.ADDRESS_ID equals address.ADDRESS_ID
                                        join accDet in db.HOTEL_ADD_DETAILs on acc.HOTEL_ID equals accDet.HOTEL_ID
                                        select new CycleApplications
                                        {
                                            ApplicationId = appl.APPLICATION_ID,
                                            HotelId = appl.HOTEL_ID,
                                            ApplicationStatus = appl.APP_STATUS,
                                            ApplicationDate = appl.APPLICATION_DATE.ToString(),
                                            ReferenceNumber = appl.REF_NUM,
                                            hotel = new Hotel()
                                            {
                                                HotelID = acc.HOTEL_ID,
                                                HotelName = acc.NAME,
                                                CycleStatus = acc.ACCRED_STATUS,
                                                Capacity = acc.CAPACITY,
                                                NearestCity = acc.NEAREST_TOWN,
                                                
                                                HotelAddress = new Address()
                                                {
                                                    AddressID = address.ADDRESS_ID,
                                                    Street = address.STREET,
                                                    Town = address.TOWN,
                                                    City = address.CITY,
                                                    PostalCode = address.POSTAL_CODE
                                                },
                                                HotelDetails = new HotelAddDetails()
                                                {
                                                    NumBathrooms = Convert.ToInt32(accDet.NUM_BATHROOM),
                                                    GenderAllowed = accDet.GENDER_ALLOWED,
                                                    NumSharingEnsuite = Convert.ToInt32(accDet.NUM_SHARING_ENSUITE),
                                                    NumSingleEnsuite = Convert.ToInt32(accDet.NUM_SINGLE_ENSUITE),
                                                    NumTwoSharingRooms = Convert.ToInt32(accDet.NUM_SHARING),
                                                    NumSingleRooms = Convert.ToInt32(accDet.NUM_SINGLES),
                                                    RentSharing = Convert.ToDouble(accDet.RENT_SHARING),
                                                    RentSingle = Convert.ToDouble(accDet.RENT_SINGLE)
                                                }
                                            },
                                            ApplicationFiles = getFilesForAccommo(appl.APPLICATION_ID.ToString())
                                        });

                    foreach (CycleApplications acc in updateAccred)
                    {
                        return acc;
                    }

                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<CycleApplications> getAllAccredApplications()
        {
            List<CycleApplications> accList = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var innerJoinQuery = from appl in db.CYCLE_APPLICATIONs
                                         join acc in db.HOTELs on appl.HOTEL_ID equals acc.HOTEL_ID
                                         select new CycleApplications
                                         {
                                             ApplicationId = appl.APPLICATION_ID,
                                             HotelId = appl.HOTEL_ID,
                                             ApplicationStatus = appl.APP_STATUS,
                                             ApplicationDate = appl.APPLICATION_DATE.ToString(),
                                             ReferenceNumber = appl.REF_NUM,
                                             hotel = new Hotel()
                                             {
                                                 HotelID = acc.HOTEL_ID,
                                                 HotelName = acc.NAME,
                                                 CycleStatus = acc.ACCRED_STATUS,  
                                                 NearestCity = acc.NEAREST_TOWN,
                                                 
                                             },
                                             ApplicationFiles = getFilesForAccommo(appl.APPLICATION_ID.ToString())
                                         };
                    accList = new List<CycleApplications>();
                    foreach (CycleApplications acc in innerJoinQuery)
                    {
                        accList.Add(acc);
                    }
                    return accList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int getApplicationByStatus(string Status)
        {
          
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = (from appl in db.CYCLE_APPLICATIONs
                                 where appl.APP_STATUS.Equals(Status)
                                 select appl);
                    if (query.Count() != 0)
                    {
                        int totAccommoRating = query.Count();

                        return totAccommoRating;
                    }
                    return -1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }


        public List<CycleApplications> getAcredApplicationByStatus(string Status)
        {
            List<CycleApplications> accList = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var innerJoinQuery = from appl in db.CYCLE_APPLICATIONs
                                         where appl.APP_STATUS.Equals(Status)
                                         join acc in db.HOTELs on appl.HOTEL_ID equals acc.HOTEL_ID
                                         select new CycleApplications
                                         {
                                             ApplicationId = appl.APPLICATION_ID,
                                            HotelId = appl.HOTEL_ID,
                                             ApplicationStatus = appl.APP_STATUS,
                                             ApplicationDate = appl.APPLICATION_DATE.ToString(),
                                             ReferenceNumber = appl.REF_NUM,
                                             Reason = appl.REASON,
                                             hotel = new Hotel()
                                             {
                                                 HotelID = acc.HOTEL_ID,
                                                 HotelName = acc.NAME,
                                                 CycleStatus = acc.ACCRED_STATUS,
                                                 NearestCity = acc.NEAREST_TOWN
                                             },
                                         };
                    accList = new List<CycleApplications>();
                 /*   foreach (CycleApplications acc in innerJoinQuery)
                    {
                        accList.Add(acc);
                    }*/
                    return accList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<ApplicationFile> getFilesForAccommo(string applicationId)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    return db.APPLICATION_FILEs.Where(file => file.APPLICATION_ID.Equals(Convert.ToInt32(applicationId))).Select(file => new ApplicationFile
                    {
                        FileId = file.FILES_ID,
                        ApplicationId = file.APPLICATION_ID,
                       FileName = file.NAME,
                        FileCategory = file.FILE_CATEGORY,
                        ContentType = file.CONTENT_TYPE,
                        FileSize = file.FILE_SIZE,
                        //data = file.DATA.ToArray(),
                        DateUploaded = file.DATE_UPLOADED.ToString(),
                        Location = file.LOCATION
                    }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string updateAccredApplication(CycleApplications application)
    {
        try
        {
            using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
            {
                var query = from accredApp in db.CYCLE_APPLICATIONs
                            where accredApp.HOTEL_ID.Equals(Convert.ToInt32(application.HotelId))
                                && accredApp.APPLICATION_ID.Equals(Convert.ToInt32(application.ApplicationId))
                            select accredApp;

                    CYCLE_APPLICATION updatedApp = new CYCLE_APPLICATION();
                updatedApp = query.Single();
                updatedApp.APP_STATUS = application.ApplicationStatus;
                updatedApp.REASON = application.Reason;
                db.SubmitChanges();

                return "Success Update Successful";
            }
        }
        catch (Exception)
        {
            return "Failed Update Failed";
        }
    }

}
    
}
