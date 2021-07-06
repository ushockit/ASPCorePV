using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeyRed.Mime;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace WebApplication2.Controllers
{
    public class FileController : Controller
    {
        IWebHostEnvironment _webHostEnvironment;
        public FileController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Download()
        {
            string filename = "1625587790463,8186free_PNG90743.png";
            string path = Path.Combine(_webHostEnvironment.WebRootPath, $"UploadFiles/{filename}");
            string mime = MimeTypesMap.GetMimeType(path);
            var fs = new FileStream(path, FileMode.Open);
            return File(fs, mime, filename);
        }
    }
}
