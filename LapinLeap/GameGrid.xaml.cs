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
using System.Windows.Media.Animation;
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
        Color animsave = Color.FromArgb(255, 26, 41, 81);


        public GameGrid()
        {

            InitializeComponent();

            currentRoom.offspring.Add(room1); currentRoom.offspring.Add(room0);
            room1.offspring.Add(room5);
            room5.offspring.Add(room6);
            room0.offspring.Add(room2); 
            //room0.ItemsList.Items.Add("test item");

            room2.offspring.Add(room3); room2.offspring.Add(room4);
            room4.offspring.Add(room7); 
            room7.offspring.Add(room8);

            room0.addAction(room2, "wait here");
            room4.addAction(room7, "wait here");
            room7.addAction(room8, "wait still");

            room2.addAction(room3, "dont wait");
            currentRoom.addAction(room1, "something");
            currentRoom.addAction(room0, "not that");
            room1.addAction(room5, "do thing");
            room5.addAction(room6, "go to 6");


            //room0.TimeConsistentAddItem("test item");
            //room0.TimeConsistentAddItem(new item("testitem"));
            //room0.ItemsList.Items.Add(new item("testing item add"));//ng
            //room0.ItemsList.Items.Add(new item());


            string testitem = "item";
           

            room0.TimeConsistentAddItem(testitem);

            //item consTest = new item("string cons");

            //room0.TimeConsistentRemoveItem("test item");
        }

        internal void adjustBG(string Time)
        {
            String[] time=Time.Split(':');
            int hour = Convert.ToInt32(time[0]); int min = Convert.ToInt32(time[1]);
            byte hc; byte mc;
            try 
            {
                hc = Convert.ToByte(41 + 3 * (((255 - 41) * (min + hour * 60)) / (24 * 60)));
            }
            catch (Exception e)
            {
                hc = 255;
            }

            try 
            {
                mc = Convert.ToByte(81 + 5*(((255 - 81) * (min + hour * 60)) / (24 * 60)));
            }
            catch(Exception e)
            {
                mc = 255;
            }

           

            ColorAnimation animation = new ColorAnimation();
            animation.From = animsave;
            animation.To = Color.FromArgb(255, 26, hc, mc);

            animation.Duration = new Duration(TimeSpan.FromSeconds(.5));
            window.bgGrid.Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);
            window.inventory.items.Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);

            //window.bgGrid.Background = new SolidColorBrush(Color.FromArgb(255, 26, hc , mc ));
            animsave =Color.FromArgb(255, 26, hc , mc ); 
        }

    
        

    }
}
