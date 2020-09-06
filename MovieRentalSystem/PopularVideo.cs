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
    public partial class PopularVideo : Form
    {
        Database dbcontext = new Database();
        public PopularVideo()
        {
            InitializeComponent();
        }

        private void PopularVideo_Load(object sender, EventArgs e)
        {
            MostPopularVideo();
        }
        private void MostPopularVideo()
        {
            DataTable dt = new DataTable();
            dt = dbcontext.MostPopularVideo();

            gridPopularVideo.DataSource = dt;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
