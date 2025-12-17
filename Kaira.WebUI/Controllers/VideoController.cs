using Kaira.WebUI.DTOs.VideoDtos;
using Kaira.WebUI.Repositories.VideoRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Controllers
{
    public class VideoController(IVideoRepositories _videoRepositories) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var video = await _videoRepositories.GetAllAsync();
            return View(video);
        }

        public IActionResult CreateVideo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(CreateVideoDto createVideoDto)
        {
            await _videoRepositories.CreateAsync(createVideoDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteVideo(int id)
        {
            await _videoRepositories.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateVideo(int id)
        {
            var video = await _videoRepositories.GetByIdAsync(id);
            return View(video);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVideo(UpdateVideoDto updateVideoDto)
        {
            await _videoRepositories.UpdateAsync(updateVideoDto);
            return RedirectToAction("Index");
        }
    }
}
