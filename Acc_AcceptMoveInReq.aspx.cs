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
    public partial class Acc_AcceptMoveInReq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string querystrAccId = Request.QueryString["AccommID"].ToString();
            string queryStrStd = Request.QueryString["StdId"].ToString();
            BookingsServicesClient bookServ = new BookingsServicesClient();
            Booking_Requests bookReq = new Booking_Requests();
            bookReq.AccommoId = Convert.ToInt32(querystrAccId);
            bookReq.BookingStatus = "APPROVED";
            bookReq.StudId = Convert.ToInt32(queryStrStd);
            string result = bookServ.updateMoveIn(bookReq);

            System.Threading.Thread.Sleep(2000);
            if (result.Contains("Success"))
            {
                Response.Redirect("Acc_ViewIndiviAccMoveInReq.aspx?Reslt=Success");
            }
            if (result.Contains("Failed"))
            {
                Response.Redirect("Acc_ViewIndiviAccMoveInReq.aspx?Reslt=Failed");
            }


        }
    }
}