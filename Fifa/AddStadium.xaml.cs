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
    /// Lógica de interacción para AddStadium.xaml
    /// </summary>
    public partial class AddStadium : UserControl
    {
        public AddStadium()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Stadium stadium = new Stadium(tbName.Text, double.Parse(tbLat.Text), double.Parse(tbLng.Text), tbAddress.Text);
            if (stadium.saveStadium() > 0)
            {
                MessageBox.Show("Se guardó el estadio");
                tbName.Text = tbLat.Text = tbLng.Text = tbAddress.Text = "";
            } else
            {
                MessageBox.Show("Ocurrió un error al guardar el estadio");
            }
        }
    }
}
