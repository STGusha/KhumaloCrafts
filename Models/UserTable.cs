using System.Data.SqlClient;

namespace KhumaloCrafts.Models
{
    public class UserTable
    {
        public static string con_string = "Server=tcp:khumaloc.database.windows.net,1433;" +
            "Initial Catalog=khumalo-database-cldv;Persist Security Info=False;User ID=samgusha;Password=Cara5002;" +
            "MultipleActiveResultSets=False;Encrypt=True;" +
            "TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection connection = new SqlConnection(con_string);

        // Models are used for constructors
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public int insert_User(UserTable e)
        {
            // inserting user data into a table
            // we dont have user id because it is autoincremented
            string sql = "INSERT INTO UserTable(Name, Surname, Email, Password) " +
                "VALUES('" + e.UserName + "','" + e.UserEmail + "','" + e.Password + "')";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("Name", e.UserName);
            cmd.Parameters.AddWithValue("Email", e.UserEmail);
            cmd.Parameters.AddWithValue("Password", e.Password);
            connection.Open();
            int resultAffected = cmd.ExecuteNonQuery();
            connection.Close();
            return resultAffected;
        }

    }
}
