using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifa
{
    class Stadium
    {
        public int id;
        public double lat { get; set; }
        public double lng { get; set; }
        public String name { get; set; }
        public String address { get; set; }

        public Stadium(int id)
        {
            this.id = id;
        }

        public Stadium(String name, double lat, double lng, String address)
        {
            this.name = name;
            this.lat = lat;
            this.lng = lng;
            this.address = address;
        }
        public Stadium(int id, String name, double lat, double lng, String address)
        {
            this.id = id;
            this.name = name;
            this.lat = lat;
            this.lng = lng;
            this.address = address;
        }
        public Stadium(double lat, double lng, String address)
        {
            this.lat = lat;
            this.lng = lng;
            this.address = address;
        }
        public Stadium(String name)
        {
            this.name = name;
        }

        public int saveStadium()
        {
            int res = 0;
            SqlConnection con = Connection.addConnection();
            if (con != null)
            {
                SqlCommand cmd = new SqlCommand(String.Format("INSERT INTO estadio VALUES('{0}', {1}, {2}, '{3}')", this.name, this.lat, this.lng, this.address), con);
                res = cmd.ExecuteNonQuery();
            }

            return res;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
