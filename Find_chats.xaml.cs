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

namespace Find_messages_with_keywords
{
    /// <summary>
    /// Логика взаимодействия для Find_chats.xaml
    /// </summary>
    public partial class Find_chats : Window
    {
        private static List<CheckBox> CheckBoxes = new List<CheckBox>();
        public Find_chats()
        {
            InitializeComponent();
            TdFunc.Find_Channel();
            Thickness tmp_margin = new Thickness(5, 15, 0, 0);
            foreach (var item in TdFunc.dict_chats)
            {
                var tmp = new CheckBox();
                tmp.Content = item.Value;
                tmp.ToolTip = item.Key;
                var all_channels = Settings_json.ReadAllChannels();
                if (all_channels != null && Settings_json.ReadAllChannels().ContainsKey(item.Key))
                    tmp.IsChecked = true;
                tmp.Margin = tmp_margin;
                CheckBoxes.Add(tmp);
                Stack_chekboxes.Children.Add(tmp);
            }
            Scroll_viewer.Content = Stack_chekboxes;

            Find_chats_text.Focus();
        }

        private void Find_chats_text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Thickness tmp_margin = new Thickness(5, 15, 0, 0);
            Stack_chekboxes.Children.Clear();
            foreach (var item in TdFunc.dict_chats)
            {
                if (item.Value.ToLower().Contains(Find_chats_text.Text.ToLower()))
                {
                    var tmp = new CheckBox();
                    tmp.Content = item.Value;
                    tmp.ToolTip = item.Key;
                    var all_channels = Settings_json.ReadAllChannels();
                    if (all_channels != null && Settings_json.ReadAllChannels().ContainsKey(item.Key))
                        tmp.IsChecked = true;
                    tmp.Margin = tmp_margin;
                    CheckBoxes.Add(tmp);
                    Stack_chekboxes.Children.Add(tmp);
                }
            }
            Scroll_viewer.Content = Stack_chekboxes;
        }

        private void Stack_chekboxes_MouseLeave(object sender, MouseEventArgs e)
        {
            Dictionary<long, string> dictionary = Settings_json.ReadAllChannels();
            foreach (var item in CheckBoxes)
            {
                if (item.IsChecked == true && !dictionary.ContainsKey((long)item.ToolTip))
                    dictionary.Add((long)item.ToolTip, item.Content.ToString());
                if (item.IsChecked == false && dictionary.ContainsKey((long)item.ToolTip))
                    dictionary.Remove((long)item.ToolTip);
            }
            Settings_json.WriteAllChannels(dictionary);
        }
    }
}
