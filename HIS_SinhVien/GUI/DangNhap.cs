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
             bll_DN = new BLL.Bll_DangNhap(this);
        }
        LopDungChung lopchung;
        BLL.Bll_DangNhap bll_DN;
        private void btn_TenDangNhap_Click(object sender, EventArgs e)
        {
            bll_DN.bll_DangNhap();     
        }

        private void frm_DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
