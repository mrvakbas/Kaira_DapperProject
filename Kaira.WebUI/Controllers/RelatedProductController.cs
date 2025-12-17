using Kaira.WebUI.DTOs.RelatedProductsDtos;
using Kaira.WebUI.Repositories.RelatedProductRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Controllers
{
    public class RelatedProductController(IRelatedProductRepository _relatedProductRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var relatedProduct = await _relatedProductRepository.GetAllAsync();
            return View(relatedProduct);
        }

        public IActionResult CreateRelatedProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRelatedProduct(CreateRelatedProductsDto createRelatedProductDto)
        {
            await _relatedProductRepository.CreateAsync(createRelatedProductDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteRelatedProduct(int id)
        {
            await _relatedProductRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateRelatedProduct(int id)
        {
            var relatedProduct = await _relatedProductRepository.GetByIdAsync(id);
            return View(relatedProduct);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRelatedProduct(UpdateRelatedProductsDto updateRelatedProductDto)
        {
            await _relatedProductRepository.UpdateAsync(updateRelatedProductDto);
            return RedirectToAction("Index");
        }
    }
}
