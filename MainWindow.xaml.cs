﻿using System;
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

        int[,] mas_placementment = new int[8, 8];
        Button[,] pieces_btn;
        Button[,] chess_btn;
        int new_i = -1;
        int old_i = -1;
        int new_j = -1;
        int old_j = -1;
        public MainWindow()
        {
            InitializeComponent();
        }

        int[,] placementmen_chess()
        {
            mas_placementment = new int[8, 8];
            mas_placementment[0, 0] = mas_placementment[0, 7] = -5;//b_castel
            mas_placementment[0, 1] = mas_placementment[0, 6] = -2;//b_knight
            mas_placementment[0, 2] = mas_placementment[0, 5] = -3;//b_bishop
            mas_placementment[0, 3] = -9;//b_queen
            mas_placementment[0, 4] = -4;//b_king
            mas_placementment[7, 0] = mas_placementment[7, 7] = 5;//w_castel
            mas_placementment[7, 1] = mas_placementment[7, 6] = 2;//w_knight
            mas_placementment[7, 2] = mas_placementment[7, 5] = 3;//w_bishop
            mas_placementment[7, 3] = 9;//w_queen
            mas_placementment[7, 4] = 4;//w_king
            for (int i = 0; i <= 7; i++)
            {
                mas_placementment[1, i] = -1;//b_pawn
            }
            for (int i = 0; i <= 7; i++)
            {
                mas_placementment[6, i] = 1;//w_pawn
            }

            return mas_placementment;
        }
        int[,] placementmen_checkers()
        {
            mas_placementment = new int[8, 8];
            for (int i = 1; i <= 7; i += 2)
            {
                mas_placementment[0, i] = -1;//b_pawn
                mas_placementment[2, i] = -1;//b_pawn
                mas_placementment[4, i] = 2;//open
                mas_placementment[6, i] = 1;//w_pawn
            }
            for (int i = 0; i < 7; i += 2)
            {
                mas_placementment[1, i] = -1;//b_pawn
                mas_placementment[3, i] = 2;//open
                mas_placementment[5, i] = 1;//w_pawn
                mas_placementment[7, i] = 1;//w_pawn
            }


            return mas_placementment;
        }
        string[,] field()
        {
            string[,] field = new string[8, 8];
            for (int row = 1; row <= 8; row++)
            {
                if (row % 2 == 0)
                {
                    for (int column = 1; column <= 8; column++)
                    {
                        if ((column % 2) == 0) field[row-1, column-1] = "w";
                        if ((column % 2) != 0) field[row-1, column-1] = "b";
                    }
                }
                if (row % 2 != 0)
                {
                    for (int column = 1; column <= 8; column++)
                    {
                        if ((column % 2) == 0) field[row-1, column-1] = "b";
                        if ((column % 2 != 0)) field[row-1, column-1] = "w";
                    }
                }
            }
            return field;
        }

        private void gen_field_Click(object sender, RoutedEventArgs e)
        {
            grid.Children.Clear();

            grid.Width = 8 * (40);
            grid.Height = 8 * (40);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Rectangle rec = new Rectangle();
                    rec.Width = 40;
                    rec.Height = 40;
                    rec.HorizontalAlignment = HorizontalAlignment.Center;
                    rec.VerticalAlignment = VerticalAlignment.Center;
                    if (field()[i, j] == "b") rec.Fill = System.Windows.Media.Brushes.Beige;
                    if (field()[i, j] == "w") rec.Fill = System.Windows.Media.Brushes.DarkGray;
                    grid.Children.Add(rec);
                }
            }
        }

        private void checkers_placement_Click(object sender, RoutedEventArgs e)
        {
            int[,] mas_placementment = placementmen_checkers();
            draw_position_checkers(mas_placementment);
        }

        private void draw_position_checkers(int[,] mas_placementment)
        {
            placement.Children.Clear();
            pieces_btn = new Button[8, 8];
            for (int i = 0; i < 64; i++)
            {
                pieces_btn[i / 8, i % 8] = new Button();

                Image Pawn = new Image();
                if (mas_placementment[i / 8, i % 8] == -1)
                {
                    Pawn.Source = B_pawn;

                    pieces_btn[i / 8, i % 8].Tag = i;
                    pieces_btn[i / 8, i % 8].Background = System.Windows.Media.Brushes.DarkGray;
                    pieces_btn[i / 8, i % 8].Content = Pawn;
                    pieces_btn[i / 8, i % 8].Click += checkers_Click;
                }
                else if (mas_placementment[i / 8, i % 8] == 1)
                {
                    Pawn.Source = W_pawn;

                    pieces_btn[i / 8, i % 8].Tag = i;
                    pieces_btn[i / 8, i % 8].Background = System.Windows.Media.Brushes.DarkGray;
                    pieces_btn[i / 8, i % 8].Content = Pawn;
                    pieces_btn[i / 8, i % 8].Click += checkers_Click;
                }
                else if (mas_placementment[i / 8, i % 8] == 2)
                {
                    pieces_btn[i / 8, i % 8].Tag = i;
                    pieces_btn[i / 8, i % 8].Content = "";
                    pieces_btn[i / 8, i % 8].Background = System.Windows.Media.Brushes.DarkGray;
                    pieces_btn[i / 8, i % 8].Click += checkers_Click;
                }
                else
                {
                    pieces_btn[i / 8, i % 8].Tag = i;
                    pieces_btn[i / 8, i % 8].Content = "";
                    pieces_btn[i / 8, i % 8].Background = System.Windows.Media.Brushes.Beige;
                    pieces_btn[i / 8, i % 8].IsEnabled = false;
                }
                placement.Children.Add(pieces_btn[i / 8, i % 8]);
            }
        }

        private void checkers_Click(object sender, RoutedEventArgs e)
        {
            int i = (int)((Button)sender).Tag / 8;
            int j = (int)((Button)sender).Tag % 8;


            if (old_j == -1)
            {
                old_i = (int)((Button)sender).Tag / 8;
                old_j = (int)((Button)sender).Tag % 8;
                return;
            }
            else if ((mas_placementment[i, j] == 2) | (mas_placementment[old_i, old_j] != mas_placementment[(int)((Button)sender).Tag / 8, (int)((Button)sender).Tag % 8]))
            {
                new_i = (int)((Button)sender).Tag / 8;
                new_j = (int)((Button)sender).Tag % 8;
            }

            if (new_i > -1)
            {
                mas_placementment[new_i, new_j] = mas_placementment[old_i, old_j];
                mas_placementment[old_i, old_j] = 2;
                draw_position_checkers(mas_placementment);
                new_i = -1;
                old_i = -1;
                new_j = -1;
                old_j = -1;
            }

        }

        private void chess_placement_Click(object sender, RoutedEventArgs e)
        {
            int[,] mas = placementmen_chess();
            draw_position_chess(mas_placementment);
        }
        private void draw_position_chess(int[,] mas_placementment)
        {
            placement.Children.Clear();
            chess_btn = new Button[8, 8];
            for (int i = 0; i < 64; i++)
            {
                Image Pieces = new Image();
                chess_btn[i / 8, i % 8] = new Button();
                if (field()[i / 8, i % 8] == "b")
                {
                    chess_btn[i / 8, i % 8].Background = Brushes.DarkGray;
                }
                else if (field()[i / 8, i % 8] == "w")
                {
                    chess_btn[i / 8, i % 8].Background = Brushes.Beige;
                }

                if (mas_placementment[i / 8, i % 8] == -1)
                {
                    Pieces.Source = B_pawn;

                    chess_btn[i / 8, i % 8].Tag = i;
                    chess_btn[i / 8, i % 8].Content = Pieces;
                    chess_btn[i / 8, i % 8].Click += bPawnMove;
                }
                else if (mas_placementment[i / 8, i % 8] == 1)
                {
                    Pieces.Source = W_pawn;

                    chess_btn[i / 8, i % 8].Tag = i;
                    chess_btn[i / 8, i % 8].Content = Pieces;
                    chess_btn[i / 8, i % 8].Click += wPawnMove;
                }
                else if (mas_placementment[i / 8, i % 8] == -2)
                {
                    Pieces.Source = B_knight;

                    chess_btn[i / 8, i % 8].Tag = i;
                    chess_btn[i / 8, i % 8].Content = Pieces;
                    chess_btn[i / 8, i % 8].Click += bKnightMove;
                }
                else if (mas_placementment[i / 8, i % 8] == 2)
                {
                    Pieces.Source = W_knight;
                    chess_btn[i / 8, i % 8].Tag = i;
                    chess_btn[i / 8, i % 8].Content = Pieces;
                    chess_btn[i / 8, i % 8].Click += wKnightMove;
                }
                else if (mas_placementment[i / 8, i % 8] == 3)
                {
                    Pieces.Source = W_bishop;

                    chess_btn[i / 8, i % 8].Tag = i;
                    chess_btn[i / 8, i % 8].Content = Pieces;
                    chess_btn[i / 8, i % 8].Click += wBishopMove;
                }
                else if (mas_placementment[i / 8, i % 8] == -3)
                {
                    Pieces.Source = B_bishop;

                    chess_btn[i / 8, i % 8].Tag = i;
                    chess_btn[i / 8, i % 8].Content = Pieces;
                    chess_btn[i / 8, i % 8].Click += bBishopMove;
                }
                else if (mas_placementment[i / 8, i % 8] == -5)
                {
                    Pieces.Source = B_castle;

                    chess_btn[i / 8, i % 8].Tag = i;
                    chess_btn[i / 8, i % 8].Content = Pieces;
                    chess_btn[i / 8, i % 8].Click += wCastleMove;
                }
                else if (mas_placementment[i / 8, i % 8] == 5)
                {
                    Pieces.Source = W_castle;

                    chess_btn[i / 8, i % 8].Tag = i;
                    chess_btn[i / 8, i % 8].Content = Pieces;
                    chess_btn[i / 8, i % 8].Click += bCastleMove;
                }
                else if (mas_placementment[i / 8, i % 8] == 4)
                {
                    Pieces.Source = W_king;

                    chess_btn[i / 8, i % 8].Tag = i;
                    chess_btn[i / 8, i % 8].Content = Pieces;
                    chess_btn[i / 8, i % 8].Click += wKingMove;
                }
                else if (mas_placementment[i / 8, i % 8] == -4)
                {
                    Pieces.Source = B_king;

                    chess_btn[i / 8, i % 8].Tag = i;
                    chess_btn[i / 8, i % 8].Content = Pieces;
                    chess_btn[i / 8, i % 8].Click += bKingMove;
                }
                else if (mas_placementment[i / 8, i % 8] == -9)
                {
                    Pieces.Source = B_queen;

                    chess_btn[i / 8, i % 8].Tag = i;
                    chess_btn[i / 8, i % 8].Content = Pieces;
                    chess_btn[i / 8, i % 8].Click += bQueenMove;
                }
                else if (mas_placementment[i / 8, i % 8] == 9)
                {
                    Pieces.Source = W_queen;

                    chess_btn[i / 8, i % 8].Tag = i;
                    chess_btn[i / 8, i % 8].Content = Pieces;
                    chess_btn[i / 8, i % 8].Click += wQueenMove;
                }
                else if (mas_placementment[i / 8, i % 8] == 0)
                {
                    chess_btn[i / 8, i % 8].Tag = i;
                    chess_btn[i / 8, i % 8].Content = "";
                    chess_btn[i / 8, i % 8].Click += emptyClick;
                }
                placement.Children.Add(chess_btn[i / 8, i % 8]);
            }
        }

        private void emptyClick(object sender, RoutedEventArgs e)
        {
            if (old_i != -1)
            {
                if ((new_i == -1) | (new_j == -1))
                {
                    new_i = (int)((Button)sender).Tag / 8;
                    new_j = (int)((Button)sender).Tag % 8;
                    mas_placementment[new_i, new_j] = mas_placementment[old_i, old_j];
                    mas_placementment[old_i, old_j] = 0;
                    draw_position_chess(mas_placementment);
                    new_i = new_j = old_i = old_j = -1;
                }
            }

        }

        private void wQueenMove(object sender, RoutedEventArgs e)
        {
            old_i = (int)((Button)sender).Tag / 8;
            old_j = (int)((Button)sender).Tag % 8;
        }

        private void bQueenMove(object sender, RoutedEventArgs e)
        {
            old_i = (int)((Button)sender).Tag / 8;
            old_j = (int)((Button)sender).Tag % 8;
        }

        private void bKingMove(object sender, RoutedEventArgs e)
        {
            old_i = (int)((Button)sender).Tag / 8;
            old_j = (int)((Button)sender).Tag % 8;
        }

        private void wKingMove(object sender, RoutedEventArgs e)
        {
            old_i = (int)((Button)sender).Tag / 8;
            old_j = (int)((Button)sender).Tag % 8;
        }

        private void bCastleMove(object sender, RoutedEventArgs e)
        {
            old_i = (int)((Button)sender).Tag / 8;
            old_j = (int)((Button)sender).Tag % 8;
        }

        private void wCastleMove(object sender, RoutedEventArgs e)
        {
            old_i = (int)((Button)sender).Tag / 8;
            old_j = (int)((Button)sender).Tag % 8;
        }

        private void bBishopMove(object sender, RoutedEventArgs e)
        {
            old_i = (int)((Button)sender).Tag / 8;
            old_j = (int)((Button)sender).Tag % 8;
        }

        private void wBishopMove(object sender, RoutedEventArgs e)
        {
            old_i = (int)((Button)sender).Tag / 8;
            old_j = (int)((Button)sender).Tag % 8;
        }

        private void wKnightMove(object sender, RoutedEventArgs e)
        {
            old_i = (int)((Button)sender).Tag / 8;
            old_j = (int)((Button)sender).Tag % 8;
        }

        private void bKnightMove(object sender, RoutedEventArgs e)
        {
            old_i = (int)((Button)sender).Tag / 8;
            old_j = (int)((Button)sender).Tag % 8;
        }

        private void wPawnMove(object sender, RoutedEventArgs e)
        {
            old_i = (int)((Button)sender).Tag / 8;
            old_j = (int)((Button)sender).Tag % 8;
        }

        private void bPawnMove(object sender, RoutedEventArgs e)
        {
            old_i = (int)((Button)sender).Tag / 8;
            old_j = (int)((Button)sender).Tag % 8;
        }
    }

}
