using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifa
{
    class Team
    {
        public Int16 id;
        public String name;
        public List<Player> players;

        public Team(String name) {
            this.name = name;
        }

        public Team(Int16 id, String name): this(name) {
            this.id = id;
        }

        public List<Player> LoadPlayers() {
            this.players = new List<Player>();
            SqlConnection con = Connection.addConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(String.Format("SELECT jugador.* FROM jugador INNER JOIN equipo ON jugador.idEquipo = equipo.id WHERE equipo.nombre = '{0}';", this.name), con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                players.Add(new Player(reader.GetInt16(0), reader.GetString(1), reader.GetString(2), reader.GetInt16(3)));
            }

            return this.players;
        }
    }
}
