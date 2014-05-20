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
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAnimatedGif;

namespace LapinLeap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            inventory.game = this;
            game.window = this;
        }

        private void MapCanvas_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MapCanvas.Visibility = Visibility.Collapsed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            game.window = this;
           
           
        }



        internal void youdroppedthis(string s)
        {
            itempulse("you dropped your "+s);
        }

        internal void yougotthis(string s)
        {
            itempulse("you got a " + s);
        }

        private void itempulse(string s){

            pulser.Content = s;
            pulser.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left;

            ColorAnimation animation = new ColorAnimation();
            animation.From = Color.FromArgb(255, 255,255,255);
            animation.To = Color.FromArgb(0, 255, 255, 255);

            animation.Duration = new Duration(TimeSpan.FromSeconds(.5));
            pulser.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, animation);
            

            //DISPLAY ANIMATION 
            //throw new NotImplementedException();
        }

        private void PhoneCanvas_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
             PhoneCanvas.Visibility = Visibility.Collapsed;
             cell.Visibility = Visibility.Collapsed;
        }



 
}
}
