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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Customer frmCust = new Customer();
            frmCust.Show();
        }

        private void buttonVideo_Click(object sender, EventArgs e)
        {
            Movies frmMovie = new Movies();
            frmMovie.Show();
        }

        private void btnRentalVideo_Click(object sender, EventArgs e)
        {
            RentalVideo frmRentalVideo = new RentalVideo();
            frmRentalVideo.Show();
        }

        private void btnReturnedVideo_Click(object sender, EventArgs e)
        {
            ReturnedVideo frmReturnVideo = new ReturnedVideo();
            frmReturnVideo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostBorrows frmMostBorrows = new MostBorrows();
            frmMostBorrows.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PopularVideo frmPopular = new PopularVideo();
            frmPopular.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
