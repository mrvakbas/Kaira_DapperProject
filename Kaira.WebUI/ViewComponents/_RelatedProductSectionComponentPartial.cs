using Kaira.WebUI.Repositories.RelatedProductRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents
{
    public class _RelatedProductSectionComponentPartial(IRelatedProductRepository _relatedProductRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _relatedProductRepository.GetAllAsync();
            return View(value);
        }
    }
}
