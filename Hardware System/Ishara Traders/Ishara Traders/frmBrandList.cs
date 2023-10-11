using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ishara_Traders
{
    public partial class frmBrandList : Form
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();

        public frmBrandList()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            loadRecords();
        }

        //------------------search---------------------->
        public void loadBrand1()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("Select id,brand from tblBrands where brand like '%" + txtSearch.Text + "%' order by brand", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            cn.Close();


        }

    

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;    
            if(colName == "Edit")
            {
                frmBrand frm = new frmBrand(this);
                
                //frm.LoadCategory();
                frm.lblID.Text = dataGridView1[1, e.RowIndex].Value.ToString();
               // frm.cName.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                //frm.txtBrand.Text = dataGridView1[3,e.RowIndex].Value.ToString();
                //frm.cName.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();


                frm.ShowDialog();
            }
            else if(colName == "Delete")
            {
                if (MessageBox.Show("Are you sure want to delete this record ? ","Delete Record ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm=new SqlCommand("delete from tblBrands where id like '" + dataGridView1[1,e.RowIndex].Value.ToString() + "'",cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    //MessageBox.Show("Brand has been successfully deleted.","POS",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    loadRecords();
                }
              
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmBrand frm=new frmBrand(this);
           // frm.LoadCategory();
            frm.ShowDialog();
        }

        public void loadRecords()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from tblBrands order by brand",cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dr["id"].ToString(),dr["brand"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadBrand1();
        }
    }
}
