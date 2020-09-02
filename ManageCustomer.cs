using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoRentalStore
{
    class ManagerCustomer
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-5VOJDGC\\SQLExpress; Initial Catalog = VRS_DB; Integrated Security = True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        string query;

        public IEnumerable View { get; set; }

        public DataTable getCustomers()
        {
            DataTable dtCustomers = new DataTable();
            try
            {
                cmd.Connection = conn;
                query = "SELECT * from Customer";
                cmd.CommandText = query;
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dtCustomers.Load(reader);
                }
                return dtCustomers;

            } catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
                return null;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public void addNewCustomer(string firstname, string lastname, string address, string phone)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = conn;
                query = "INSERT INTO Customer(FirstName,LastName,Address,Phone) VALUES (@fname,@lname,@addr,@phone)";
                cmd.Parameters.AddWithValue("@fname", firstname);
                cmd.Parameters.AddWithValue("@lname", lastname);
                cmd.Parameters.AddWithValue("@addr", address);
                cmd.Parameters.AddWithValue("@phone", phone);

                cmd.CommandText = query;

                conn.Open();
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
        public void deleteCustomer(int id)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = conn;
                query = "SELECT Count(*) FROM RentedMovies WHERE CustIDFK=@custid";
                cmd.Parameters.AddWithValue("@custid", id);
                cmd.CommandText = query;
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if(count==0)
                {
                    query = "DELETE FROM Customer WHERE CustID = @custid";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }else
                {
                    MessageBox.Show("Customer cannot be deleted. customer has rented a movie. first take movie from him", "Problem");
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            finally
            {
                if(conn!=null)
                {
                    conn.Close();
                }
             
            }
        }
        public void UpdateCustomer(int CustID, string FirstName, string LastName, string Address, string Phone)
        {
            //This method updates customer
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = conn;
                query = "Update Coustmer Set FirstName = @FirstName, LastName = @LastName, Address = @Address, Phone = @Phone where CustID = @CustID";


                cmd.Parameters.AddWithValue("@CustID", CustID);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Phone", Phone);

                cmd.CommandText = query;

                //connection opened
                conn.Open();

                // Executed query
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

    }

}
