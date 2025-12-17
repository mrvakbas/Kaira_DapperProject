using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.DTOs.SellingProductDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.SellingProductRepositories
{
    public class SellingProductRepository(AppDbContext context) : ISellingProductRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateSellingProductDto sellingProductDto)
        {
            string query = "insert into sellingProduct (name, ımageUrl, Price) values (@Name, @ImageUrl, @Price)";
            var paramaters = new DynamicParameters(sellingProductDto);
            await _db.ExecuteAsync(query, paramaters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "delete from sellingProduct where SellingProductId=@SellingProductId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@SellingProductId", id);
            await _db.ExecuteAsync(query, paramaters);
        }

        public async Task<IEnumerable<ResultSellingProductDto>> GetAllAsync()
        {
            string query = "select * from sellingProduct";
            return await _db.QueryAsync<ResultSellingProductDto>(query);
        }

        public async Task<UpdateSellingProductDto> GetByIdAsync(int id)
        {
            string query = "select * from sellingProduct where SellingProductId=@SellingProductId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@SellingProductId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateSellingProductDto>(query, paramaters);
        }

        public async Task UpdateAsync(UpdateSellingProductDto sellingProductDto)
        {
            var query = "Update sellingProduct set name = @Name, ımageUrl = @ImageUrl, price = @Price where SellingProductId=@SellingProductId";
            var paramaters = new DynamicParameters(sellingProductDto);
            await _db.ExecuteAsync(query, paramaters);
        }
    }
}
