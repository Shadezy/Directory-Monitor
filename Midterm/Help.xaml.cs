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
using System.Windows.Shapes;

namespace Midterm
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : Window
    {
        public Help()
        {
            InitializeComponent();

            lbl_details.Content = "This program lets a user monitor activity in a given directory such as creating, deleting, renaming, and\n" +
                "editing files/directories/subdirectories. More control options are added in this one as apposed\n" +
                "to Assignment2 such as letting users filter results by extensions. The user also has the option to select which\n" +
                "database they want use whenever interacting with a database.\n\nVersion 1.0\n\nDeveloper: Travis Cartmell";
        }
    }
}
