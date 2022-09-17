using APIEvent.Core.Interfaces;
using APIEvent.Core.Model;
using APIEvent.Core.Model.DTO;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace APIEvent.Core.Service
{
    public class CityEventRepository : ICityEventRepository
    {
        private readonly IConfiguration _configuration;
        public CityEventRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<ActionResult<List<CityEvent>>> GetEventByTitleAsync(string title)
        { 
            
            var query = "SELECT * FROM cityEvent WHERE Title LIKE @Title";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters();
            parameters.Add("@title", $"%{title}%");

            return (await conn.QueryAsync<CityEvent>(query, parameters)).ToList();
        }
        public async Task<ActionResult<List<CityEvent>>> GetEventByLocalAndDateAsync(string local, string date)
        {
            var query = "SELECT * FROM cityEvent WHERE Local=@local AND DateHourEvent=@date";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters();
            parameters.Add("@local", local);
            parameters.Add("@date", date);

            return (await conn.QueryAsync<CityEvent>(query, parameters)).ToList();
        }
        public async Task<ActionResult<List<CityEvent>>> GetEventByDateAndRangeAsync(string date, string initialPrice, string finalPrice)
        {
            var query = "SELECT * FROM cityEvent WHERE Price>=@initialPrice AND Price <= @finalPrice AND DateHourEvent=@date";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters();
            parameters.Add("@initialPrice", initialPrice);
            parameters.Add("@finalPrice", finalPrice);
            parameters.Add("@date", date);

            return (await conn.QueryAsync<CityEvent>(query, parameters)).ToList();
        }
        public async Task<bool> PostEventAsync(CityEventDTO cityEvent)
        {
            var query = "INSERT INTO cityEvent VALUES (@Title, @Description, @DateHourEvent, @Local, @Address, @Price, @Status)";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters(cityEvent);

            return (await conn.ExecuteAsync(query, parameters)) == 1;
        }
        public async Task<bool> UpdateEventAsync(long id, CityEvent cityEvent)
        {
            var query = "Update cityEvent SET Title = @Title, Description = @Description," +
                " DateHourEvent = @DateHourEvent, Local = @Local, Address = @Address, " +
                "Price = @Price, Status = @Status WHERE IdEvent = @IdEvent";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters(cityEvent);
            cityEvent.IdEvent = id;

            return (await conn.ExecuteAsync(query, parameters)) == 1;
        }
        public async Task<bool> DeleteEventAsync(long id)
        {
            var query = "Update cityEvent SET Status = 0 WHERE IdEvent = @IdEvent";
            if (!(await CheckReservationAsync(id)))
            {
                query = "DELETE FROM cityEvent WHERE IdEvent = @IdEvent";
            }
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters();
            parameters.Add("@IdEvent", id);

            return (await conn.ExecuteAsync(query, parameters)) == 1;
        }
        public async Task<bool> CheckReservationAsync(long IdEvent)
        {
            var query = "SELECT * FROM eventReservation WHERE IdEvent = @id";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters();
            parameters.Add("@id", IdEvent);

            return (await conn.ExecuteAsync(query, parameters)) >= 1;
        }
    }
}
