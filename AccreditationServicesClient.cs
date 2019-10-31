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
    public class AccreditationServicesClient
    {
        private string BASE_URL = "http://localhost:50706/AccreditationServices.svc/";
        //Insertions
        public int applyForAccred(AccreditationApplications application)
        {
            string response = null;
            string data = null;
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(AccreditationApplications));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, application);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(BASE_URL + "applyForAccred" , "POST", data);

                return Convert.ToInt32(response);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //Updates   
        public string updateAccredApplication(AccreditationApplications application)
        {
            string response = "";
            string data = null;
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                   typeof(AccreditationApplications));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, application);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(BASE_URL + "updateAccredApplication", "PUT", data);

                return response;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string accreditAccommo(string accommoId)
        {
            string response = "";
            //string data = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(BASE_URL + "accreditAccommo/" + accommoId, "PUT", "");

                return response;
            }
            catch (Exception)
            {
                return "";
            }
        }

        //Getters
        
        public List<AccreditationApplications> getAllAccredApplications()
        {
            string json = null;
            List<AccreditationApplications> acc = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getAllAccredApplications");
                acc = JsonConvert.DeserializeObject<List<AccreditationApplications>>(json);

                return acc;
            }
            catch
            {
                return null;
            }
        }

        public string getAccreditStatus(string accommoId)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getAccreditStatus/" + accommoId);

                return json;
            }
            catch
            {
                return "";
            }
        }

        public int getApplicationByStatus(string status)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getAccreditStatus/" + status);

                return Convert.ToInt32( json);
            }
            catch
            {
                return -1;
            }
        }
        public List<AccreditationApplications> getAcredApplicationByStatus(string status)
        {
            string json = null;
            List<AccreditationApplications> acc = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getAcredApplicationByStatus/" + status);
                acc = JsonConvert.DeserializeObject<List<AccreditationApplications>>(json);

                return acc;
            }
            catch
            {
                return null;
            }
        }

        public AccreditationApplications getApplicationDetailsByRefNum(string refNum)
        {
            string json = null;
            AccreditationApplications acc = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getApplicationDetailsByRefNum/" + refNum);
                acc = JsonConvert.DeserializeObject<AccreditationApplications>(json);

                return acc;
            }
            catch
            {
                return null;
            }
        }

        public AccreditationApplications getAccreditDetails(string accommoId)
        {
            string json = null;
            AccreditationApplications acc = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getAccreditDetails/" + accommoId);
                acc = JsonConvert.DeserializeObject<AccreditationApplications>(json);

                return acc;
            }
            catch
            {
                return null;
            }
        }

        //Deletions
        public string cancelAccredit(string accommoId)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(BASE_URL + "cancelAccredit/" + accommoId, "PUT", "");

                return json;
            }
            catch
            {
                return "";
            }
        }
    }
}
