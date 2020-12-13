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
using System.Xml;

namespace XMLveriOkuma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int say = 1;
        private void btnXmlOlustur_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-HBD9E76;Initial Catalog=OgrenciTakip;Integrated Security=True";
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Kayit";

            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            string xmlPath = Application.StartupPath + "\\Kayit1.xml";
            XmlTextWriter customer = new XmlTextWriter(xmlPath, UTF8Encoding.UTF8);
            customer.Formatting = Formatting.Indented;

            customer.WriteStartDocument();
            customer.WriteStartElement("Kayit");

            while (dr.Read())
            {
                customer.WriteStartElement("Kayit");
                customer.WriteAttributeString("id", say.ToString());
                customer.WriteElementString("Ad", dr["Ad"].ToString());
                customer.WriteElementString("Soyad", dr["Soyad"].ToString());
                customer.WriteElementString("Sınıf", dr["Sınıf"].ToString());
                customer.WriteElementString("TcNo", dr["TcNo"].ToString());
                customer.WriteElementString("Adres", dr["Adres"].ToString());
                customer.WriteEndElement();
                say++;
            }
            customer.WriteEndDocument();
            customer.Close();

        }
    }
}
