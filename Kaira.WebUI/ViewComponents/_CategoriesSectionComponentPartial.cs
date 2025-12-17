using Kaira.WebUI.Repositories.CategoryRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents
{
    public class _CategoriesSectionComponentPartial(ICategoryRepository _categoryRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _categoryRepository.GetAllAsync();    
            return View(value);
        }
    }
}
