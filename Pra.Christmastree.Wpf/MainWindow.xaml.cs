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

namespace Pra.Christmastree.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartSituation();
        }
        private void StartSituation()
        {
            btnStartChristmas.IsEnabled = true;
            btnReleaseHavoc.IsEnabled = false;
        }
        private void ChristmasSituation()
        {
            btnReleaseHavoc.IsEnabled = true;
            btnStartChristmas.IsEnabled = false;

        }
        private void btnStartChristmas_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnReleaseHavoc_Click(object sender, RoutedEventArgs e)
        {
        }

        private void rdbAll_Checked(object sender, RoutedEventArgs e)
        {
            if (!this.IsLoaded) return;
        }

        private void rdbBaubles_Checked(object sender, RoutedEventArgs e)
        {
            if (!this.IsLoaded) return;
        }

        private void rdbCookies_Checked(object sender, RoutedEventArgs e)
        {
            if (!this.IsLoaded) return;
        }

        private void rdbLights_Checked(object sender, RoutedEventArgs e)
        {
            if (!this.IsLoaded) return;
        }


    }
}
