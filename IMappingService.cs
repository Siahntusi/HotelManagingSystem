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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMappingService" in both code and config file together.
    [ServiceContract]
    public interface IMappingService
    {
        //Insertions
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "insertAddress", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int insertAddress(Address addr);      

        //Getters
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getStringToMap/{campusId},{accommoId}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string getStringToMap(string campusId, string accommoId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAddressById/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Address getAddressById(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAllAddresses", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Address> getAllAddresses();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAllAccommoAddressesByCampus/{campusAbbrev}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Address> getAllAccommoAddressesByCampus(string campusAbbrev);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "updateAllCoordinatesInDb", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string updateAllCoordinatesInDb();       

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getLatLong/{street},{town},{city}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle=WebMessageBodyStyle.WrappedRequest)]
        List<string> getLatLong(string street, string town, string city);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getDistance/{campusId},{Tstreet},{Ttown},{Tcity}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        double getDistance(string campusId, string Tstreet, string Ttown, string Tcity); 

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "calculateDistance/{Fstreet},{Ftown},{Fcity},{Tstreet},{Ttown},{Tcity}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        double calculateDistance(string Fstreet, string Ftown, string Fcity, string Tstreet, string Ttown, string Tcity); 
    }
}
