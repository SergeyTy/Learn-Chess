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
        BitmapImage W_pawn = new BitmapImage(new Uri(@"pack://application:,,,/Images/Б_Пешка.png", UriKind.Absolute));
        BitmapImage B_pawn = new BitmapImage(new Uri(@"pack://application:,,,/Images/Ч_Пешка.png", UriKind.Absolute));
        BitmapImage W_knight = new BitmapImage(new Uri(@"pack://application:,,,/Images/Б_Конь.png", UriKind.Absolute));
        BitmapImage B_knight = new BitmapImage(new Uri(@"pack://application:,,,/Images/Ч_Конь.png", UriKind.Absolute));
        BitmapImage W_bishop = new BitmapImage(new Uri(@"pack://application:,,,/Images/Б_Слон.png", UriKind.Absolute));
        BitmapImage B_bishop = new BitmapImage(new Uri(@"pack://application:,,,/Images/Ч_Слон.png", UriKind.Absolute));
        BitmapImage W_castle = new BitmapImage(new Uri(@"pack://application:,,,/Images/Б_Ладья.png", UriKind.Absolute));
        BitmapImage B_castle = new BitmapImage(new Uri(@"pack://application:,,,/Images/Ч_Ладья.png", UriKind.Absolute));
        BitmapImage W_king = new BitmapImage(new Uri(@"pack://application:,,,/Images/Б_Король.png", UriKind.Absolute));
        BitmapImage B_king = new BitmapImage(new Uri(@"pack://application:,,,/Images/Ч_Король.png", UriKind.Absolute));
        BitmapImage W_queen = new BitmapImage(new Uri(@"pack://application:,,,/Images/Б_Ферзь.png", UriKind.Absolute));
        BitmapImage B_queen = new BitmapImage(new Uri(@"pack://application:,,,/Images/Ч_Ферзь.png", UriKind.Absolute));

        public MainWindow()
        {
            InitializeComponent();
        }



        private void gen_field_Click(object sender, RoutedEventArgs e)
        {
            //grid.Children.Clear();

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

        private void checkers_placement_Click(object sender, RoutedEventArgs e)
        {

            placement.Children.Clear();

            for (int i = 1; i <= 64; i++)
            {
                Image Pawn = new Image();
                if (i <= 8)
                {
                    if (i % 2 == 0)
                    {
                        Pawn.Source = B_pawn;
                    }
                }
                else if ((8 < i) && (i <= 16))
                {
                    if (i % 2 != 0)
                    {
                        Pawn.Source = B_pawn;
                    }
                }
                else if ((16 < i) && (i <= 24))
                {
                    if (i % 2 == 0)
                    {
                        Pawn.Source = B_pawn;
                    }
                }
                else if ((40 < i) && (i <= 48))
                {
                    if (i % 2 != 0)
                    {
                        Pawn.Source = W_pawn;
                    }
                }
                else if ((48 < i) && (i <= 56))
                {
                    if (i % 2 == 0)
                    {
                        Pawn.Source = W_pawn;
                    }
                }
                else if ((56 < i) && (i <= 64))
                {
                    if (i % 2 != 0)
                    {
                        Pawn.Source = W_pawn;
                    }
                }
                placement.Children.Add(Pawn);
            }
        }

        private void chess_placement_Click(object sender, RoutedEventArgs e)
        {
            placement.Children.Clear();
            for (int i = 1; i <= 64; i++)
            {
                Image Pieces = new Image();

                if ((i == 1) | (i == 8))
                {
                    Pieces.Source = B_castle;
                }
                else if ((i == 2) | (i == 7))
                {
                    Pieces.Source = B_knight;
                }
                else if ((i == 3) | (i == 6))
                {
                    Pieces.Source = B_bishop;
                }
                else if (i == 4)
                {
                    Pieces.Source = B_queen;
                }
                else if (i == 5)
                {
                    Pieces.Source = B_king;
                }
                else if ((8 < i) & (i <= 16))
                {
                    Pieces.Source = B_pawn;
                }
                else if ((i == 57) | (i == 64))
                {
                    Pieces.Source = W_castle;
                }                   
                else if ((i == 58) |(i == 63))
                {                   
                    Pieces.Source = W_knight;
                }                   
                else if ((i == 59) |(i == 62))
                {                   
                    Pieces.Source = W_bishop;
                }                   
                else if (i == 60)   
                {                   
                    Pieces.Source = W_queen;
                }                   
                else if (i == 61)   
                {                   
                    Pieces.Source = W_king;
                }                   
                else if ((48 < i) & (i <= 56))
                {                   
                    Pieces.Source = W_pawn;
                }
                placement.Children.Add(Pieces);
            }
        }
    }
}
