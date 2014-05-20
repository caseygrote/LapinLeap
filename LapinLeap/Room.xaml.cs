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
using System.Collections;
using WpfAnimatedGif;

namespace LapinLeap
{
    /// <summary>
    /// Interaction logic for Room.xaml
    /// </summary>
    public partial class Room : UserControl
    {
        

        public string Time { get; set; }
        public string roomname { get; set; }
        public List<Room> offspring = new List<Room>();
        public GameGrid game;
        public string[] winConditions = new string[5];
        public Hashtable actions = new Hashtable();

        public Room()
        {
            InitializeComponent();
            DoomsdayClock.Content = Time;
            RoomName.Content = roomname;

        }


        public List<Room> getalldescendents()
        {
            List<Room> ret = offspring;
            foreach (Room kid in offspring)
            {
               ret= Enumerable.ToList(ret.Concat(kid.getalldescendents()));
            }
            return ret;

        }

        public void addAction(Room dest, string action)
        {
            actions.Add(action, dest);
            optionsList.Items.Add(action);
        }

        //move 
        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //BGgrid.Background = Brushes.Blue;
            DoomsdayClock.Content = Time;
            Grid g = (Grid)this.Parent;
            Grid roomgrid = (Grid)g.Parent;
            GameGrid game = (GameGrid)roomgrid.Parent;

            ThicknessAnimation animation = new ThicknessAnimation();
            

            Thickness oldCenter = game.currentRoom.Margin;
            Thickness newCenter = this.Margin;
            Thickness oldMargin = roomgrid.Margin;

            

            //roomgrid.Margin =
            Thickness newMargin= new Thickness(oldMargin.Left + (oldCenter.Left - newCenter.Left),
                oldMargin.Top + (oldCenter.Top - newCenter.Top),  
                oldMargin.Right + (oldCenter.Right - newCenter.Right),
                oldMargin.Bottom + (oldCenter.Bottom - newCenter.Bottom));


            animation.From = oldMargin;
            animation.To = newMargin;

            PowerEase pe = new PowerEase();
            pe.EasingMode = EasingMode.EaseInOut; pe.Power=3;

            animation.EasingFunction = pe;
            animation.Duration = new Duration(TimeSpan.FromSeconds(.5)); 

            roomgrid.BeginAnimation(Grid.MarginProperty, animation);

            List<Room> desc = game.currentRoom.getalldescendents();
            game.currentRoom.BGgrid.Background = new SolidColorBrush(Color.FromArgb(190, 255, 152, 152));

           // game.StartRoom.BGgrid.Background = new SolidColorBrush(Color.FromArgb(255, 255, 152, 152));

            foreach(Room r in desc)
            {
                r.BGgrid.Background = new SolidColorBrush(Color.FromArgb(190, 255, 152, 152));
            }

            game.currentRoom = this;

            desc = game.currentRoom.getalldescendents();

            foreach (Room r in desc)
            {
                r.BGgrid.Background = new SolidColorBrush(Color.FromArgb(255, 255, 152, 152));
            }


            game.window.DoomsdayClock.Content = Time;

            game.adjustBG(Time);


            BGgrid.Background = Brushes.Blue;
            //CHANGE CHARA LOC

            if (oldCenter.Left == newCenter.Left)
                game.window.avatar.standstill();
            else if (oldCenter.Left < newCenter.Left)//traveling forward
                game.window.avatar.fwd();
            else
                game.window.avatar.bwd();

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DoomsdayClock.Content = Time;

            Grid g = (Grid)this.Parent; Grid gg = (Grid)g.Parent;
         try{
            game = (GameGrid)gg.Parent;
         }
            catch(Exception error)
         {}
         RoomName.Content = roomname;
        }



        public void TimeConsistentAddItem(String s)
        {

            if (s == null) 
                return;
            ItemsList.Items.Add(s);
            List<Room> des = this.getalldescendents();
            foreach (Room kid in des)
            {
                kid.ItemsList.Items.Add(s);
            }
        }

       

        internal void TimeConsistentRemoveItem(string s)
        {

            if (s == null) return;
            game.window.inventory.add(s + "");


            //ItemsList.Items.Remove(s);
            List<Room> des = this.getalldescendents();

            foreach (Room kid in des)
            {
                kid.RoomRemove(s);
            }


            this.RoomRemove(s);
        }

        private void RoomRemove(string s) //removes first instance of specified string in room
        {

            ItemsList.Items.Remove(s);
            //int itemindex =-1;
            //foreach (string item in ItemsList.Items)
            //{
            //    if (s.Equals(item))
            //        itemindex = ItemsList.Items.IndexOf(item);
            //}
            //try
            //{
            //    ItemsList.Items.RemoveAt(itemindex);

            //}
            //catch(Exception e){}
            
        }

        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String s = (string) ((ListBox)sender).SelectedItem;

            if (s == null) return;
            TimeConsistentRemoveItem(s);
            ((ListBox)sender).SelectedItem = null;
        }

        private void optionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String s = (string)((ListBox)sender).SelectedItem;
            if (s == null) return;
            Room selectedroom =(Room)actions[s];
            (selectedroom).Visibility = Visibility.Visible;
            ((ListBox)sender).SelectedItem = null;

            //v sloppy, revist later

            DoomsdayClock.Content = Time;
            Grid g = (Grid)this.Parent;
            Grid roomgrid = (Grid)g.Parent;
            GameGrid game = (GameGrid)roomgrid.Parent;

            ThicknessAnimation animation = new ThicknessAnimation();


            Thickness oldCenter = game.currentRoom.Margin;
            Thickness newCenter = selectedroom.Margin;
            Thickness oldMargin = roomgrid.Margin;



            //roomgrid.Margin =
            Thickness newMargin = new Thickness(oldMargin.Left + (oldCenter.Left - newCenter.Left),
                oldMargin.Top + (oldCenter.Top - newCenter.Top),
                oldMargin.Right + (oldCenter.Right - newCenter.Right),
                oldMargin.Bottom + (oldCenter.Bottom - newCenter.Bottom));


            animation.From = oldMargin;
            animation.To = newMargin;

            PowerEase pe = new PowerEase();
            pe.EasingMode = EasingMode.EaseInOut; pe.Power = 3;

            animation.EasingFunction = pe;
            animation.Duration = new Duration(TimeSpan.FromSeconds(.5));

            roomgrid.BeginAnimation(Grid.MarginProperty, animation);

            List<Room> desc = game.currentRoom.getalldescendents();
            game.currentRoom.BGgrid.Background = new SolidColorBrush(Color.FromArgb(190, 255, 152, 152));

            // game.StartRoom.BGgrid.Background = new SolidColorBrush(Color.FromArgb(255, 255, 152, 152));

            foreach (Room r in desc)
            {
                r.BGgrid.Background = new SolidColorBrush(Color.FromArgb(190, 255, 152, 152));
            }

            game.currentRoom = selectedroom;

            desc = game.currentRoom.getalldescendents();

            foreach (Room r in desc)
            {
                r.BGgrid.Background = new SolidColorBrush(Color.FromArgb(255, 255, 152, 152));
            }


            game.window.DoomsdayClock.Content = Time;

            game.adjustBG(Time);


            selectedroom.BGgrid.Background = Brushes.Blue;
            //CHANGE CHARA LOC

            if (oldCenter.Left == newCenter.Left)
                game.window.avatar.standstill();
            else if (oldCenter.Left < newCenter.Left)//traveling forward
                game.window.avatar.fwd();
            else
                game.window.avatar.bwd();

        }



    }



}
