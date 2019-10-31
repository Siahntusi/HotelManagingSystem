using WCF_SERVICE_CLIENT_HOST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInspectionSevices" in both code and config file together.
    [ServiceContract]
    public interface IInspectionSevices
    {
        //**************************************************INSPECTION PROCESS**********************************************************************
        //Inspection
        //Insertions
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "insertQuestions", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string insertQuestions(List<InpecQuestions> inspecQ);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "insertEvaluationComMembers", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string insertEvaluationComMembers(List<EvaluationCommitte> evalCommitte);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "insertCategories", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string insertCategories(List<Category> cat);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "createInspection", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string createInspection(HotelInspection inspection);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "performInspection", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string performInspection(InspectionAdditionalDetails inspectionAddDet);

        [OperationContract]
        [WebInvoke(Method = "*", UriTemplate = "performInspectionJason/{response}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string performInspectionJason(string response);


       //////////////////////////////login?email={email}&password={password}
        //Update
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "changeInspecResult/{inspecId},{result}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string changeInspecResult(string inspecId, string result);

        [OperationContract]
        [WebInvoke(Method = "*", UriTemplate = "changeInspecResultJason?inspecId={inspecId}&result={result}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string changeInspecResultJason(string inspecId, string result);


        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "changeInspecDate/{inspecId},{date}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string changeInspecDate(string inspecId, string date);

        //Getters
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getInspecQuestions", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<InpecQuestions> getInspecQuestions();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getCategories", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Category> getCategories();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAllInspections", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<HotelInspection> getAllInspections();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getInspecsByStatus/{inspecStatus}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<HotelInspection> getInspecsByStatus(string inspecStatus);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getInspecsByDate/{inspecDate}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<HotelInspection> getInspecsByDate(string inspecDate);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getFullAccommoInspec/{accommoId}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        HotelInspection getFullAccommoInspec(string accommoId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getListAccommoByInspecStatus/{inspecStatus}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Hotel> getListAccommoByInspecStatus(string inspecStatus);


        //Will implement them when needed
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAccommoInspecStatus/{accommoId}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string getAccommoInspecStatus(string accommoId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAccommoInspecDate/{accommoId}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string getAccommoInspecDate(string accommoId);
        
        //**************************************************INSPECTION IMAGES**********************************************************************
        //Images
        //Getters
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAllInspecImages", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<ImageFile> getAllImages();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getInspecImageById/{fileId}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        ImageFile getImageById(string fileId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getInspeImagesByAccommoId/{accommoId}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<ImageFile> getInspeImagesByAccommoId(string accommoId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getInspecImagesForAccommo/{applicationId}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<ImageFile> getImagesForAccommo(string applicationId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getInspecImagesByCat/{category}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<ImageFile> getImagesByCategory(string category);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getInspecImagesByDate/{dateUploaded}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<ImageFile> getImagesByDate(string dateUploaded);

        //Insertions
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "saveInspecImage", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string saveImage(ImageFile image);

        //Deletions
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteInspecImage/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string deleteImage(string id); 
    }
}
