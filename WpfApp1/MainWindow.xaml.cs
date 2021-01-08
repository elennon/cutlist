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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public understairDrawerUnit drawerUnit;
        public MainWindow()
        {
            InitializeComponent();
        }

        

        public int DrawerCount(string drawers)
        {
            if (drawers.Contains("3"))
                return 3;
            else
                if (drawers.Contains("5"))
                return 5;
            return 6;
        }

        private void wardrobeCheck_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wardrobePage());
        }

        private void onlyDrawersCheck_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Page2());
        }

        private void drawerandTallCheck_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Page2());
        }
    }
}
