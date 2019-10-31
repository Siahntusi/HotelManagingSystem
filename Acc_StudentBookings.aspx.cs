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
    public partial class Acc_StudentBookings : System.Web.UI.Page
    {
        string OwnrID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            OwnrID = Session["ID"].ToString();

            BookingsServicesClient bookservClnt = new BookingsServicesClient();

            OwnerServicesClient OwnerServClnt = new OwnerServicesClient();

            string AccommodationsList = "";

            AccommoServicesClient accServClnt = new AccommoServicesClient();

            List<Accommodation> MyAccommoList = new List<Accommodation>();
            MyAccommoList = accServClnt.getAccommoByOwnerId(OwnrID.ToString());


            AccommodationsList += "<table class='table table-striped'>";
            //AccommodationsList += "<caption>Accommodations</caption>";
            AccommodationsList += "<tr>";

            AccommodationsList += "<th>" + "Accommodation Name";
            AccommodationsList += "</th>";

            //AccommodationsList += "<th >" + "Address";
            //AccommodationsList += "</th>";

            AccommodationsList += "<th >" + "Capacity ";
            AccommodationsList += "</th>";

            AccommodationsList += "<th >" + "Number of Bookings";
            AccommodationsList += "</th>";

            AccommodationsList += "<th >" + "Remaining Space";
            AccommodationsList += "</th>";

            AccommodationsList += "<th >" + " View Move In Requests";
            AccommodationsList += "</th>";

            AccommodationsList += "<th >" + " View All Bookings";
            AccommodationsList += "</th>";


            AccommodationsList += "</tr>";


            foreach (Accommodation myAccommmo in MyAccommoList)
            {
                int NumBookings = bookservClnt.getNumBookingsByAccommo(myAccommmo.AccommoID.ToString());
                int Remaining = myAccommmo.Capacity - NumBookings;

                AccommodationsList += "<tr>";

                AccommodationsList += "<th>" + myAccommmo.AccommoName;
                AccommodationsList += "</th>";

                //AccommodationsList += "<td>" + myAccommmo.AccommoAddress.Street + " " + myAccommmo.AccommoAddress.Town + " " + myAccommmo.AccommoAddress.City;
                //AccommodationsList += "</td>";

                AccommodationsList += "<td>" + myAccommmo.Capacity;
                AccommodationsList += "</td>";

                AccommodationsList += "<td>" + NumBookings;
                AccommodationsList += "</td>";

                AccommodationsList += "<td>" + Remaining;
                AccommodationsList += "</td>";

                AccommodationsList += "<td>";
                AccommodationsList += "<a class='btn btn-info' style='color: #000;width:80%;' href='Acc_ViewIndiviAccMoveInReq.aspx?AccommID=" + myAccommmo.AccommoID + "'>View</a>";
                AccommodationsList += "</td>";

                AccommodationsList += "<td>";
                AccommodationsList += "<a class='btn btn-info' style='color: #000;width:80%;' href='Acc_ViewIndiviAccommoBookings.aspx?AccommID=" + myAccommmo.AccommoID + "'>View</a>";
                AccommodationsList += "</td>";

                AccommodationsList += "</tr>";
            }
            AccommodationsList += "</Table>";

            AccommoBookingsDiv.InnerHtml = AccommodationsList;

        }
    }
}