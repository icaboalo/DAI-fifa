using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fifa {
    class User {

        String username, password;

        public User(String username, String password) {
            this.username = username;
            this.password = password;
        }

        private String hashPassword(String password) {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < hash.Length; i++) {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

        public bool Login() {
            SqlConnection con = Connection.addConnection();

            SqlCommand cmd = new SqlCommand(String.Format("SELECT password FROM usuario WHERE username = '{0}'", 
                this.username), con);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            
            // if (reader.GetString(0) != hashPassword(this.password)) {
            if (reader.GetString(0) != this.password) { 
                con.Close();
                return false;
            }

            con.Close();
            return true;
        }
    }
}
