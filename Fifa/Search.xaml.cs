using System;
using System.Collections.Generic;
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

namespace Fifa
{
    /// <summary>
    /// Lógica de interacción para Search.xaml
    /// </summary>
    public partial class Search : UserControl
    {
        public Search()
        {
            InitializeComponent();
            cbSelection.Items.Add("Partido");
            cbSelection.Items.Add("Jugador");
            cbSelection.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cbSelection.SelectedItem.ToString() == "Partido") {
                lbName.Visibility = Visibility.Hidden;
                tbName.Visibility = Visibility.Hidden;
                lbDate.Visibility = Visibility.Visible;
                dpDate.Visibility = Visibility.Visible;
            } else if (cbSelection.SelectedItem.ToString() == "Jugador") {
                lbName.Visibility = Visibility.Visible;
                tbName.Visibility = Visibility.Visible;
                lbDate.Visibility = Visibility.Hidden;
                dpDate.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            switch(cbSelection.SelectedItem.ToString()) {
                case "Partido":
                    List<Match> matchList = new Match(dpDate.Text).SearchMatches();
                    dgResult.ItemsSource = matchList;
                    if (matchList.Count() == 0)
                    {
                        MessageBox.Show("No habia datos");
                    }
                    break;
                case "Jugador":
                    List<Player> playerList = new Player(tbName.Text).SearchPlayers();
                    dgResult.ItemsSource = playerList;
                    if (playerList.Count() == 0)
                    {
                        MessageBox.Show("No habia datos");
                    }
                    break;
            }
        }
    }
}
