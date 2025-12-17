using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.DTOs.NewProductDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.NewProductRepositories
{
    public class NewProductRepository(AppDbContext context) : INewProductRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateNewProductDto newProductDto)
        {
            string query = "insert into newProduct (name, ımageUrl, Price) values (@Name, @ImageUrl, @Price)";
            var paramaters = new DynamicParameters(newProductDto);
            await _db.ExecuteAsync(query, paramaters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "delete from newProduct where newProductId=@NewProductId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@NewProductId", id);
            await _db.ExecuteAsync(query, paramaters);
        }

        public async Task<IEnumerable<ResultNewProductDto>> GetAllAsync()
        {
            string query = "select * from newProduct";
            return await _db.QueryAsync<ResultNewProductDto>(query);
        }

        public async Task<UpdateNewProductDto> GetByIdAsync(int id)
        {
            string query = "select * from newProduct where NewProductId=@NewProductId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@NewProductId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateNewProductDto>(query, paramaters);
        }

        public async Task UpdateAsync(UpdateNewProductDto newProductDto)
        {
            var query = "Update newProduct set Name = @Name, ImageUrl = @ImageUrl, Price = @Price where NewProductId=@NewProductId";
            var paramaters = new DynamicParameters(newProductDto);
            await _db.ExecuteAsync(query, paramaters);
        }
    }
}
