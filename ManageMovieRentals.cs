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
    class ManageMovieRentals
    {
        SqlConnection conn = new SqlConnection("Data Source=ABC\\SQLExpress;Initial Catalog=VRS_DB;Integrated Security=True");
        SqlDataReader reader;
        SqlCommand cmd = new SqlCommand();
        string query = "";
        public IEnumerable Defaultview { get; set; }

        public DataTable getRentedMovies()
        {
            DataTable dtRentedMovies = new DataTable();
            try
            {
                cmd.Connection = conn;
                query = "SELECT * FROM RentedMovies Order by RMID DESC";
                cmd.CommandText = query;
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dtRentedMovies.Load(reader);
                }
                return dtRentedMovies;

            }catch(Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
                return null;
            }finally
            {
                if(conn!=null)
                {
                    conn.Close();
                }
                if(reader !=null)
                    {
                    reader.Close();
                }
            }
        }
        public void addRented(int MovieIDFK,int CustIDFK, DateTime dateRented,int copies,int rented)
        {
            try
            {

            cmd.Parameters.Clear();
            cmd.Connection = conn;
            query = "INSERT INTO RentedMovies(MovieIDFK, CustIDFK, DateRented,Rented) VALUES (@MovieIDFK,@CustIDFK,@DateRented,@Rented)";
            cmd.Parameters.AddWithValue("@MovieIDFK", MovieIDFK);
            cmd.Parameters.AddWithValue("@CustIDFK", CustIDFK);
            cmd.Parameters.AddWithValue("@DateRented", dateRented);
            cmd.Parameters.AddWithValue("@Rented", rented);
            cmd.CommandText = query;
            conn.Open();
            cmd.ExecuteNonQuery();
            }catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }

        }
        public void updateRented(int RMID,int MovieID,DateTime dateRented,DateTime dateReturned)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = conn;
                int rentTotal = 0, cost = 0;
                // calculate rent days
                double days = (dateReturned - dateRented).TotalDays;

                string S1 = "SELECT Rental_Cost FROM Movies WHERE MovieID = @MovieIDFK";
                cmd.Parameters.AddWithValue("@MovieIDFK", MovieID);

                cmd.CommandText = S1;
                conn.Open();
                cost = Convert.ToInt32(cmd.ExecuteScalar());
                /*
                 * if movie is rented for 0 days then rent = cost
                 * else rent = days*cost
                 */
                if (Convert.ToInt32(days) == 0)
                {
                    rentTotal = cost;
                }
                else
                {
                    rentTotal =  Convert.ToInt32(days)* cost;
                }

                query = "UPDATE RentedMovies SET DateReturned = @DateReturned WHERE RMID = @RMID";
                cmd.Parameters.AddWithValue("@DateReturned", dateReturned);
                cmd.Parameters.AddWithValue("@RMID", RMID);
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();


                query = "UPDATE Movies SET copies = copies+1 WHERE MovieID = @MovieIDFK";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                query = "UPDATE RentedMovies SET Rented = 0 WHERE RMID = @RMID";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Total Rent is " + rentTotal);



            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception: " + ex.Message);
            }finally
            {
                if(conn!=null)
                {
                    conn.Close();
                }
            }
        }
    }
}
