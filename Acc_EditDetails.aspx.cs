using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCF_SERVICE_CLIENT_HOST.Models;
using WCF_SERVICE_CLIENT_HOST;
using AjaxControlToolkit;
using System.IO;

namespace AAFS
{
    public partial class Acc_EditDetails : System.Web.UI.Page
    {
        private string SUB_FOLDER = "Accomm_Images";
        //private string CATEGORY_GENERAL = "GENERAL";
        private string CATEGORY_FRONT = "MAIN";
        private int total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string AccommoId = Request.QueryString["AccommID"];
            Session.Add("AccommodationId", AccommoId);
            AccommoServicesClient accServClnt = new AccommoServicesClient();
            FileUploadsServicesClient imagesClnt = new FileUploadsServicesClient();
            Accommodation accommo = new Accommodation();
            ImageFile imageMain = new ImageFile();

            imageMain = imagesClnt.getMainImageByAccommoId(AccommoId);
            accommo = accServClnt.getAccommoFullInfoById(AccommoId);

            //View Accommo as student
            String strRef = null;
            strRef += "<a class='btn btn-info' style='color: #000' href='ViewIndividualAccommodation.aspx?AccommID=" + accommo.AccommoID + "'>View As Student</a>";
            ahrefdiv.InnerHtml = strRef;


            txtNumBathrooms.Text = (accommo.AccommoDetails.NumBathrooms).ToString();
            txtNumSharing.Text = (accommo.AccommoDetails.NumTwoSharingRooms + accommo.AccommoDetails.NumSharingEnsuite).ToString();
            txtNumSingles.Text = (accommo.AccommoDetails.NumSingleRooms + accommo.AccommoDetails.NumSingleEnsuite).ToString();
            //txtNumSinglEnS.Text = accommo.AccommoDetails.NumSingleEnsuite.ToString();
            //txtNumSharEnS.Text = accommo.AccommoDetails.NumSharingEnsuite.ToString();
            CalcTotalCapacity();
            txtCapacity.Text = total.ToString();

            txtPricSharing.Text = accommo.AccommoDetails.RentSharing.ToString();
            txtPricSingle.Text = accommo.AccommoDetails.RentSingle.ToString();
            drpGender.SelectedItem.Text = accommo.AccommoDetails.GenderAllowed;

            //ProfileImage
            if (imageMain == null)
            {

            }
            if (imageMain != null)
            {
                imgMainPic.ImageUrl = "Accommodations/" + AccommoId + "/Accomm_Images/" + imageMain.ImageName;
            }

            //Features
            if (accommo.AccommoDetails.Gym == 1)
            {
                Gym.Checked = true;
            }
            else { Gym.Checked = false; }
            if (accommo.AccommoDetails.CleaningService == 1)
            {
                Cleaning.Checked = true;
            }
            else { Cleaning.Checked = false; }
            if (accommo.AccommoDetails.WashingMachine == 1)
            {
                Laundry.Checked = true;
            }
            else { Laundry.Checked = false; }
            if (accommo.AccommoDetails.ParkingPort == 1)
            {
                Parking.Checked = true;
            }
            else { Parking.Checked = false; }
            if (accommo.AccommoDetails.WiFi == 1)
            {
                Wifi.Checked = true;
            }
            else { Wifi.Checked = false; }
            if (accommo.AccommoDetails.DSTV == 1)
            {
                TvArea.Checked = true;
            }
            else { TvArea.Checked = false; }
            if (accommo.AccommoDetails.EntertainmentArea == 1)
            {
                EntArea.Checked = true;
            }
            else { EntArea.Checked = false; }
            if (accommo.AccommoDetails.DedicatedStudyArea == 1)
            {
                StudyArea.Checked = true;
            }
            else { StudyArea.Checked = false; }
            if (accommo.AccommoDetails.TransportShuttle == 1)
            {
                TransServ.Checked = true;
            }
            else { TransServ.Checked = false; }
        }

        protected void btnChngeProPic_Click(object sender, EventArgs e)
        {
            FileUploadsServicesClient uploadServClnt = new FileUploadsServicesClient();
            string AccommoId = Request.QueryString["AccommID"];
            ImageFile mainPicture = new ImageFile();
            mainPicture = UploadFile(MainPic, CATEGORY_FRONT, Convert.ToInt32(AccommoId), SUB_FOLDER);

            uploadServClnt.saveImage(mainPicture);
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000);

