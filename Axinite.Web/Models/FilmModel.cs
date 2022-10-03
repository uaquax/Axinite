namespace Axinite.Web.Models
{
    public class FilmModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
        public IFormFile Image { get; set; }
    }
}
