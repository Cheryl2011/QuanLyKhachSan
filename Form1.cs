using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void ketnoi()
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True");
            con.Open();
            string sql = "select * from tblPhong";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adp.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ketnoi();
        }
        int index;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dataGridView1.CurrentRow.Index;
            txtMaphong.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtTenphong.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtDongia.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
 }

        private void bntThem_Click(object sender, EventArgs e)
        {
            txtMaphong.Clear();
            txtTenphong.Clear();
            txtDongia.Clear();
            txtMaphong.Focus();
            txtTenphong.Focus();
            txtDongia.Focus();
            txtMaphong.ReadOnly = false;
         }

        private void bntHuy_Click(object sender, EventArgs e)
        {
            txtMaphong.Clear();
            txtTenphong.Clear();
            txtDongia.Clear();
        }

        private void bntLuu_Click(object sender, EventArgs e)
        {
            txtMaphong.ReadOnly = false;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True");
                con.Open();
                string sql = "insert into tblPhong values('" + txtMaphong.Text + "','" + txtTenphong.Text + "','" + txtDongia.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                ketnoi();
            }
            catch
            {
                MessageBox.Show("Không lưu được");
                txtMaphong.Clear();
                txtTenphong.Clear();
                txtDongia.Clear();
            }
            finally
            {
                SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True");
                con.Close();
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaphong.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa chọn dòng để xóa");
            }
            txtMaphong.ReadOnly = false;
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True");
            con.Open();
            string sql = "delete from tblPhong where Maphong='" + txtMaphong.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            ketnoi();
            txtMaphong.Clear();
            txtTenphong.Clear();
            txtDongia.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaphong.ReadOnly = true;
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True");
            con.Open();
            string sql = "update tblPhong set Tenphong='" + txtTenphong.Text + "',Dongia='" + txtDongia.Text + "' where Maphong='" + txtMaphong.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            ketnoi();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
