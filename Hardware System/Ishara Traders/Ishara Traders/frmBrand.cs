using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ishara_Traders
{
    public partial class frmBrand : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        frmBrandList frmlist;

        public frmBrand(frmBrandList flist)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            frmlist = flist;
        }

        private void frmBrand_Load(object sender, EventArgs e)
        {

        }



        private void Clear()
        {
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            txtBrand.Clear();          
            txtBrand.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string ccid = "";
                if (MessageBox.Show("Are you sure you want to save this brand ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes);
                cn.Open();
                cm=new SqlCommand("INSERT INTo tblBrands(Brand)VALUEs(@brand)",cn);
                cm.Parameters.AddWithValue("@brand", txtBrand.Text);
               // cm.Parameters.AddWithValue("@ccid", cName.Text);
                cm.ExecuteNonQuery();
                cn.Close();
                //MessageBox.Show("Record has been successfully saved. ");
                Clear();
                frmlist.loadRecords();





            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            //this.Dispose();
            Clear();
        }

        private void cName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBrand_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
