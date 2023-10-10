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
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using OfficeOpenXml;
using Microsoft.Win32;

namespace Find_messages_with_keywords
{
    public partial class MainWindow : Window
    {
        public static Thread td_client;
        public static long time = 0;
        public Dictionary<string, string> settings_json = Settings_json.LoadDictionaryFromJson();
        public static List<string> keywords = new List<string>();
        public static string name_channel = "";
        Thread search_thread;
        public MainWindow()
        {
            InitializeComponent();
            if (!IsCppRedistributableInstalled())
            {
                MessageBox.Show("To use the program, you need to install C++ from Microsoft");
                return;
            }
            if (settings_json["Is_autorization"] == "True")
            {
                Create_client();
            }
        }
        public static bool IsCppRedistributableInstalled()
        {
            string registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

            RegistryView[] registryViews = new RegistryView[]
            {
                RegistryView.Registry32,
                RegistryView.Registry64
            };

            foreach (var view in registryViews)
            {
                using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view))
                {
                    using (var uninstallKey = baseKey.OpenSubKey(registryPath))
                    {
                        foreach (var subKeyName in uninstallKey.GetSubKeyNames())
                        {
                            using (var subKey = uninstallKey.OpenSubKey(subKeyName))
                            {
                                var displayName = subKey.GetValue("DisplayName") as string;
                                if (displayName != null && displayName.Contains("Visual C++"))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }
        private void Create_client()
        {
            Abort_client();
            td_client = new Thread(o =>
            {
                TdFunc.Start();
                if (TdFunc._haveAuthorization)
                {
                    settings_json["Is_autorization"] = "True";
                    Settings_json.SaveDictionaryToJson(settings_json);
                }
                System.Windows.Threading.Dispatcher.Run();
            });
            td_client.Start();
        }
        public static void Abort_client()
        {
            try
            {
                if (td_client != null)
                {
                    TdFunc.Exit_autorization();
                    td_client.Abort();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Menu_autorize_Click(object sender, RoutedEventArgs e)
        {
            if (settings_json["Is_autorization"] == "True")
                MessageBox.Show("Ви уже авторизированы");
            else
            {
                Create_client();
            }
        }

        private void Menu_change_chat_links_Click(object sender, RoutedEventArgs e)
        {
            if (settings_json["Is_autorization"] == "False")
            {
                MessageBox.Show("Ви не авторизированы");
                return;
            }
            if (search_thread != null)
            {
                MessageBox.Show("Процесс поиска уже начат");
                return;
            }
            Find_chats find_channel = new Find_chats();
            find_channel.ShowDialog();
        }

        private void Menu_keywords_Click(object sender, RoutedEventArgs e)
        {
            if (search_thread != null)
            {
                MessageBox.Show("Процесс пошуку вже розпочато");
                return;
            }
            var filePath = "keywords.txt";
            if (!File.Exists(filePath))
                File.Create(filePath).Close();
            System.Diagnostics.Process.Start(filePath);
        }

        private void TextBox_time_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.D0 && e.Key != Key.D1 && e.Key != Key.D2 &&
                e.Key != Key.D3 && e.Key != Key.D4 && e.Key != Key.D5 &&
                e.Key != Key.D6 && e.Key != Key.D7 && e.Key != Key.D8 &&
                e.Key != Key.D9)
            {
                e.Handled = true;
            }
        }

        private void TextBox_time_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (long.Parse(TextBox_time.Text) > 168)
                    TextBox_time.Text = 168.ToString();
            }
            catch { }
        }
        private void Delete_directory(string directoryPath)
        {
            try
            {
                Directory.Delete(directoryPath, true);
            }
            catch { }
        }
        private void Delete_account()
        {
            settings_json["Is_autorization"] = "False";
            Settings_json.SaveDictionaryToJson(settings_json);
            Abort_client();
            Delete_directory(@"tdlib");
            TdFunc._haveAuthorization = false;
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            if (!TdFunc._haveAuthorization)
                Delete_account();
            if (search_thread != null)
                SaveToExcel();
            Environment.Exit(0);
        }
        private static void Change_TextBlock(ListView Scroll_viewer)
        {
            ObservableCollection<Scroll_source> items = new ObservableCollection<Scroll_source>();
            Scroll_viewer.ItemsSource = items;
            for (int index = 0; index < TdFunc.all_id_exist_message.Count; index++)
            {
                var tmp = new Scroll_source()
                {
                    Text = TdFunc.all_id_exist_message_text[index] + "\n",
                    LinkText = TdFunc.all_link_exist_user[index] + "\n" + TdFunc.all_full_name_exist_user[index],
                    Url = TdFunc.all_link_exist_user[index]
                };
                items.Add(tmp);
            }

        }
        public static void SaveToExcel()
        {
            if (TdFunc.all_id_exist_message_text.Count == 0)
                return;
            string currentTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            string name_dir = "Данные";
            string filePath = name_dir + "\\Збір даних_" + currentTime + ".xlsx";
            if (!Directory.Exists(name_dir))
                Directory.CreateDirectory(name_dir);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                for (int i = 0; i < TdFunc.all_id_exist_message_text.Count; i++)
                {
                    worksheet.Cells[i + 1, 1].Value = TdFunc.all_id_exist_message_text[i];
                }

                for (int i = 0; i < TdFunc.all_full_name_exist_user.Count; i++)
                {
                    worksheet.Cells[i + 1, 2].Value = TdFunc.all_full_name_exist_user[i];
                }
                for (int i = 0; i < TdFunc.all_link_exist_user.Count; i++)
                {
                    worksheet.Cells[i + 1, 3].Value = TdFunc.all_link_exist_user[i];
                }
                package.SaveAs(new FileInfo(filePath));
            }
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            //"Is_autorization"
            if (settings_json["Is_autorization"] == "False")
            {
                MessageBox.Show("Ви не авторизированы");
                return;
            }
            if (search_thread != null)
            {
                MessageBox.Show("Процесс поиска уже начат");
                return;
            }
            Start.IsEnabled = false;
            Stop.IsEnabled = true;
            TextBox_time.IsReadOnly = true;
            var filePath = "keywords.txt";
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines("keywords.txt");
                keywords = new List<string>(lines);
            }
            else
            {
                keywords = new List<string>();
            }
            Scroll_viewer.ItemsSource = new List<string>();
            TdFunc.all_id_exist_chat = new List<long>();
            TdFunc.all_id_exist_message = new List<long>();
            TdFunc.all_id_exist_message_text = new List<string>();
            TdFunc.all_id_exist_user = new List<long>();
            TdFunc.all_link_exist_user = new List<string>();
            TdFunc.all_full_name_exist_user = new List<string>();

            try
            {
                if (TextBox_time.Text != "")
                    time = long.Parse(TextBox_time.Text);
                else time = 0;
            }
            catch
            {
                time = 0;
            }
            search_thread = new Thread(() =>
            {
                if (time > 0)
                {
                    foreach (var channel in Settings_json.ReadAllChannels())
                    {
                        name_channel = channel.Value;
                        TdFunc.is_exist = false;
                        TdFunc.Search_old_messanges(channel.Key);
                        if (TdFunc.is_exist)
                            Scroll_viewer.Dispatcher.Invoke(() =>
                            {
                                Change_TextBlock(Scroll_viewer);
                            });
                    }
                }
                while (true)
                {
                    foreach (var channel in Settings_json.ReadAllChannels())
                    {
                        name_channel = channel.Value;
                        TdFunc.is_exist = false;
                        TdFunc.Search_new_messanges(channel.Key);
                        if (TdFunc.is_exist)
                            Scroll_viewer.Dispatcher.Invoke(() =>
                            {
                                Change_TextBlock(Scroll_viewer);
                            });
                    }
                    System.Threading.Thread.Sleep(1000);
                }
                System.Windows.Threading.Dispatcher.Run();
            });
            search_thread.Start();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            if (settings_json["Is_autorization"] == "False")
            {
                MessageBox.Show("Ви не авторизированы");
                return;
            }
            if (search_thread == null)
            {
                MessageBox.Show("Процесс ещё не начат");
                return;
            }
            SaveToExcel();
            TextBox_time.IsReadOnly = false;
            Start.IsEnabled = true;
            Stop.IsEnabled = false;
            search_thread.Abort();
            search_thread = null;
        }
        private void Scroll_viewer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (settings_json["Is_autorization"] == "False")
            {
                MessageBox.Show("Ви не авторизированы");
                return;
            }
            this.Dispatcher.Invoke(() =>
            {
                if ((Find_messages_with_keywords.Scroll_source)((System.Windows.Controls.Primitives.Selector)sender).SelectedItem != null)
                {
                    try
                    {
                        string url = ((Find_messages_with_keywords.Scroll_source)((System.Windows.Controls.Primitives.Selector)sender).SelectedItem).Url;
                        System.Diagnostics.Process.Start(url);
                    }
                    catch
                    {
                        Clipboard.SetText(((Find_messages_with_keywords.Scroll_source)((System.Windows.Controls.Primitives.Selector)sender).SelectedItem).Text);
                    }
                }
            });
        }

        private void Menu_about_program_Click(object sender, RoutedEventArgs e)
        {
            About_program about_program_form = new About_program();
            about_program_form.ShowDialog();
        }
    }
    public class Scroll_source
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public string LinkText { get; set; }
    }
}
