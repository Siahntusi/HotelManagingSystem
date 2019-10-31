using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_SERVICE_CLIENT_HOST.Models;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReportingServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ReportingServices.svc or ReportingServices.svc.cs at the Solution Explorer and start debugging.
    public class ReportingServices : IReportingServices
    {
        #region OfficerReports
        public List<int> accommodationCounts()
        {
            List<int> data = null;
            try
            {
                data = new List<int>();
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    int countAPK = (from acc in db.HOTELs where acc.NEAREST_TOWN.Equals("JHB") select acc).Count();
                    int countAPB = (from acc in db.HOTELs where acc.NEAREST_TOWN.Equals("PTA") select acc).Count();
                    int countDFC = (from acc in db.HOTELs where acc.NEAREST_TOWN.Equals("DBN") select acc).Count();
                    int countSWC = (from acc in db.HOTELs where acc.NEAREST_TOWN.Equals("CPT") select acc).Count();

                    data.Add(countAPK);
                    data.Add(countAPB);
                    data.Add(countDFC);
                    data.Add(countSWC);

                    return data;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<int> accommodationTypeCounts(string campus)
        {
            List<int> statusCount = null;
            try
            {
                statusCount = new List<int>();
                int countFlat =0;
                int countDetatched=0;
                int countSemiDet=0;
                int countTerraced=0;
                int countAttached=0;

                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    if (campus.ToUpper() == "ALL")
                    {
                        countFlat = (from feature in db.HOTELs where feature.HOTEL_TYPE.Equals("Flat") select feature).Count();
                        countDetatched = (from feature in db.HOTELs where feature.HOTEL_TYPE.Equals("Detatched") select feature).Count();
                        countSemiDet = (from feature in db.HOTELs where feature.HOTEL_TYPE.Equals("Semi-Detatched") select feature).Count();
                        countTerraced = (from feature in db.HOTELs where feature.HOTEL_TYPE.Equals("Terraced") select feature).Count();
                        countAttached = (from feature in db.HOTELs where feature.HOTEL_TYPE.Equals("Attached") select feature).Count();
 
                        statusCount.Add(countFlat);
                        statusCount.Add(countDetatched);
                        statusCount.Add(countSemiDet);
                        statusCount.Add(countTerraced);
                        statusCount.Add(countAttached);

                    }
                    else
                    {
                        if ((campus.ToUpper()) == "JHB" || (campus.ToUpper()) == "PTA" || (campus.ToUpper()) == "DBN" || (campus.ToUpper()) == "CPT")
                        {
                            countFlat = (from feature in db.HOTELs where feature.HOTEL_TYPE.Equals("Flat") && feature.NEAREST_TOWN.Equals(campus.ToUpper()) select feature).Count();
                            countDetatched = (from feature in db.HOTELs where feature.HOTEL_TYPE.Equals("Detatched") && feature.NEAREST_TOWN.Equals(campus.ToUpper()) select feature).Count();
                            countSemiDet = (from feature in db.HOTELs where feature.HOTEL_TYPE.Equals("Semi-Detatched") && feature.NEAREST_TOWN.Equals(campus.ToUpper()) select feature).Count();
                            countTerraced = (from feature in db.HOTELs where feature.HOTEL_TYPE.Equals("Terraced") && feature.NEAREST_TOWN.Equals(campus.ToUpper()) select feature).Count();
                            countAttached = (from feature in db.HOTELs where feature.HOTEL_TYPE.Equals("Attached") && feature.NEAREST_TOWN.Equals(campus.ToUpper()) select feature).Count();

                            statusCount.Add(countFlat);
                            statusCount.Add(countDetatched);
                            statusCount.Add(countSemiDet);
                            statusCount.Add(countTerraced);
                            statusCount.Add(countAttached);

                        }
                    }

                    return statusCount;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int genderGroupings(string gender)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var count = from details in db.HOTEL_ADD_DETAILs
                                where details.GENDER_ALLOWED.Equals(gender)
                                select details;

                    return count.Count();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<int> accommodationsByStatus(string campus)
        {
            List<int> statusCount = null;
            try
            {
                statusCount = new List<int>();
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    if (campus.ToUpper() == "ALL")
                    {
                        int countAccredited = (from feature in db.HOTELs where feature.ACCRED_STATUS.Equals("ACCREDITED") select feature).Count();
                        int countNotAccredited = (from feature in db.HOTELs where feature.ACCRED_STATUS.Equals("NOT ACCREDITED") select feature).Count();

                        statusCount.Add(countAccredited);
                        statusCount.Add(countNotAccredited);

                    }
                    else
                    {
                        if ((campus.ToUpper()) == "JHB" || (campus.ToUpper()) == "PTA" || (campus.ToUpper()) == "DBN" || (campus.ToUpper()) == "CPT")
                        {
                            int countAccredited = (from feature in db.HOTELs where feature.ACCRED_STATUS.Equals("ACCREDITED") && feature.NEAREST_TOWN.Equals(campus.ToUpper()) select feature).Count();
                            int countNotAccredited = (from feature in db.HOTELs where feature.ACCRED_STATUS.Equals("NOT ACCREDITED") && feature.NEAREST_TOWN.Equals(campus.ToUpper()) select feature).Count();

                            statusCount.Add(countAccredited);
                            statusCount.Add(countNotAccredited);

                        }
                    }

                    return statusCount;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int accommoListInDistanceRange(string lower, string upper, string campus)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    int count = 0;
                    int lowerBound = Convert.ToInt32(lower);
                    int upperBound = Convert.ToInt32(upper);

                    var query = from acc in db.HOTELs
                                where acc.NEAREST_TOWN.Equals(campus.ToUpper())
                                select new Hotel
                                {
                                    NearestCity = acc.NEAREST_TOWN,
                                    Distance = Convert.ToDecimal(acc.DISTANCE_FROM_TOWN),
                                };

                    foreach (Hotel accommo in query)
                    {
                        if (accommo.Distance >= lowerBound && accommo.Distance < upperBound)
                        {
                            count++;
                        }
                    }

                    return count;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int rentRates(string lower, string upper, string campus)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = from acc in db.HOTELs
                                where acc.NEAREST_TOWN.Equals(campus.ToUpper())
                                join details in db.HOTEL_ADD_DETAILs on acc.HOTEL_ID equals details.HOTEL_ID
                                select new Hotel
                                {
                                    HotelDetails = new HotelAddDetails()
                                    {
                                        RentSharing = Convert.ToDouble(details.RENT_SHARING),
                                        RentSingle = Convert.ToDouble(details.RENT_SINGLE)
                                    },
                                };
                    int count = 0;
                    int lowerBound = Convert.ToInt32(lower);
                    int upperBound = Convert.ToInt32(upper);

                    foreach (Hotel acc in query)
                    {
                        if (acc.HotelDetails.RentSharing >= lowerBound && acc.HotelDetails.RentSharing < upperBound || acc.HotelDetails.RentSingle >= lowerBound && acc.HotelDetails.RentSingle < upperBound)
                        {
                            count++;
                        }
                    }

                    return count;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int capacities(string lower, string upper, string campus)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = from acc in db.HOTELs
                                where acc.NEAREST_TOWN.Equals(campus.ToUpper())
                                select new Hotel
                                {
                                    Capacity = acc.CAPACITY
                                };

                    int count = 0;
                    int lowerBound = Convert.ToInt32(lower);
                    int upperBound = Convert.ToInt32(upper);

                    foreach (Hotel acc in query)
                    {
                        if (acc.Capacity >= lowerBound && acc.Capacity < upperBound)
                        {
                            count++;
                        }
                    }

                    return count;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int accommdatedCount(string campus)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    int count = 0;

                    foreach (CLIENT_BOOKS_HOTEL booking in db.CLIENT_BOOKS_HOTELs)
                    {
                        if (booking.BOOKING_STATUS.Equals("MOVED IN"))
                        {
                            count++;
                        }
                    }

                    return count;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int nonAccommdatedCount(string campus)
        {
            int campusID = 0;
            if (campus.ToUpper() == "JHB") { campusID = 2; }
            if (campus.ToUpper() == "PTA") { campusID = 3; }
            if (campus.ToUpper() == "DBN") { campusID = 4; }
            if (campus.ToUpper() == "CPT") { campusID = 5; }

            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    int countAllStud = (from stud in db.CLIENTs where stud.CITY_ID.Equals(campusID) select stud).Count();
                    return countAllStud - accommdatedCount(campus);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<int> getTotalCapacityAbility(string campus)
        {
            int campusID = 0;
            if (campus.ToUpper() == "APK") { campusID = 2; }
            if (campus.ToUpper() == "APB") { campusID = 3; }
            if (campus.ToUpper() == "DFC") { campusID = 4; }
            if (campus.ToUpper() == "SWC") { campusID = 5; }

            List<int> data = null;
            try
            {
                data = new List<int>();
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    int capacityAbility = (from acc in db.HOTELs where acc.NEAREST_TOWN.Equals(campus.ToUpper()) select acc.CAPACITY).Sum();
                    int totalStud = (from stud in db.CLIENTs where stud.CITY_ID.Equals(campusID) select stud).Count();

                    data.Add(totalStud);
                    data.Add(capacityAbility);

                    return data;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int getByFundingType(string type)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = from student in db.CLIENTs where student.FUNDING_TYPE.Equals(type) select student;

                    return query.Count();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<int> getFeatures(string campus)
        {
            List<int> featureCount = null;
            try
            {
                featureCount = new List<int>();
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    if (campus.ToUpper() == "ALL")
                    {

                        int countWifi = (from feature in db.HOTEL_ADD_DETAILs where feature.WIFI.Equals(1) select feature).Count();
                        int countTvArea = (from feature in db.HOTEL_ADD_DETAILs where feature.TV_AREA.Equals(1) select feature).Count();
                        int countCleaning = (from feature in db.HOTEL_ADD_DETAILs where feature.CLEANING_SER.Equals(1) select feature).Count();
                        int countLaundry = (from feature in db.HOTEL_ADD_DETAILs where feature.LAUNDRY.Equals(1) select feature).Count();
                        int countEntertaiment = (from feature in db.HOTEL_ADD_DETAILs where feature.ENTERTAINMENT_AREA.Equals(1) select feature).Count();
                        int countStudy = (from feature in db.HOTEL_ADD_DETAILs where feature.STUDY_AREA.Equals(1) select feature).Count();
                        int countTransport = (from feature in db.HOTEL_ADD_DETAILs where feature.TRANSPORT_SHUTTLE.Equals(1) select feature).Count();
                        int countGym = (from feature in db.HOTEL_ADD_DETAILs where feature.GYM.Equals(1) select feature).Count();
                        int countParking = (from feature in db.HOTEL_ADD_DETAILs where feature.PARKING.Equals(1) select feature).Count();

                        featureCount.Add(countWifi);
                        featureCount.Add(countTvArea);
                        featureCount.Add(countCleaning);
                        featureCount.Add(countLaundry);
                        featureCount.Add(countEntertaiment);
                        featureCount.Add(countStudy);
                        featureCount.Add(countTransport);
                        featureCount.Add(countGym);
                        featureCount.Add(countParking);
                    }
                    else
                    {
                        if ((campus.ToUpper()) == "JHB" || (campus.ToUpper()) == "PTA" || (campus.ToUpper()) == "DBN" || (campus.ToUpper()) == "CPT")
                        {
                            int countWifi = (from feature in db.HOTEL_ADD_DETAILs
                                             where feature.WIFI.Equals(1)
                                             join acc in db.HOTELs on feature.HOTEL_ID equals acc.HOTEL_ID
                                             where acc.NEAREST_TOWN.Equals(campus.ToUpper())
                                             select feature).Count();
                            int countTvArea = (from feature in db.HOTEL_ADD_DETAILs
                                               where feature.TV_AREA.Equals(1)
                                               join acc in db.HOTELs on feature.HOTEL_ID equals acc.HOTEL_ID
                                               where acc.NEAREST_TOWN.Equals(campus.ToUpper())
                                               select feature).Count();
                            int countCleaning = (from feature in db.HOTEL_ADD_DETAILs
                                                 where feature.CLEANING_SER.Equals(1)
                                                 join acc in db.HOTELs on feature.HOTEL_ID equals acc.HOTEL_ID
                                                 where acc.NEAREST_TOWN.Equals(campus.ToUpper())
                                                 select feature).Count();
                            int countLaundry = (from feature in db.HOTEL_ADD_DETAILs
                                                where feature.LAUNDRY.Equals(1)
                                                join acc in db.HOTELs on feature.HOTEL_ID equals acc.HOTEL_ID
                                                where acc.NEAREST_TOWN.Equals(campus.ToUpper())
                                                select feature).Count();
                            int countEntertaiment = (from feature in db.HOTEL_ADD_DETAILs
                                                     where feature.ENTERTAINMENT_AREA.Equals(1)
                                                     join acc in db.HOTELs on feature.HOTEL_ID equals acc.HOTEL_ID
                                                     where acc.NEAREST_TOWN.Equals(campus.ToUpper())
                                                     select feature).Count();
                            int countStudy = (from feature in db.HOTEL_ADD_DETAILs
                                              where feature.STUDY_AREA.Equals(1)
                                              join acc in db.HOTELs on feature.HOTEL_ID equals acc.HOTEL_ID
                                              where acc.NEAREST_TOWN.Equals(campus.ToUpper())
                                              select feature).Count();
                            int countTransport = (from feature in db.HOTEL_ADD_DETAILs
                                                  where feature.TRANSPORT_SHUTTLE.Equals(1)
                                                  join acc in db.HOTELs on feature.HOTEL_ID equals acc.HOTEL_ID
                                                  where acc.NEAREST_TOWN.Equals(campus.ToUpper())
                                                  select feature).Count();
                            int countGym = (from feature in db.HOTEL_ADD_DETAILs
                                            where feature.GYM.Equals(1)
                                            join acc in db.HOTELs on feature.HOTEL_ID equals acc.HOTEL_ID
                                            where acc.NEAREST_TOWN.Equals(campus.ToUpper())
                                            select feature).Count();
                            int countParking = (from feature in db.HOTEL_ADD_DETAILs
                                                where feature.PARKING.Equals(1)
                                                join acc in db.HOTELs on feature.HOTEL_ID equals acc.HOTEL_ID
                                                where acc.NEAREST_TOWN.Equals(campus.ToUpper())
                                                select feature).Count();

                            featureCount.Add(countWifi);
                            featureCount.Add(countTvArea);
                            featureCount.Add(countCleaning);
                            featureCount.Add(countLaundry);
                            featureCount.Add(countEntertaiment);
                            featureCount.Add(countStudy);
                            featureCount.Add(countTransport);
                            featureCount.Add(countGym);
                            featureCount.Add(countParking);
                        }
                    }


                    return featureCount;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int getNumUpcomInspec(string status)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = from Inspec in db.HOTEL_INSPECTIONs
                                where Inspec.INSPEC_RESULT.Equals(status)
                                select Inspec;

                    return query.Count();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int getNumUpcomApplications(string status)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = from Apply in db.CYCLE_APPLICATIONs
                                where Apply.APP_STATUS.Equals(status)
                                select Apply;

                    return query.Count();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        #region Owner
        public int getNumBookingsByGender(string AccommoId, string Gender)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = (from booking in db.CLIENT_BOOKS_HOTELs
                                 where booking.HOTEL_ID.Equals(Convert.ToInt32(AccommoId)) && booking.CLIENT.GENDER.Equals(Gender) && booking.BOOKING_STATUS.Equals("VALID")
                                 select booking);

                    int count = query.Count();

                    return count;
                }

            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int getNumBookingsToAccommo(string accommoId)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = (from booking in db.CLIENT_BOOKS_HOTELs
                                 where booking.HOTEL_ID.Equals(Convert.ToInt32(accommoId)) && booking.BOOKING_STATUS.Equals("VALID")
                                 select booking);

                    int count = query.Count();

                    return count;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }
        #endregion
    }
}
