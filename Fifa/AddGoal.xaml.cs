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
    /// Lógica de interacción para AddGol.xaml
    /// </summary>
    public partial class AddGoal : UserControl
    {
        public AddGoal()
        {
            InitializeComponent();
            cbPlayer.Items.Add("Selecciona una opción");
            cbPlayer.IsEnabled = false;
            cbTeam.Items.Add("Selecciona una opción");
            cbTeam.IsEnabled = false;
            cbMatch.Items.Add("Selecciona una opción");
        }

        private void cbPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void cbMatch_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cbMatch.SelectedIndex > 0) {
                Match match = new Match(cbMatch.SelectedItem.ToString());

                cbTeam.Items.Clear();
                cbTeam.Items.Add("Selecciona una opción");

                List<Team> teams = match.LoadTeams();
                for (int i = 0; i < teams.Count(); i++) {
                    cbTeam.Items.Add(teams[i].name);
                }
                cbTeam.IsEnabled = true;
            } else {
                cbPlayer.IsEnabled = false;
                cbTeam.IsEnabled = false;
            }
        }

        private void cbTeam_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cbTeam.SelectedIndex > 0) {
                Team team = new Team(cbTeam.SelectedItem.ToString());
                cbPlayer.Items.Clear();
                cbPlayer.Items.Add("Selecciona una opción");
                List<Player> players = team.LoadPlayers();
                for (int i = 0; i < players.Count(); i++) {
                    cbPlayer.Items.Add(players[i].name);
                }
                cbPlayer.IsEnabled = true;
            }
            else {
                cbPlayer.IsEnabled = false;
            }
        }
    }
}
