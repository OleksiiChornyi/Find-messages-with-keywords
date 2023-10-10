using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Td = Telegram.Td;
using TdApi = Telegram.Td.Api;
using System.Threading;
using System.Windows;

namespace Find_messages_with_keywords
{
    class TdFunc
    {
        public static bool _isResultReceived = false;
        private readonly static Td.ClientResultHandler _defaultHandler = new Handlers.DefaultHandler();
        public static Authorization autoForm;
        private static TdApi.AuthorizationState _authorizationState = null;
        public static volatile bool _haveAuthorization = false;
        private static volatile string _currentPrompt = null;
        private static Td.Client _client = CreateTdClient();
        private static volatile bool _needQuit = false;
        private static volatile AutoResetEvent _gotAuthorization = new AutoResetEvent(false);
        private static Thread Td_cloud_start;
        private static Thread Td_cloud_auto_form;
        private static volatile bool _canQuit = false;
        public static readonly string _newLine = Environment.NewLine;
        public static List<long> all_messages_id = new List<long>();
        public static List<long> all_chats_id = new List<long>();
        public static Dictionary<long, string> dict_chats = new Dictionary<long, string>();
        public static long chat_id;

        private readonly static Td.ClientResultHandler _chatHandler = new Handlers.NameAllChatsHandler();
        private readonly static Td.ClientResultHandler _allchatsHandler = new Handlers.AllChatsIdsHandler();
        private readonly static Td.ClientResultHandler _oldmessageHandler = new Handlers.OldMessagesHandler();
        private readonly static Td.ClientResultHandler _newmessageHandler = new Handlers.NewMessagesHandler();
        private readonly static Td.ClientResultHandler _getUserLinkHandler = new Handlers.GetUserLinkHandler();

