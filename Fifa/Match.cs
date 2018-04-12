using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fifa
{
    class Match
    {
        public Int16 id { get; set; }
        private Team local { get; set; }
        private Team visit { get; set; }
        private Stadium stadium { get; set; }
        public String date { get; set; }
        public String scoreBoard { get; set; }
        List<Team> teams;

        public Match(Int16 id, Team local, Team visit, String date, Stadium stadium): this(local, visit, date, stadium) {
            this.id = id;
        }

        public Match(Team local, Team visit, String date, Stadium stadium) {
            this.local = local;
            this.visit = visit;
            this.date = date;
            this.stadium = stadium;
        }

        public Match(String date) {
            this.date = date;
        }

        public List<Team> LoadTeams() {
            this.teams = new List<Team>();
            SqlConnection con = Connection.addConnection();
            // "SELECT * FROM equipo INNER JOIN partido ON equipo.id = partido.idLocal OR partido.idVisitante WHERE partido.fecha = '{0}';"
            SqlCommand cmd = new SqlCommand(String.Format("SELECT equipo.* FROM equipo INNER JOIN partido as p ON p.idLocal = equipo.id OR p.idVisitante = equipo.id WHERE p.id = {0};", this.id), con);
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

            SqlCommand cmd = new SqlCommand(String.Format("INSERT INTO partido VALUES(CONVERT(datetime, '{0}'), {1}, {2}, {5}, {3}, {4})",
                this.date.Substring(6) + "-" + this.date.Substring(2, 4).Replace("/", "") + "-" + this.date.Substring(0, 2), this.local.id, this.visit.id, userId, userId, this.stadium.id), con);

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
            SqlCommand cmd = new SqlCommand(String.Format("UPDATE partido SET fecha = CONVERT(datetime, '{0}'), actualizadoPor = {1} WHERE id = {2}", date.Substring(6) + "-" + date.Substring(2, 4).Replace("/", "") + "-" + date.Substring(0, 2), userId, this.id), con);

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
            
            SqlCommand cmd = new SqlCommand(String.Format("SELECT * FROM partido WHERE fecha = CONVERT(datetime, '{0}')", this.date.Substring(6) + "-" + this.date.Substring(2, 4).Replace("/", "") + "-" + this.date.Substring(0, 2)), con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {
                Match match = new Match(reader.GetInt16(0), new Team(reader.GetInt16(2)), new Team(reader.GetInt16(3)), reader.GetDateTime(1).ToString(), new Stadium(reader.GetInt16(4)));
                match.scoreBoard = match.getScoreboard();
                list.Add(match);
            }

            return list;
        }

        private String getScoreboard() {
            int visitScore = 0, localScore = 0;
            SqlConnection con = Connection.addConnection();
            SqlCommand localCmd = new SqlCommand(String.Format("SELECT COUNT(*) AS count FROM gol INNER JOIN jugador on idJugador = jugador.numero INNER JOIN equipo ON equipo.id = jugador.idEquipo WHERE gol.idPartido = {0} AND equipo.id = {1}", this.id, this.local.id), con);
            SqlCommand visitCmd = new SqlCommand(String.Format("SELECT COUNT(*) AS count FROM gol INNER JOIN jugador on idJugador = jugador.numero INNER JOIN equipo ON equipo.id = jugador.idEquipo WHERE gol.idPartido = {0} AND equipo.id = {1}", this.id, this.visit.id), con);

            SqlDataReader localReader = localCmd.ExecuteReader();
            while (localReader.Read())
            {
                localScore = localReader.GetInt32(0);
            }
            localReader.Close();

            SqlDataReader visitReader = visitCmd.ExecuteReader();            
            while(visitReader.Read()) {
                visitScore = visitReader.GetInt32(0);
            }

            visitReader.Close();
            con.Close();

            return localScore + " - " + visitScore;
        }

        public override string ToString() {
            return this.date;
        }
    }
}
