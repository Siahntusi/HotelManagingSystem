using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_SERVICE_CLIENT_HOST.Models
{
    [DataContract]
    public class AccommodationInspection
    {
        [DataMember(Name = "Accommodation")]
        public Accommodation accomodation
        {
            set;
            get;
        }

        [DataMember(Name = "AccreditationApplication")]
        public AccreditationApplications Applications
        {
            set;
            get;
        }

        [DataMember(Name = "ListOfInspecDetails")]
        public List<InspectionAdditionalDetails> ListOfInspecDetails
        {
            set;
            get;
        }
        [DataMember(Name = "AccommoId")]

        public int AccommoId
        {
            set;
            get;
        }
        [DataMember(Name = "InspecId")]

        public int InspecId
        {
            set;
            get;
        }
        [DataMember(Name = "OfficerId")]

        public int OfficerId
        {
            set;
            get;
        }
        [DataMember(Name = "ApplicationId")]

        public int ApplicationId
        {
            set;
            get;
        }
        [DataMember(Name = "InspecDate")]

        public string InspecDate
        {
            set;
            get;
        }
                [DataMember(Name = "InspecOutcome")]

        public string InspecOutcome
        {
            set;
            get;
        }
    }
}