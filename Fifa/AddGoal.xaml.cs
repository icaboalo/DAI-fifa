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

        Int16 userId;
        public AddGoal(Int16 userId)
        {
            InitializeComponent();
            this.userId = userId;
            cbPlayer.Items.Add("Selecciona una opción");
            cbPlayer.IsEnabled = false;
            cbPlayer.SelectedIndex = 0;
            cbTeam.Items.Add("Selecciona una opción");
            cbTeam.IsEnabled = false;
            cbTeam.SelectedIndex = 0;
            cbMatch.Items.Add("Selecciona una opción");
            cbMatch.SelectedIndex = 0;

            Connection.LoadMatches(cbMatch);
        }

        private void cbPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        }

        private void cbMatch_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cbMatch.SelectedIndex > 0) {
                Match match = cbMatch.SelectedItem as Match;

                cbTeam.Items.Clear();
                cbTeam.Items.Add("Selecciona una opción");
                cbTeam.SelectedIndex = 0;

                List<Team> teams = match.LoadTeams();
                for (int i = 0; i < teams.Count(); i++) {
                    cbTeam.Items.Add(teams[i]);
                }
                cbTeam.IsEnabled = true;
            } else {
                cbPlayer.IsEnabled = false;
                cbTeam.IsEnabled = false;
            }
        }

        private void cbTeam_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cbTeam.SelectedIndex > 0) {
                Team team = cbTeam.SelectedItem as Team;
                cbPlayer.Items.Clear();
                cbPlayer.Items.Add("Selecciona una opción");
                cbPlayer.SelectedIndex = 0;
                List<Player> players = team.LoadPlayers();
                for (int i = 0; i < players.Count(); i++) {
                    cbPlayer.Items.Add(players[i]);
                }
                cbPlayer.IsEnabled = true;
            }
            else {
                cbPlayer.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((cbMatch.SelectedItem as Match).SaveGoal(int.Parse(tbMinute.Text), (cbPlayer.SelectedItem as Player).id, userId) > 0)
            {
                MessageBox.Show("Gol registrado!");
            }
            else
            {
                MessageBox.Show("Ocurrió un error al guardar");
            }
        }
    }
}
