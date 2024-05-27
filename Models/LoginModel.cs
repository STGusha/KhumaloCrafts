using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace KhumaloCrafts.Models
{
    public class LoginModel
    {
        public static string con_string = "Server=tcp:khumaloc.database.windows.net,1433;Initial Catalog=KhumaloDatabase;" +
            "Persist Security Info=False;" + "User ID=samgusha;Password=Cara5002#;MultipleActiveResultSets=False;" +
            "Encrypt=True;" + "TrustServerCertificate=False;Connection Timeout=30;";

        public int SelectUser(string email, string username, string password)
        {
            int UserId = -1; // Default value to indicate no user found
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT UserID FROM UserTable WHERE UserEmail = @Email AND userName = @Name AND Password = @Password";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", password);
                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        UserId = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    //System.Diagnostics.Trace.WriteLine(ex.ToString());
                    // For now, rethrow the exception
                    throw ex;
                }
            }
            return UserId;
        }
    }
}
