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
        public Int16 id;
        public Team local, visit;
        public String date;
        List<Team> teams;

        public Match(Int16 id, Team local, Team visit, String date): this(local, visit, date) {
            this.id = id;
        }

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
            SqlCommand cmd = new SqlCommand(String.Format("SELECT DISTINCT equipo.* FROM equipo, partido WHERE partido.fecha = '{0}' AND equipo.id = partido.idLocal OR equipo.id = partido.idVisitante", this.date), con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                teams.Add(new Team(reader.GetInt16(0), reader.GetString(1)));
            }
            con.Close();
            return this.teams;
        }

        public int SaveMatch() {
            int res;
            SqlConnection con = Connection.addConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand(String.Format("INSERT INTO partido VALUES('{0}', {1}), {2}))", 
                this.date, this.local.id, this.visit.id), con);

            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int SaveGoal(int minute, Int16 playerId) {
            int res;
            SqlConnection con = Connection.addConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand(String.Format("INSESRT INTO gol VALUES({0}, {1}, {2})", minute, playerId, this.id), con);

            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int UpdateMatch(String date) {
            int res;
            SqlConnection con = Connection.addConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand(String.Format("UPDATE partido SET fecha = '{0}' WHERE id = {1}", date, this.id), con);

            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int DeleteMatch() {
            int res;
            SqlConnection con = Connection.addConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand(String.Format("DELETE FROM partido WHERE id = {0}", this.id), con);

            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public List<Match> SearchMatches() {
            List<Match> list = new List<Match>();

            SqlConnection con = Connection.addConnection();

            SqlCommand cmd = new SqlCommand(String.Format("SELECT * FROM partido WHERE date = '{0}'", this.date), con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {
                list.Add(new Match(reader.GetInt16(0), new Team(reader.GetInt16(1)), new Team(reader.GetInt16(2)), reader.GetString(3)));
            }

            return list;
        }

        public override string ToString() {
            return this.date;
        }
    }
}
