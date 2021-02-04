using System.Data;
using System.Data.SqlClient;


public static class DatabaseSqlServerAccess
{

    public static SqlConnection GetConnection(this SqlConnectionStringBuilder sqlConnectionStringBuilder)
    {
        SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

        return connection;
    }
    public static SqlConnection GetConnection(this string connectionString)
    {
        SqlConnection connection = new SqlConnection(connectionString);

        return connection;
    }

    public static DataTable Query(this SqlConnection connection, string queryString)
    {
        DataTable result;
        DataSet ds;

        using (SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection))
        {
            ds = new DataSet();
            adapter.Fill(ds);
        }

        result = ds.Tables[0];
        return result;
    }
}
