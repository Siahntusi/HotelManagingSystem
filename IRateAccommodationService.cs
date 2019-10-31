using WCF_SERVICE_CLIENT_HOST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRateAccommodationService" in both code and config file together.
    [ServiceContract]
    public interface IRateAccommodationService
    {

        //Insertions
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "makeRating", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void makeRating(ClientHotelRatings ratingMade);

        [OperationContract]
        [WebInvoke(Method = "*", UriTemplate = "makeRatingJson/{studentId},{accommoId},{ratingValue}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        String makeRatingJson(string studentId, string accommoId, string ratingValue);


        //Getters
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "rememberRating/{studId},{accommoId}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int rememberRating(string studId, string accommoId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getToFiveRatedAccommos", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Hotel> getToFiveRatedAccommos();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAccommoRatingsByStud/{studId},{accommoId}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int getAccommoRatingsByStud(string studId, string accommoId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAccommoAvgRatings/{accommoId}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        double getAccommoAvgRatings(string accommoId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAccommoTotalUsrRatings/{accommoId}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int getAccommoTotalUsrRatings(string accommoId);
    }
}
