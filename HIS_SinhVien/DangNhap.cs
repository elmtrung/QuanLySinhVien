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
    public partial class frm_DangNhap : Form
    {
        public frm_DangNhap()
        {
            InitializeComponent();
            lopchung = new LopDungChung();
        }
        LopDungChung lopchung;
        private void btn_TenDangNhap_Click(object sender, EventArgs e)
        {
            String sqlDN = "select count(*) from TAIKHOAN where TenDangNhap = '"+txt_TenDangNhap.Text+"' and MatKhau = '"+txt_MatKhau.Text+"' ";
            int ketQua = (int)lopchung.Scalar(sqlDN);
            if (ketQua >= 1)
            {
                frm_SinhVien SV = new frm_SinhVien();
                SV.Show();
            }
            else MessageBox.Show("Sai tên ĐN hoặc MK");         
        }

        private void frm_DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
