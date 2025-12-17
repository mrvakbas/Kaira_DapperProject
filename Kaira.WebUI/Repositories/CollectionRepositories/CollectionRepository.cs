using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.DTOs.CollectionDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.CollectionRepositories
{
    public class CollectionRepository(AppDbContext context) : ICollectionRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateCollectionDto collectionDto)
        {
            string query = "insert into collections (ımageUrl, Title, Description) values (@ImageUrl, @Title, @Description)";
            var paramaters = new DynamicParameters(collectionDto);
            await _db.ExecuteAsync(query, paramaters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "delete from collections where CollectionId=@CollectionId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@CollectionId", id);
            await _db.ExecuteAsync(query, paramaters);
        }

        public async Task<IEnumerable<ResultCollectionDto>> GetAllAsync()
        {
            string query = "select * from collections";
            return await _db.QueryAsync<ResultCollectionDto>(query);
        }

        public async Task<UpdateCollectionDto> GetByIdAsync(int id)
        {
            string query = "select * from collections where CollectionId=@CollectionId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@CollectionId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateCollectionDto>(query, paramaters);
        }

        public async Task UpdateAsync(UpdateCollectionDto collectionDto)
        {
            var query = "Update collections set ımageUrl = @ImageUrl, title = @Title, description = @Description where CollectionId=@CollectionId";
            var paramaters = new DynamicParameters(collectionDto);
            await _db.ExecuteAsync(query, paramaters);
        }
    }
}
