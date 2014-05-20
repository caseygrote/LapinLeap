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
    /// Interaction logic for avatar.xaml
    /// </summary>
    public partial class avatar : UserControl
    {
        public avatar()
        {
            InitializeComponent();
        }

        public void AnimationCompleted(object sender, EventArgs e)
        {
            standing.Visibility = Visibility.Visible;
            leftfwdanim.Visibility = Visibility.Hidden; rightfwdanim.Visibility = Visibility.Hidden;
            leftbwdanim.Visibility = Visibility.Hidden; rightbwdanim.Visibility = Visibility.Hidden;
        }

        internal void fwd()
        {
            standing.Visibility = Visibility.Hidden;
            leftfwdanim.Visibility = Visibility.Visible;
            rightfwdanim.Visibility = Visibility.Visible;
            var lc = WpfAnimatedGif.ImageBehavior.GetAnimationController(leftfwdanim);
            lc.Play();
            var rc = WpfAnimatedGif.ImageBehavior.GetAnimationController(rightfwdanim);
            rc.Play();

        }

        internal void bwd()
        {
            standing.Visibility = Visibility.Hidden;
            leftfwdanim.Visibility = Visibility.Visible;
            rightfwdanim.Visibility = Visibility.Visible;
            var lc = WpfAnimatedGif.ImageBehavior.GetAnimationController(leftbwdanim);
            lc.Play();
            var rc = WpfAnimatedGif.ImageBehavior.GetAnimationController(rightbwdanim);
            rc.Play();

        }
    }
}
