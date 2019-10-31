using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_SERVICE_CLIENT;

namespace WFC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRegistrationUser" in both code and config file together.
    [ServiceContract]
    public interface IRegistrationUser
    {
        [OperationContract]
        [WebInvoke(Method = "POST")]
        string RegisterClient(Client client);
    }
}
