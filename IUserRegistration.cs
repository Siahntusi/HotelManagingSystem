using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_SERVICE_CLIENT_HOST.Models;
using System.ServiceModel.Web;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserRegistration" in both code and config file together.
    [ServiceContract]
    public interface IUserRegistration
    {
        [OperationContract]
        [WebInvoke(Method="POST", UriTemplate="registerClient",ResponseFormat=
            WebMessageFormat.Json, RequestFormat= WebMessageFormat.Json)]
        string RegisterClient(Client client);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "registerManager", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string RegisterManager(Manager manager);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "registerOwner", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string RegisterOwner(Owner owner);

        [OperationContract]
        [WebInvoke(Method = "*", UriTemplate = "registerClientJason/{client}", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        void RegisterClientJason(string client);

        [OperationContract]
        [WebInvoke(Method = "*", UriTemplate = "registerManagerJason/{manager}", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        void registerManagerJason(string manager);
    }
}
