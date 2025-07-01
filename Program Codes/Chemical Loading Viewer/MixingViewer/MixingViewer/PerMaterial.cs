using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace GSrequest
{
    public class PerMaterial
    {
        // distinct material per machine - all shift
        public static string cs = ConfigurationManager.ConnectionStrings["connectionMYSQL"].ConnectionString;
        public static List<string> _distictPerMat_all(string datex, string machine)
        {
            List<string> _material = new List<string>();
            using (MySqlConnection con = new MySqlConnection(cs))
            {
                con.Open();
                string _query = "select distinct MATERIAL_NO from output_tbl where MATERIAL_NO is not null " + datex + " and MACHINE_NAME='" + machine + "'";
                using (MySqlCommand _cmd = new MySqlCommand(_query, con))
                {
                    MySqlDataReader _rd = _cmd.ExecuteReader();

                    while (_rd.Read())
                    {
                        _material.Add(_rd["MATERIAL_NO"].ToString());
                    }
                    _rd.Close();
                    _rd.Dispose();
                }
                con.Close();
                con.Dispose();
            }
            return _material;
        }

        // count material per machine - all shift
        public static int _countPerMaterial(string datex, string material, string machine)
        {
            int _material = 0;
            using (MySqlConnection _conn = new MySqlConnection(cs))
            {
                _conn.Open();
                string _query = "select count(*) as CountPerMaterial from output_tbl where MATERIAL_NO = '" + material + "' " + datex + " and MACHINE_NAME='" + machine + "'";
                using (MySqlCommand _cmd = new MySqlCommand(_query, _conn))
                {
                    MySqlDataReader _rd = _cmd.ExecuteReader();

                    if (_rd.Read())
                    {
                        _material = (Convert.ToInt32(_rd["CountPerMaterial"].ToString()));
                    }
                    _rd.Close();
                    _rd.Dispose();
                }
                _conn.Close();
                _conn.Dispose();
            }
            return _material;
        }
    }
}