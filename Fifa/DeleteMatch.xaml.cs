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

namespace Fifa {
    /// <summary>
    /// Lógica de interacción para DeleteMatch.xaml
    /// </summary>
    public partial class DeleteMatch : UserControl {
        public DeleteMatch() {
            InitializeComponent();
            Connection.LoadMatches(cbMatch);
        }

        private void ButtonDeleteMatch_Click(object sender, RoutedEventArgs e) {
            if ((cbMatch.SelectedItem as Match).DeleteMatch() > 0) {
                MessageBox.Show("Partido borrado!");
            } else {
                MessageBox.Show("Ocurrió un error al eliminar");
            }
        }
    }
}
