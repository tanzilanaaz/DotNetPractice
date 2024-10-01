using System.Configuration;
using System.Data.SqlClient;

namespace KitchenDALLibrary
{
    public class AdminInfoDAL
    {
        public string kitchenStr;
        public SqlConnection con;
        public AdminInfoDAL()
        {
            kitchenStr = ConfigurationManager.ConnectionStrings["KitchenStoryDB"].ConnectionString;
            con = new SqlConnection(kitchenStr);
        }

        public bool AdminLogin(AdminInfo adminInfo)
        {
            SqlCommand cmd = new SqlCommand("Select Password from Admin where EmailId = @EmailId", con);
            cmd.Parameters.AddWithValue("@EmailId", adminInfo.Email);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string strPassword = reader["Password"].ToString();
                if (strPassword == adminInfo.Password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool UpdatePassword(AdminInfo adminInfo)
        {
            SqlCommand cmd = new SqlCommand("dbo.sp_UpdateAdminPassword", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_Email", adminInfo.Email);
            cmd.Parameters.AddWithValue("@p_Password", adminInfo.Password);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return true;
        }

        public bool ValidateEmail(string EmailId)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Admin WHERE EmailId = @EmailId", con);
            cmd.Parameters.AddWithValue("@EmailId", EmailId);

            con.Open();
            int count = (int)cmd.ExecuteScalar();
            con.Close();

            return count > 0;
        }
    }

}

