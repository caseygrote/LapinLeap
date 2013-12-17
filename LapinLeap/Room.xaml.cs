﻿using System;
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

        public Room()
        {
            InitializeComponent();
            DoomsdayClock.Content = Time;
        }

        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            BGgrid.Background = Brushes.Blue;
            DoomsdayClock.Content = Time;
            Grid g = (Grid)this.Parent;
            Grid roomgrid = (Grid)g.Parent;
            GameGrid game = (GameGrid)roomgrid.Parent;

            ThicknessAnimation animation = new ThicknessAnimation();
            

            Thickness oldCenter = game.StartRoom.Margin;
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

            game.StartRoom.BGgrid.Background = new SolidColorBrush(Color.FromArgb(255, 255, 152, 152));
            game.StartRoom = this;
            game.window.DoomsdayClock.Content = Time;

            game.adjustBG(Time);

            

            //CHANGE CHARA LOC
        }
    }
}
