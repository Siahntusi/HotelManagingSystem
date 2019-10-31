using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AAFS
{
    public partial class Acc_DashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDateNow.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            Response.Redirect("NothingPage.aspx");
        }

        protected void linkMyAccommo_Click(object sender, EventArgs e)
        {
            string ownrId = Session["ID"].ToString();
            Response.Redirect("Acc_MyAccommodations.aspx?OwnrID=" + ownrId);
        }

        protected void linkUpComInspec_Click(object sender, EventArgs e)
        {
            Response.Redirect("Acc_UpComingInspection.aspx");
        }

        protected void linkReports_Click(object sender, EventArgs e)
        {
            Response.Redirect("Acc_GenerelReports.aspx");
        }
    }
}