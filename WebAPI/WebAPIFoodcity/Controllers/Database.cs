using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAPIFoodcity.Models;

namespace WebAPIFoodcity.Controllers
{
    public class Database
    {
        public static DataTable Read_Table(string StoredProcedureName, Dictionary<string, object> dic_param = null)
        {
            string SQLconnectionString = ConfigurationManager.ConnectionStrings["Connectionstringfoodcity"].ConnectionString;
            DataTable result = new DataTable("table1");
            using (SqlConnection conn = new SqlConnection(SQLconnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandText = StoredProcedureName;
                cmd.CommandType = CommandType.StoredProcedure;
                if (dic_param != null)
                {
                    foreach (KeyValuePair<string, object> data in dic_param)
                    {
                        if (data.Value == null)
                        {
                            cmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                        }
                    }
                }
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return result;
        }


        public static object Exec_Command(string StoredProcedureName, Dictionary<string, object> dic_param = null)
        {
            string SQLconnectionString = ConfigurationManager.ConnectionStrings["Connectionstringfoodcity"].ConnectionString;
            object result = null;
            using (SqlConnection conn = new SqlConnection(SQLconnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandText = StoredProcedureName;
                cmd.CommandType = CommandType.StoredProcedure;
                if (dic_param != null)
                {
                    foreach (KeyValuePair<string, object> data in dic_param)
                    {
                        if (data.Value == null)
                        {
                            cmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                        }
                    }
                }
                cmd.Parameters.Add("@CurrentID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    cmd.ExecuteNonQuery();
                    result = cmd.Parameters["@CurrentID"].Value;
                    // Attempt to commit the transaction.



                }
                catch (Exception ex)
                {



                    result = null;
                }



            }
            return result;
        }

        public static DataTable getRestaurant()
        {
            DataTable tb = Read_Table("getRestaurant");
            return tb;
        }

        public static Restaurant getRestaurant(string id)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("rsdt", id);
            DataTable tb = Read_Table("getRestaurantId", param);
            Restaurant res = new Restaurant();
            if (tb.Rows.Count > 0)
            {
                res.rsdt = (tb.Rows[0]["rsdt"].ToString());
                res.rname = (tb.Rows[0]["rname"].ToString());
                res.raddress = (tb.Rows[0]["raddress"].ToString());
                res.rtype = int.Parse(tb.Rows[0]["rtype"].ToString());
                res.hurl = (tb.Rows[0]["hurl"].ToString());
            }
            else
            {
                res.rsdt = "0";
            }
            return res;
        }

        public static DataTable getAdvertisement()
        {
            DataTable tb = Read_Table("getAdvertisement");
            return tb;
        }

        public static DataTable getFood()
        {
            DataTable tb = Read_Table("getFood");
            return tb;
        }

        public static DataTable getFoodByResId(string id)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("rsdt", id);
            DataTable tb = Read_Table("getFoodByResId", param);
            return tb;
        }

        public static DataTable getFoodtype(int id)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("ftype", id);
            DataTable tb = Read_Table("getFoodtype", param);
            return tb;
        }

        public static DataTable getFoodText(string text)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("fname", text);
            DataTable tb = Read_Table("getFoodByText", param);
            return tb;
        }

        public static DataTable getReviewByResId(string id)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("rsdt", id);
            DataTable tb = Read_Table("getReviewByResId", param);
            return tb;
        }

        public static User getUser(string sdt, string pass)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("usdt", sdt);
            param.Add("upassword", pass);
            DataTable tb = Read_Table("getUser", param);
            User user = new User();
            if (tb.Rows.Count > 0)
            {
                user.usdt = tb.Rows[0]["usdt"].ToString();
                user.uavatar = tb.Rows[0]["uavatar"].ToString();
                user.uname = tb.Rows[0]["uname"].ToString();
                user.uaddress = tb.Rows[0]["uaddress"].ToString();
            }
            else
                user.usdt = "0";
            return user;
        }

        public static User AddUser(User nd)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("usdt", nd.usdt);
            param.Add("uavatar", nd.uavatar);
            param.Add("uname", nd.uname);
            param.Add("uaddress", nd.uaddress);
            param.Add("upassword", nd.upassword);

            string kq = (Exec_Command("setUser", param).ToString());

            if (kq != "-1")
            {
                return nd;
            }
            else
            {
                nd.usdt = kq;
                return nd;
            }

            
        }
    }
}