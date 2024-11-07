using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIS_SinhVien.DAL
{
    internal class Dal_SinhVien
    {
        
        public Dal_SinhVien()
        {
            lopchung = new LopDungChung();  
        }
        LopDungChung lopchung;
        public DataTable dal_Grid()
        {
            String sqlLoadData = "select * from SINHVIEN";
            return lopchung.LoadDuLieu(sqlLoadData);
        }
        public DataTable dal_ComBo()
        {
            String sqlLoadKhoa = "select * from KHOA";
            return lopchung.LoadDuLieu(sqlLoadKhoa);
        }
        public void dal_Them(String maSV, String hoTen, 
            DateTime ngayNhapHoc, String maKhoa, String tenHinh)
        {
            String sqlThem = "insert into SINHVIEN " +
             "values('" + maSV + "', N'" + hoTen + "', " +
             "Convert(Datetime,'" + ngayNhapHoc + "', 103)," +
             " '" + maKhoa + "', '"+tenHinh+"')";
            lopchung.Nonquery(sqlThem);
        }
        public void dal_Sua(String hoTen,
            DateTime ngayNhapHoc, String maKhoa, String tenHinh, String maSV)
        {
            String sqlSua = "update SINHVIEN set HoTen = N'" + hoTen + "', " +
                "NgayNhapHoc = Convert(Datetime,'" + ngayNhapHoc + "', 103), " +
                "MaKhoa = '" + maKhoa + "', " +
                "TenHinh = '" + tenHinh + "' where MaSV = '" + maSV + "' ";
            lopchung.Nonquery(sqlSua);
        }
        public void dal_Xoa(String maSV)
        {
            String sqlXoa = "delete from SINHVIEN" +
                " where MaSV = '"+maSV+"'";
            lopchung.Nonquery(sqlXoa);
        }
    }
}
