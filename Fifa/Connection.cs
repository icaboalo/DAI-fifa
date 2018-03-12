using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
