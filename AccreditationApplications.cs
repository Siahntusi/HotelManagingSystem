using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_SERVICE_CLIENT_HOST.Models
{
    public class AccreditationApplications
    {
        public Accommodation accommo
        {
            set;
            get;
        }

        public List<ApplicationFile> ApplicationFiles
        {
            set;
            get;
        }

        public int ApplicationId
        {
            set;
            get;
        }

        public int AccommoId
        {
            set;
            get;
        }

        public string ApplicationDate
        {
            set;
            get;
        }

        public string ReferenceNumber
        {
            set;
            get;
        }

        public string ApplicationStatus
        {
            set;
            get;
        }

        public string Reason
        {
            set;
            get;
        }
    }
}