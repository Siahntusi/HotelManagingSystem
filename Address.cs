using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace WCF_SERVICE_CLIENT_HOST.Models
{
    [DataContract]
    public class Address
    {
        private int addressID;
        private string street;
        private string town;
        private string city;
        private int postalCode;
        private string longitude;
        private string lattitude;
        private string infoUrl;

        [DataMember]
        public string InfoUrl
        {
            get { return infoUrl; }
            set { infoUrl = value; }
        }

        [DataMember]
        public string Lattitude
        {
            get { return lattitude; }
            set { lattitude = value; }
        }

        [DataMember]
        public string Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        [DataMember]
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        [DataMember]
        public string Town
        {
            get { return town; }
            set { town = value; }
        }

        [DataMember]
        public int PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }

        [DataMember]
        public int AddressID
        {
            get { return addressID; }
            set { addressID = value; }
        }

        [DataMember]
        public string Street
        {
            get { return street; }
            set { street = value; }
        }
    }
}