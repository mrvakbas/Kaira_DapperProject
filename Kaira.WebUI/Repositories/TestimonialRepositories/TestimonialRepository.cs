using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.DTOs.TestimonialDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.TestimonialRepositories
{
    public class TestimonialRepository(AppDbContext context) : ITestimonialRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();

        public async Task CreateAsync(CreateTestimonialDto testimonialDto)
        {
            string query = "insert into testimonials (nameSurname, comment) values (@NameSurname, @Comment)";
            var paramaters = new DynamicParameters(testimonialDto);
            await _db.ExecuteAsync(query, paramaters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "delete from testimonials where TestimonialId=@TestimonialId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@TestimonialId", id);
            await _db.ExecuteAsync(query, paramaters);
        }

        public async Task<IEnumerable<ResultTestimonialDto>> GetAllAsync()
        {
            string query = "select * from testimonials";
            return await _db.QueryAsync<ResultTestimonialDto>(query);
        }

        public async Task<UpdateTestimonialDto> GetByIdAsync(int id)
        {
            string query = "select * from testimonials where TestimonialId=@TestimonialId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@TestimonialId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateTestimonialDto>(query, paramaters);
        }

        public async Task UpdateAsync(UpdateTestimonialDto testimonialDto)
        {
            var query = "Update testimonials set nameSurname = @NameSurname, comment = @Comment where TestimonialId=@TestimonialId";
            var paramaters = new DynamicParameters(testimonialDto);
            await _db.ExecuteAsync(query, paramaters);
        }
    }
}
