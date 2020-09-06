using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRentalSystem
{
    public partial class ReturnedVideo : Form
    {
        Database dbcontext = new Database();
        public ReturnedVideo()
        {
            InitializeComponent();
        }

        private void ReturnedVideo_Load(object sender, EventArgs e)
        {
            RentedmovieGridData();
        }
        private void RentedmovieGridData()
        {
            DataTable dt = new DataTable();

            dt = dbcontext.SelectRentedOutMoviesView();

            //custGrid.AutoGenerateColumns = false;
            gridRentedMovie.DataSource = dt;
        }

        private void gridRentedMovie_Click(object sender, EventArgs e)
        {
            if (gridRentedMovie.Rows.Count > 0)
            {
                lblRMID.Text = gridRentedMovie.CurrentRow.Cells["RMID"].Value.ToString();

                lblMovieId.Text = gridRentedMovie.CurrentRow.Cells["MovieId"].Value.ToString();
            }
        }

        private void btnReturned_Click(object sender, EventArgs e)
        {
            if (gridRentedMovie.Rows.Count > 0)
            {
                lblRMID.Text = gridRentedMovie.CurrentRow.Cells["RMID"].Value.ToString();

                lblMovieId.Text = gridRentedMovie.CurrentRow.Cells["MovieId"].Value.ToString();
            }
            if (string.IsNullOrEmpty(lblRMID.Text))
            {
                MessageBox.Show("Please Select the Rented Movie");
                return;
            }



            int Success = dbcontext.ReturnedMovie(Convert.ToInt32(lblRMID.Text));
            if(Success==1)
            {
                int chngeStatus = dbcontext.ChangedMovieStatus(Convert.ToInt32(lblMovieId.Text), "Yes");
                MessageBox.Show("Movie Returned successfully");
                lblMovieId.Text = "";
                lblRMID.Text = "";
                RentedmovieGridData();
            }
            else
            {
                MessageBox.Show("Something is wrong");
            }



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
