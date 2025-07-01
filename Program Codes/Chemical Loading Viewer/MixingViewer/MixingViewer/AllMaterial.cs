using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace GSrequest
{
    public class AllMaterial
    {
        public static string cs = ConfigurationManager.ConnectionStrings["connectionMYSQL"].ConnectionString;

        // distinct all mat - all shift - RAnge
        public static List<string> _distictMat_all(string from, string to)
        {
            List<string> _material = new List<string>();
            using (MySqlConnection con = new MySqlConnection(cs))
            {
                con.Open();
                string _query = "select distinct MATERIAL_NO from output_tbl where MATERIAL_NO is not null and SYS_DATE_TIME between '" + from + "' and '" + to + "'";
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
        // function for counting All Machine contained material -- RANGE
        public static int _countAll(string from, string to, string material)
        {
            int _material = 0;
            using (MySqlConnection _conn = new MySqlConnection(cs))
            {
                _conn.Open();
                string _query = "select count(*) as CountPerMaterial from output_tbl where material_no ='" + material + "' and SYS_DATE_TIME between '" + from + "' and '" + to + "'";
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