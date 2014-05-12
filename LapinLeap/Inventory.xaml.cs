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
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Inventory : UserControl
    {
        public Inventory()
        {
            InitializeComponent();
        }

        private void MAP_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            game.MapCanvas.Visibility = Visibility.Visible;
        }



        public MainWindow game { get; set; }

        internal void add(string s)
        {
            if (s == null) return;
            items.Items.Add(s);
            game.yougotthis(s);
        }

        private void items_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s = (string) items.SelectedItem;

            if (s == null) return;
            items.Items.Remove(s);
                
            game.game.currentRoom.TimeConsistentAddItem(s);
            game.youdroppedthis(s);

            items.SelectedItem = null;

        }
    }
}
