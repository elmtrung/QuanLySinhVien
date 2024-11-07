using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIS_SinhVien.BLL
{
    internal class Bll_DangNhap
    {
        DAL.Dal_DangNhap dal_DN;
        frm_DangNhap DN;
        public Bll_DangNhap(frm_DangNhap fDN) {
            dal_DN = new DAL.Dal_DangNhap();
            DN = fDN;
        }
        public void bll_DangNhap()
        {
            int kq = dal_DN.Dal_DN(DN.txt_TenDangNhap.Text,
                DN.txt_MatKhau.Text);
            if (kq >= 1)
            {
                frm_SinhVien SV = new frm_SinhVien();
                SV.Show();
            }
            else MessageBox.Show("Sai tên ĐN hoặc MK");
        }
    }
}
