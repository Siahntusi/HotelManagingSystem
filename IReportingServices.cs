using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_SERVICE_CLIENT_HOST.Models;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReportingServices" in both code and config file together.
    [ServiceContract]
    public interface IReportingServices
    {
        #region OfficerReports
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "accommodationCounts", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<int> accommodationCounts();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "accommodationTypeCounts/{campus}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<int> accommodationTypeCounts(string campus);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "genderGroupings/{gender}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int genderGroupings(string gender);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAccommodationsByStatus/{campus}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<int> accommodationsByStatus(string campus);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAccommoListInDistanceRange/{lower},{upper},{campus}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int accommoListInDistanceRange(string lower, string upper, string campus);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getRentRates/{lower},{upper},{campus}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int rentRates(string lower, string upper, string campus);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getCapacities/{lower},{upper},{campus}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int capacities(string lower, string upper, string campus);

        //Housing Ability
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getTotalCapacityAbility/{campus}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<int> getTotalCapacityAbility(string campus);

        //Accommodated vs NonAccommodated
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAccommdatedCount/{campus}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int accommdatedCount(string campus);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getNonAccommdatedCount/{campus}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int nonAccommdatedCount(string campus);

        //Funding Types
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getByFundingType/{type}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int getByFundingType(string type);

        //Features

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getFeatures/{campus}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<int> getFeatures(string campus);

        //NumInspcetion
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getNumUpcomInspec/{status}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int getNumUpcomInspec(string status);
        
        //NumApplications
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getNumUpcomApplications/{status}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int getNumUpcomApplications(string status);
        #endregion

        #region Owner

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getNumBookingsByGender/{AccommId},{gender}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int getNumBookingsByGender(string AccommId, string gender);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getNumBookingsToAccommo/{AccommId}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int getNumBookingsToAccommo(string AccommId);
        #endregion
    }
}
