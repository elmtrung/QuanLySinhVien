using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIS_SinhVien
{
    public partial class frm_SinhVien : Form
    {
        BLL.Bll_SinhVien bll_SinhVien;
        public frm_SinhVien()
        {
            InitializeComponent();
            conn = new SqlConnection(chuoiKetNoi);
            lopchung = new LopDungChung();
            bll_SinhVien = new BLL.Bll_SinhVien(this);
        }
        private void frm_SinhVien_Load(object sender, EventArgs e){
            int nam = dateTimePicker1.Value.Year + 4;
            txt_NamRaTruong.Text = nam.ToString();
            int namThu = DateTime.Now.Year - dateTimePicker1.Value.Year + 1;
            txt_NamThu.Text = namThu.ToString();
            LoadKhoa();
            LoadData();
        }
        public void LoadData()
        {
            bll_SinhVien.bll_Grid();
        }
        String chuoiKetNoi = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Desktop\\.NET\\F_ADO\\HIS_SinhVien\\HIS_SinhVien\\SQL_SV.mdf;Integrated Security=True";
        SqlConnection conn;
        LopDungChung lopchung; // = new LopDungChung();
       
        public void LoadKhoa()
        {
            bll_SinhVien.bll_Combo();
        }
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
   File.Delete(duongDan + txt_Hinh.Text);
            bll_SinhVien.bll_Xoa();
            LoadData();
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                //pictureBox1.Image.Save(@"C:\Users\Admin\Desktop\.NET\HIS_ADO\HIS_SinhVien\HINHANH\" + txt_Hinh.Text);
                pictureBox1.Image.Save(duongDan + txt_Hinh.Text);
                bll_SinhVien.bll_Them();
            }
            catch (Exception ex)
            {
                MessageBox.Show("chưa nhập tên hình");
            }

            LoadData();
        }
        string duongDan = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\HINHANH\\";

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                //pictureBox1.Image.Save(@"C:\Users\Admin\Desktop\.NET\HIS_ADO\HIS_SinhVien\HINHANH\" + txt_Hinh.Text);
                pictureBox1.Image.Save(duongDan + txt_Hinh.Text);
                bll_SinhVien.bll_Sua();
            }catch(Exception ex){
MessageBox.Show("chưa nhập tên hình");
            }
           
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        int chon = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaSV.Text = dataGridView1.CurrentRow.Cells["MaSV"].Value.ToString();
            txt_HoTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            chon = 1;
            cb_Khoa.SelectedValue = dataGridView1.CurrentRow.Cells["MaKhoa"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_Hinh.Text = dataGridView1.CurrentRow.Cells["TenHinh"].Value.ToString();
            pictureBox1.ImageLocation = duongDan + txt_Hinh.Text;
        }

        private void btn_Dem_Click(object sender, EventArgs e)
        {
            String sqlDem = "select count (*) from SINHVIEN";
            int dem = (int)lopchung.Scalar(sqlDem);
            txt_Dem.Text = dem.ToString();
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            String sqlTim = "select * from SINHVIEN" +
                " where MaSV like N'%"+txt_Tim.Text+"%' or HoTen like N'%"+txt_Tim.Text+"%' ";
            dataGridView1.DataSource = lopchung.LoadDuLieu(sqlTim);
        }

        private void btn_LoadLai_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cb_Khoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(chon == 0)
            {
                String sqlLoadData = "select * from SINHVIEN" +
                                " where MaKhoa = '" + cb_Khoa.SelectedValue + "'";
                dataGridView1.DataSource =lopchung.LoadDuLieu(sqlLoadData);
            }
            chon = 0; 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ODF = new OpenFileDialog();
            ODF.Title = "Hãy chọn ảnh";
            ODF.Filter = "Tất cả đuôi|*.*|JPG|*.jpg|JPEG|*.jpeg|PNG|*.png";
            if(ODF.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ODF.FileName);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int nam = dateTimePicker1.Value.Year + 4;
            txt_NamRaTruong.Text = nam.ToString();
            int namThu = DateTime.Now.Year - dateTimePicker1.Value.Year;
            txt_NamThu.Text = namThu.ToString();
        }
    }
}
