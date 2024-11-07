using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_SinhVien.BLL
{
    internal class Bll_SinhVien
    {
        DAL.Dal_SinhVien dal_SV;
        frm_SinhVien SV;
        public Bll_SinhVien(frm_SinhVien fSV)
        {
            dal_SV = new DAL.Dal_SinhVien();
            SV = fSV;
        }
        public void bll_Grid()
        {
            SV.dataGridView1.DataSource = dal_SV.dal_Grid();
        }
        public void bll_Combo()
        {
            SV.cb_Khoa.DataSource = dal_SV.dal_ComBo();
            SV.cb_Khoa.DisplayMember = "TenKhoa";
            SV.cb_Khoa.ValueMember = "MaKhoa";
        }
        public void bll_Them()
        {
            dal_SV.dal_Them(SV.txt_MaSV.Text, SV.txt_HoTen.Text,
                SV.dateTimePicker1.Value, SV.cb_Khoa.SelectedValue.ToString(),
                SV.txt_Hinh.Text);
        }
        public void bll_Sua()
        {
            dal_SV.dal_Sua(SV.txt_HoTen.Text,SV.dateTimePicker1.Value, 
                SV.cb_Khoa.SelectedValue.ToString(),SV.txt_Hinh.Text,
                SV.txt_MaSV.Text);
        }
        public void bll_Xoa()
        {
            dal_SV.dal_Xoa(SV.txt_MaSV.Text);
        }
    }
}