        private static string[] name_keys = new string[]
        {
            "Phone Number", "Email Address", "Phone Code", "Email Code"
        };
        private static Dictionary<string, string> dictionary = new Dictionary<string, string>()
        {
            [name_keys[0]] = "",
            [name_keys[1]] = "",
            [name_keys[2]] = "",
            [name_keys[3]] = ""
        };
        public static string result = "No empty";
        public static bool is_exist = false;
        public static List<long> all_id_exist_chat = new List<long>();
        public static List<long> all_id_exist_message = new List<long>();
        public static List<string> all_id_exist_message_text = new List<string>();
        public static List<long> all_id_exist_user = new List<long>();
        public static List<string> all_link_exist_user = new List<string>();
        public static List<string> all_full_name_exist_user = new List<string>();
        public static long count_data = 0;
        private static void Print(string str)
        {
            if (_currentPrompt != null)
            {
                Console.WriteLine();
            }
            //Console.WriteLine(str);
            if (_currentPrompt != null)
            {
                Console.Write(_currentPrompt);
            }
        }
        private static Td.Client CreateTdClient()
        {
            return Td.Client.Create(new Handlers.UpdateHandler());
        }
        private static void Vesible_elements_auto_form(TdApi.AuthorizationState authorizationState)
        {
            if (authorizationState == null)
                return;
            if (authorizationState is TdApi.AuthorizationStateWaitCode)
            {
                autoForm.Dispatcher.Invoke(() =>
                {
                    if (dictionary[name_keys[0]] != "")
                    {
                        Authorization.Visible_TextBox(autoForm.Phone_Number, dictionary[name_keys[0]]);
                        autoForm.Phone_Number.IsReadOnly = true;
                    }
                });
            }
            else if (authorizationState is TdApi.AuthorizationStateWaitEmailCode)
            {
                autoForm.Dispatcher.Invoke(() =>
                {
                    if (dictionary[name_keys[0]] != "")
                    {
                        Authorization.Visible_TextBox(autoForm.Phone_Number, dictionary[name_keys[0]]);
                        autoForm.Phone_Number.IsReadOnly = true;
                    }
                    if (dictionary[name_keys[1]] != "")
                    {
                        Authorization.Visible_TextBox(autoForm.Email_Address, dictionary[name_keys[1]]);
                        autoForm.Email_Address.IsReadOnly = true;
                    }
                    if (dictionary[name_keys[2]] != "")
                    {
                        Authorization.Visible_TextBox(autoForm.Auth_Phone_Code, dictionary[name_keys[2]]);
                        autoForm.Auth_Phone_Code.IsReadOnly = true;
                    }
                });
            }
            else if (authorizationState is TdApi.AuthorizationStateWaitPassword)
            {
                autoForm.Dispatcher.Invoke(() =>
                {
                    if (dictionary[name_keys[0]] != "")
                    {
                        Authorization.Visible_TextBox(autoForm.Phone_Number, dictionary[name_keys[0]]);
                        autoForm.Phone_Number.IsReadOnly = true;
                    }
                    if (dictionary[name_keys[1]] != "")
                    {
                        Authorization.Visible_TextBox(autoForm.Email_Address, dictionary[name_keys[1]]);
                        autoForm.Email_Address.IsReadOnly = true;
                    }
                    if (dictionary[name_keys[2]] != "")
                    {
                        Authorization.Visible_TextBox(autoForm.Auth_Phone_Code, dictionary[name_keys[2]]);
                        autoForm.Auth_Phone_Code.IsReadOnly = true;
                    }
                    if (dictionary[name_keys[3]] != "")
                    {
                        Authorization.Visible_TextBox(autoForm.Auth_Email_Code, dictionary[name_keys[3]]);
                        autoForm.Auth_Email_Code.IsReadOnly = true;
                    }
                });
            }
        }
        public static void OnAuthorizationStateUpdated(TdApi.AuthorizationState authorizationState)
        {
            Vesible_elements_auto_form(authorizationState);
            if (authorizationState != null)
            {
                _authorizationState = authorizationState;
                //Console.WriteLine(authorizationState.ToString());
            }
            if (_authorizationState is TdApi.AuthorizationStateWaitTdlibParameters)
            {
                TdApi.SetTdlibParameters request = new TdApi.SetTdlibParameters();
                request.DatabaseDirectory = "tdlib";
                request.UseMessageDatabase = true;
                request.UseSecretChats = true;
                request.ApiId = 28738351;
                request.ApiHash = "f1960186b809b0bf1931d70874f07688";
                request.SystemLanguageCode = "en";
                request.DeviceModel = "Desktop";
                request.ApplicationVersion = "1.0";
                request.EnableStorageOptimizer = true;
                _client.Send(request, new Handlers.AuthorizationRequestHandler());
            }
            else if (_authorizationState is TdApi.AuthorizationStateWaitPhoneNumber)
            {
                autoForm.Dispatcher.Invoke(() =>
                {
                    Authorization.Visible_TextBox(autoForm.Phone_Number, dictionary[name_keys[0]]);
                });
                while (!autoForm.isReadyPhoneNumber) ;
                autoForm.Dispatcher.Invoke(() =>
                {
                    _client.Send(new TdApi.SetAuthenticationPhoneNumber(autoForm.Phone_Number.Text, null), new Handlers.AuthorizationRequestHandler());
                    dictionary[name_keys[0]] = autoForm.Phone_Number.Text;
                    autoForm.isReadyPhoneNumber = false;
                });
            }
            else if (_authorizationState is TdApi.AuthorizationStateWaitEmailAddress)
            {
                autoForm.Dispatcher.Invoke(() =>
                {
                    Authorization.Visible_TextBox(autoForm.Email_Address, dictionary[name_keys[1]]);
                });
                while (!autoForm.isReadyEmail) ;
                autoForm.Dispatcher.Invoke(() =>
                {
                    _client.Send(new TdApi.SetAuthenticationEmailAddress(autoForm.Email_Address.Text), new Handlers.AuthorizationRequestHandler());
                    dictionary[name_keys[1]] = autoForm.Email_Address.Text;
                    autoForm.isReadyEmail = false;
                });
            }
            else if (_authorizationState is TdApi.AuthorizationStateWaitEmailCode)
            {
                autoForm.Dispatcher.Invoke(() =>
                {
                    Authorization.Visible_TextBox(autoForm.Auth_Email_Code, dictionary[name_keys[3]]);
                });
                while (!autoForm.isReadyEmailCode) ;
                autoForm.Dispatcher.Invoke(() =>
                {
                    _client.Send(new TdApi.CheckAuthenticationEmailCode(new TdApi.EmailAddressAuthenticationCode(autoForm.Auth_Email_Code.Text)), new Handlers.AuthorizationRequestHandler());
                    dictionary[name_keys[3]] = autoForm.Auth_Email_Code.Text;
                    autoForm.isReadyEmailCode = false;
                });
            }
            else if (_authorizationState is TdApi.AuthorizationStateWaitOtherDeviceConfirmation state)
            {
                MessageBox.Show("Please confirm this login link on another device: " + state.Link);
            }
            else if (_authorizationState is TdApi.AuthorizationStateWaitCode)
            {
                autoForm.Dispatcher.Invoke(() =>
                {
                    Authorization.Visible_TextBox(autoForm.Auth_Phone_Code, dictionary[name_keys[2]]);
                });
                while (!autoForm.isReadyPhoneCode) ;
                autoForm.Dispatcher.Invoke(() =>
                {
                    _client.Send(new TdApi.CheckAuthenticationCode(autoForm.Auth_Phone_Code.Text), new Handlers.AuthorizationRequestHandler());
                    dictionary[name_keys[2]] = autoForm.Auth_Phone_Code.Text;
                    autoForm.isReadyPhoneCode = false;
                });
            }
            else if (_authorizationState is TdApi.AuthorizationStateWaitRegistration)
            {
                MessageBox.Show("This user don`t register, please create an account on telegram.org and continue on this app");
            }
            else if (_authorizationState is TdApi.AuthorizationStateWaitPassword)
            {
                autoForm.Dispatcher.Invoke(() =>
                {
                    Authorization.Visible_TextBox(autoForm.Password);
                });
                while (!autoForm.isReadyPassword) ;
                autoForm.Dispatcher.Invoke(() =>
                {
                    _client.Send(new TdApi.CheckAuthenticationPassword(autoForm.Password.Text), new Handlers.AuthorizationRequestHandler());
                    autoForm.isReadyPassword = false;
                });
            }
            else if (_authorizationState is TdApi.AuthorizationStateReady)
            {
                _haveAuthorization = true;
                _needQuit = true;
                _gotAuthorization.Set();
                while (autoForm == null) ;
                Close_auto_Form();
            }
            else if (_authorizationState is TdApi.AuthorizationStateLoggingOut)
            {
                _haveAuthorization = false;
                Print("Logging out");
            }
            else if (_authorizationState is TdApi.AuthorizationStateClosing)
            {
                _haveAuthorization = false;
                Print("Closing");
            }
            else if (_authorizationState is TdApi.AuthorizationStateClosed)
            {
                Print("Closed");
                if (!_needQuit)
                {
                    _client = CreateTdClient(); // recreate _client after previous has closed
                }
                else
                {
                    _canQuit = true;
                }
            }
            else
            {
                Print("Unsupported authorization state:" + _newLine + _authorizationState);
            }
        }
        public static void Get_user_url()
        {
            count_data = all_id_exist_message.Count;
            _isResultReceived = false;
            var func_message = new TdApi.GetUser(all_id_exist_user[all_id_exist_user.Count - 1]);
            _client.Send(func_message, _getUserLinkHandler);
            while (!_isResultReceived)
            {
                Td.Client.Execute(func_message);
            }
        }
        public static void Search_old_messanges(long id)
        {
            result = "No empty";
            all_messages_id = new List<long> { 0 };

            while (result != "")
            {
                _isResultReceived = false;
                var func_message = new TdApi.GetChatHistory(id, all_messages_id[all_messages_id.Count - 1], 0, 1, false);
                _client.Send(func_message, _oldmessageHandler);
                while (!_isResultReceived)
                {
                    Td.Client.Execute(func_message);
                }
                if (is_exist)
                    Get_user_url();
            }
        }
        public static void Search_new_messanges(long id)
        {
            _isResultReceived = false;
            var func_message = new TdApi.GetChatHistory(id, 0, 0, 1, false);
            _client.Send(func_message, _newmessageHandler);
            while (!_isResultReceived)
            {
                Td.Client.Execute(func_message);
            }
            if (is_exist)
                Get_user_url();
        }
        public static void Find_id_channels()
        {
            while (!_haveAuthorization) ;
            all_chats_id.Clear();
            _isResultReceived = false;
            var func_all_chats = new TdApi.GetChats(new TdApi.ChatListMain(), int.MaxValue);
            _client.Send(func_all_chats, _allchatsHandler);
            while (!_isResultReceived)
            {
                Td.Client.Execute(func_all_chats);
            }
            if (is_exist)
                Get_user_url();
        }
        public static void Find_name_channels()
        {
            dict_chats.Clear();
            foreach (var id in all_chats_id)
            {
                _isResultReceived = false;
                chat_id = 0;
                var func_chats = new TdApi.GetChat(id);
                _client.Send(func_chats, _chatHandler);
                while (!_isResultReceived)
                {
                    Td.Client.Execute(func_chats);
                }
            }
        }
        public static void Find_Channel()
        {
            Find_id_channels();
            while (all_chats_id.Count == 0)
                Find_id_channels();
            Find_name_channels();
            while (dict_chats.Count == 0)
                Find_name_channels();
        }
        public static void Close_auto_Form()
        {
            if (autoForm == null)
            {
                return;
            }
            autoForm.Dispatcher.Invoke(() =>
            {
                try
                {
                    autoForm.Close();
                }
                catch { }
            });

        }
        public static void Exit_autorization()
        {
            if (_client != null)
            {
                _client.Send(new TdApi.Close(), _defaultHandler);
            }
            if (Td_cloud_start != null)
            {
                Td_cloud_start.Abort();
                Td_cloud_start.Join();
            }
            _gotAuthorization.Close();
            _haveAuthorization = false;
            _needQuit = true;
            Close_auto_Form();
        }

