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
        int y = -1;
        Timer timer_ball = new Timer(10);

        public MainWindow()
        {
            InitializeComponent();

            //timer
            timer_ball.Elapsed += Timer_ball_Elapsed;
            timer_ball.Start();


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
                if (margin.Left + img_ball.Width >= Background.Width) x = -x;
            });

        }
    }
}
