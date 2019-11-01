using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_SERVICE_CLIENT_HOST.Models
{
    [DataContract]
    public class Booking
    {
        private Student student;
        private Accommodation accommodation;
        private BookingDuration duration;
        private string timeStamp;

        [DataMember(Name = "BookingStatus")]
        public string BookingStatus
        {
            get;
            set;
        }
        
        [DataMember(Name = "TimeStamp")]
        public string TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }

        [DataMember(Name = "Student")]
        public Student Student
        {
            get { return student; }
            set { student = value; }
        }

        [DataMember(Name = "Accommodation")]
        public Accommodation Accommodation
        {
            get { return accommodation; }
            set { accommodation = value; }
        }

                [DataMember(Name = "Duration")]
        public BookingDuration Duration
        {
            get { return duration; }
            set { duration = value; }
        }
    }
}