using Kaira.WebUI.DTOs.SellingProductDtos;

namespace Kaira.WebUI.Repositories.SellingProductRepositories
{
    public interface ISellingProductRepository
    {
        Task<IEnumerable<ResultSellingProductDto>> GetAllAsync();
        Task<UpdateSellingProductDto> GetByIdAsync(int id);
        Task CreateAsync(CreateSellingProductDto sellingProductDto);
        Task UpdateAsync(UpdateSellingProductDto sellingProductDto);
        Task DeleteAsync(int id);
    }
}
