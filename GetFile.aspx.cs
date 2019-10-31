using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCF_SERVICE_CLIENT_HOST.Models;

namespace AAFS
{
    public partial class GetFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void downloadFile(ApplicationFile file)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = file.ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + file.FileName);
            //Response.BinaryWrite(file.data);
            Response.Flush();
            Response.End();
        }

        private void downloadImage(ImageFile image)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = image.ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + image.ImageName);
            //Response.BinaryWrite(image.Data);
            Response.Flush();
            Response.End();
        }
    }
}