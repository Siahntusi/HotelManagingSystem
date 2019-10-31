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
    public partial class MA_AssignAccommos : System.Web.UI.Page
    {
        OfficerServicesClient offServ = null;
        string OfficerId = null;
        Officer assgnOfficer = null;
        int AccoId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            offServ = new OfficerServicesClient();
            OfficerId = Request.QueryString["OffID"].ToString();
            AccoId = Convert.ToInt32(Request.QueryString["AccommID"]);
            assgnOfficer = offServ.getOffficerById(OfficerId);
            AccommoServicesClient accServ = new AccommoServicesClient();
            Accommodation acc = accServ.getAccommoFullInfoById(AccoId.ToString());


            //Accommodation  
            lblAccName.Text = acc.AccommoName;
            lblAccAddress.Text = acc.AccommoAddress.Street + " " + acc.AccommoAddress.Town + " " + acc.AccommoAddress.Town;


            //Officer
            lblNameSurname.Text = assgnOfficer.Surname + " " + assgnOfficer.Name;
            lblTele.Text = assgnOfficer.ContactNumber;
            lblEmail.Text = assgnOfficer.Email;
            if (assgnOfficer.CampusId == 2)
            {
                lblCampus.Text = "APK";
            }
            else if (assgnOfficer.CampusId == 3)
            {
                lblCampus.Text = "APB";
            }
            else if (assgnOfficer.CampusId == 4)
            {
                lblCampus.Text = "DFC";
            }
            else if (assgnOfficer.CampusId == 5)
            {
                lblCampus.Text = "SWC";
            }


        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000);
            offServ = new OfficerServicesClient();

            OfficerHandlesAccommo offHandlsAcc = new OfficerHandlesAccommo();
            offHandlsAcc.OfficerID = assgnOfficer.ID;
            offHandlsAcc.AccommoID = AccoId;
            offHandlsAcc.AssignDate = DateTime.Now.ToString();


            string outcome = offServ.assignAccommodations(offHandlsAcc);
            if (outcome.Contains("Success"))
            {
                ModalPopupExtenderSuccess.Show();
                System.Threading.Thread.Sleep(2000);
            }
            else if (outcome.Contains("Failed"))
            {
                ModalPopupExtenderFailed.Show();
                System.Threading.Thread.Sleep(2000);
            }


        }
    }
}