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

namespace Learn_Chess
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void gen_field_Click(object sender, RoutedEventArgs e)
        {

            grid.Width = 8 * (40);
            grid.Height = 8 * (40);

            for (int row = 1; row <= 8; row++)
            {
                if (row % 2 == 0)
                {
                    for (int column = 1; column <= 8; column++)
                    {
                        Rectangle rec = new Rectangle();
                        rec.Width = 40;
                        rec.Height = 40;
                        rec.HorizontalAlignment = HorizontalAlignment.Center;
                        rec.VerticalAlignment = VerticalAlignment.Center;
                        if ((column % 2) == 0) rec.Fill = System.Windows.Media.Brushes.Beige;
                        if (column % 2 != 0) rec.Fill = System.Windows.Media.Brushes.DarkGray;
                        grid.Children.Add(rec);
                    }
                }
                if (row % 2 != 0)
                {
                    for (int column = 1; column <= 8; column++)
                    {
                        Rectangle rec = new Rectangle();
                        rec.Width = 40;
                        rec.Height = 40;
                        rec.HorizontalAlignment = HorizontalAlignment.Center;
                        rec.VerticalAlignment = VerticalAlignment.Center;
                        if ((column % 2) == 0) rec.Fill = System.Windows.Media.Brushes.DarkGray;
                        if (column % 2 != 0) rec.Fill = System.Windows.Media.Brushes.Beige;
                        grid.Children.Add(rec);
                    }
                }
            }
        }
    }
}
