using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            List<Survey_Result> output = new List<Survey_Result>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL_GetAllSurveys, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Survey_Result sr = new Survey_Result();

                    sr.Id = Convert.ToInt32(reader["surveyId"]);
                    sr.ParkCode = Convert.ToString(reader["parkCode"]);
                    sr.Email = Convert.ToString(reader["emailAddress"]);
                    sr.State = Convert.ToString(reader["state"]);
                    sr.ActivityLevel = Convert.ToString(reader["activityLevel"]);

                    output.Add(sr);
                }
            }

            return output;
        }


    }
}
