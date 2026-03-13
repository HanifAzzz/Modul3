using System;
using System.Data;
using System.Data.SqlClient;

namespace OrganisasiWeb
{
    public partial class Organisasi : System.Web.UI.Page
    {

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-B20J65F\\SQLEXPRESS;Initial Catalog=ORGANISASI_KEL38;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                LoadBidang();
            }
        }

        void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter(
            "SELECT m.id_mahasiswa,m.Nama,m.NIM,m.Angkatan,b.NamaBidang FROM mahasiswa m JOIN bidang b ON m.id_bidang=b.ID_bidang",
            conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        void LoadBidang()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM bidang", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlBidang.DataSource = dt;
            ddlBidang.DataTextField = "NamaBidang";
            ddlBidang.DataValueField = "ID_bidang";
            ddlBidang.DataBind();
        }

        protected void btnTambah_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand(
            "INSERT INTO mahasiswa(Nama,NIM,Angkatan,id_bidang) VALUES(@Nama,@NIM,@Angkatan,@id_bidang)",
            conn);

            cmd.Parameters.AddWithValue("@Nama", txtNama.Text);
            cmd.Parameters.AddWithValue("@NIM", txtNIM.Text);
            cmd.Parameters.AddWithValue("@Angkatan", txtAngkatan.Text);
            cmd.Parameters.AddWithValue("@id_bidang", ddlBidang.SelectedValue);

            cmd.ExecuteNonQuery();
            conn.Close();

            LoadData();
        }

        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LoadData();
        }

        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadData();
        }

        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            string nama = ((System.Web.UI.WebControls.TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string nim = ((System.Web.UI.WebControls.TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string angkatan = ((System.Web.UI.WebControls.TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;

            conn.Open();

            SqlCommand cmd = new SqlCommand(
            "UPDATE mahasiswa SET Nama=@Nama,NIM=@NIM,Angkatan=@Angkatan WHERE id_mahasiswa=@id",
            conn);

            cmd.Parameters.AddWithValue("@Nama", nama);
            cmd.Parameters.AddWithValue("@NIM", nim);
            cmd.Parameters.AddWithValue("@Angkatan", angkatan);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conn.Close();

            GridView1.EditIndex = -1;
            LoadData();
        }

        protected void GridView1_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            conn.Open();

            SqlCommand cmd = new SqlCommand(
            "DELETE FROM mahasiswa WHERE id_mahasiswa=@id",
            conn);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conn.Close();

            LoadData();
        }

    }
}