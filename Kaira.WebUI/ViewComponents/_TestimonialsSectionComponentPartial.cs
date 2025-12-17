using Kaira.WebUI.Repositories.TestimonialRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents
{
    public class _TestimonialsSectionComponentPartial(ITestimonialRepository _testimonialRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _testimonialRepository.GetAllAsync();
            return View(value);
        }
    }
}
