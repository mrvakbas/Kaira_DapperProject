using Kaira.WebUI.DTOs.SellingProductDtos;
using Kaira.WebUI.Repositories.SellingProductRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Controllers
{
    public class SellingProductController(ISellingProductRepository _sellingProductRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var sellingProduct = await _sellingProductRepository.GetAllAsync();
            return View(sellingProduct);
        }

        public IActionResult CreateSellingProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSellingProduct(CreateSellingProductDto createSellingProductDto)
        {
            await _sellingProductRepository.CreateAsync(createSellingProductDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteSellingProduct(int id)
        {
            await _sellingProductRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateSellingProduct(int id)
        {
            var sellingProduct = await _sellingProductRepository.GetByIdAsync(id);
            return View(sellingProduct);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSellingProduct(UpdateSellingProductDto updateSellingProductDto)
        {
            await _sellingProductRepository.UpdateAsync(updateSellingProductDto);
            return RedirectToAction("Index");
        }
    }
}