            AccommoServicesClient accServ = new AccommoServicesClient();
            AccommodationAddDetails addDetails = new AccommodationAddDetails();
            //AddDetails
            addDetails.NumSingleRooms = Convert.ToInt32(txtNumSingles.Text);
            addDetails.NumTwoSharingRooms = Convert.ToInt32(txtNumSharing.Text);
            addDetails.NumBathrooms = Convert.ToInt32(txtNumBathrooms.Text);
            addDetails.RentSingle = Convert.ToDouble(txtPricSingle.Text);
            addDetails.RentSharing = Convert.ToDouble(txtPricSharing.Text);
            addDetails.GenderAllowed = drpGender.SelectedItem.Text;

            //Features
            if (Gym.Checked)
            {
                addDetails.Gym = 1;
            }
            else { addDetails.Gym = 0; }
            if (Cleaning.Checked)
            {
                addDetails.CleaningService = 1;
            }
            else { addDetails.CleaningService = 0; }
            if (Laundry.Checked)
            {
                addDetails.WashingMachine = 1;
            }
            else { addDetails.WashingMachine = 0; }
            if (Parking.Checked)
            {
                addDetails.ParkingPort = 1;
            }
            else { addDetails.ParkingPort = 0; }
            if (Wifi.Checked)
            {
                addDetails.WiFi = 1;
            }
            else { addDetails.WiFi = 0; }
            if (TvArea.Checked)
            {
                addDetails.DSTV = 1;
            }
            else { addDetails.DSTV = 0; }
            if (EntArea.Checked)
            {
                addDetails.EntertainmentArea = 1;
            }
            else { addDetails.EntertainmentArea = 0; }
            if (StudyArea.Checked)
            {
                addDetails.DedicatedStudyArea = 1;
            }
            else { addDetails.DedicatedStudyArea = 0; }
            if (TransServ.Checked)
            {
                addDetails.TransportShuttle = 1;
            }
            else { addDetails.TransportShuttle = 0; }
            AccommodationAddDetails outcome = new AccommodationAddDetails();
            outcome = accServ.updateAccommoAddDetails(Request.QueryString["AccommID"], addDetails);
            if (outcome != null)
            {
                ModalPopupExtenderSuccess.Show();
                System.Threading.Thread.Sleep(2000);
            }
            else if (outcome == null)
            {
                ModalPopupExtenderFailed.Show();
                System.Threading.Thread.Sleep(2000);
            }

        }

        private ImageFile UploadFile(FileUpload fileToUpload, string Cat, int accommoId, string subfolder)
        {
            if (fileToUpload.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(fileToUpload.FileName);
                    string serverLocation = "~/Accommodations/" + accommoId.ToString() + "/" + subfolder + "/" + filename;
                    string SaveLoc = Server.MapPath(serverLocation);
                    int fileSize = fileToUpload.PostedFile.ContentLength;
                    string fileExtention = Path.GetExtension(fileToUpload.FileName);

                    if (fileExtention.ToLower() == ".jpg" || fileExtention.ToLower() == ".png" || fileExtention.ToLower() == ".jpeg" && fileSize <= 15728640)
                    {
                        fileToUpload.SaveAs(SaveLoc);
                        ImageFile file = new ImageFile()
                        {
                            CategoryId = accommoId,
                            ImageName = filename,
                            FileSize = fileSize,
                            Location = "AAFS/AAFS/Accommodations/" + accommoId.ToString() + "/" + subfolder + "/" + filename,
                            ContentType = fileExtention,
                            DateUploaded = DateTime.Now.ToString(),
                            ImageCategory = Cat,
                        };

                        return file;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
                return null;
        }

        protected void txtNumSingles_TextChanged(object sender, EventArgs e)
        {
            bool isVal = false;
            String num = txtNumSingles.Text;

            isVal = checkNumber(num);

            if (isVal == false)
            {
                txtNumSingles.BorderColor = System.Drawing.Color.Red;
            }
            if (isVal == true)
            {
                txtNumSingles.BorderColor = System.Drawing.Color.Green;
                CalcTotalCapacity();
            }
        }

        protected void txtNumSharing_TextChanged(object sender, EventArgs e)
        {
            bool isVal = false;
            String num = txtNumSharing.Text;

            isVal = checkNumber(num);

            if (isVal == false)
            {
                txtNumSharing.BorderColor = System.Drawing.Color.Red;


            }
            if (isVal == true)
            {
                txtNumSharing.BorderColor = System.Drawing.Color.Green;
                CalcTotalCapacity();
            }
        }

        //protected void txtNumSharEnS_TextChanged(object sender, EventArgs e)
        //{
        //    bool isVal = false;
        //    String num = txtNumSharEnS.Text;

        //    isVal = checkNumber(num);

        //    if (isVal == false)
        //    {
        //        txtNumSharEnS.BorderColor = System.Drawing.Color.Red;


        //    }
        //    if (isVal == true)
        //    {
        //        txtNumSharEnS.BorderColor = System.Drawing.Color.Green;
        //        CalcTotalCapacity();
        //    }
        //}

        //protected void txtNumSinglEnS_TextChanged(object sender, EventArgs e)
        //{
        //    bool isVal = false;
        //    String num = txtNumSinglEnS.Text;

        //    isVal = checkNumber(num);

        //    if (isVal == false)
        //    {
        //        txtNumSinglEnS.BorderColor = System.Drawing.Color.Red;


        //    }
        //    if (isVal == true)
        //    {
        //        txtNumSinglEnS.BorderColor = System.Drawing.Color.Green;
        //        CalcTotalCapacity();
        //    }
        //}

        protected void txtCapacity_TextChanged(object sender, EventArgs e)
        {
            bool isVal = false;
            String num = txtCapacity.Text;

            isVal = checkNumber(num);

            if (isVal == false)
            {
                txtCapacity.BorderColor = System.Drawing.Color.Red;


            }
            if (isVal == true)
            {
                txtCapacity.BorderColor = System.Drawing.Color.Green;
                CalcTotalCapacity();
            }
        }

        protected void txtPricSingle_TextChanged(object sender, EventArgs e)
        {
            bool isVal = false;
            String num = txtPricSingle.Text;

            isVal = checkNumber(num);

            if (isVal == false)
            {
                txtPricSingle.BorderColor = System.Drawing.Color.Red;
                CalcTotalCapacity();

            }
            if (isVal == true)
            {
                txtPricSingle.BorderColor = System.Drawing.Color.Green;

            }
        }

        protected void txtPricSharing_TextChanged(object sender, EventArgs e)
        {
            bool isVal = false;
            String num = txtPricSingle.Text;

            isVal = checkNumber(num);

            if (isVal == false)
            {
                txtPricSingle.BorderColor = System.Drawing.Color.Red;
                CalcTotalCapacity();

            }
            if (isVal == true)
            {
                txtPricSingle.BorderColor = System.Drawing.Color.Green;

            }
        }

        protected void txtNumBathrooms_TextChanged(object sender, EventArgs e)
        {
            bool isVal = false;
            String num = txtNumBathrooms.Text;

            isVal = checkNumber(num);

            if (isVal == false)
            {
                txtNumBathrooms.BorderColor = System.Drawing.Color.Red;


            }
            if (isVal == true)
            {
                txtNumBathrooms.BorderColor = System.Drawing.Color.Green;
                CalcTotalCapacity();
            }
        }

        /*   protected void dropCampus_SelectedIndexChanged(object sender, EventArgs e)
           {
               if (dropCampus.SelectedValue == "-1")
               {
                   dropCampus.BorderColor = System.Drawing.Color.Red;

               }
               if (dropCampus.SelectedValue != "-1")
               {

                   dropCampus.BorderColor = System.Drawing.Color.Green;
               }
           }*/

        private void CalcTotalCapacity()
        {
            total =
            convToInt(txtNumSharing.Text) * 2 +
                convToInt(txtNumSingles.Text);
            txtCapacity.Text = total.ToString();
        }
        ////utility
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

        private int convToInt(string numb)
        {
            int result;
            Int32.TryParse(numb, out result);
            return result;
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
    }
}