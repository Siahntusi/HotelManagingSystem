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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHotelServicee" in both code and config file together.
    [ServiceContract]
    public interface IHotelServicee
    {
        //Insertions
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "insertHotel", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int insertHotel(HotelEntity accommo);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "insertHotelAddDetails", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string insertHotelAddDetails(HotelAddDetails accommoDetails);

        //Update
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "updateHotel/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        Hotel updateHotel(string id, Hotel accommo);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "updateHotelAddDetails/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        HotelAddDetails updateHotelAddDetails(string id, HotelAddDetails det);

        //Getters
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getHotelById/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Hotel getHotelById(string id);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getHotelByOwnerId/{ownerId}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Hotel> getHotelByOwnerId(string ownerId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getHotelAddDetails/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        HotelAddDetails getHotelAddDetails(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getHotelFullInfoById/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Hotel getHotelFullInfoById(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAllHotel", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Hotel> getAllHotel();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getHotelNearCity/{campusAbbreviation}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Hotel> getHotelNearCity(string campusAbbreviation);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getHotelByCycleStatus/{accredStatus}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Hotel> getHotelByCycleStatus(string accredStatus);

        //Helper Getters
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getNumOfHotelOwned/{ownerId}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int getNumOfHotelOwned(string ownerId);

        //Deletions
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteHotel/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        string deleteHotel(string id);

        //Banned
        /*[OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "insertHotel", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int insertHotel(Hotel accommo);*/
    }
}