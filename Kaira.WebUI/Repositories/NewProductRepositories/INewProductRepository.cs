using Kaira.WebUI.DTOs.NewProductDtos;

namespace Kaira.WebUI.Repositories.NewProductRepositories
{
    public interface INewProductRepository
    {
        Task<IEnumerable<ResultNewProductDto>> GetAllAsync();
        Task<UpdateNewProductDto> GetByIdAsync(int id);
        Task CreateAsync(CreateNewProductDto newProductDto);
        Task UpdateAsync(UpdateNewProductDto newProductDto);
        Task DeleteAsync(int id);
    }
}
