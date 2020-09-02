using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoRentalStore
{
    public class ManageLoginRegister
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-5VOJDGC\\SQLExpress;Initial Catalog=VRS_DB;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        string query = "";

        public bool Login(string username, string password)
        {
            try
            {
                cmd.Connection = conn;
                query = "SELECT user_name, password FROM users WHERE user_name = @user AND password = @pass;";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.CommandText = query;
                conn.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
                return false;
            }
            finally
            {
                if(reader!=null)
                {
                    reader.Close();
                }
                if(conn!=null)
                {
                    conn.Close();
                }
            }
        }
        public bool Register(string username, string password)
        {
            try
            {
                if(Login(username,password))
                {
                    return false;
                }
                else
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT into users(user_name,password) VALUES(@username,@password)";
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }

                
            }catch(Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
                return false;
            }finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
               
            }
        }
        // method for testing  database connection
        public bool CheckDatabaseConnection()
        {
            if(conn.State==System.Data.ConnectionState.Closed)
            {
                conn.Open();

            }
            return true;
        }
        
    }
}
