using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCF_SERVICE_CLIENT
{
    [DataContract]
    class Manager : BaseUser
    {
        private int employeeNumber;

        [DataMember(Name = "EmployeeNumber")]
        public int EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
        }
    }
}
