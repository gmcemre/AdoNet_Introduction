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

namespace AdoNet_Introduction
{
    public partial class KategoriForm : Form
    {
        public KategoriForm()
        {
            InitializeComponent();
        }

        private void KategoriForm_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Server=. ; Database=Northwind ; Integrated Security = true");
            SqlCommand command = new SqlCommand("SELECT * FROM Kategoriler", connection);
            connection.Open();

            SqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                string adi = rdr["KategoriAdi"].ToString();
                string tanimi = rdr["Tanimi"].ToString();
                listBox1.Items.Add(string.Format("{0}-{1}", adi, tanimi));
            }
            connection.Close();
        }
    }
}
