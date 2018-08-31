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
        Timer timer_ball = new Timer(100);

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
            });

        }
    }
}
