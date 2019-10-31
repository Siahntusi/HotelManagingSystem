using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using WCF_SERVICE_CLIENT_HOST.Models;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RateAccommodationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RateAccommodationService.svc or RateAccommodationService.svc.cs at the Solution Explorer and start debugging.
    public class RateAccommodationService : IRateAccommodationService
    {
        private FileUploadsServices files = new FileUploadsServices();
        public void makeRating(ClientHotelRatings ratingMade)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = (from rating in db.CLIENT_HOTEL_RATINGs
                                 where rating.CLIENT_ID.Equals(Convert.ToInt32(ratingMade.ClientID)) && rating.HOTEL_ID.Equals(Convert.ToInt32(ratingMade.HotelID))
                                 select rating);

                    int count = query.Count();
                    if (count == 0)
                    {
                        CLIENT_HOTEL_RATING AccommoRating = new CLIENT_HOTEL_RATING()
                        {
                            HOTEL_ID = ratingMade.HotelID,
                            CLIENT_ID = ratingMade.ClientID,
                            RATING_VALUE = ratingMade.RatingValue
                        };

                        db.CLIENT_HOTEL_RATINGs.InsertOnSubmit(AccommoRating);
                        db.SubmitChanges();
                    }
                    if (count == 1)
                    {
                        CLIENT_HOTEL_RATING update = new CLIENT_HOTEL_RATING();
                        update = query.Single();

                        update.RATING_VALUE = ratingMade.RatingValue;
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
        }

        public int getAccommoRatingsByStud(string studId, string accommoId)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = (from rating in db.CLIENT_HOTEL_RATINGs
                                 where rating.CLIENT_ID.Equals(Convert.ToInt32(studId)) && rating.HOTEL_ID.Equals(Convert.ToInt32(accommoId))
                                 select rating);
                    CLIENT_HOTEL_RATING ratedAccommo = query.Single();

                    return ratedAccommo.RATING_VALUE;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public double getAccommoAvgRatings(string accommoId)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = (from rating in db.CLIENT_HOTEL_RATINGs
                                 where rating.HOTEL_ID.Equals(Convert.ToInt32(accommoId))
                                 select rating.RATING_VALUE);
                    if (query.Count() != 0)
                    {
                        int totAccommoRating = query.Sum();
                        int count = query.Count();
                        double avgRating = totAccommoRating / count;

                        return avgRating;
                    }

                    return -1.00;
                }
            }
            catch (Exception)
            {
                return -1.00;
            }
        }

        public List<Hotel> getToFiveRatedAccommos()
        {
            try
            {
                List<Hotel> accList = new List<Hotel>();
                Hotel accommo = null;
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    foreach (HOTEL acc in db.HOTELs)
                    {
                        accommo = new Hotel()
                        {
                            HotelName = acc.NAME,
                            NearestCity = acc.NEAREST_TOWN,
                            HotelID = acc.HOTEL_ID,
                            avgHotelRating = Convert.ToInt32(getAccommoAvgRatings(acc.HOTEL_ID.ToString())),
                            numRatings = getAccommoTotalUsrRatings(acc.HOTEL_ID.ToString()),
                            HotelMainImage = files.getMainImageByAccommoId(acc.HOTEL_ID.ToString()),
                        };

                        accList.Add(accommo);
                    }

                    return accList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int getAccommoTotalUsrRatings(string accommoId)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = (from rating in db.CLIENT_HOTEL_RATINGs
                                 where rating.HOTEL_ID.Equals(Convert.ToInt32(accommoId))
                                 select rating);
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

        public int rememberRating(string studId, string accommoId)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = (from rate in db.CLIENT_HOTEL_RATINGs where rate.CLIENT_ID.Equals(Convert.ToInt32(studId)) && rate.HOTEL_ID.Equals(Convert.ToInt32(accommoId)) select rate);

                    if (query.Count() == 1)
                    {
                        CLIENT_HOTEL_RATING tbl = query.Single();

                        return tbl.RATING_VALUE;
                    }
                    else { }

                    return -1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }


      /**  public void makeRatingJson(string studentId, string accommoId, string ratingValue)
        {
            
        }*/


        string IRateAccommodationService.makeRatingJson(string studentId, string accommoId, string ratingValue)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    ClientHotelRatings ratings = new ClientHotelRatings()
                    {
                        HotelID = Convert.ToInt32(accommoId),
                        RatingValue = Convert.ToInt32(ratingValue),
                        ClientID = Convert.ToInt32(studentId),
                    };
                    makeRating(ratings);
                    return "Successfully Submitted";
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return "Didnt submit";
           
        }

    }
}
