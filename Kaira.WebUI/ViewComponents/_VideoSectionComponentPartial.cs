using Kaira.WebUI.Repositories.VideoRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents
{
    public class _VideoSectionComponentPartial(IVideoRepositories _videoRepositories) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _videoRepositories.GetAllAsync();
            return View(value);
        }
    }
}
