using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_SERVICE_CLIENT_HOST.Models
{
    public class ApplicationFile
    {
        public int FileId
        {
            get;
            set;
        }

        public int ApplicationId
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }

        public string FileName
        {
            get;
            set;
        }

        public string FileCategory
        {
            get;
            set;
        }

        public string ContentType
        {
            get;
            set;
        }

        public long FileSize
        {
            get;
            set;
        }

        //public byte[] data
        //{
        //    get;
        //    set;
        //}

        public string DateUploaded
        {
            get;
            set;
        }
    }
}