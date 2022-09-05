﻿using APIEvent.Core.Interfaces;
using APIEvent.Core.Model;
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

        public ActionResult<List<CityEvent>> GetEvent()
        {
            var query = "SELECT * FROM cityEvent";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<CityEvent>(query).ToList();
        }

        public bool PostEvent(CityEvent cityEvent)
        {
 
            var query = "INSERT INTO cityEvent VALUES (@Title, @Description, @DateHourEvent, @Local, @Address, @Price)";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters(cityEvent);

            return conn.Execute(query, parameters) == 1;
        }
    }
}
