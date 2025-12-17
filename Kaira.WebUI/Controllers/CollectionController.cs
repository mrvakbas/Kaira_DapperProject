using Kaira.WebUI.DTOs.CollectionDtos;
using Kaira.WebUI.Repositories.CollectionRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Controllers
{
    public class CollectionController(ICollectionRepository _collectionRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var collections = await _collectionRepository.GetAllAsync();
            return View(collections);
        }

        public IActionResult CreateCollection()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCollection(CreateCollectionDto createCollectionDto)
        {
            await _collectionRepository.CreateAsync(createCollectionDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCollection(int id)
        {
            await _collectionRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCollection(int id)
        {
            var collections = await _collectionRepository.GetByIdAsync(id);
            return View(collections);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCollection(UpdateCollectionDto updateCollectionDto)
        {
            await _collectionRepository.UpdateAsync(updateCollectionDto);
            return RedirectToAction("Index");
        }
    }
}
