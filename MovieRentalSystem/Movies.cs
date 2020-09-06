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
    public partial class Movies : Form
    {
        Database dbcontext = new Database();
        public Movies()
        {
            InitializeComponent();
        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            
        }
        public void MovieGridFill()
        {
            DataTable dt = new DataTable();

            dt = dbcontext.GetAllVideo();

            //custGrid.AutoGenerateColumns = false;
            gridVideo.DataSource = dt;
        }

        private void Movies_Load(object sender, EventArgs e)
        {
            MovieGridFill();
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            if (dtpReleaseDate.Value.Date <= DateTime.Now.Date.AddYears(-5))
            {
                txtCost.Text = "2";
            }
            else
            {
                txtCost.Text = "5";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("Movie Title is required");
                return;
            }
            else if (string.IsNullOrEmpty(txtCost.Text))
            {
                MessageBox.Show("Rental Cost is required");
                return;
            }

            int success = dbcontext.InsertVideo(txtTitle.Text,dtpReleaseDate.Value.Date,Convert.ToDecimal(txtCost.Text), txtGenre.Text,txtPlot.Text);
            if (success == 1)
            {
                lblMovieId.Text = "";

                ClearTextBoxes();
                MovieGridFill();

                MessageBox.Show("Successfully Add Movie");
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                if (dtpReleaseDate.Value.Date <= DateTime.Now.Date.AddYears(-5))
                {
                    txtCost.Text = "2";
                }
                else
                {
                    txtCost.Text = "5";
                }
            }
            else
            {
                MessageBox.Show("Wrong Data Input");
            }

        }
        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblMovieId.Text))
            {
                MessageBox.Show("Please Select the Video for Update");
                return;
            }

            int success = dbcontext.UpdateVideo(txtTitle.Text, dtpReleaseDate.Value.Date, Convert.ToDecimal(txtCost.Text), txtGenre.Text, txtPlot.Text,Convert.ToInt32(lblMovieId.Text));
            if (success == 1)
            {
                lblMovieId.Text = "";

                ClearTextBoxes();
                MovieGridFill();

                MessageBox.Show("Successfully Update Movie");
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                if (dtpReleaseDate.Value.Date <= DateTime.Now.Date.AddYears(-5))
                {
                    txtCost.Text = "2";
                }
                else
                {
                    txtCost.Text = "5";
                }
            }
            else
            {
                MessageBox.Show("Wrong Data Input");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblMovieId.Text))
            {
                MessageBox.Show("Please Select the Video for Delete");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE THIS Video ??", "Record Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int success = dbcontext.DeleteVideo(Convert.ToInt32(lblMovieId.Text));
                if (success == 1)
                {
                    lblMovieId.Text = "";

                    ClearTextBoxes();
                    MovieGridFill();

                    MessageBox.Show("Successfully Delete Movie");
                    btnAdd.Enabled = true;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    if (dtpReleaseDate.Value.Date <= DateTime.Now.Date.AddYears(-5))
                    {
                        txtCost.Text = "2";
                    }
                    else
                    {
                        txtCost.Text = "5";
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Data Input");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridVideo_Click(object sender, EventArgs e)
        {
            if (gridVideo.Rows.Count > 0)
            {
                lblMovieId.Text = gridVideo.CurrentRow.Cells[0].Value.ToString();
                txtTitle.Text = gridVideo.CurrentRow.Cells[1].Value.ToString();
                dtpReleaseDate.Text = gridVideo.CurrentRow.Cells[2].Value.ToString();
                txtCost.Text = gridVideo.CurrentRow.Cells[3].Value.ToString();
                txtGenre.Text = gridVideo.CurrentRow.Cells[4].Value.ToString();
                txtPlot.Text = gridVideo.CurrentRow.Cells[5].Value.ToString();
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;

            }
        }

        private void dtpReleaseDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpReleaseDate.Value.Date <= DateTime.Now.Date.AddYears(-5))
            {
                txtCost.Text = "2";
            }
            else
            {
                txtCost.Text = "5";
            }
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
