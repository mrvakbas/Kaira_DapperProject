using Kaira.WebUI.Repositories.SellingProductRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents
{
    public class _SellingProductSectionComponentPartial(ISellingProductRepository _sellingProductRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _sellingProductRepository.GetAllAsync();
            return View(value);
        }
    }
}
