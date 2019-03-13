using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAL : IWeatherSqlDAL
    {
        private const string SQL_GetWeather = "SELECT * FROM weather";

        private string connectionString;

        public WeatherSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Weather> GetWeather()
        {
            return null;
        }
    }
}
