using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace DebugMvc5601.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpGet]
        private ActionResult publicActionResultUploadFile()
        {
            return View();
        }

        [HttpPost]
        private ActionResult publicActionResultUploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }
    }
}