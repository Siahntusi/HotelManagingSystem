using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCF_SERVICE_CLIENT_HOST;
using WCF_SERVICE_CLIENT_HOST.Models;

namespace AAFS
{
    public partial class Acc_ViewIndiviAccommoBookings : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            HotelServicesClient accServClnt = new HotelServicesClient();
            BookingsServicesClient bookingServClnt = new BookingsServicesClient();
            Hotel Accommo = new Hotel();
            string quearyString = Request.QueryString["AccommID"];
            Accommo = accServClnt.getHotelFullInfoById(quearyString);
            List<ClientBooksHotel> studBookList = new List<ClientBooksHotel>();
            bookingServClnt.checkForInvalidBookingsForHotel(quearyString);
            studBookList = bookingServClnt.getAllBookingsMadeToHotel(quearyString);

            lblNAme.Text = Accommo.HotelName + " Student Bookings";

            String AccommodationsList = "";



            if (studBookList != null)
            {
                AccommodationsList += "<table class='table table-striped'>";
                //AccommodationsList += "<caption>Accommodations</caption>";
                AccommodationsList += "<tr>";

                AccommodationsList += "<th>" + "Student Name(s) & Surname";
                AccommodationsList += "</th>";

                AccommodationsList += "<th >" + "Contact Number";
                AccommodationsList += "</th>";

                AccommodationsList += "<th >" + "Date Booked";
                AccommodationsList += "</th>";

                AccommodationsList += "<th >" + "Booking Expiry";
                AccommodationsList += "</th>";

                AccommodationsList += "<th >" + "Funding Type";
                AccommodationsList += "</th>";

                AccommodationsList += "<th >" + "Booking Status";
                AccommodationsList += "</th>";

                AccommodationsList += "</tr>";
            
            foreach (ClientBooksHotel studBook in studBookList)
            {
                AccommodationsList += "<tr>";

                AccommodationsList += "<th>" + studBook.Client.Name + " "+ studBook.Client.Surname;
                AccommodationsList += "</th>";

                AccommodationsList += "<td>" + studBook.Client.ContactNumber;
                AccommodationsList += "</td>";

                AccommodationsList += "<td>" + studBook.TimeStamp;
                AccommodationsList += "</td>";

                AccommodationsList += "<td>" + studBook.BookingDuration;
                AccommodationsList += "</td>";

                AccommodationsList += "<td>" + studBook.Client.FundingType;
                AccommodationsList += "</td>";

                AccommodationsList += "<td>" + studBook.BookingStatus;
                AccommodationsList += "</td>";

                AccommodationsList += "</tr>";
            }
            AccommodationsList += "</Table>";

            
            }
            else
            {
                AccommodationsList += "<p class='alert alert-info'><big><strong>No Bookings</strong></big></p>";
            }
            AccommoStudBookingsDiv.InnerHtml = AccommodationsList;
        }

    }
}