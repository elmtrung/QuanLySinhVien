using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIS_SinhVien
{
    internal class LopDungChung
    {
        public LopDungChung()
        {
            conn = new SqlConnection(chuoiKetNoi);
        }
        String chuoiKetNoi = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Desktop\\.NET\\HIS_ADO\\HIS_SinhVien\\SQL_SV.mdf;Integrated Security=True";
        SqlConnection conn;
        public DataTable LoadDuLieu(String sqlDL)
        {
            SqlDataAdapter da = new SqlDataAdapter(sqlDL, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void Nonquery(String sqlNon) 
        {
            conn.Open();
            SqlCommand comm = new SqlCommand(sqlNon, conn);
            int ketqua = comm.ExecuteNonQuery();
            conn.Close();
            if (ketqua >= 1)
            {
                MessageBox.Show("Thành công");
            }
            else MessageBox.Show("Thất bại");
        }
        public Object Scalar(String sqlScalar)
        {
            SqlCommand comm = new SqlCommand(sqlScalar, conn);
            conn.Open();          
            int ketqua = (int)comm.ExecuteScalar();
            conn.Close();
            return ketqua;
        }
    }
}
