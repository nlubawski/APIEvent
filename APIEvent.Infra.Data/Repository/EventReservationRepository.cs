﻿using APIEvent.Core.Interfaces;
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

        public ActionResult<List<ReservationDTO>> GetReservation(string personName, string title)
        {

            var query = "SELECT * FROM cityEvent AS c JOIN eventReservation AS e " +
                "ON c.IdEvent = e.IdEvent WHERE c.Title Like @title AND e.PersonName = @personName";


            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters();
            parameters.Add("@title", $"%{title}%");
            parameters.Add("@personName", personName);

            return conn.Query<ReservationDTO>(query, parameters).ToList();
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
