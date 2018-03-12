using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Fifa {
    class Connection {

        private static SqlConnection connection;

		public static SqlConnection addConnection() {
			if (connection == null) {
				// TODO ADD CONNECTION
                connection = new SqlConnection("");
            }
            return connection;
        }

        public static void LoadMatches(ComboBox comboBox) {
            SqlConnection con = addConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT fecha FROM partido;", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                comboBox.Items.Add(new Match(reader.GetInt16(0), new Team(reader.GetInt16(2)), new Team(reader.GetInt16(3)), reader.GetDateTime(1).ToString().Substring(0, 10)));
            }
            con.Close();
        }

        public static void LoadTeams(ComboBox comboBox) {
            SqlConnection con = addConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT fecha FROM equipo;", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                comboBox.Items.Add(new Team(reader.GetInt16(0), reader.GetString(1)));
            }
            con.Close();
        }
    }
}
