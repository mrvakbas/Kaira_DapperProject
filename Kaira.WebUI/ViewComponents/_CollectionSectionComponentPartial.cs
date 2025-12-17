using Kaira.WebUI.Repositories.CollectionRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents
{
    public class _CollectionSectionComponentPartial(ICollectionRepository _collectionRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _collectionRepository.GetAllAsync();
            return View(value); 
        }
    }
}
