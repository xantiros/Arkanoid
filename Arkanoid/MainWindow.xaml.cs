using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Arkanoid
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int win = 9;
        int x = -8;
        int y = -8;
        Timer timer_ball = new Timer(40);
        Timer timer_left = new Timer(10);
        Timer timer_right = new Timer(10);

        bool Check_colision(Image ball, Image brick)
        {
            if (img_ball.Margin.Left >= brick.Margin.Left - img_ball.Width &&
                 img_ball.Margin.Left <= brick.Margin.Left + brick.Width &&
                 img_ball.Margin.Top >= brick.Margin.Top - img_ball.Height &&
                 img_ball.Margin.Top <= brick.Margin.Top + brick.Height)
                return true;
            else
                return false;
        }

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
                if (margin.Left + paddle.Width <= Window.Width - 15)
                    margin.Left += 10;
                paddle.Margin = margin;
            });
        }

        private void Timer_left_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                var margin = paddle.Margin;
                if (margin.Left >= 5)
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
                //botom End game
                if (margin.Top >= paddle.Height + paddle.Margin.Top)
                {
                    timer_ball.Stop();
                    img_ball.Visibility = Visibility.Hidden;
                    btnEndGame.Content = "You lose. Again?";
                    btnEndGame.Visibility = Visibility.Visible;
                }//odbicie
                else if (margin.Left > paddle.Margin.Left-img_ball.Width/2 
                        && margin.Left < paddle.Margin.Left+paddle.Width
                        && margin.Top + img_ball.Height > paddle.Margin.Top)
                {
                    if (y > 0) y = -y;
                }
                if (win <= 0)
                {
                    timer_ball.Stop();
                    img_ball.Visibility = Visibility.Hidden;
                    btnEndGame.Content = "You won!!!! Again?";
                    btnEndGame.Visibility = Visibility.Visible;
                }
                //colision
                if(Check_colision(img_ball, brick1) && brick1.Visibility == Visibility.Visible)
                {
                    x = -x;
                    y = -y;
                    brick1.Visibility = Visibility.Hidden;
                    win--;
                }
                if (Check_colision(img_ball, brick2) && brick2.Visibility == Visibility.Visible)
                {
                    x = -x;
                    y = -y;
                    brick2.Visibility = Visibility.Hidden;
                    win--;
                }
                if (Check_colision(img_ball, brick3) && brick3.Visibility == Visibility.Visible)
                {
                    x = -x;
                    y = -y;
                    brick3.Visibility = Visibility.Hidden;
                    win--;
                }
                if (Check_colision(img_ball, brick4) && brick4.Visibility == Visibility.Visible)
                {
                    x = -x;
                    y = -y;
                    brick4.Visibility = Visibility.Hidden;
                    win--;
                }
                if (Check_colision(img_ball, brick5) && brick5.Visibility == Visibility.Visible)
                {
                    x = -x;
                    y = -y;
                    brick5.Visibility = Visibility.Hidden;
                    win--;
                }
                if (Check_colision(img_ball, brick6) && brick6.Visibility == Visibility.Visible)
                {
                    x = -x;
                    y = -y;
                    brick6.Visibility = Visibility.Hidden;
                    win--;
                }
                if (Check_colision(img_ball, brick7) && brick7.Visibility == Visibility.Visible)
                {
                    x = -x;
                    y = -y;
                    brick7.Visibility = Visibility.Hidden;
                    win--;
                }
                if (Check_colision(img_ball, brick8) && brick8.Visibility == Visibility.Visible)
                {
                    x = -x;
                    y = -y;
                    brick8.Visibility = Visibility.Hidden;
                    win--;
                }
                if (Check_colision(img_ball, brick9) && brick9.Visibility == Visibility.Visible)
                {
                    x = -x;
                    y = -y;
                    brick9.Visibility = Visibility.Hidden;
                    win--;
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

        private void BtnEndGame_Click(object sender, RoutedEventArgs e)
        {
            var margin = img_ball.Margin;
            margin.Left = 50;
            margin.Top = 50;
            img_ball.Margin = margin;
            img_ball.Visibility = Visibility.Visible;
            x = -8;
            y = -8;
            timer_ball.Start();
            btnEndGame.Visibility = Visibility.Hidden;
            win = 9;

            brick1.Visibility = Visibility.Visible;
            brick2.Visibility = Visibility.Visible;
            brick3.Visibility = Visibility.Visible;
            brick4.Visibility = Visibility.Visible;
            brick5.Visibility = Visibility.Visible;
            brick6.Visibility = Visibility.Visible;
            brick7.Visibility = Visibility.Visible;
            brick8.Visibility = Visibility.Visible;
            brick9.Visibility = Visibility.Visible;
        }
    }
}
