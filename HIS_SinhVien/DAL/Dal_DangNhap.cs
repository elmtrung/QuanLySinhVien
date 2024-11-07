using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIS_SinhVien.DAL
{
    internal class Dal_DangNhap
    {
        LopDungChung lopChung;
        public Dal_DangNhap()
        {
            lopChung = new LopDungChung();
        }
        public int Dal_DN(String tenDangNhap, String matKhau)
        {
            String sqlDN = "select count(*) from TAIKHOAN " +
                "where TenDangNhap = '" + tenDangNhap + "'" +
                " and MatKhau = '" + matKhau + "' ";
            return (int)lopChung.Scalar(sqlDN);
        }
    }
}
