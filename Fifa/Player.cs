using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifa
{
    class Player
    {
        public Int16 id { get; set; }
        public Int16 num { get; set; }
        public String name { get; set; }
        public String position { get; set; }
        public Int16 teamId { get; set; }
        public int goalCount { get; set; }

        public Player(Int16 id, Int16 num, String name, String position, Int16 teamId) {
            this.num = num;
            this.name = name;
            this.position = position;
            this.teamId = teamId;
        }

        public Player(String name) {
            this.name = name;
        }

        public List<Player> SearchPlayers() {
            List<Player> list = new List<Player>();
            SqlConnection con = Connection.addConnection();

            SqlCommand cmd = new SqlCommand(String.Format("SELECT * FROM jugador WHERE nombre LIKE '%{0}%'", this.name), con);
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read()) {
                Player player = new Player(reader.GetInt16(0), reader.GetInt16(1), reader.GetString(2), reader.GetString(3), reader.GetInt16(4));
                player.goalCount = player.getGoalCount();
                list.Add(player);
            }
            con.Close();
            return list;
        }

        public int getGoalCount() {
            int count = 0;
            SqlConnection con = Connection.addConnection();

            SqlCommand cmd = new SqlCommand(String.Format("SELECT COUNT(*) FROM gol WHERE idJugador = {0}", this.id), con);

            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read()) {
                count = reader.GetInt16(0);
            }

            return count;
        }

        public override string ToString() {
            return this.num + " - " + this.name;
        }
    }
}
