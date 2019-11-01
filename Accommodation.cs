using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace WCF_SERVICE_CLIENT_HOST.Models
{
    [DataContract]
    public class Accommodation
    {       
        //Basic Details
        private int accommoID;
        private string accommoName;
        private int addressId;
        private decimal distance;
        private string nearestCampus;
        private int capacity;
        private string accredStatus;
        private string startDate;
        private string endDate;
        private int ownerId;
        //
        private Address accommoAddress;
        private AccommodationAddDetails accommoDetails;

        private List<ImageFile> accommoImages;

        [DataMember]
        public int numRatings
        {
            get;
            set;
        }

        [DataMember]
        public int avgAccommoRating
        {
            get;
            set;
        }

        [DataMember]
        public ImageFile AccommoMainImage
        {
            get;
            set;
        }

        [DataMember]
        public List<ImageFile> AccommoImages
        {
            get { return accommoImages; }
            set { accommoImages = value; }
        }

        [DataMember]
        public int OwnerId
        {
            get { return ownerId; }
            set { ownerId = value; }
        }

        [DataMember]
        public string AccommoType
        {
            get;
            set;
        }

        [DataMember]
        public decimal Distance
        {
            get { return distance; }
            set { distance = value; }
        }      

        [DataMember]
        public int AddressId
        {
            get { return addressId; }
            set { addressId = value; }
        }
        [DataMember]
        public string EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        [DataMember]
        public string StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        [DataMember]
        public string AccredStatus
        {
            get { return accredStatus; }
            set { accredStatus = value; }
        }
        [DataMember]
        public AccommodationAddDetails AccommoDetails
        {
            get { return accommoDetails; }
            set { accommoDetails = value; }
        }
        [DataMember]
        public int AccommoID
        {
            get { return accommoID; }
            set { accommoID = value; }

        }
        [DataMember]
        public string AccommoName
        {
            get { return accommoName; }
            set { accommoName = value; }

        }
        [DataMember]
        public Address AccommoAddress
        {
            get { return accommoAddress; }
            set { accommoAddress = value; }
        }
        [DataMember]
        public string NearestCampus
        {
            get { return nearestCampus; }
            set { nearestCampus = value; }
        }
        [DataMember]
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
    }
}