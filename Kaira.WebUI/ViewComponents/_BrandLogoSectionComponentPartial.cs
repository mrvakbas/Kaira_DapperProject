
using Kaira.WebUI.Repositories.BrandRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents
{
    public class _BrandLogoSectionComponentPartial(IBrandRepository _brandRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _brandRepository.GetAllAsync();
            return View(value);
        }
      
    }
}
