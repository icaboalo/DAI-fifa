using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifa
{
    class Match
    {
        Team local, visit;
        String date;
        List<Team> teams;

        public Match(Team local, Team visit, String date) {
            this.local = local;
            this.visit = visit;
            this.date = date;
        }

        public Match(String date) {
            this.date = date;
        }

        public List<Team> LoadTeams() {
            this.teams = new List<Team>();
            SqlConnection con = Connection.addConnection();
            con.Open();
            // "SELECT * FROM equipo INNER JOIN partido ON equipo.id = partido.idLocal OR partido.idVisitante WHERE partido.fecha = '{0}';"
            SqlCommand cmd = new SqlCommand(String.Format("SELECT equipo.* FROM equipo, partido WHERE partido.fecha = '{0}' AND equipo.id = partido.idLocal OR equipo.id = partido.Visitante", this.date), con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                teams.Add(new Team(reader.GetInt16(0), reader.GetString(1)));
            }
            con.Close();
            return this.teams;
        }

        public int SaveMatch(String localName, String visitName, String date) {
            int res;
            SqlConnection con = Connection.addConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand(String.Format("INSERT INTO partido VALUES('{0}', (SELECT id FROM equipo WHERE nombre = '{1}'), (SELECT id From equipo WHERE nombre = '{2}'))", 
                date, localName, visitName), con);

            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }
}
