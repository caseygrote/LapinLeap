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
    /// Interaction logic for item.xaml
    /// </summary>
    public partial class item : UserControl
    {
        public string itemName  { get; set; }
        public bool isInInv = true;
        public MainWindow window;
        private string p;

        public item()
        {
            InitializeComponent();
           
        }

        //public item(string p)
        //{
        //    isInInv = false;
        //    itemName = p;


        //}

        private void itemName_Loaded(object sender, RoutedEventArgs e)
        {
            nameLabel.Content = itemName;
        }

        public void manual_Loaded() { nameLabel.Content = itemName; }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //switch item bt currentroom/inv
            if (isInInv)
            {
                window.inventory.lb.Items.Remove(this);
                //window.game.currentRoom.ItemsList.Items.Add(this);
                window.game.currentRoom.TimeConsistentAddItem(this);
            }
            else
            {
                window.game.currentRoom.TimeConsistentRemoveItem(this);
                window.inventory.lb.Items.Add(this);
            }

        }


    }
}
