using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using WCF_SERVICE_CLIENT_HOST.Models;

namespace WCF_SERVICE_CLIENT_HOST
{
    public class BookingsServicesClient
    {
        private string BASE_URL = "http://localhost:50706/BookingServices.svc/";

        public string makeAccommoBooking(StudentBooksAccommodation studBooksAccommo)
        {
            string response = null;
            string data = null;
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(StudentBooksAccommodation));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, studBooksAccommo);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(BASE_URL + "makeAccommoBooking", "POST", data);

                return response;
            }
            catch
            {
                return "Couldn't make booking";
            }
        }

        public string moveIn(string studId, string accommoId)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(BASE_URL + "moveIn/" + studId + "," + accommoId, "PUT", "");

                return json;
            }
            catch
            {
                return "";
            }
        }

        public StudentBooksAccommodation getBookingsByStudToAccommo(string studentId, string AccommoId)
        {
            string json = null;
            StudentBooksAccommodation bookings = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getBookingsByStudToAccommo/" + studentId + "," + AccommoId);
                bookings = JsonConvert.DeserializeObject<StudentBooksAccommodation>(json);

                return bookings;
            }
            catch
            {
                return null;
            }
        }


        //Getters

        public int getNumBookingsByAccommo(string accommoId)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getNumBookingsByAccommo/" + accommoId);

                return Convert.ToInt32(json);
            }
            catch
            {
                return -1;
            }
        }

        public void checkForInvalidBookings(string studId)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "checkForInvalidBookings/" + studId);
            }
            catch
            {
                //
            }
        }

        public void checkForInvalidBookingsForAccommo(string studId)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "checkForInvalidBookingsForAccommo/" + studId);
            }
            catch
            {
                //
            }
        }

        public int getNumBookingsByStudent(string studId)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getNumBookingsByStudent/" + studId);

                return Convert.ToInt32(json);
            }
            catch
            {
                return -1;
            }
        }

        public List<StudentBooksAccommodation> getAllBookingsByStatus(string bookingStatus)
        {
            string json = null;
            List<StudentBooksAccommodation> bookings = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getAllBookingsByStatus/" + bookingStatus);
                bookings = JsonConvert.DeserializeObject<List<StudentBooksAccommodation>>(json);

                return bookings;
            }
            catch
            {
                return null;
            }
        }

        public List<StudentBooksAccommodation> getAllBookingsByDate(string bookingDate)
        {
            string json = null;
            List<StudentBooksAccommodation> bookings = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getAllBookingsByDate/" + bookingDate);
                bookings = JsonConvert.DeserializeObject<List<StudentBooksAccommodation>>(json);

                return bookings;
            }
            catch
            {
                return null;
            }
        }

        public List<StudentBooksAccommodation> getAllBookingsByStud(string studentId)
        {
            string json = null;
            List<StudentBooksAccommodation> bookings = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getAllBookingsByStud/" + studentId);
                bookings = JsonConvert.DeserializeObject<List<StudentBooksAccommodation>>(json);

                return bookings;
            }
            catch
            {
                return null;
            }
        }

        public List<StudentBooksAccommodation> getAllBookingsMadeToAccommo(string accommoId)
        {
            string json = null;
            List<StudentBooksAccommodation> bookings = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getAllBookingsMadeToAccommo/" + accommoId);
                bookings = JsonConvert.DeserializeObject<List<StudentBooksAccommodation>>(json);

                return bookings;
            }
            catch
            {
                return null;
            }
        }

        //Updates
        public string updateMoveIn(Booking_Requests bookingMade)
        {
            string json = null;
            string data = null;
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                   typeof(Booking_Requests));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, bookingMade);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(BASE_URL + "updateMoveIn", "PUT", data);

                return json;
            }
            catch
            {
                return "";
            }
        }

        //Deletions      
        public string cancelBooking(string accommoId, string studId)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(BASE_URL + "cancelBooking/" + accommoId + "," + studId, "PUT", "");

                return json;
            }
            catch
            {
                return "";
            }
        }
    }
}
