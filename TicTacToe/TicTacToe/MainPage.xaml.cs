using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TicTacToe
{
    public partial class MainPage : ContentPage
    {
        Grid grid;
        Frame frame;
        BoxView b1, b2, b3, b4, b5, b6, b7, b8, b9;
        string choise;
        public MainPage()
        {
            Choise();

            //строим сетку
            Grid grid = new Grid();
            {
                for (int i = 0; i < 3; i++)
                {
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                }
            }
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;

            b1 = new BoxView { Color = Color.WhiteSmoke, CornerRadius = 30 };
            grid.Children.Add(b1, 0, 0);
            b1.GestureRecognizers.Add(tap);

            b2 = new BoxView { Color = Color.WhiteSmoke, CornerRadius = 30 };
            grid.Children.Add(b2, 1, 0);
            b2.GestureRecognizers.Add(tap);

            b3 = new BoxView { Color = Color.WhiteSmoke, CornerRadius = 30 };
            grid.Children.Add(b3, 2, 0);
            b3.GestureRecognizers.Add(tap);

            b4 = new BoxView { Color = Color.WhiteSmoke, CornerRadius = 30 };
            grid.Children.Add(b4, 0, 1);
            b4.GestureRecognizers.Add(tap);

            b5 = new BoxView { Color = Color.WhiteSmoke, CornerRadius = 30 };
            grid.Children.Add(b5, 1, 1);
            b5.GestureRecognizers.Add(tap);

            b6 = new BoxView { Color = Color.WhiteSmoke, CornerRadius = 30 };
            grid.Children.Add(b6, 2, 1);
            b6.GestureRecognizers.Add(tap);

            b7 = new BoxView { Color = Color.WhiteSmoke, CornerRadius = 30 };
            grid.Children.Add(b7, 0, 2);
            b7.GestureRecognizers.Add(tap);

            b8 = new BoxView { Color = Color.WhiteSmoke, CornerRadius = 30 };
            grid.Children.Add(b8, 1, 2);
            b8.GestureRecognizers.Add(tap);

            b9 = new BoxView { Color = Color.WhiteSmoke, CornerRadius = 30 };
            grid.Children.Add(b9, 2, 2);
            b9.GestureRecognizers.Add(tap);


            frame = new Frame
            {
                Content = grid,
                HeightRequest = 560,
                WidthRequest = 560
            };
            StackLayout st = new StackLayout
            {
                Children = { frame }
            };

            Content = st;
        }

        private async void Choise()
        {
            string result = await DisplayActionSheet("Who plays first?", "Choose:", null, "x", "o");

            if (result == "x")
            {
                choise = "x";
            }
            else if (result == "o")
            {
                choise = "o";
            }
        }
       
        private void Clear()
        {
            b1.Color = Color.WhiteSmoke;
            b2.Color = Color.WhiteSmoke;
            b3.Color = Color.WhiteSmoke;
            b4.Color = Color.WhiteSmoke;
            b5.Color = Color.WhiteSmoke;
            b6.Color = Color.WhiteSmoke;
            b7.Color = Color.WhiteSmoke;
            b8.Color = Color.WhiteSmoke;
            b9.Color = Color.WhiteSmoke;
        }
        public async void Tap_Tapped(object sender, EventArgs e)
        {
            //var box = BoxView
            var b = (BoxView)sender;
            var r = Grid.GetRow(b); //определяем координату 
            var c = Grid.GetColumn(b);

            if (choise == "x")
            {
                b.Color = Color.Black;
                choise = "o";

            }
            else if (choise == "o")
            {
                b.Color = Color.Red;
                choise = "x";

            }
            WinCheck();

        }
        private void XWin()
        {
            choise = "x";
        }
        public void WinCheck()
        {
            //check if X (black) win

            // 1, 2, 3 - первый ряд по горизонтали
            if (b1.Color == Color.Black && b2.Color == Color.Black && b3.Color == Color.Black)
            {
                DisplayAlert("!", "x win!!!", "OK");
                Clear();
                choise = "x";
            }
            // 4, 5, 6 - второй ряд по горизонтали
            else if (b4.Color == Color.Black && b5.Color == Color.Black && b6.Color == Color.Black)
            {
                DisplayAlert("!", "x win!!!", "OK");
                Clear();
                choise = "x";
            }
            // 7, 8, 9 - третий ряд по горизонтали
            else if (b7.Color == Color.Black && b8.Color == Color.Black && b9.Color == Color.Black)
            {
                DisplayAlert("!", "x win!!!", "OK");
                Clear();
                choise = "x";
            }
            //1, 4, 7 - первый ряд по вертикали
            else if (b1.Color == Color.Black && b4.Color == Color.Black && b7.Color == Color.Black)
            {
                DisplayAlert("!", "x win!!!", "OK");
                Clear();
                choise = "x";
            }
            //2, 5, 8 - второй ряд по вертикали
            else if (b2.Color == Color.Black && b5.Color == Color.Black && b8.Color == Color.Black)
            {
                DisplayAlert("!", "x win!!!", "OK");
                Clear();
                choise = "x";
            }
            //3, 6, 9 - третий ряд по вертикали
            else if (b3.Color == Color.Black && b6.Color == Color.Black && b9.Color == Color.Black)
            {
                DisplayAlert("!", "x win!!!", "OK");
                Clear();
                choise = "x";
            }
            //1, 5, 9 - по диагонали
            else if (b1.Color == Color.Black && b5.Color == Color.Black && b9.Color == Color.Black)
            {
                DisplayAlert("!", "x win!!!", "OK");
                Clear();
                choise = "x";
            }
            //3, 5, 7 - по диагонали
            else if (b3.Color == Color.Black && b5.Color == Color.Black && b7.Color == Color.Black)
            {
                DisplayAlert("!", "x win!!!", "OK");
                Clear();
                choise = "x";
            }

            //check if 0 (red) win

            // 1, 2, 3 - первый ряд по горизонтали
            else if (b1.Color == Color.Red && b2.Color == Color.Red && b3.Color == Color.Red)
            {
                DisplayAlert("!", "o win!!!", "OK");
                Clear();
                choise = "o";
            }
            // 4, 5, 6 - второй ряд по горизонтали
            else if (b4.Color == Color.Red && b5.Color == Color.Red && b6.Color == Color.Red)
            {
                DisplayAlert("!", "o win!!!", "OK");
                Clear();
                choise = "o";
            }
            // 7, 8, 9 - третий ряд по горизонтали
            else if (b7.Color == Color.Red && b8.Color == Color.Red && b9.Color == Color.Red)
            {
                DisplayAlert("!", "o win!!!", "OK");
                Clear();
                choise = "o";
            }
            //1, 4, 7 - первый ряд по вертикали
            else if (b1.Color == Color.Red && b4.Color == Color.Red && b7.Color == Color.Red)
            {
                DisplayAlert("!", "o win!!!", "OK");
                Clear();
                choise = "o";
            }
            //2, 5, 8 - второй ряд по вертикали
            else if (b2.Color == Color.Red && b5.Color == Color.Red && b8.Color == Color.Red)
            {
                DisplayAlert("!", "o win!!!", "OK");
                Clear();
                choise = "o";
            }
            //3, 6, 9 - третий ряд по вертикали
            else if (b3.Color == Color.Red && b6.Color == Color.Red && b9.Color == Color.Red)
            {
                DisplayAlert("!", "o win!!!", "OK");
                Clear();
                choise = "o";
            }
            //1, 5, 9 - по диагонали
            else if (b1.Color == Color.Red && b5.Color == Color.Red && b9.Color == Color.Red)
            {
                DisplayAlert("!", "o win!!!", "OK");
                Clear();
                choise = "o";
            }
            //3, 5, 7 - по диагонали
            else if (b3.Color == Color.Red && b5.Color == Color.Red && b7.Color == Color.Red)
            {
                DisplayAlert("!", "o win!!!", "OK");
                Clear();
                choise = "o";

            }

        }
    }
}
