using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

namespace CapstoneTests.DAL_Tests
{
    [TestClass]
    public class Survey_ResultSqlDALTests
    {
        private TransactionScope tran;
        private string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=NPGeek;Integrated Security=True";

        [TestInitialize]
        public void TestInitialize()
        {
            tran = new TransactionScope();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            tran.Dispose();
        }
    }
}
