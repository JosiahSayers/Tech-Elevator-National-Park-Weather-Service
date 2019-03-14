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
        private const string SQL_GetAllSurveys = "SELECT * FROM survey_result JOIN park on park.parkCode = survey_result.parkCode;";
        private const string SQL_AddResult = "INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@parkCode, @email, @state, @activityLevel);";

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

        public bool AddResult(Survey_Result result)
        {
            bool output;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_AddResult, conn);
                    cmd.Parameters.AddWithValue("@parkCode", result.ParkCode);
                    cmd.Parameters.AddWithValue("@email", result.Email);
                    cmd.Parameters.AddWithValue("@state", result.State);
                    cmd.Parameters.AddWithValue("@activityLevel", result.ActivityLevel);

                    cmd.ExecuteNonQuery();
                }
                output = true;
            }
            catch
            {
                output = false;
            }

            return output;
        }

        public List<KeyValuePair<string, int>> GetTopRankedParks()
        {
            List<Survey_Result> allSurveys = GetAllSurveys();
            //should i make an instance of parksqldal and get the list of parks this way?
            Dictionary<string, int> parks = new Dictionary<string, int>();

            IParkSqlDAL parkDAL = new ParkSqlDAL(connectionString);
                
            List<Park> allParks = parkDAL.GetAllParks();

            foreach (Park item in allParks)
            {
                parks.Add(item.Code, 0);
            }

            foreach (Survey_Result surveyResult in allSurveys)
            {
                parks[surveyResult.ParkCode] += 1;
            }

            List<KeyValuePair<string, int>> output = parks.ToList();

            output.Sort(delegate (KeyValuePair<string, int> pair1, KeyValuePair<string, int> pair2)
            {
                return pair1.Value.CompareTo(pair2.Value);
            });

            output.Reverse();

            return output;
        }
    }
}
