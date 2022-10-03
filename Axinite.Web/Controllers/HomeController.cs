using Axinite.Web.Areas.Identity.Data;
using Axinite.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace Axinite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _environment;
        public HomeController(DataContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return Redirect("/admin");
            }
            else
            {
                var films = _context.Set<FilmEntity>().ToList();
                return View(films);
            }
        }

        public FileResult Download(string path)
        {
            var bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", path);
        }
    }
}