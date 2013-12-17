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
    /// Interaction logic for GameGrid.xaml
    /// </summary>
    public partial class GameGrid : UserControl
    {
        public MainWindow window;

        public GameGrid()
        {
            InitializeComponent();
        }

        internal void adjustBG(string Time)
        {
            String[] time=Time.Split(':');
            int hour = Convert.ToInt32(time[0]); int min = Convert.ToInt32(time[1]);
            byte hc; byte mc;
            try 
            {
                hc = Convert.ToByte(41 + 5 * (((255 - 41) * (min + hour * 60)) / (24 * 60)));
            }
            catch (Exception e)
            {
                hc = 255;
            }

            try { 

             
             mc = Convert.ToByte(81 + 3*(((255 - 81) * (min + hour * 60)) / (24 * 60)));
                }
            catch(Exception e)
            {
                mc = 255;
            }

            window.bgGrid.Background = new SolidColorBrush(Color.FromArgb(255, 26, hc , mc ));
            
        }
    }
}
