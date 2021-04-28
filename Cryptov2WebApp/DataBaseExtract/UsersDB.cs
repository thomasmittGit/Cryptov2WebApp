using Cryptov2WebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Cryptov2WebApp.WorkClasses;

namespace Cryptov2WebApp.DataBaseExtract
{
    public static class UsersDB
    {
        private static String connString = ConfigurationManager.ConnectionStrings["API"].ToString();

        public static Users ValidateLogin(String usuario, String senha)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                String QUERY = "SELECT TOP(1) * FROM [API].[dbo].[Users] WHERE [username] = '" + usuario + "' AND[senha] = '" + usuario + "'";

                SqlCommand cmd = new SqlCommand(QUERY, conn);

                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                Users user = null;
                if (dr.HasRows)
                {
                    user = new Users();
                    user.id = (Int32)dr.GetValue(1);
                    user.username = (String)dr.GetValue(2);
                    user.senha = (String)dr.GetValue(3);
                    user.apiKey = (Int32)dr.GetValue(4);
                }

                SessionVariables.usuarioLogado = user;

                conn.Close();
                return user;
            }
        }
    }
}