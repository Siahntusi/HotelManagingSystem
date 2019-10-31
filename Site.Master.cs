using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCF_SERVICE_CLIENT_HOST.Models;
using WCF_SERVICE_CLIENT_HOST;

namespace AAFS
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((String)Session["Level"] == "S")
            {
                BookingsServicesClient bookSrvClnt = new BookingsServicesClient();
                numBookings.InnerHtml = bookSrvClnt.getNumBookingsByStudent(Session["ID"].ToString()).ToString();
                logout.Visible = true;
                nameStudent.InnerText = (String)Session["Name"];
                StudentSideBar.Visible = true;
                OfficerSideBar.Visible = false;
                OwnerSideBar.Visible = false;
                loginBtn.Visible = false;
                RegBtn.Visible = false;
            }
            else if((String)Session["Level"] == "A")
            {
                logout.Visible = true;
                nameOfficer.InnerText = (String)Session["Name"];
                StudentSideBar.Visible = false;
                OfficerSideBar.Visible = true;
                OwnerSideBar.Visible = false;
                loginBtn.Visible = false;
                RegBtn.Visible = false;
            }
            else if((String)Session["Level"] == "O")
            {
                logout.Visible = true;
                nameOwner.InnerText = (String)Session["Name"];
                StudentSideBar.Visible = false;
                OfficerSideBar.Visible = false;
                OwnerSideBar.Visible = true;
                loginBtn.Visible = false;
                RegBtn.Visible = false;
            }
            else
            {
                logout.Visible = false;
                notificantionBtn.Visible = false;
                //SideBar Stuff
                bookingDiv.Visible = false;
                accountDiv.Visible = false;
                OwnerSideBar.Visible = false;
                OfficerSideBar.Visible = false;
                //end of Sidebar stuff
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            if((String)Session["Level"] != null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }

        protected void linkHome_Click(object sender, EventArgs e)
        {
            if ((String)Session["Level"] != null)
            {
                if ((String)Session["Level"] == "A")
                {
                    Response.Redirect("Off_Dashboard.aspx");
                }
                if ((String)Session["Level"] == "S")
                {
                    Response.Redirect("Home.aspx");
                }
                if ((String)Session["Level"] == "O")
                {
                    Response.Redirect("Acc_Dashboard.aspx");
                }
            }
            else
            {
                Response.Redirect("Home.aspx");
            }


        }

        protected void linkMyAccommo_Click(object sender, EventArgs e)
        {
            string ownrId = Session["ID"].ToString();
            Response.Redirect("Acc_MyAccommodations.aspx?OwnrID=" + ownrId);
        }

        protected void linkAccRpt_Click(object sender, EventArgs e)
        {
            string ownrId = Session["ID"].ToString();
            Response.Redirect("Rpt_Accommos.aspx?OwnrID=" + ownrId);
        }
    }
}