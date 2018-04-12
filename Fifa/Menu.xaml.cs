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

        Int16 userId;
        public Menu(Int16 userId) {
            InitializeComponent();
            this.userId = userId;
            SwapFragment(new AddMatch(userId));
        }

        private void ButtonAddMatch_Click(object sender, RoutedEventArgs e) {
            SwapFragment(new AddMatch(userId));
        }

        private void SwapFragment(UIElement screen) {
            gContent.Children.Clear();
            gContent.Children.Add(screen);
        }

        private void ButtonModifyMatch_Click(object sender, RoutedEventArgs e) {
            SwapFragment(new ModifyMatch(userId));
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e) {
            SwapFragment(new Search(userId));
        }

        private void ButtonAddGoal_Click(object sender, RoutedEventArgs e) {
            SwapFragment(new AddGoal(userId));
        }

        private void ButtonDeleteMatch_Click(object sender, RoutedEventArgs e) {
            SwapFragment(new DeleteMatch());
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void ButtonAddStadium_Click(object sender, RoutedEventArgs e)
        {
            SwapFragment(new AddStadium());
        }
    }
}
