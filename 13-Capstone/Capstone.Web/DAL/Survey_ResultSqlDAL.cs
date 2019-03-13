using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class Survey_ResultSqlDAL : ISurvey_ResultSqlDAL
    {
        private const string SQL_GetAllSurveys = "SELECT * FROM survey_result";

        private string connectionString;

        public Survey_ResultSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Survey_Result> GetAllSurveys()
        {
            return null;
        }


    }
}
