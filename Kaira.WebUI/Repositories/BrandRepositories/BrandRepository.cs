using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.DTOs.BrandDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.BrandRepositories
{
    public class BrandRepository(AppDbContext context) : IBrandRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateBrandDto brandDto)
        {
            string query = "insert into brands (brandImage) values (@BrandImage)";
            var paramaters = new DynamicParameters(brandDto);
            await _db.ExecuteAsync(query, paramaters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "delete from brands where BrandId=@BrandId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@BrandId", id);
            await _db.ExecuteAsync(query, paramaters);
        }

        public async Task<IEnumerable<ResultBrandDto>> GetAllAsync()
        {
            string query = "select * from brands";
            return await _db.QueryAsync<ResultBrandDto>(query);
        }

        public async Task<UpdateBrandDto> GetByIdAsync(int id)
        {
            string query = "select * from brands where BrandId=@BrandId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@BrandId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateBrandDto>(query, paramaters);
        }

        public async Task UpdateAsync(UpdateBrandDto brandDto)
        {
            var query = "Update brands set brandImage = @BrandImage where BrandId=@BrandId";
            var paramaters = new DynamicParameters(brandDto);
            await _db.ExecuteAsync(query, paramaters);
        }
    }
}
