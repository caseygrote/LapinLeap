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
            //DISPLAY ANIMATION 
            //throw new NotImplementedException();
        }
    }
}
