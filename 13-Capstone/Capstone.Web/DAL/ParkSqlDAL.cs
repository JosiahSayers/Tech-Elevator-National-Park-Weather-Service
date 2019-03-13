using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAL : IParkSqlDAL
    {
        private const string SQL_GetAllParks = "SELECT * FROM park";

        private string connectionString;

        public ParkSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Park> GetAllParks()
        {
            return null;
        }

        public Park GetPark(string ParkCode)
        {
            return null;
        }
    }
}
