﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fifa {
    class Connection {

		public static SqlConnection addConnection() {
            SqlConnection connection;
			try {
                connection = new SqlConnection("Data Source=localhost;Initial Catalog=fifa;Integrated Security=True");
                connection.Open();
            } catch (Exception e)
            {
                connection = null;
                MessageBox.Show("No se pudo conectar " + e.Message);
            }
            
            return connection;
        }

        public static void LoadMatches(ComboBox comboBox) {
            SqlConnection con = addConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM partido;", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                comboBox.Items.Add(new Match(reader.GetInt16(0), new Team(reader.GetInt16(2)), new Team(reader.GetInt16(3)), reader.GetDateTime(1).ToString().Substring(0, 10), new Stadium(reader.GetInt16(4))));
            }
            con.Close();
        }

        public static void LoadTeams(ComboBox comboBox) {
            SqlConnection con = addConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM equipo;", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                comboBox.Items.Add(new Team(reader.GetInt16(0), reader.GetString(1)));
            }
            con.Close();
        }

        public static void LoadStadiums(ComboBox comboBox)
        {
            SqlConnection con = addConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM estadio;", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox.Items.Add(new Stadium(reader.GetInt16(0), reader.GetString(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetString(4)));
            }
            con.Close();
        }
    }
}
