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
    /// Interaction logic for phone.xaml
    /// </summary>
    public partial class phone : UserControl
    {
        public phone()
        {
            InitializeComponent();
        }

        private void Label_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (dialing.Content.ToString().Length == 9)
            {
                dialing.Content = "";
            }
                if (dialing.Content.ToString().Length == 3)
                    dialing.Content = dialing.Content + "-";

                dialing.Content = dialing.Content.ToString() + ((Label)sender).Content.ToString();

                if (dialing.Content.ToString().Length == 9)
                {
                    dialing.Content = "";
                }
            }
        
    }
}
