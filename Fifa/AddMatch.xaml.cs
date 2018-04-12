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
    /// Lógica de interacción para AddMatch.xaml
    /// </summary>
    public partial class AddMatch : UserControl
    {
        Int16 userId;
        public AddMatch(Int16 userId)
        {
            InitializeComponent();
            this.userId = userId;
            Connection.LoadTeams(cbLocal);
            Connection.LoadTeams(cbVisit);
            Connection.LoadStadiums(cbStadium);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (new Match((cbLocal.SelectedItem as Team), (cbVisit.SelectedItem as Team), dpDate.Text, (cbStadium.SelectedItem as Stadium)).SaveMatch(userId) > 0) {
                MessageBox.Show("Partido guardado!");
                cbLocal.SelectedIndex = cbVisit.SelectedIndex = cbStadium.SelectedIndex = 0;

            } else {
                MessageBox.Show("Ocurrió un error al guardar");
            }
        }
    }
}
