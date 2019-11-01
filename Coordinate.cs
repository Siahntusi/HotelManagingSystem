using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_SERVICE_CLIENT_HOST.Models
{
    public struct Coordinate
    {
        private double lat; 
        private double lng; 

        public Coordinate(double latitude, double longitude) 
        { 
            lat = latitude; 
            lng = longitude; 
        } 
        public double Latitude { get { return lat; } set { lat = value; } } 
        public double Longitude { get { return lng; } set { lng = value; } } 
    }
}
