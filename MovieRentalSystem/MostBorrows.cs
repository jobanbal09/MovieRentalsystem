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
    public partial class MostBorrows : Form
    {
        Database dbcontext = new Database();
        public MostBorrows()
        {
            InitializeComponent();
        }

        private void MostBorrows_Load(object sender, EventArgs e)
        {
            MostBorrowsVideo();
        }
        private void MostBorrowsVideo()
        {
            DataTable dt = new DataTable();
            dt = dbcontext.CustomerMostBorrowsVideo();

            gridMostBorrow.DataSource = dt;
        }
    }
}
