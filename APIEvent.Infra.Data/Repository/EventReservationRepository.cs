using APIEvent.Core.Interfaces;
using APIEvent.Core.Model;
using APIEvent.Core.Model.DTO;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace APIEvent.Infra.Data.Repository
{
    public class EventReservationRepository : IEventReservationRepository
    {
        private readonly IConfiguration _configuration;

        public EventReservationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ActionResult<List<ReservationDTO>>> GetReservationAsync(string personName, string title)
        {

            var query = "SELECT * FROM cityEvent AS c JOIN eventReservation AS e " +
                "ON c.IdEvent = e.IdEvent WHERE c.Title Like @title AND e.PersonName = @personName";


            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters();
            parameters.Add("@title", $"%{title}%");
            parameters.Add("@personName", personName);

            return (await conn.QueryAsync<ReservationDTO>(query, parameters)).ToList();
        }

        public async Task<bool> PostReservationAsync(EventReservationDTO eventReservation)
        {
            var query = "INSERT INTO eventReservation VALUES (@PersonName, @Quantity, @IdEvent)";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters(eventReservation);

            return (await conn.ExecuteAsync(query, parameters)) == 1;
        }

        public async Task<bool> UpdateQuantityReservationAsync(long idReservation, long quantity)
        {
            var query = "UPDATE eventReservation SET Quantity = @quantity WHERE IdReservation = @idReservation";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters();
            parameters.Add("@idReservation", idReservation);
            parameters.Add("@quantity", quantity);

            return (await conn.ExecuteAsync(query, parameters)) == 1;
        }

        public async Task<bool> DeleteReservationAsync(long IdReservation)
        {
            var query = "DELETE FROM eventReservation WHERE IdReservation = @id";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters();
            parameters.Add("@id", IdReservation);

            return (await conn.ExecuteAsync(query, parameters)) >= 1;
        }
    }
}
