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
    public partial class Customer : Form
    {
        Database dbcontext = new Database();
        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            CustomerGridFill();
            btnAddCustomer.Enabled = true;
            btnUpdateCustomer.Enabled = false;
            btnDeleteCustomer.Enabled = false;
        }
        public void CustomerGridFill()
        {
            DataTable dt = new DataTable();

            dt = dbcontext.GetAllCustomer();

            //custGrid.AutoGenerateColumns = false;
            custGrid.DataSource = dt;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required");
                return;
            }
            else if (string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required");
                return;
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Address is required");
                return;
            }
            else if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Phone No. is required");
                return;
            }
            int cust = dbcontext.InsertCustomer(txtFirstName.Text,txtLastName.Text,txtAddress.Text,txtPhone.Text);
            if (cust == 1)
            {
                lblCustId.Text = "";

                ClearTextBoxes();
                CustomerGridFill();

                MessageBox.Show("Successfully Add Customer");
                btnAddCustomer.Enabled = true;
                btnUpdateCustomer.Enabled = false;
                btnDeleteCustomer.Enabled = false;
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

        private void custGrid_Click(object sender, EventArgs e)
        {
            if (custGrid.Rows.Count > 0)
            {
                lblCustId.Text = custGrid.CurrentRow.Cells[0].Value.ToString();
                txtFirstName.Text = custGrid.CurrentRow.Cells[1].Value.ToString();
                txtLastName.Text = custGrid.CurrentRow.Cells[2].Value.ToString();
                txtAddress.Text = custGrid.CurrentRow.Cells[3].Value.ToString();
                txtPhone.Text = custGrid.CurrentRow.Cells[4].Value.ToString();
                btnAddCustomer.Enabled = false;
                btnUpdateCustomer.Enabled = true;
                btnDeleteCustomer.Enabled = true;
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblCustId.Text))
            {
                MessageBox.Show("Please Select the Customer for Update");
                return;
            }
            int cust = dbcontext.UpdateCustomer(txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtPhone.Text,Convert.ToInt32(lblCustId.Text));
            if (cust == 1)
            {
                lblCustId.Text = "";

                ClearTextBoxes();
                CustomerGridFill();

                MessageBox.Show("Successfully Update Customer");
                btnAddCustomer.Enabled = true;
                btnUpdateCustomer.Enabled = false;
                btnDeleteCustomer.Enabled = false;
            }
            else
            {
                MessageBox.Show("Wrong Data Input");
            }
           
           
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblCustId.Text))
            {
                MessageBox.Show("Please Select the Customer for Delete");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE THIS Customer ??", "Customer Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int cust = dbcontext.DeleteCustomer(Convert.ToInt32(lblCustId.Text));
                if (cust == 1)
                {
                    lblCustId.Text = "";

                    ClearTextBoxes();
                    CustomerGridFill();

                    MessageBox.Show("Successfully Delete Customer");
                    btnAddCustomer.Enabled = true;
                    btnUpdateCustomer.Enabled = false;
                    btnDeleteCustomer.Enabled = false;
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

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
