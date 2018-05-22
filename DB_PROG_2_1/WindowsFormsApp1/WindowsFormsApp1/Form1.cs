using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using WindowsFormsApp1.Database;

namespace WindowsFormsApp1
{
    public partial class Personalverwaltung : Form
    {

        string connectstring;
        public DatabaseAccess _acess = new DatabaseAccess();
        public List<int> _indexlist = new List<int>();
        public int _lastID;       


        public Personalverwaltung()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshDataList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlconnection = new SqlConnection(connectstring))
            {
                sqlconnection.Open();
                button1.BackColor = Color.Green;
                sqlconnection.Close();
            }
               
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string conctstring = @"Provider=sqloledb;Data Source=NB3004\SQLEXPRESS;" +
                            "Initial Catalog=Mitarbeiter;Integrated Security='SSPI'";


            string insertstring = "INSERT INTO Personen" +
                                 "(Name, Vorname, Strasse, PLZ, Ort, Telefon) VALUES (?, ?, ?, ?, ?, ?)";

            OleDbCommand cmd = new OleDbCommand(insertstring);

            cmd.Parameters.AddWithValue("@Name", "Meier");
            cmd.Parameters.AddWithValue("@Vorname", textBox2.Text);
            cmd.Parameters.AddWithValue("@Strasse", textBox3.Text);
            cmd.Parameters.AddWithValue("@PLZ", Int32.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@Ort", textBox5.Text);
            cmd.Parameters.AddWithValue("@Telefon", textBox6.Text);




            using (OleDbConnection conn = new OleDbConnection(conctstring))
            {
                conn.Open();
                cmd.Connection = conn;

                cmd.ExecuteNonQuery();

                button2.BackColor = Color.Green;
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string conctstring = @"Data Source=NB3004\SQLEXPRESS;" +
                            "Initial Catalog=Mitarbeiter;Integrated Security = true";


            string insertstring = "INSERT INTO Personen" +
                                 "(Name, Vorname, Strasse, PLZ, Ort, Telefon) VALUES (@Name, @Vorname, @Strasse, @PLZ, @Ort, @Telefon)";


            SqlCommand cmdsql = new SqlCommand(insertstring);

            cmdsql.Parameters.AddWithValue("@Name", textBox1.Text);
            cmdsql.Parameters.AddWithValue("@Vorname", textBox2.Text);
            cmdsql.Parameters.AddWithValue("@Strasse", textBox3.Text);
            cmdsql.Parameters.AddWithValue("@PLZ", Int32.Parse(textBox4.Text));
            cmdsql.Parameters.AddWithValue("@Ort", textBox5.Text);
            cmdsql.Parameters.AddWithValue("@Telefon", textBox6.Text);




            using (SqlConnection conn = new SqlConnection(conctstring))
            {
                conn.Open();
                cmdsql.Connection = conn;

                cmdsql.ExecuteNonQuery();

                button3.BackColor = Color.Green;
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string conctstring = @"Data Source=NB3004\SQLEXPRESS;" +
                            "Initial Catalog=Mitarbeiter;Integrated Security = true";
            int index;
            string[,] result = new string[2,10];
            object[] resultrow = new object[10];

            string insertstring = "SELECT * FROM Personen WHERE PLZ = 1";

            using (SqlConnection conn = new SqlConnection(conctstring))
            {
                SqlCommand cmdsql = new SqlCommand(insertstring, conn);
                conn.Open();

                SqlDataReader reader = cmdsql.ExecuteReader();
                index = 0;
                while (reader.Read())
                {
                    reader.GetValues(resultrow);
                    result[index,0] = reader[0].ToString();
                    result[index,1] = reader[1].ToString();
                    result[index,2] = reader[2].ToString();
                    result[index,3] = reader[3].ToString();
                    result[index,4] = reader[4].ToString();
                    result[index,5] = reader[5].ToString();
                    index++;
                }
                reader.Close();
            }

            textBox1.Text = (string)resultrow[0];
            button4.BackColor = Color.Green;
        }

        
        void RefreshDataList()
        {
            LstBx_Daten.DataSource = null;
            LstBx_Daten.DataSource = _acess.RefreshList("SELECT * FROM Personen", out _indexlist);

            _lastID = _indexlist.Max();

            Lbl_LastIndex.Text = _lastID.ToString();
        }


        void SearchDataSets(string searchstr)
        {
            LstBx_Daten.DataSource = null;
            LstBx_Daten.DataSource = _acess.RefreshList($"SELECT * FROM Personen WHERE Vorname LIKE '%{searchstr}%'", out _indexlist);
        }

        private void LstBx_Daten_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(LstBx_Daten.SelectedIndex != -1)
            { 
                List<string> _list = new List<string>();

                _list = _acess.ShowData(_indexlist[LstBx_Daten.SelectedIndex]);

                TxtBx_Vorname.Text = _list[0];
                TxtBx_Name.Text = _list[1];
                TxtBx_Strasse.Text = _list[2];
                TxtBx_PLZ.Text = _list[3];
                TxtBx_Ort.Text = _list[4];
                TxtBx_Telefon.Text = _list[5];
            }

        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            SearchDataSets(TxtBx_Suchen.Text);
        }
    }
}
