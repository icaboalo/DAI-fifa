using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fifa {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            /*
            User user = new User(tbUsername.Text, tbPassword.Text);
            Int16 userId = user.Login();
            if (userId <= 0) {
                MessageBox.Show("Credenciales incorrectas");
            } else {
                new Menu(userId).Show();
                this.Close();               
            }
            */
            SqlConnection con;
            SqlDataReader dr;
            SqlCommand cmd;
            
            try
            {
                con = Connection.addConnection();
                cmd = new SqlCommand(String.Format("select password from usuario where username= '{0}'", tbUsername.Text), con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr.GetString(0).Trim().Equals(tbPassword.Text))
                    {
                        MessageBox.Show("Contraseña válida");
                        User user = new User(tbUsername.Text, tbPassword.Text);
                        Int16 userId = user.Login();
                        Menu w = new Menu(userId);
                        w.Show();
                        this.Close();
                        
                    }
                    else
                        MessageBox.Show("Contraseña inválida");
                }
                else
                {
                    MessageBox.Show("Usuario incorrecto");
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar --" + ex);
            }
        }
    }
}
