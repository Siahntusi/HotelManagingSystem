using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCF_SERVICE_CLIENT_HOST.Models
{
    [DataContract]
    public class AccommodationAddDetails
    {
        //Room types
        private int numSingleRooms;
        private int numTwoSharingRooms;
        private double rentSingle;
        private double rentSharing;
        private string roomType;
        private int numSingleEnsuite;
        private int numSharingEnsuite;

        //Restrooms
        private int numBathrooms;

        //Safety&Security
        /**Level is determined by a certain criteria*/
        private int securityLevel;
        private string safetyLevel;

        //Additional Accommodation Details
        private string genderAllowed;

        private int cleaningService;
        private int parkingPort;
        private int gym;
        private int washingMachine;
        private int wiFi;
        private int dSTV;
        private int dedicatedStudyArea;
        private int entertainmentArea;
        
        private  int transportShuttle;

        [DataMember]
        public int AccommoId
        {
            get;
            set;
        }

        [DataMember]
        public int TransportShuttle
        {
            get { return transportShuttle; }
            set { transportShuttle = value; }
        }
        [DataMember]
        public string RoomType
        {
            get { return roomType; }
            set { roomType = value; }
        }
        [DataMember]
        public int NumSingleEnsuite
        {
            get { return numSingleEnsuite; }
            set { numSingleEnsuite = value; }
        }
        [DataMember]
        public int NumSharingEnsuite
        {
            get { return numSharingEnsuite; }
            set { numSharingEnsuite = value; }
        }

        [DataMember]
        public int EntertainmentArea
        {
            get { return entertainmentArea; }
            set { entertainmentArea = value; }
        }

        [DataMember]
        public int NumSingleRooms
        {
            get { return numSingleRooms; }
            set { numSingleRooms = value; }
        }
        [DataMember]
        public int NumTwoSharingRooms
        {
            get { return numTwoSharingRooms; }
            set { numTwoSharingRooms = value; }
        }
        [DataMember]
        public double RentSingle
        {
            get { return rentSingle; }
            set { rentSingle = value; }
        }
        [DataMember]
        public double RentSharing
        {
            get { return rentSharing; }
            set { rentSharing = value; }
        }
        [DataMember]
        public int NumBathrooms
        {

            get { return numBathrooms; }
            set { numBathrooms = value; }
        }
        [DataMember]
        public int SecurityLevel
        {

            get { return securityLevel; }
            set { securityLevel = value; }
        }
        public string SafetyLevel
        {
            get { return safetyLevel; }
            set { safetyLevel = value; }
        }

        [DataMember]
        public string GenderAllowed
        {
            get { return genderAllowed; }
            set { genderAllowed = value; }
        }
        [DataMember]
        public int CleaningService
        {
            get { return cleaningService; }
            set { cleaningService = value; }
        }

        [DataMember]
        public int ParkingPort
        {
            get { return parkingPort; }
            set { parkingPort = value; }
        }

        [DataMember]
        public int Gym
        {

            get { return gym; }
            set { gym = value; }

        }

        [DataMember]
        public int WashingMachine
        {
            get { return washingMachine; }
            set { washingMachine = value; }
        }

        [DataMember]
        public int WiFi
        {
            get { return wiFi; }
            set { wiFi = value; }
        }

        [DataMember]
        public int DSTV
        {
            get { return dSTV; }
            set { dSTV = value; }
        }
        [DataMember]
        public int DedicatedStudyArea
        {

            get { return dedicatedStudyArea; }
            set { dedicatedStudyArea = value; }
        }
    }
}