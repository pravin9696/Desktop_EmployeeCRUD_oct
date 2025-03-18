using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_EmployeeCRUD_oct
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void AddDept()
        {
            //cmbDept.DataSource = null;
          //  cmbDept.Items.Clear();
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Shopping;Integrated Security=True;TrustServerCertificate=True");
            SqlDataAdapter adp = new SqlDataAdapter("select * from tblDepartment",con);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            DataRow dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "--select Department--" };
            dt.Rows.InsertAt(dr, 0);
            cmbDept.ValueMember = "DeptName";
            cmbDept.DisplayMember = "DeptName";
            cmbDept.DataSource = dt;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtNAme.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
          
            rbMale.Checked = rbFemale.Checked = false;
            AddDept();
            cmbDept.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddDept();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNAme.Text))
            {
                MessageBox.Show("Enter Employee Name");
                return;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Enter Address");
                return;
            }
            if (cmbDept.SelectedIndex==0)
            {
                MessageBox.Show("select Department type");
                cmbDept.Focus();
                return;
            }
            if (rbFemale.Checked==false && rbMale.Checked==false)
            {
                MessageBox.Show("select Gender of Employee");
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("enter email of employee");
                return;               
            }

            string empName = txtNAme.Text;
            string address = txtAddress.Text;
            string email = txtEmail.Text;
            string dept = cmbDept.SelectedValue.ToString();
            string gender = rbMale.Checked ? "Male" : "Female";

            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Shopping;Integrated Security=True;TrustServerCertificate=True");

            SqlDataAdapter adp = new SqlDataAdapter("select * from tblEmployee",con);
           SqlCommandBuilder cmdb = new SqlCommandBuilder(adp);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            //DataSet ds = new DataSet();
            //adp.Fill(ds, "tblEmployee");

            DataRow dr = dt.NewRow();
            dr["Name"] = empName;
            //dr[1] = empName;
            dr["Address"] = address;
            dr["Dept"] = dept;
            dr["Gender"] = gender;
            dr["Email"] = email;

            dt.Rows.Add(dr);


           int n= adp.Update(dt);
            if (n>0)
            {
                MessageBox.Show("record inserted Successfully");
                btnNew_Click(sender, e);
            }
            else
            {
                MessageBox.Show("record not inserted!!!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            SqlConnection con=new SqlConnection(@"Data Source=.;Initial Catalog=Shopping;Integrated Security=True;TrustServerCertificate=True");
            SqlDataAdapter adp = new SqlDataAdapter("select * from tblEmployee where Email=@email", con);
            adp.SelectCommand.Parameters.AddWithValue("@email", email);

            DataTable dt = new DataTable();
            adp.Fill(dt);

            SqlCommandBuilder cmdb = new SqlCommandBuilder(adp);
            if (dt.Rows.Count>0)
            {
                txtNAme.Text = dt.Rows[0][1].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                cmbDept.SelectedValue = dt.Rows[0]["Dept"].ToString();
                string gender = dt.Rows[0]["Gender"].ToString();
                if (gender=="Male")
                {
                    rbMale.Checked = true; ;
                }
                else
                {
                    rbFemale.Checked = true;
                }
                btnUpdate.Enabled = true;
            }
            else
            {
                MessageBox.Show("Record not Found");
                btnNew_Click(sender, e);
                btnUpdate.Enabled = false;
            }
        }
    }
}
