using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
    /// Interaction logic for CloseConfirmation.xaml
    /// </summary>
    public partial class CloseConfirmation : Window
    {
        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;
        List<Item> item_list = new List<Item>();
        public CloseConfirmation()
        {
            InitializeComponent();
        }

        public void setList(List<Item> item_list)
        {
            this.item_list = item_list;
        }

        private void Btn_no_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Btn_yes_Click(object sender, RoutedEventArgs e)
        {
            /*Code grabbed from https://stackoverflow.com/questions/10315188/open-file-dialog-and-select-a-file-using-wpf-controls-and-c-sharp */

            // Create OpenFileDialog 
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "database"; // Default file name
            dlg.DefaultExt = ".db"; // Default file extension
            dlg.Filter = "Database files (.db)|*.db"; // Filter files by extension


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                string[] f;
                // Open document 
                f = dlg.FileName.Split('\\');

                sqlite_conn = new SQLiteConnection($"Data Source={dlg.FileName};Version=3;New=True;Compress=True;");

                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();

                sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS log (extension varchar(10), filename varchar(25), path varchar(100), event varchar(25), date varchar(30));";
                sqlite_cmd.ExecuteNonQuery();

                foreach (Item item in item_list)
                {
                    sqlite_cmd.CommandText = $"INSERT INTO log (extension, filename, path, event, date) VALUES ('{item.Extension}', '{item.Filename}', '{item.Path}', '{item.Event}', '{item.Date}');";
                    sqlite_cmd.ExecuteNonQuery();
                }

                sqlite_conn.Close();

                Environment.Exit(0);
            }
        }
    }
}
