using Axinite.Web.Areas.Identity.Data;
using Axinite.Web.Data;
using Axinite.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Axinite.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _environment;

        public AdminController(DataContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return Redirect("identity/account/login");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,Description,File,Image")] FilmModel film)
        {
            if (User.Identity!.IsAuthenticated)
            {
                string root = _environment.WebRootPath;
                string videoFileName = Path.GetFileName(film!.File!.FileName);
                string videoPath = Path.Combine(root + @"\Films\" + $"{DateTime.Now.ToString("yyMMms")}{videoFileName}");
                
                string imageFileName = Path.GetFileName(film!.Image!.FileName);
                string imagePath = Path.Combine(root + @"\Images\" + $"{DateTime.Now.ToString("yyMMms")}{imageFileName}");


                if (Directory.Exists(root + @"\Films\") == false)
                {
                    Directory.CreateDirectory(root + @"\Films\");
                }
                if (Directory.Exists(root + @"\Images\") == false)
                {
                    Directory.CreateDirectory(root + @"\Images\");
                }

                using (var stream = new FileStream(videoPath, FileMode.Create))
                {
                    await film.File.CopyToAsync(stream);
                }

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await film.Image.CopyToAsync(stream);
                }

                var entity = new FilmEntity()
                {
                    Title = film.Title,
                    Description = film.Description,
                    Path = videoPath,
                    ImagePath = imagePath
                };
                _context.Add(entity);
                _context.SaveChanges();

                return Redirect("/");
            }
            else
            {
                return Redirect("identity/account/login");
            }
        }
    }
}
