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
    public partial class AccMyCompanies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string OwnrID = Session["ID"].ToString();
            OwnerServicesClient ownrServClnt = new OwnerServicesClient();
            List<OwnersCompany> ownrCompList = new List<OwnersCompany>();

            ownrCompList = ownrServClnt.getCompByOwnerId(OwnrID);
             string CompanyList = "";


                CompanyList += "<table class='table table-striped'>";
                //CompanyList += "<caption>Accommodations</caption>";
                CompanyList += "<tr>";

                CompanyList += "<th>" + "Company Name";
                CompanyList += "</th>";

                CompanyList += "<th >" + "Company Registration Number ";
                CompanyList += "</th>";

                CompanyList += "<th >" + "Telephone number";
                CompanyList += "</th>";

                CompanyList += "<th >" + "Email";
                CompanyList += "</th>";

                CompanyList += "<th >" + " Edit Company Details";
                CompanyList += "</th>";

                CompanyList += "</tr>";

                foreach (OwnersCompany myCompany in ownrCompList)
                {
                    CompanyList += "<tr>";

                    CompanyList += "<th>" + myCompany.CompanyName;
                    CompanyList += "</th>";

                    CompanyList += "<td>" + myCompany.RegNum;
                    CompanyList += "</td>";

                    CompanyList += "<td>" + myCompany.ContactNum;
                    CompanyList += "</td>";

                    CompanyList += "<td>" + myCompany.Email;
                    CompanyList += "</td>";

                    CompanyList += "<td>";
                    CompanyList += "<a class='btn btn-info' style='color: #000;width:80%;' href='Acc_EditCompanyDet.aspx?CompID=" + myCompany.CompId + "'>Update</a>";
                    CompanyList += "</td>";

                    CompanyList += "</tr>";

                }
                CompanyList += "</Table>";

                MyCompListDiv.InnerHtml = CompanyList;
            }

        protected void btnAddNewCompany_Click(object sender, EventArgs e)
        {
            Response.Redirect("Acc_AddCompany.aspx");
        }

     
    }
}