using NUnit.Framework;
using System.Data;
using System.Data.SqlClient;

namespace Core.UnitTest.Test.Actions.DataAccessTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class DataBaseSqlServerAccessTests
    {
        [Test]
        public void GetConnection_WithValidConnectionString_Pass()
        {
            string connectionString = "Server=HN-SD-0966-WK;Database=w33;User Id=admin;Password=1;";

            SqlConnection connection = connectionString.GetConnection();
            connection.State.AreEqual(ConnectionState.Closed);
        }

        [Test]
        public void GetConnection_WithValidConnectionStringBuilder_Pass()
        {
            string connectionString = "Server=HN-SD-0966-WK;Database=w33;User Id=admin;Password=1;";
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);


            SqlConnection connection = connectionStringBuilder.GetConnection();
            connection.State.AreEqual(ConnectionState.Closed);
        }

        [Test]
        public void GetConnection_ExecuteQueryStringSuccessfully_ReturnData()
        {
            string connectionString = "Server=HN-SD-0966-WK;Database=w33;User Id=admin;Password=1;";
            string QueryString = "select * from Student";
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);


            SqlConnection connection = connectionStringBuilder.GetConnection();
            var data = connection.Query(QueryString);
            data.Rows.Count.AreGreaterThan(500);
        }
    }
}
