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
using System.Windows.Threading;

namespace SmartPong
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        private Pong pong = new Pong();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = pong; // Data binding

            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Start();
            timer.Tick += ((x, y) =>
            {
               pong.PlayerPadY = (int)Mouse.GetPosition(this).Y;
            });

        }
    }
}
