using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.DTOs.CategoryDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.CategoryRepositories
{
    public class CategoryRepository(AppDbContext context) : ICategoryRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateCategoryDto categoryDto)
        {
            string query = "insert into categories (name, categoryImage) values (@Name, @CategoryImage)";
            var paramaters = new DynamicParameters(categoryDto);
            await _db.ExecuteAsync(query, paramaters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "delete from categories where CategoryId=@CategoryId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@CategoryId", id);
            await _db.ExecuteAsync(query, paramaters);
        }

        public async Task<IEnumerable<ResultCategoryDto>> GetAllAsync()
        {
            string query = "select * from categories";
            return await _db.QueryAsync<ResultCategoryDto>(query);
        }

        public async Task<UpdateCategoryDto> GetByIdAsync(int id)
        {
            string query = "select * from categories where CategoryId=@CategoryId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@CategoryId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateCategoryDto>(query, paramaters);
        }

        public async Task UpdateAsync(UpdateCategoryDto categoryDto)
        {
            var query = "Update categories set name = @Name, categoryImage = @CategoryImage where CategoryId=@CategoryId";
            var paramaters = new DynamicParameters(categoryDto);
            await _db.ExecuteAsync(query, paramaters);
        }
    }
}
