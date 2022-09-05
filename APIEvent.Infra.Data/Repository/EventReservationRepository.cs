using APIEvent.Core.Interfaces;
using APIEvent.Core.Model;
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

        public ActionResult<List<EventReservation>> GetReservation()
        {
            var query = "SELECT * FROM eventReservation";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<EventReservation>(query).ToList();
        }

        public bool PostReservation(long idEvent, EventReservation eventReservation)
        {
            var query = "INSERT INTO eventReservation VALUES (@PersonName, @Quantity, @IdEvent)";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters(eventReservation);
            //eventReservation.IdEvent = idEvent;

            return conn.Execute(query, parameters) == 1;
        }
    }
}
