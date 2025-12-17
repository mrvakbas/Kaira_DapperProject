using Kaira.WebUI.Repositories.NewProductRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents
{
    public class _NewProductSectionComponentPartial(INewProductRepository _newProductRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _newProductRepository.GetAllAsync(); 
            return View(value); 
        }
    }
}