        public static void Start()
        {

            //_haveAuthorization = false;
            _needQuit = false;
            _gotAuthorization = new AutoResetEvent(false);
            // disable TDLib log
            Td.Client.Execute(new TdApi.SetLogVerbosityLevel(0));
            if (Td.Client.Execute(new TdApi.SetLogStream(new TdApi.LogStreamFile("tdlib.log", 1 << 27, false))) is TdApi.Error)
            {
                throw new System.IO.IOException("Write access to the current directory is required");
            }
            Td_cloud_start = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Td.Client.Run();
            });//.Start(); //добавить два потока которые можно выключать
            Td_cloud_start.Start();

            // test Client.Execute
            _defaultHandler.OnResult(Td.Client.Execute(new TdApi.GetTextEntities("@telegram /test_command https://telegram.org telegram.me @gif @test")));
            if (Td_cloud_auto_form != null)
                Td_cloud_auto_form.Abort();
            Td_cloud_auto_form = new Thread(o =>
            {
                autoForm = new Authorization();
                autoForm.Show();
                System.Windows.Threading.Dispatcher.Run();
            });
            Td_cloud_auto_form.SetApartmentState(ApartmentState.STA);
            Td_cloud_auto_form.Start();
            // main loop
            while (!_needQuit)
            {
                _gotAuthorization.Reset();
                _gotAuthorization.WaitOne();
            }
        }
    }
}
