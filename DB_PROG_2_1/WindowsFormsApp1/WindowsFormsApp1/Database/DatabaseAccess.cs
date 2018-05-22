using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1.Database
{
    public class DatabaseAccess
    {

        SqlConnection _conn2;


        public List<string> RefreshList(string command, out List<int> ID_Index)
        {
            List<string> _databaselist = new List<string>();
            List<int> _index = new List<int>();

            dbinitn();

            using (SqlConnection _conn = new SqlConnection(GetConnString()))
            {
                SqlCommand cmdsql = new SqlCommand(command, _conn);
                _conn.Open();
       

                SqlDataReader reader = cmdsql.ExecuteReader();
                while (reader.Read())
                {
                    _index.Add(Int32.Parse(reader[0].ToString()));
                    _databaselist.Add($"{reader[1].ToString()} , {reader[2].ToString()}");
                }
                reader.Close();
            }
            ID_Index = _index;

            return _databaselist;
        }

        public void dbinitn()
        {
            _conn2 = new SqlConnection(GetConnString());
        }

        public List<string> ShowData(int iD)
        {
            string _command = $"SELECT * FROM Personen WHERE ID = {iD}";
            List<string> _data = new List<string>();
            

            using (SqlConnection _conn = new SqlConnection(GetConnString()))
            {
                SqlCommand cmdsql = new SqlCommand(_command, _conn);
                _conn.Open();

                SqlDataReader reader = cmdsql.ExecuteReader();
                while (reader.Read())
                {
                    _data.Add(reader[1].ToString());
                    _data.Add(reader[2].ToString());
                    _data.Add(reader[3].ToString());
                    _data.Add(reader[4].ToString());
                    _data.Add(reader[5].ToString());
                    _data.Add(reader[6].ToString());
                }
                reader.Close();
            }
            return _data;
        }

        public string GetConnString()
        {
            return ConfigurationManager.AppSettings["ConnString"];
           
        }

    }
}
