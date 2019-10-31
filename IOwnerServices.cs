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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOwnerServices" in both code and config file together.
    [ServiceContract]
    public interface IOwnerServices
    {
        //Number generator
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getCurrentOwnerCount", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int getCurrentOwnerCount();//This is a helper method

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "generateServProviderNum", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int generateServiceProviderNumber();

        //Getters
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAllOwners", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Owner> getAllOwners();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getOwnerById/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Owner getOwnerById(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getOwnerByAccommoId/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Owner getOwnerByAccommoId(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAllComp", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<OwnersCompany> getAllComp();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getCompById/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        OwnersCompany getCompById(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getCompByOwnerId/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<OwnersCompany> getCompByOwnerId(string id);

        //Insertions
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "insertCompany", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string insertCompany(OwnersCompany comp);

        //Update
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "updateOwner/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        Owner updateOwner(string id, Owner owner);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "updateCompany/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        OwnersCompany updateCompany(string id, OwnersCompany comp);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "changePassword/{id},{oldPassword},{newPassword}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string changePassword(string id, string oldPassword, string newPassword);

        //Deletions
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteOwner/{ownerId}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void deleteOwner(string ownerId);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteCompany/{compId}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void deleteCompany(string compId);
    }
}
