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
        public Int16 id { get; set; }
        private Team local { get; set; }
        private Team visit { get; set; }
        public String date { get; set; }
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
            // "SELECT * FROM equipo INNER JOIN partido ON equipo.id = partido.idLocal OR partido.idVisitante WHERE partido.fecha = '{0}';"
            SqlCommand cmd = new SqlCommand(String.Format("SELECT DISTINCT equipo.* FROM equipo, partido WHERE partido.fecha = '{0}' AND equipo.id = partido.idLocal OR equipo.id = partido.idVisitante", this.date), con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                teams.Add(new Team(reader.GetInt16(0), reader.GetString(1)));
            }
            con.Close();
            return this.teams;
        }

        public int SaveMatch(Int16 userId) {
            int res;
            SqlConnection con = Connection.addConnection();

            SqlCommand cmd = new SqlCommand(String.Format("INSERT INTO partido VALUES('{0}', {1}, {2}, {3}, {4})", 
                this.date, this.local.id, this.visit.id, userId, userId), con);

            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int SaveGoal(int minute, Int16 playerId, Int16 userId) {
            int res;
            SqlConnection con = Connection.addConnection();

            SqlCommand cmd = new SqlCommand(String.Format("INSERT INTO gol VALUES({0}, {1}, {2}, {3})", minute, playerId, this.id, userId), con);

            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int UpdateMatch(String date, Int16 userId) {
            int res;
            SqlConnection con = Connection.addConnection();

            SqlCommand cmd = new SqlCommand(String.Format("UPDATE partido SET fecha = '{0}', actualizadoPor = {1} WHERE id = {2}", date, userId, this.id), con);

            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int DeleteMatch() {
            int res;
            SqlConnection con = Connection.addConnection();

            SqlCommand cmd = new SqlCommand(String.Format("DELETE FROM partido WHERE id = {0}", this.id), con);

            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public List<Match> SearchMatches() {
            List<Match> list = new List<Match>();

            SqlConnection con = Connection.addConnection();

            SqlCommand cmd = new SqlCommand(String.Format("SELECT * FROM partido WHERE fecha = CONVERT(datetime, '{0}')", this.date), con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {
                list.Add(new Match(reader.GetInt16(0), new Team(reader.GetInt16(2)), new Team(reader.GetInt16(3)), reader.GetDateTime(1).ToString().Substring(0, 10)));
            }

            return list;
        }

        private String getScoreboard(Int16 matchId, Int16 localId, Int16 visitId) {
            int visitScore = 0, localScore = 0;
            SqlConnection con = Connection.addConnection();
            SqlCommand localCmd = new SqlCommand(String.Format("SELECT COUNT(*) FROM gol INNER JOIN jugador on idJugador = jugador.numero INNER JOIN equipo ON equipo.id = jugador.idEquipo WHERE gol.idPartido = {0} AND equipo.id = {1}", matchId, localId), con);
            SqlCommand visitCmd = new SqlCommand(String.Format("SELECT COUNT(*) FROM gol INNER JOIN jugador on idJugador = jugador.numero INNER JOIN equipo ON equipo.id = jugador.idEquipo WHERE gol.idPartido = {0} AND equipo.id = {1}", matchId, visitId), con);

            SqlDataReader localReader = localCmd.ExecuteReader();
            SqlDataReader visitReader = visitCmd.ExecuteReader();

            while(localReader.Read()) {
                localScore = localReader.GetInt16(0);
            }
            while(visitReader.Read()) {
                visitScore = visitReader.GetInt16(0);
            }

            return localScore + " - " + visitScore;
        }

        public override string ToString() {
            return this.date;
        }
    }
}
