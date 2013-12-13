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
    /// Interaction logic for Room.xaml
    /// </summary>
    public partial class Room : UserControl
    {
        

        public string Time { get; set; }

        public Room()
        {
            InitializeComponent();
            DoomsdayClock.Content = Time;
        }

        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            BGgrid.Background = Brushes.Blue;
            DoomsdayClock.Content = Time;
            //CENTER THIS!
            //CHANGE TIME; CHANGe MAINGRID BG
            //CHANGE CHARA LOC
        }
    }
}
