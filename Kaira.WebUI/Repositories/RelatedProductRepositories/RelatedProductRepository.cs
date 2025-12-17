using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.DTOs.RelatedProductsDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.RelatedProductRepositories
{
    public class RelatedProductRepository(AppDbContext context) : IRelatedProductRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateRelatedProductsDto relatedProductDto)
        {
            string query = "insert into relatedProducts (name, ımageUrl, price) values (@Name, @ImageUrl, @Price)";
            var paramaters = new DynamicParameters(relatedProductDto);
            await _db.ExecuteAsync(query, paramaters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "delete from relatedProducts where RelatedProductId=@RelatedProductId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@RelatedProductId", id);
            await _db.ExecuteAsync(query, paramaters);
        }

        public async Task<IEnumerable<ResultRelatedProductsDto>> GetAllAsync()
        {
            string query = "select * from relatedProducts";
            return await _db.QueryAsync<ResultRelatedProductsDto>(query);
        }

        public async Task<UpdateRelatedProductsDto> GetByIdAsync(int id)
        {
            string query = "select * from relatedProducts where RelatedProductId=@RelatedProductId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@RelatedProductId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateRelatedProductsDto>(query, paramaters);
        }

        public async Task UpdateAsync(UpdateRelatedProductsDto relatedProductDto)
        {
            var query = "Update relatedProducts set name = @Name, ımageUrl = @ImageUrl, price = @Price where RelatedProductId=@RelatedProductId";
            var paramaters = new DynamicParameters(relatedProductDto);
            await _db.ExecuteAsync(query, paramaters);
        }
    }
}
