using CatApp.Interfaces;
using CatApp.Models;
namespace CatApp.Controllers
{

    public class CatController : Controller
    {
        private readonly ICatService _catService;
        private readonly IConfiguration _configuration;
        public CatController(ICatService catService, IConfiguration configuration)
        {
            _catService = catService;
            _configuration = configuration;
        }
        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> GetCats()
        {
            List<Cat> catUrls = await _catService.GetCatUrls();

            List<string> luckyImages = new();

            int match = int.Parse(_configuration["Match"]);

            int count = int.Parse(_configuration["LimitValue"]);

            Random rnd = new Random();

            for (int i = 0; i < match; i++)
            {
                int randValue = rnd.Next(0, count);
                luckyImages.Add(catUrls[randValue].CatImageUrl);

            }

            return View(luckyImages);
        }

    }
}
