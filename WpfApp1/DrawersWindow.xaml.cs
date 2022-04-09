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
    /// Interaction logic for DrawersWindow.xaml
    /// </summary>
    public partial class DrawersWindow : Window
    {
        public DrawersWindow()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Drawers unit = new Drawers(Int32.Parse(width.Text),
                Int32.Parse(fullHeight.Text),
                Int32.Parse(kicker.Text),
                Int32.Parse(bottomUpstandHeight.Text),
                Int32.Parse(flatTopWidth.Text),
                Int32.Parse(angle.Text),
                Int32.Parse(drawerNumber.Text),
                Int32.Parse(depth.Text),
                Int32.Parse(drawerSectionWidth.Text));
            unit.getCuttingList(unit);
        }
    }
}
