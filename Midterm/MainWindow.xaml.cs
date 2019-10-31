/*
 * Travis Cartmell
 * 
 * This program lets a user monitor activity in a given directory such as creating, deleting, renaming, and editing files/directories.
 * More control options are added in this one as apposed to Assignment2 such as letting users filter results by extensions.
 * 
 * Added database functionality. User can choose which db to upload to, and which to query.
 * Closing the form from the menu toolbar is the only way to get the save data confirmation to pop up. Can't figure out how to do it
 * by clicking the x in the top right. <- figured it out.
 * 
 * Added hotkeys (way easier than I thought). Don't specifiy them in the help doc though.
 * 
 * Started monitoring subdirectories. I'm mad that it was only one line of code setting a boolean to true.
 * 
 * 
 * 
 * 
 * 
 * Possible Extra Credit:
 * 
 * User can select their an existing database rather than creating a new one program execution.
 * Also, when a user creates a database, they can select the name and location it gets saved to.
 * 
 * When closing the program before saving the log to a db, the confirmation prompt comes up, however, the user can then choose
 * whether to write to an existing db or create a new one and write the data to that one.
 * 
 */

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
using System.IO;
using System.Data;
using System.Collections.ObjectModel;
using System.Data.SQLite;

namespace Midterm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileSystemWatcher watcher;
        List<Item> item_list = new List<Item>();
        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;

        public MainWindow()
        {
            InitializeComponent();
            watcher = new FileSystemWatcher();
            watcher.IncludeSubdirectories = true;

            watcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;

            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnRenamed;

            cmb_extensions.Items.Add("");
            cmb_extensions.Items.Add(".txt");
            cmb_extensions.Items.Add(".exe");
            cmb_extensions.Items.Add(".pdf");
            cmb_extensions.Items.Add(".wordx");
            cmb_extensions.Items.Add(".cs");
            cmb_extensions.Items.Add(".java");

            lbl_current.Content = "Current filter: all";
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            string text = $"{e.Name}: {e.FullPath} {e.ChangeType} {DateTime.Now}";
            string[] ext_array = e.Name.Split('.');
            string ext;
            if (ext_array.Length < 2)
                ext = "Directory";
            else
                ext = "." + ext_array[1];

            this.Dispatcher.Invoke(() =>
            {
                Item item = new Item
                {
                    Extension = ext,
                    Filename = e.Name,
                    Path = e.FullPath,
                    Event = e.ChangeType.ToString(),
                    Date = DateTime.Now.ToString()
                };

                item_list.Add(item);
                dg_content.Items.Add(item);
            });

            Console.WriteLine(text);
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            string text = $"{e.OldName} renamed to {e.Name}: {e.FullPath} {e.ChangeType} {DateTime.Now}";
            string[] ext_array = e.Name.Split('.');
            string ext;
            if (ext_array.Length < 2)
                ext = "Directory";
            else
                ext = "." + ext_array[1];

            this.Dispatcher.Invoke(() =>
            {
                Item item = new Item
                {
                    Extension = ext,
                    Filename = e.OldName + " -> " + e.Name,
                    Path = e.FullPath,
                    Event = e.ChangeType.ToString(),
                    Date = DateTime.Now.ToString()
                };

                item_list.Add(item);
                dg_content.Items.Add(item);
            });

            Console.WriteLine(text);
        }

        private void Btn_start_Click(object sender, RoutedEventArgs e)
        {
            string path = txt_path.Text;

            if (Directory.Exists(path))
            {
                lbl_err.Content = "";
                watcher.Path = path;
                watcher.EnableRaisingEvents = true;
                btn_start.IsEnabled = false;
                btn_stop.IsEnabled = true;
                menu_file_start.IsEnabled = false;
                menu_file_stop.IsEnabled = true;

                lbl_err.Content = "Starting...";
            }
            else
            {
                lbl_err.Content = "Please enter a valid path";
            }
        }

        private void Btn_stop_Click(object sender, RoutedEventArgs e)
        {
            watcher.EnableRaisingEvents = false;
            btn_start.IsEnabled = true;
            btn_stop.IsEnabled = false;
            menu_file_start.IsEnabled = true;
            menu_file_stop.IsEnabled = false;

            watcher.Filter = "*";
            lbl_err.Content = "Stopping...";
        }

        private void Btn_extensions_Click(object sender, RoutedEventArgs e)
        {
            watcher.Filter = "*" + txt_extensions.Text;

            string val = "";
            if (txt_extensions.Text.Equals(""))
                val = "all";
            else
                val = txt_extensions.Text;
            lbl_current.Content = "Current filter: " + val;
        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_extensions.SelectedItem != null)
                txt_extensions.Text = cmb_extensions.SelectedItem.ToString();
        }

        private void Btn_write_Click(object sender, RoutedEventArgs e)
        {

            /*Code grabbed from https://stackoverflow.com/questions/10315188/open-file-dialog-and-select-a-file-using-wpf-controls-and-c-sharp */

            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".db";
            dlg.Filter = "DB Files (*.db)|*.db";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            string[] f;

            if (result == true)
            {
                // Open document 
                f = dlg.FileName.Split('\\');
                lbl_db_name.Content = "Database: " + f[f.Length-1];

                sqlite_conn = new SQLiteConnection($"Data Source={dlg.FileName};Version=3;New=True;Compress=True;");
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();

                foreach (Item item in item_list)
                {
                    sqlite_cmd.CommandText = $"INSERT INTO log (extension, filename, path, event, date) VALUES ('{item.Extension}', '{item.Filename}', '{item.Path}', '{item.Event}', '{item.Date}');";
                    sqlite_cmd.ExecuteNonQuery();
                }
                item_list = new List<Item>();

                sqlite_conn.Close();
            }
        }

        private void Menu_file_db_Click(object sender, RoutedEventArgs e)
        {
            QueryDB query_window = new QueryDB();
            query_window.Show();
        }

        private void Btn_create_db_Click(object sender, RoutedEventArgs e)
        {

            /* Code taken from https://stackoverflow.com/questions/5622854/how-do-i-show-a-save-as-dialog-in-wpf */
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "database"; // Default file name
            dlg.DefaultExt = ".db"; // Default file extension
            dlg.Filter = "Database files (.db)|*.db"; // Filter files by extension

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {

                sqlite_conn = new SQLiteConnection($"Data Source={dlg.FileName};Version=3;New=True;Compress=True;");
                sqlite_conn.Open();

                sqlite_cmd = sqlite_conn.CreateCommand();

                sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS log (extension varchar(10), filename varchar(25), path varchar(100), event varchar(25), date varchar(30));";
                sqlite_cmd.ExecuteNonQuery();

                sqlite_conn.Close();

                lbl_db_err.Content = $"{dlg.FileName} created";
            }
        }

        private void Menu_help_Click(object sender, RoutedEventArgs e)
        {
            Help help_window = new Help();
            help_window.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (item_list.Count != 0)
            {
                CloseConfirmation close_window = new CloseConfirmation();
                close_window.setList(item_list);
                close_window.ShowDialog();
            }
            else
                Environment.Exit(0);
        }

        private void Window_Closing(object sender, RoutedEventArgs e)
        {
            if (item_list.Count != 0)
            {
                CloseConfirmation close_window = new CloseConfirmation();
                close_window.setList(item_list);
                close_window.ShowDialog();
            }
            else
                Environment.Exit(0);
        }

        private void Menu_edit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You found me!", "Useless Box");
        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            dg_content.Items.Clear();
        }
    }
}
