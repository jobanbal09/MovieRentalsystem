using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalSystem
{
   public  class Database
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["VideoRentalDB"].ConnectionString);
       

        public DataTable GetAllCustomer()
        {
            DataTable dt = new DataTable();
            try
            {
                
                using (SqlCommand cmd = new SqlCommand("spGetAllCustomer", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {


                        da.Fill(dt);
                    }
                }
                return dt;
            }
            catch
            {
                return dt;
            }
        }
        public int InsertCustomer(string firstName, string lastname, string address,string mobileNo)
        {
          
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("insert into Customer(FirstName,LastName,Address,Phone)values(@FirstName,@LastName,@Address,@Phone)", sqlcon))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastname);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Phone", mobileNo);

                    cmd.ExecuteNonQuery();
                    
                }
                sqlcon.Close();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int UpdateCustomer(string firstName, string lastname, string address, string mobileNo,int custId)
        {

            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("update Customer set FirstName=@FirstName,LastName=@LastName,Address=@Address,Phone=@Phone  where CustId=@CustId", sqlcon))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastname);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Phone", mobileNo);
                    cmd.Parameters.AddWithValue("@CustId", custId);
                  
                    cmd.ExecuteNonQuery();

                }
                sqlcon.Close();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int DeleteCustomer(int custId)
        {

            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("delete from Customer where CustId=@CustId", sqlcon))
                {
                    cmd.Parameters.AddWithValue("@CustId", custId);
                   
                    cmd.ExecuteNonQuery();

                }
                sqlcon.Close();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public DataTable GetAllVideo()
        {
            DataTable dt = new DataTable();
            try
            {

                using (SqlCommand cmd = new SqlCommand("select * from Movie", sqlcon))
                {
                   
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                return dt;
            }
            catch
            {
                return dt;
            }
        }
        public int InsertVideo(string title, DateTime releaseDate, decimal cost, string genre,string plot)
        {

            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("insert into Movie(Title,ReleaseDate,RentalCost,Genre,Plot,Available)values(@Title,@ReleaseDate,@RentalCost,@Genre,@Plot,@Available)", sqlcon))
                {
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@ReleaseDate", releaseDate);
                    cmd.Parameters.AddWithValue("@RentalCost", cost);
                    cmd.Parameters.AddWithValue("@Genre", genre);
                    cmd.Parameters.AddWithValue("@Plot", plot);
                    cmd.Parameters.AddWithValue("@Available", "Yes");
                    cmd.ExecuteNonQuery();

                }
                sqlcon.Close();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int UpdateVideo(string title, DateTime releaseDate, decimal cost, string genre, string plot, int movieId)
        {

            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("update Movie set Title=@Title,ReleaseDate=@ReleaseDate,RentalCost=@RentalCost,Genre=@Genre,Plot=@Plot where MovieId=@MovieId", sqlcon))
                {
                    cmd.Parameters.AddWithValue("@MovieId", movieId);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@ReleaseDate", releaseDate);
                    cmd.Parameters.AddWithValue("@RentalCost", cost);
                    cmd.Parameters.AddWithValue("@Genre", genre);
                    cmd.Parameters.AddWithValue("@Plot", plot);


                    cmd.ExecuteNonQuery();

                }
                sqlcon.Close();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int DeleteVideo(int movieId)
        {

            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("delete from Movie where MovieId=@MovieId", sqlcon))
                {
                    cmd.Parameters.AddWithValue("@MovieId", movieId);

                    cmd.ExecuteNonQuery();

                }
                sqlcon.Close();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public DataTable AllAvailableVideo()
        {
            DataTable dt = new DataTable();
            try
            {

                using (SqlCommand cmd = new SqlCommand("select * from Movie where Available='Yes'", sqlcon))
                {

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                return dt;
            }
            catch
            {
                return dt;
            }
        }
        public int InsertRentalVideo(int movieId, int custId, DateTime rentedDate)
        {

            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("insert into RentedMovies(MovieId,CustId,DateRented)values(@MovieId,@CustId,@DateRented)", sqlcon))
                {
                    cmd.Parameters.AddWithValue("@MovieId", movieId);
                    cmd.Parameters.AddWithValue("@CustId", custId);
                    cmd.Parameters.AddWithValue("@DateRented", rentedDate);

                    cmd.ExecuteNonQuery();

                }
                sqlcon.Close();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public DataTable SelectRentedMoviesView()
        {
            DataTable dt = new DataTable();
            try
            {

                using (SqlCommand cmd = new SqlCommand("select * from ViewRentedMovies", sqlcon))
                {

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                return dt;
            }
            catch
            {
                return dt;
            }
        }
        public int ChangedMovieStatus(int movieId, string status)
        {

            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("update Movie set Available=@Available where MovieId=@MovieId", sqlcon))
                {
                    cmd.Parameters.AddWithValue("@MovieId", movieId);
                    cmd.Parameters.AddWithValue("@Available", status);
                   
                    cmd.ExecuteNonQuery();

                }
                sqlcon.Close();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public DataTable SelectRentedOutMoviesView()
        {
            DataTable dt = new DataTable();
            try
            {

                using (SqlCommand cmd = new SqlCommand("select * from ViewRentedMovies where DateReturned is Null", sqlcon))
                {

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                return dt;
            }
            catch
            {
                return dt;
            }
        }
        public int ReturnedMovie(int rmid)
        {

            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("update RentedMovies set DateReturned=@DateReturned where RentedMovieId=@RentedMovieId", sqlcon))
                {
                    cmd.Parameters.AddWithValue("@RentedMovieId", rmid);
                    cmd.Parameters.AddWithValue("@DateReturned", DateTime.Now);

                    cmd.ExecuteNonQuery();

                }
                sqlcon.Close();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public DataTable CustomerMostBorrowsVideo()
        {
            DataTable dt = new DataTable();
            try
            {

                using (SqlCommand cmd = new SqlCommand("select CustId,FirstName,LastName,Address,Phone,Count(*) as 'Total Borrows' from ViewRentedMovies group by CustId,FirstName,LastName,Address,Phone order by 'Total Borrows' desc", sqlcon))
                {

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                return dt;
            }
            catch
            {
                return dt;
            }
        }
        public DataTable MostPopularVideo()
        {
            DataTable dt = new DataTable();
            try
            {

                using (SqlCommand cmd = new SqlCommand("select MovieId,Title,ReleaseDate,RentalCost,Genre,Count(*) as 'Total Rented' from ViewRentedMovies group by MovieId,Title,ReleaseDate,RentalCost,Genre order by 'Total Rented' desc", sqlcon))
                {

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                return dt;
            }
            catch
            {
                return dt;
            }
        }
    }
}
