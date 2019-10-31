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
    public partial class Acc_AddCompany : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Page.Validate();
            }
        }


        protected void txtCompName_TextChanged(object sender, EventArgs e)
        {
            bool isVal = checkString(txtCompName.Text);
            if (isVal == false)
            {

                txtCompName.BorderColor = System.Drawing.Color.Red;
            }
            if (isVal == true)
            {
                txtCompName.BorderColor = System.Drawing.Color.Green;
            }
        }

        protected void txtCompRegNo_TextChanged(object sender, EventArgs e)
        {
            bool isVal = checkString(txtCompRegNo.Text);
            if (isVal == false)
            {

                txtCompRegNo.BorderColor = System.Drawing.Color.Red;
            }
            if (isVal == true)
            {
                txtCompRegNo.BorderColor = System.Drawing.Color.Green;
            }

        }

        protected void txtTeleNo_TextChanged(object sender, EventArgs e)
        {
            String telephone = txtTeleNo.Text;
            bool isVal = checkNumber(telephone);
            if (isVal == false)
            {

                txtTeleNo.BorderColor = System.Drawing.Color.Red;

            }
            if (isVal == true)
            {
                txtTeleNo.BorderColor = System.Drawing.Color.Green;

            }
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            String emailvalue = txtEmail.Text;
            bool emailIsval = isValidEmail(emailvalue);
            if (emailIsval == false)
            {
                txtEmail.BorderColor = System.Drawing.Color.Red;

            }
            if (emailIsval == true)
            {
                txtEmail.BorderColor = System.Drawing.Color.Green;

            }
        }

        private bool isValidEmail(String email)
        {
            string emailReg = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            if (email != null)
            {
                return System.Text.RegularExpressions.Regex.IsMatch(email, emailReg);
            }
            else
            {
                return false;
            }
        }


        private bool checkNumber(String input)
        {
            int result;
            if (Int32.TryParse(input, out result))
            {

                return true;
            }
            else
            {

                return false;
            }
        }

        private bool checkString(String input, int len)
        {
            bool isVal = false;

            if (input.Length < len)
            {

                isVal = false;

            }
            else if (input.Length > len)
            {


                isVal = true;
            }
            return isVal;
        }

        private bool checkString(String input)
        {
            bool isVal = false;

            if (input == "")
            {

                isVal = false;

            }
            else if (input != "")
            {


                isVal = true;
            }
            return isVal;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000);
            OwnerServicesClient oServ = new OwnerServicesClient();
            OwnersCompany comp = new OwnersCompany()
            {
                OwnerId = Convert.ToInt32(Session["ID"]),
                CompanyName = txtCompName.Text,
                ContactNum = txtTeleNo.Text,
                Email = txtEmail.Text,
                RegNum = txtCompRegNo.Text
            };
            string outcome = oServ.insertCompany(comp);
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