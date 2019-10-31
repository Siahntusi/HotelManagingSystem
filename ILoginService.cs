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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILoginService" in both code and config file together.
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "login?email={email}&password={password}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        BaseUser Login(string email, string password);
    }
}
