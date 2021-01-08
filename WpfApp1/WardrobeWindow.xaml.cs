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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for WardrobeWindow.xaml
    /// </summary>
    public partial class WardrobeWindow : Window
    {
        public Wardrobe wardrobe;

        public WardrobeWindow()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            wardrobe = new Wardrobe(Int32.Parse(width.Text),
                Int32.Parse(depth.Text),
                Int32.Parse(fullHeight.Text),
                Int32.Parse(angle.Text),
                Int32.Parse(flatTopWidth.Text),
                Int32.Parse(bottomUpstandHeight.Text),
                Int32.Parse(kicker.Text));
            //drawerUnit.getCuttingList(drawerUnit);
        }
    }
}
