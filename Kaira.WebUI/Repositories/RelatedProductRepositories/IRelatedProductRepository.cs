using Kaira.WebUI.DTOs.RelatedProductsDtos;

namespace Kaira.WebUI.Repositories.RelatedProductRepositories
{
    public interface IRelatedProductRepository
    {
        Task<IEnumerable<ResultRelatedProductsDto>> GetAllAsync();
        Task<UpdateRelatedProductsDto> GetByIdAsync(int id);
        Task CreateAsync(CreateRelatedProductsDto relatedProductDto);
        Task UpdateAsync(UpdateRelatedProductsDto relatedProductDto);
        Task DeleteAsync(int id);
    }
}
