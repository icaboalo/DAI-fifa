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
using System.Windows.Shapes;

namespace Fifa {
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window {
        public Menu() {
            InitializeComponent();
        }

        private void ButtonAddMatch_Click(object sender, RoutedEventArgs e) {
            SwapFragment(new AddMatch());
        }

        private void SwapFragment(UIElement screen) {
            gContent.Children.Clear();
            gContent.Children.Add(screen);
        }

        private void ButtonModifyMatch_Click(object sender, RoutedEventArgs e) {
            SwapFragment(new ModifyMatch());
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e) {
            SwapFragment(new Search());
        }

        private void ButtonAddGoal_Click(object sender, RoutedEventArgs e) {
            SwapFragment(new AddGoal());
        }

        private void ButtonDeleteMatch_Click(object sender, RoutedEventArgs e) {
            SwapFragment(new DeleteMatch());
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
