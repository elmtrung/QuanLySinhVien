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

namespace HIS_SinhVien
{
    public partial class frm_SinhVien : Form
    {
        public frm_SinhVien()
        {
            InitializeComponent();
            conn = new SqlConnection(chuoiKetNoi);
            lopchung = new LopDungChung();
        }
        private void frm_SinhVien_Load(object sender, EventArgs e){
            LoadKhoa();
            LoadData();
        }
        String chuoiKetNoi = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Desktop\\.NET\\F_ADO\\HIS_SinhVien\\HIS_SinhVien\\SQL_SV.mdf;Integrated Security=True";
        SqlConnection conn;
        LopDungChung lopchung; // = new LopDungChung();
        public void LoadData()
        {
            String sqlLoadData = "select * from SINHVIEN";          
            dataGridView1.DataSource = lopchung.LoadDuLieu(sqlLoadData);
        }
        public void LoadKhoa()
        {
            String sqlLoadData = "select * from KHOA";         
            cb_Khoa.DataSource = lopchung.LoadDuLieu(sqlLoadData); 
            cb_Khoa.DisplayMember = "TenKhoa";
            cb_Khoa.ValueMember = "MaKhoa";
        }
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            String sqlXoa = "delete from SINHVIEN where MaSV = '"+txt_MaSV.Text+"' ";
            lopchung.Nonquery(sqlXoa);
            LoadData();
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            String sqlThem = "insert into SINHVIEN " +
                "values('"+txt_MaSV.Text+"', '"+txt_HoTen.Text+"', " +
                "Convert(Datetime,'"+dateTimePicker1.Text+"', 103)," +
                " '"+cb_Khoa.SelectedValue+"')";
            lopchung.Nonquery(sqlThem);
            LoadData();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            String sqlSua = "update SINHVIEN set HoTen = N'"+txt_HoTen.Text+"', " +
                "NgayNhapHoc = Convert(Datetime,'"+dateTimePicker1.Text+"', 103), " +
                "MaKhoa = '"+cb_Khoa.SelectedValue+"' where MaSV = '" + txt_MaSV.Text + "' ";
            lopchung.Nonquery(sqlSua) ;
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
    }
}
