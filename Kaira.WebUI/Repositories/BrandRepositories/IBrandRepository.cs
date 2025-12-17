using Kaira.WebUI.DTOs.BrandDtos;

namespace Kaira.WebUI.Repositories.BrandRepositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<ResultBrandDto>> GetAllAsync();
        Task<UpdateBrandDto> GetByIdAsync(int id);
        Task CreateAsync(CreateBrandDto brandDto);
        Task UpdateAsync(UpdateBrandDto brandDto);
        Task DeleteAsync(int id);
    }
}
