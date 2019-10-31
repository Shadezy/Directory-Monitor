using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Data.SQLite;
using System.IO;

namespace Midterm
{
    /// <summary>
    /// Interaction logic for QueryDB.xaml
    /// </summary>
    public partial class QueryDB : Window
    {
        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;
        SQLiteDataReader sqlite_datareader;

        string path = "";

        public QueryDB()
        {
            InitializeComponent();
        }

        private void Btn_extensions_Click(object sender, RoutedEventArgs e)
        {
            string filter = txt_extensions.Text;

            string val = "";
            if (txt_extensions.Text.Equals(""))
                val = "all";
            else
                val = txt_extensions.Text;
            lbl_current.Content = val;
        }

        private void Btn_db_Click(object sender, RoutedEventArgs e)
        {
            /*Code grabbed from https://stackoverflow.com/questions/10315188/open-file-dialog-and-select-a-file-using-wpf-controls-and-c-sharp*/

            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".db";
            dlg.Filter = "DB Files (*.db)|*.db";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            string[] f;
            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                path = dlg.FileName;
                f = dlg.FileName.Split('\\');
                lbl_db_err.Content = f[f.Length - 1];
            }
        }

        private void Btn_go_Click(object sender, RoutedEventArgs e)
        {
            string cmd = "";

            if (path.Equals(""))
            {
                lbl_db_err.Content = "please enter a database";
                return;
            }

            dg_content.Items.Clear();
            lbl_delete.Content = "";

            if (lbl_current.Content.ToString().Equals("") || lbl_current.Content.ToString().Equals("all"))
                cmd = "SELECT * FROM log";
            else
                cmd = $"SELECT * FROM log WHERE extension = '{lbl_current.Content.ToString()}'";

            sqlite_conn = new SQLiteConnection($"Data Source={path};Version=3;New=True;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = cmd;
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                dg_content.Items.Add(new Item
                {
                    Extension = sqlite_datareader["extension"].ToString(),
                    Filename = sqlite_datareader["filename"].ToString(),
                    Path = sqlite_datareader["path"].ToString(),
                    Event = sqlite_datareader["event"].ToString(),
                    Date = sqlite_datareader["date"].ToString()
                });
            }
            sqlite_conn.Close();
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (lbl_db_err.Content.ToString() == null)
            {
                lbl_delete.Content = "Database not selected";
                return;
            }

            if (!File.Exists(path))
            {
                lbl_delete.Content = "Database file does not exist";
                return;
            }

            lbl_delete.Content = "Content deleted";

            sqlite_conn = new SQLiteConnection($"Data Source={path};Version=3;New=True;Compress=True;");
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "DROP TABLE log";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS log (extension varchar(10), filename varchar(25), path varchar(100), event varchar(25), date varchar(30));";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_conn.Close();

            dg_content.Items.Clear();
        }
    }
}
