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

        public ActionResult<List<CityEvent>> GetEventByTitle(string title)
        { 
            
            var query = "SELECT * FROM cityEvent WHERE Title LIKE @Title";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters();
            parameters.Add("@title", $"%{title}%");

            return conn.Query<CityEvent>(query, parameters).ToList();


        }

        public ActionResult<List<CityEvent>> GetEventByLocalAndDate(string local, string date)
        {
            var query = "SELECT * FROM cityEvent WHERE Local=@local AND DateHourEvent=@date";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters();
            parameters.Add("@local", local);
            parameters.Add("@date", date);

            return conn.Query<CityEvent>(query, parameters).ToList();
        }

        public ActionResult<List<CityEvent>> GetEventByDateAndRange(string date, string initialPrice, string finalPrice)
        {
            var query = "SELECT * FROM cityEvent WHERE Price>=@initialPrice AND Price <= @finalPrice AND DateHourEvent=@date";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters();
            parameters.Add("@initialPrice", initialPrice);
            parameters.Add("@finalPrice", finalPrice);
            parameters.Add("@date", date);

            return conn.Query<CityEvent>(query, parameters).ToList();
        }

        public bool PostEvent(CityEvent cityEvent)
        {
            var query = "INSERT INTO cityEvent VALUES (@Title, @Description, @DateHourEvent, @Local, @Address, @Price, @Status)";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters(cityEvent);

            return conn.Execute(query, parameters) == 1;
        }

        public bool UpdateEvent(long id, CityEvent cityEvent)
        {
            var query = "Update cityEvent SET Title = @Title, Description = @Description," +
                " DateHourEvent = @DateHourEvent, Local = @Local, Address = @Address, " +
                "Price = @Price, Status = @Status WHERE IdEvent = @IdEvent";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters(cityEvent);
            cityEvent.IdEvent = id;

            return conn.Execute(query, parameters) == 1;
        }
        public bool DeleteEvent(long id)
        {
            var query = "Update cityEvent SET Status = 0 WHERE IdEvent = @IdEvent";
            if (!CheckReservation(id))
            {
                query = "DELETE FROM cityEvent WHERE IdEvent = @IdEvent";
            }
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters();
            parameters.Add("@IdEvent", id);

            return conn.Execute(query, parameters) == 1;
        }

        public bool CheckReservation(long IdEvent)
        {
            var query = "SELECT * FROM eventReservation WHERE IdEvent = @id";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters();
            parameters.Add("@id", IdEvent);

            return conn.Execute(query, parameters) >= 1;
        }
    }
}
