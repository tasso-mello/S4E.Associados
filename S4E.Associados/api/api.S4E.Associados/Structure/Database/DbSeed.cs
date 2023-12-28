namespace api.S4E.Associados.Structure.Database
{
    using domain.S4E.Associados.Queries;
    using Microsoft.Data.SqlClient;

    public class DbSeed
    {
        public static void AddDatabase(string connection)
            => CreateDataBase(connection);

        private static void CreateDataBase(string connection)
        {
            var myConn = new SqlConnection(connection);

            SqlCommand myCommand = new SqlCommand(Queries.CreateDatabase(), myConn);

            myConn.Open();
            myCommand.ExecuteNonQuery();
            myConn.Close();
        }
    }
}
