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
        }
        //The connection was not closed. The connection's current state is open.'

        private void frm_SinhVien_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        String chuoiKetNoi = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Downloads\\HIS_SinhVien\\HIS_SinhVien\\SQL_SV.mdf;Integrated Security=True";
        SqlConnection conn;
        private void button1_Click(object sender, EventArgs e)
        {
           
            String sqlThem = "insert into SINHVIEN values('"+txt_MaSV.Text+"',N'"+txt_HoTen.Text+"')";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlThem, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();
        }
        public void LoadData()
        {
            //String chuoiKetNoi = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Downloads\\HIS_SinhVien\\HIS_SinhVien\\SQL_SV.mdf;Integrated Security=True";
           // conn = new SqlConnection(chuoiKetNoi);
            String sqlLoadData = "select * from SINHVIEN";
            SqlDataAdapter da = new SqlDataAdapter(sqlLoadData, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
