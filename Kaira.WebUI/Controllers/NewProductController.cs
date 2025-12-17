using Kaira.WebUI.DTOs.NewProductDtos;
using Kaira.WebUI.Repositories.NewProductRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Controllers
{
    public class NewProductController(INewProductRepository _newProductRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var newProduct = await _newProductRepository.GetAllAsync();
            return View(newProduct);
        }

        public IActionResult CreateNewProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewProduct(CreateNewProductDto createNewProductDto)
        {
            await _newProductRepository.CreateAsync(createNewProductDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteNewProduct(int id)
        {
            await _newProductRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateNewProduct(int id)
        {
            var newProduct = await _newProductRepository.GetByIdAsync(id);
            return View(newProduct);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNewProduct(UpdateNewProductDto updateNewProductDto)
        {
            await _newProductRepository.UpdateAsync(updateNewProductDto);
            return RedirectToAction("Index");
        }
    }
}
