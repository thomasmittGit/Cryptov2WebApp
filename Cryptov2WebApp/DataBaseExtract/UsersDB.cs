using Cryptov2WebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Cryptov2WebApp.WorkClasses;
using System.Data;

namespace Cryptov2WebApp.DataBaseExtract
{
    public class UsersDB
    {
        private static String connString = ConfigurationManager.ConnectionStrings["API"].ToString();

        public static Users ValidateLogin(String usuario, String senha)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                String QUERY = "SELECT TOP(1) * FROM [API].[dbo].[Users] WHERE [username] = '" + usuario + "' AND [senha] = '" + senha + "'";
                SqlCommand cmd = new SqlCommand(QUERY, conn);

                conn.Open();

                Users user = null;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        user = new Users();
                        user.id = (Int32)dt.Rows[0]["id"];
                        user.username = dt.Rows[0]["username"].ToString();
                        user.senha = dt.Rows[0]["senha"].ToString();
                        user.apiKey = (Int32)dt.Rows[0]["apiKey"];
                    }
                }

                SessionVariables.usuarioLogado = user;

                conn.Close();
                return user;
            }
        }
    }
}