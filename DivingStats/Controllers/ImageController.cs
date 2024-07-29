using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace DivingStats.Controllers
{
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public ImageController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public ActionResult GetImage(string imageName)
        {
            var imagePath = Path.Combine(_env.WebRootPath, "Images", imageName);
            if (System.IO.File.Exists(imagePath))
            {
                return PhysicalFile(imagePath, "image/jpeg");
            }
            else
            {
                return NotFound(); // or return a 404 error
            }
        }
    }
}