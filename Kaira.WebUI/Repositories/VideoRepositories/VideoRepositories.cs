using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.DTOs.VideoDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.VideoRepositories
{
    public class VideoRepositories(AppDbContext context) : IVideoRepositories
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateVideoDto videoDto)
        {
            string query = "insert into videos (url, backgroundImageUrl) values (@Url, @BackgroundImageUrl)";
            var paramaters = new DynamicParameters(videoDto);
            await _db.ExecuteAsync(query, paramaters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "delete from videos where VideoId=@VideoId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@VideoId", id);
            await _db.ExecuteAsync(query, paramaters);
        }

        public async Task<IEnumerable<ResultVideoDto>> GetAllAsync()
        {
            string query = "select * from videos";
            return await _db.QueryAsync<ResultVideoDto>(query);
        }

        public async Task<UpdateVideoDto> GetByIdAsync(int id)
        {
            string query = "select * from videos where VideoId=@VideoId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@VideoId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateVideoDto>(query, paramaters);
        }

        public async Task UpdateAsync(UpdateVideoDto videoDto)
        {
            var query = "Update videos set url = @Url, backgroundImageUrl = @BackgroundImageUrl where VideoId=@VideoId";
            var paramaters = new DynamicParameters(videoDto);
            await _db.ExecuteAsync(query, paramaters);

        }
    }
}
