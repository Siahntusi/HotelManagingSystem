using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;
using WCF_SERVICE_CLIENT_HOST.Models;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "InspectionSevices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select InspectionSevices.svc or InspectionSevices.svc.cs at the Solution Explorer and start debugging.
    public class InspectionSevices : IInspectionSevices
    {
        private AccreditationServices accreServ = new AccreditationServices();
        //*********************FILE UPLOADS*******************************
        public List<ImageFile> getAllImages()
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    return db.INSPEC_IMAGEs.Select(image => new ImageFile
                    {
                        
                        ImageId = image.IMAGE_ID,
                        CategoryId = image.CATEGORY_ID,
                        ImageName = image.IMAGE_NAME,
                       InspectionId = image.INSPEC_ID,
                        ImageCategory = image.FILE_CATEGORY,
                        ContentType = image.CONTENT_TYPE,
                        FileSize = image.FILE_SIZE,
                        
                        DateUploaded = image.DATE_UPLOADED.ToString(),
                        Location = image.LOCATION
                    }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ImageFile getImageById(string fileId)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    return db.INSPEC_IMAGEs.Where(image => image.IMAGE_ID.Equals(Convert.ToInt32(fileId))).Select(image => new ImageFile
                    {
                        ImageId = image.IMAGE_ID,
                        CategoryId = image.CATEGORY_ID,
                        ImageName = image.IMAGE_NAME,
                        InspectionId = image.INSPEC_ID,
                        ImageCategory = image.FILE_CATEGORY,
                        ContentType = image.CONTENT_TYPE,
                        FileSize = image.FILE_SIZE,
                        
                        DateUploaded = image.DATE_UPLOADED.ToString(),
                        Location = image.LOCATION
                    }).First();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ImageFile> getImagesForAccommo(string inspecId)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    return db.HOTEL_IMAGEs.Where(image => image.IMAGE_ID.Equals(Convert.ToInt32(inspecId))).Select(image => new ImageFile
                    {
                        ImageId = image.IMAGE_ID,
                        ImageName = image.NAME,
                        
                        ImageCategory = image.IMAGE_CATERGORY,
                        ContentType = image.CONTENT_TYPE,
                        FileSize = image.FILE_SIZE,
                       // Data = image.DATA.ToArray(),
                        DateUploaded = image.DATE_UPLOADED.ToString(),
                       
                    }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ImageFile> getImagesByCategory(string category)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    return db.INSPEC_IMAGEs.Where(image => image.CATEGORY_ID.Equals(category)).Select(image => new ImageFile
                    {
                        ImageId = image.IMAGE_ID,
                        CategoryId = image.CATEGORY_ID,
                        ImageName = image.IMAGE_NAME,
                        InspectionId = image.INSPEC_ID,
                        ImageCategory = image.FILE_CATEGORY,
                        ContentType = image.CONTENT_TYPE,
                        FileSize = image.FILE_SIZE,
                        //Data = image.DATA.ToArray(),
                        DateUploaded = image.DATE_UPLOADED.ToString(),
                        Location = image.LOCATION
                    }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ImageFile> getImagesByDate(string dateUploaded)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    return db.INSPEC_IMAGEs.Where(image => image.DATE_UPLOADED.Equals(dateUploaded)).Select(image => new ImageFile
                    {
                        ImageId = image.IMAGE_ID,
                        CategoryId = image.CATEGORY_ID,
                        ImageName = image.IMAGE_NAME,
                        InspectionId = image.INSPEC_ID,
                        ImageCategory = image.FILE_CATEGORY,
                        ContentType = image.CONTENT_TYPE,
                        FileSize = image.FILE_SIZE,
                        //Data = image.DATA.ToArray(),
                        DateUploaded = image.DATE_UPLOADED.ToString(),
                        Location = image.LOCATION
                    }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string saveImage(ImageFile image)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    INSPEC_IMAGE fileToSave = ConvertToLinq.ConvertInspecImageToLinq(image);
                    db.INSPEC_IMAGEs.InsertOnSubmit(fileToSave);
                    db.SubmitChanges();
                }
                return "Success File Uploaded";
            }
            catch (Exception)
            {
                return "Failed Upload Failed";
            }
        }

        public string deleteImage(string id)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    INSPEC_IMAGE fileToDelete = (from file in db.INSPEC_IMAGEs where file.IMAGE_ID.Equals(Convert.ToInt32(id)) select file).Single();
                    db.INSPEC_IMAGEs.DeleteOnSubmit(fileToDelete);
                    db.SubmitChanges();

                    return "Success Deletion successful";
                }
            }
            catch (Exception)
            {
                return "Failed Unable to perform deletion";
            }
        }
        //*********************END FILE UPLOADS*******************************

        //*************************************************************************************************
        //Inspections

        public List<Hotel> getListAccommoByInspecStatus(string inspecStatus)
        {
            List<Hotel> accList = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var innerJoinQuery =
                    from inspec in db.HOTEL_INSPECTIONs
                    where inspec.INSPEC_RESULT.Equals(inspecStatus)
                    join accred_app in db.CYCLE_APPLICATIONs on inspec.APPLICATION_ID equals accred_app.APPLICATION_ID
                    join accommo in db.HOTELs on accred_app.HOTEL_ID equals accommo.HOTEL_ID
                    select new Hotel
                    {
                        HotelID = accommo.HOTEL_ID,
                        HotelName = accommo.NAME,
                        NearestCity = accommo.NEAREST_TOWN,
                        AddressId = accommo.ADDRESS_ID,
                        Distance = (decimal)accommo.DISTANCE_FROM_TOWN,
                        Capacity = accommo.CAPACITY,
                        CycleStatus = accommo.ACCRED_STATUS,
                        StartDate = Convert.ToString(accommo.ACCRED_START_DATE),
                        EndDate = Convert.ToString(accommo.ACCRED_EXPIRY_DATE)
                    };
                    accList = new List<Hotel>();
                    foreach (Hotel acc in innerJoinQuery)
                    {

                        accList.Add(acc);
                    }
                    return accList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ImageFile> getInspeImagesByAccommoId(string accommoId)
        {
            List<ImageFile> fileList = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var innerJoinQuery =
                    from accommo in db.CYCLE_APPLICATIONs
                    where accommo.HOTEL_ID.Equals(Convert.ToInt32(accommoId))
                    join accInspec in db.HOTEL_INSPECTIONs on accommo.APPLICATION_ID equals accInspec.APPLICATION_ID
                    join inspecAddDetail in db.INSPEC_ADD_DETAILs on accInspec.INSPEC_ID equals inspecAddDetail.INSPEC_ID
                    join file in db.INSPEC_IMAGEs on inspecAddDetail.INSPEC_ID equals file.INSPEC_ID
                    select new ImageFile
                    {
                        ImageId = file.IMAGE_ID,
                        InspectionId = file.INSPEC_ID,
                        ImageName = file.IMAGE_NAME,
                        ImageCategory = file.FILE_CATEGORY,
                        ContentType = file.CONTENT_TYPE,
                        FileSize = file.FILE_SIZE,
                        //Data = file.DATA.ToArray(),
                        DateUploaded = file.DATE_UPLOADED.ToString(),
                        Location = file.LOCATION
                    };

                    fileList = new List<ImageFile>();

                    foreach (ImageFile acc in innerJoinQuery)
                    {
                        fileList.Add(acc);
                    }

                    return fileList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        //**************************************************INSPECTION PROCESS**********************************************************************
        public string performInspection(InspectionAdditionalDetails details)
        {
            INSPEC_ADD_DETAIL inspectionLinq = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    //foreach (InspectionAdditionalDetails details in inspectionAddDet)
                    //{
                    inspectionLinq = new INSPEC_ADD_DETAIL()
                    {
                        INSPEC_ID = details.InspecId,
                        QUESTION = details.Question,
                        CORRECTIVE_ACTION = details.CorrectiveAction,
                        ANSWER = details.Answer,
                    };
                    db.INSPEC_ADD_DETAILs.InsertOnSubmit(inspectionLinq);
                    db.SubmitChanges();

                    if (details.InspecImages != null)
                    {
                        foreach (ImageFile image in details.InspecImages)
                        {
                            saveImage(image);
                        }
                        db.SubmitChanges();
                    }
                }

                return "Insertion Successfullllllllllllll";
            }
            //}
            catch (Exception e)
            {
                return e.Message + "hello";
            }
        }

        public string performInspectionJason(string response)
        {
            try
            {
                string result = "";
                var jsonSerializer = new JavaScriptSerializer();

                InspectionAdditionalDetails innerS = new InspectionAdditionalDetails();
                innerS = jsonSerializer.Deserialize<InspectionAdditionalDetails>(response);
                System.Threading.Thread.Sleep(5000);
                result = performInspection(innerS);

                return result + "I am in";
            }
            catch (Exception e)
            {
                return e.Message + "Phulu";
            }
        }

        public string insertQuestions(List<InpecQuestions> inspecQ)
        {
            INSPECTION_QUESTION questionLinq = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {

                    foreach (InpecQuestions question in inspecQ)
                    {
                        questionLinq = new INSPECTION_QUESTION()
                        {
                            CATEGORY_ID = question.CategoryId,
                            QUESTION = question.Question,
                            REQUIRES_PIC = question.RequiresPicture
                        };

                        db.INSPECTION_QUESTIONs.InsertOnSubmit(questionLinq);
                    }
                    db.SubmitChanges();

                    return "Success Insertion Successful";
                }
            }
            catch (Exception)
            {
                return "Failed Insertion Failed";
            }
        }

        public string insertEvaluationComMembers(List<EvaluationCommitte> evalCommitte)
        {
            EVALUATION_COMM comm = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {

                    foreach (EvaluationCommitte person in evalCommitte)
                    {
                        comm = new EVALUATION_COMM()
                        {
                            INSPEC_ID = person.InspecId,
                            IDENTIFICATION = person.Identification,
                            NAME = person.Name,
                            SURNAME = person.Surname,
                            OCCUPATION = person.Occupation,
                            COMPANY = person.Oraganisation
                        };
                        db.EVALUATION_COMMs.InsertOnSubmit(comm);

                    }
                    db.SubmitChanges();
                    return "Success Insertion Successful";
                }
            }
            catch (Exception)
            {
                return "Failed Insertion Failed";
            }
        }

        public string insertCategories(List<Category> cat)
        {
            CATEGORY catLinq = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {

                    foreach (Category category in cat)
                    {
                        catLinq = new CATEGORY()
                        {
                            CATEGORY_NAME = category.CategoryName,
                        };
                        db.CATEGORies.InsertOnSubmit(catLinq);
                    }
                    db.SubmitChanges();

                    return "Success Insertion Successful";
                }
            }
            catch (Exception)
            {
                return "Failed Insertion Failed";
            }
        }

        public string createInspection(HotelInspection inspection)
        {
            HOTEL_INSPECTION inspec = null;
            //ACCRED_APPLICATION appl = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    /*var query = from application in db.ACCRED_APPLICATIONs
                                where application.ACCOMMO_ID.Equals(inspection.AccommoId) &&
                                    application.APPLICATION_ID.Equals(inspection.ApplicationId)
                                select application;

                    appl = new ACCRED_APPLICATION();
                    appl = query.Single();
                   
                    appl.APP_STATUS = "APPROVED";
                    appl.REASON = "CRITERIA MET";
                    db.SubmitChanges();*/

                    inspec = new HOTEL_INSPECTION()
                    {
                        MANAGER_ID = inspection.OfficerId,
                        APPLICATION_ID = inspection.ApplicationId,
                        INSPEC_DATE = DateTime.Now,
                        INSPEC_RESULT = "PENDING"
                    };
                    db.HOTEL_INSPECTIONs.InsertOnSubmit(inspec);
                    db.SubmitChanges();

                    return "Success Insertion Successful";
                }
            }
            catch (Exception)
            {
                return "Failed Insertion Failed";
            }
        }

        public string changeInspecResult(string inspecId, string result)
        {
            HOTEL_INSPECTION inspec = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = from accInspec in db.HOTEL_INSPECTIONs
                                where accInspec.INSPEC_ID.Equals(Convert.ToInt32(inspecId))
                                select accInspec;

                    inspec = query.Single();
                    inspec.INSPEC_RESULT = result;

                    db.SubmitChanges();

                    return "Success Update Successful";
                }
            }
            catch (Exception)
            {
                return "Failed Update Failed";
            }
        }

        public string changeInspecDate(string inspecId, string date)
        {
            HOTEL_INSPECTION inspec = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = from accInspec in db.HOTEL_INSPECTIONs
                                where accInspec.INSPEC_ID.Equals(Convert.ToInt32(inspecId))
                                select accInspec;

                    inspec = query.Single();
                    inspec.INSPEC_DATE = Convert.ToDateTime(date);

                    db.SubmitChanges();

                    return "Success Update Successful";
                }
            }
            catch (Exception)
            {
                return "Failed Update Failed";
            }
        }

        public List<InpecQuestions> getInspecQuestions()
        {
            List<InpecQuestions> quesList = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = from question in db.INSPECTION_QUESTIONs
                                join cat in db.CATEGORies on question.CATEGORY_ID equals cat.CATEGORY_ID
                                select new InpecQuestions
                                {
                                    CategoryId = question.CATEGORY_ID,
                                    
                                    Question = question.QUESTION,
                                    RequiresPicture = question.REQUIRES_PIC,
                                    Category = new Category()
                                    {
                                        CategoryId = cat.CATEGORY_ID,
                                        CategoryName = cat.CATEGORY_NAME
                                    }
                                };

                    quesList = new List<InpecQuestions>();
                    foreach (InpecQuestions acc in query)
                    {
                        quesList.Add(acc);
                    }

                    return quesList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Category> getCategories()
        {
            List<Category> catList = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = from cat in db.CATEGORies
                                select new Category
                                {
                                    CategoryId = cat.CATEGORY_ID,
                                    CategoryName = cat.CATEGORY_NAME
                                };

                    catList = new List<Category>();
                    foreach (Category acc in query)
                    {
                        catList.Add(acc);
                    }

                    return catList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<HotelInspection> getAllInspections()
        {
            List<HotelInspection> catList = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = from accInspec in db.HOTEL_INSPECTIONs
                                select new HotelInspection
                                {
                                    ApplicationId = accInspec.APPLICATION_ID,
                                    OfficerId = accInspec.MANAGER_ID,
                                    InspecId = accInspec.INSPEC_ID,
                                    InspecDate = accInspec.INSPEC_DATE.ToString(),
                                    InspecOutcome = accInspec.INSPEC_RESULT,
                                };

                    catList = new List<HotelInspection>();

                    foreach (HotelInspection acc in query)
                    {
                        catList.Add(acc);
                    }

                    return catList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<HotelInspection> getInspecsByStatus(string inspecStatus)
        {
            List<HotelInspection> catList = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = from accInspec in db.HOTEL_INSPECTIONs
                                where accInspec.INSPEC_RESULT.Equals(inspecStatus.ToUpper())
                                join accApp in db.CYCLE_APPLICATIONs on accInspec.APPLICATION_ID equals accApp.APPLICATION_ID
                                join Acc in db.HOTELs on accApp.HOTEL_ID equals Acc.HOTEL_ID
                                select new HotelInspection
                                {
                                    ApplicationId = accInspec.APPLICATION_ID,
                                    OfficerId = accInspec.MANAGER_ID,
                                    InspecId = accInspec.INSPEC_ID,
                                    InspecDate = accInspec.INSPEC_DATE.ToString(),
                                    InspecOutcome = accInspec.INSPEC_RESULT,


                                    accomodation = new Hotel()
                                    {
                                        HotelName = Acc.NAME,
                                    },
                                    Applications = new CycleApplications()
                                    {
                                        ApplicationDate = accApp.APPLICATION_DATE.ToString(),
                                        ReferenceNumber = accApp.REF_NUM
                                    }

                                };


                    catList = new List<HotelInspection>();
                    foreach (HotelInspection acc in query)
                    {
                        catList.Add(acc);
                    }

                    return catList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<HotelInspection> getInspecsByDate(string date)
        {
            List<HotelInspection> catList = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = from accInspec in db.HOTEL_INSPECTIONs
                                where accInspec.INSPEC_DATE.Equals(Convert.ToDateTime(date.ToString()))
                                select new HotelInspection
                                {
                                    ApplicationId = accInspec.APPLICATION_ID,
                                    OfficerId = accInspec.MANAGER_ID,
                                    InspecId = accInspec.INSPEC_ID,
                                    InspecDate = accInspec.INSPEC_DATE.ToString(),
                                    InspecOutcome = accInspec.INSPEC_RESULT,
                                };

                    catList = new List<HotelInspection>();
                    foreach (HotelInspection acc in query)
                    {
                        catList.Add(acc);
                    }

                    return catList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Work on the inner join when I get home
        public HotelInspection getFullAccommoInspec(string accommoId)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = from acc in db.HOTELs
                                where acc.HOTEL_ID.Equals(Convert.ToInt32(accommoId))
                                join accApp in db.CYCLE_APPLICATIONs on acc.HOTEL_ID equals accApp.HOTEL_ID
                                join accInsp in db.HOTEL_INSPECTIONs on accApp.APPLICATION_ID equals accInsp.APPLICATION_ID
                                join inspDet in db.INSPEC_ADD_DETAILs on accInsp.INSPEC_ID equals inspDet.INSPEC_ID
                                select new HotelInspection
                                {
                                    ApplicationId = accInsp.APPLICATION_ID,
                                    OfficerId = accInsp.MANAGER_ID,
                                    InspecId = accInsp.INSPEC_ID,
                                    InspecDate = accInsp.INSPEC_DATE.ToString(),
                                    InspecOutcome = accInsp.INSPEC_RESULT,
                                };

                    foreach (HotelInspection acc in query)
                    {
                        return acc;
                    }

                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Will implement them when needed
        public string getAccommoInspecDate(string accommoId)
        {
            throw new NotImplementedException();
        }

        public string getAccommoInspecStatus(string accommoId)
        {
            throw new NotImplementedException();
        }


        public string changeInspecResultJason(string inspecId, string result)
        {
            HOTEL_INSPECTION inspec = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var query = from accInspec in db.HOTEL_INSPECTIONs
                                where accInspec.INSPEC_ID.Equals(Convert.ToInt32(inspecId))
                                select accInspec;

                    inspec = query.Single();
                    inspec.INSPEC_RESULT = result;

                    db.SubmitChanges();

                    return "Success Update Successful";
                }
            }
            catch (Exception)
            {
                return "Failed Update Failed";
            }
        }
    }
}
