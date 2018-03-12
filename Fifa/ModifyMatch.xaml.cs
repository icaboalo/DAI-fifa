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
    /// Lógica de interacción para ModifyMatch.xaml
    /// </summary>
    public partial class ModifyMatch : UserControl
    {
        public ModifyMatch()
        {
            InitializeComponent();
            Connection.LoadMatches(cbMatch);
        }

        private void tbModificar_Click(object sender, RoutedEventArgs e) {
            if ((cbMatch.SelectedItem as Match).UpdateMatch(dpDate.Text) > 0) {
                MessageBox.Show("Se actualizó el partido!");
            } else {
                MessageBox.Show("Ocurrió un error al guardar");
            }
        }
    }
}
