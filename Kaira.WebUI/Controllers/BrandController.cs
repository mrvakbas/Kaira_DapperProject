using Kaira.WebUI.Repositories.BrandRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Controllers
{
    public class BrandController(IBrandRepository _brandRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var brand = await _brandRepository.GetAllAsync();
            return View(brand);
        }
    }
}
