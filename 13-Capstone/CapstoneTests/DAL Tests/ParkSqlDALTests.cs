using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;

namespace CapstoneTests.DAL_Tests
{
    [TestClass]
    public class ParkSqlDALTests
    {
        private TransactionScope tran;
        private string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=NPGeek;Integrated Security=True";

        [TestInitialize]
        public void TestInitialize()
        {
            tran = new TransactionScope();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                conn.Open();

                cmd = new SqlCommand("INSERT INTO park (parkCode, parkName, state, acreage, elevationInFeet, milesOfTrail, numberOfCampsites, climate, yearFounded, annualVisitorCount, inspirationalQuote, inspirationalQuoteSource, parkDescription, entryFee, numberOfAnimalSpecies) VALUES ('ABC', 'Test Park National Park', 'Ohio', 100, 1, 10, 0, 'Woodland', 2019, 7, 'To say something inspirational you must be inspired.', 'Nick Paraskos', 'Park Description', 0, 500)", conn);
                cmd.ExecuteNonQuery();
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            tran.Dispose();
        }

        [TestMethod()]
        public void GetAllParksTest()
        {
            ParkSqlDAL parkSqlDAL = new ParkSqlDAL(connectionString);

            List<Park> parks = parkSqlDAL.GetAllParks();

            bool found = false;
            foreach (Park park in parks)
            {
                if (park.Code == "ABC")
                    found = true;
            }

            Assert.AreEqual(true, found, "Park ABC not found in test");
            Assert.IsNotNull(parks);
        }

        [TestMethod()]
        public void GetParkTest()
        {
            ParkSqlDAL parkSqlDAL = new ParkSqlDAL(connectionString);

            Park park = parkSqlDAL.GetPark("ABC");

            Assert.AreEqual("Test Park National Park", park.Name);
            Assert.IsNotNull(park);
        }
    }
}
