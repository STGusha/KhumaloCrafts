using System.Data.SqlClient;

namespace KhumaloCrafts.Models
{
    public class Orders // transaction table or order table
    {
        public static string con_string = "Server=tcp:khumaloc.database.windows.net,1433;" +
            "Initial Catalog=khumalo-database-cldv;Persist Security Info=False;User ID=samgusha;Password=Cara5002;" +
            "MultipleActiveResultSets=False;Encrypt=True;" +
            "TrustServerCertificate=False;Connection Timeout=30;";

        public static SqlConnection connection = new SqlConnection(con_string);

        public int OrderID { get; set; }

        public int UserID { get; set; }

        public int ProductID { get; set; }

        public int order_date { get; set; }

        public int total_amount { get; set; }

        public string status { get; set; }

        public int insert_order(Orders o)
        {
            // inserting order data into a table
            // we dont have order id because it is autoincremented
            string sql = "INSERT INTO Orders(UserID, order_date, total_amount) " +
                "VALUES('" + o.UserID + "','" + o.order_date + "','" + o.total_amount + "')";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("UserID", o.UserID);
            cmd.Parameters.AddWithValue("order_date", o.order_date);
            cmd.Parameters.AddWithValue("total_amount", o.total_amount);
            connection.Open();
            int resultAffected = cmd.ExecuteNonQuery();
            connection.Close();
            return resultAffected;
        }   


    }
}
