using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Td = Telegram.Td;
using TdApi = Telegram.Td.Api;

namespace Find_messages_with_keywords
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public static TdApi.AuthorizationState _authorizationState = null;
        private static Td.Client _client = null;
        private static volatile bool _haveAuthorization = false;
        private static volatile AutoResetEvent _gotAuthorization = new AutoResetEvent(false);
        private static volatile bool _needQuit = false;
        private static volatile bool _canQuit = false;
        public static readonly string _newLine = Environment.NewLine;
        public bool isReadyPhoneNumber = false;
        public bool isReadyEmail = false;
        public bool isReadyEmailCode = false;
        public bool isReadyPhoneCode = false;
        public bool isReadyPassword = false;
        public bool isReautorization = false;
        public Authorization()
        {
            InitializeComponent();
        }
        private static void Hidden_TextBox(TextBox textBox)
        {
            textBox.Text = " ";
            textBox.Visibility = Visibility.Hidden;
        }
        public static void Visible_TextBox(TextBox textBox, string text = "")
        {
            textBox.Text = text;
            textBox.Visibility = Visibility.Visible;
        }

        private void Phone_Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string text = textBox.Text;
            int caretIndex = textBox.CaretIndex;

            if (text.Length == 0 || caretIndex == 0)
            {
                if (e.Text == "+")
                {
                    e.Handled = false;
                    return;
                }
            }

            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Email_Address_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string text = textBox.Text;
            int caretIndex = textBox.CaretIndex;

            string pattern = @"/^[a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9._-]+$/";
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(text.Insert(caretIndex, e.Text)))
            {
                e.Handled = true;
            }
        }

        private void Phone_Number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                isReadyPhoneNumber = true;
        }

        private void Email_Address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                isReadyEmail = true;
        }

        private void Auth_Email_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                isReadyEmailCode = true;
        }

        private void Auth_Phone_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                isReadyPhoneCode = true;
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                isReadyPassword = true;
        }

        private void Password_MouseEnter(object sender, MouseEventArgs e)
        {
            Password.Effect = null;
        }

        private void Password_MouseLeave(object sender, MouseEventArgs e)
        {
            var blur_effect = new System.Windows.Media.Effects.BlurEffect();
            blur_effect.Radius = 7;
            Password.Effect = blur_effect;
        }
    }
}
