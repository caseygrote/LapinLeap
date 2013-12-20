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
    /// Interaction logic for Room.xaml
    /// </summary>
    public partial class Room : UserControl
    {
        

        public string Time { get; set; }
        public List<Room> offspring = new List<Room>();
        public GameGrid game;

        public Room()
        {
            InitializeComponent();
            DoomsdayClock.Content = Time;
        }

        //returns all future events
        //public List<Room> getalldescendents()
        //{
        //    List<Room> kids = new List<Room>();
        //    //kids.Concat(offspring);
        //    foreach (Room kid in offspring)
        //    {
        //        kids.Add(kid);
        //        foreach (Room k in kid.getalldescendents())
        //        {
        //            kids.Add(k);
        //        }
        //    }

        //    return kids;

        //}

        public List<Room> getalldescendents()
        {
            List<Room> ret = offspring;
            foreach (Room kid in offspring)
            {
               ret= Enumerable.ToList(ret.Concat(kid.getalldescendents()));
            }
            return ret;

        }

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
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DoomsdayClock.Content = Time;
        }


        //actually causes everything to multiply, amazing
        //private void ItemsList_Loaded(object sender, RoutedEventArgs e)
        //{
            
        //        foreach (Object item in ItemsList.Items)
        //        {
        //            foreach (Room r in this.getalldescendents())
        //            {
        //            r.ItemsList.Items.Add(item);
        //        }
        //    }
        //}

        public void TimeConsistentAddItem(String s)
        {
            ItemsList.Items.Add(s);
            List<Room> des = this.getalldescendents();
            foreach (Room kid in des)
            {
                kid.ItemsList.Items.Add(s);
            }
        }

        public void TimeConsistentAddItem(item s)
        {
            ItemsList.Items.Add(s);
            List<Room> des = this.getalldescendents();
            foreach (Room kid in des)
            {
                item i = new item();
                i.itemName = s.itemName;
                
              kid.ItemsList.Items.Add(i);
              //i.manual_Loaded();
                    
                
            }
            
        }

        internal void TimeConsistentRemoveItem(string p)
        {
            if (ItemsList.Items.Contains(p)) 
                ItemsList.Items.Remove(p);
            
            List<Room> des = this.getalldescendents();
            foreach (Room kid in des)
            {
                if(kid.ItemsList.Items.Contains(p))
                    kid.ItemsList.Items.Remove(p);
            }
        }

        internal void TimeConsistentRemoveItem(item p)
        {
            //if (ItemsList.Items.Contains(p))
            //    ItemsList.Items.Remove(p);

            //List<Room> des = this.getalldescendents();
            //foreach (Room kid in des)
            //{
            //    if (kid.ItemsList.Items.Contains(p))
            //        kid.ItemsList.Items.Remove(p);
            //}



            foreach (item i in ItemsList.Items)
            {
                if (i.itemName.Equals(p.itemName))
                {
                    ItemsList.Items.Remove(i);
                }
            }

            List<Room> des = this.getalldescendents();

            foreach (Room kid in des)
            {
                foreach (item i in kid.ItemsList.Items)
                {
                    if (i.itemName.Equals(p.itemName))
                    {
                        kid.ItemsList.Items.Remove(i);
                    }
                }
            }


        }



    }



}
