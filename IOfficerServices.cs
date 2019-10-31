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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOfficerServices" in both code and config file together.
    [ServiceContract]
    public interface IOfficerServices
    {
        //Getters
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAllOfficers", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Manager> getAllOfficers();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getOfficerById/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Manager getOffficerById(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getOfficersInCampus/{campusAbbreviation}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Manager> getOfficersInCampus(string campusAbbreviation);

        //Update
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "assignAccommodations", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string assignAccommodations(OfficerHandlesAccommo assignment);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "updateOfficer/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        Manager updateOfficer(string id, Manager owner);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "makeAdmin/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string makeAdmin(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "removeAdmin/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string removeAdmin(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "changePassword/{id},{oldPassword},{newPassword}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string changePassword(string id, string oldPassword, string newPassword);

        //Deletions
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteOfficer/{offId}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void deleteOfficer(string offId);
    }
}
