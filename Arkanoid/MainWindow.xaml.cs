using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Arkanoid
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int x = -8;
        int y = -8;
        Timer timer_ball = new Timer(60);
        Timer timer_left = new Timer(10);
        Timer timer_right = new Timer(10);

        public MainWindow()
        {
            InitializeComponent();

            //Timer ball
            timer_ball.Elapsed += Timer_ball_Elapsed;
            timer_ball.Start();

            //Timer left
            timer_left.Elapsed += Timer_left_Elapsed;
            //timer right
            timer_right.Elapsed += Timer_right_Elapsed;

        }

        private void Timer_right_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                var margin = paddle.Margin;
                margin.Left += 10;
                paddle.Margin = margin;
            });
        }

        private void Timer_left_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                var margin = paddle.Margin;
                margin.Left -= 10;
                paddle.Margin = margin;
            });
        }

        private void Timer_ball_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                var margin = img_ball.Margin;
                margin.Left += x;
                margin.Top += y;
                img_ball.Margin = margin;

                //left wall
                if (margin.Left <= Background.Margin.Left) x = -x;
                //top wall
                if (margin.Top <= Background.Margin.Top) y = -y;
                //right wall
                if (margin.Left + img_ball.Width + 10 >= Window.Width)
                    x = -x;
                //botom
                if (margin.Top >= paddle.Height + paddle.Margin.Top)
                {
                    timer_ball.Stop();
                    img_ball.Visibility = Visibility.Hidden;
                }
            });
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left) timer_left.Start();
            if (e.Key == Key.Right) timer_right.Start();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left) timer_left.Stop();
            if (e.Key == Key.Right) timer_right.Stop();
        }
    }
}
