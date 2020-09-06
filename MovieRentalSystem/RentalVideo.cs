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
    public partial class RentalVideo : Form
    {
        Database dbcontext = new Database();
        public RentalVideo()
        {
            InitializeComponent();
        }

        private void RentalVideo_Load(object sender, EventArgs e)
        {
            ddlfill_Customer();
            ddlfill_Movie();
            RentedmovieGridData();
        }
        private void ddlfill_Customer()
        {

            DataTable dt = new DataTable();

            dt = dbcontext.GetAllCustomer();
            if (dt.Rows.Count > 0)
            {
                cmbCustomer.DataSource = dt;
                cmbCustomer.ValueMember = "CustId";
                cmbCustomer.DisplayMember = "FirstName";

            }
        }
        private void ddlfill_Movie()
        {

            DataTable dt = new DataTable();

            dt = dbcontext.AllAvailableVideo();
            if (dt.Rows.Count > 0)
            {
                cmbVideo.DataSource = dt;
                cmbVideo.ValueMember = "MovieId";
                cmbVideo.DisplayMember = "Title";

            }
        }

        private void btnRentalVideo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbCustomer.SelectedValue.ToString()) || string.IsNullOrEmpty(cmbVideo.SelectedValue.ToString()))
            {
                MessageBox.Show("Please Select the Customer and Movie for rental");
                return;
            }


            int success = dbcontext.InsertRentalVideo(Convert.ToInt32(cmbVideo.SelectedValue.ToString()), Convert.ToInt32(cmbCustomer.SelectedValue.ToString()), dtpRentedDate.Value.Date);
           
            if(success==1)
            {
                int chngeStatus = dbcontext.ChangedMovieStatus(Convert.ToInt32(cmbVideo.SelectedValue.ToString()), "No");
                MessageBox.Show("Movie Rented successfully");
                ddlfill_Customer();
                ddlfill_Movie();
                RentedmovieGridData();

            }
            else
            {
                MessageBox.Show("Wrong Data Input");
            }
           
            
        }
        private void RentedmovieGridData()
        {
            DataTable dt = new DataTable();

            dt = dbcontext.SelectRentedMoviesView();

            //custGrid.AutoGenerateColumns = false;
            gridRentedMovie.DataSource = dt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
