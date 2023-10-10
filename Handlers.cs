using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Td = Telegram.Td;
using TdApi = Telegram.Td.Api;

namespace Find_messages_with_keywords
{
    internal class Handlers
    {
        public class DefaultHandler : Td.ClientResultHandler
        {
            void Td.ClientResultHandler.OnResult(TdApi.BaseObject @object)
            {
                //string qwe = @object.ToString();
                //MessageBox.Show(@object.ToString());
                //Console.WriteLine("default");
                //Console.WriteLine(@object.ToString());
                TdFunc._isResultReceived = true;
            }
        }
        public class SendMessageHandler : Td.ClientResultHandler
        {
            void Td.ClientResultHandler.OnResult(TdApi.BaseObject @object)
            {
                if (@object.GetType() != typeof(Telegram.Td.Api.Message))
                {
                    TdFunc._isResultReceived = true;
                    return;
                }
                try
                {
                }
                catch
                {
                }
                TdFunc._isResultReceived = true;
            }
        }
        //GetUserNameHandler
        public class GetUserLinkHandler : Td.ClientResultHandler
        {
            void Td.ClientResultHandler.OnResult(TdApi.BaseObject @object)
            {
                if (@object.GetType() != typeof(Telegram.Td.Api.User))
                {
                    TdFunc._isResultReceived = true;
                    return;
                }
                try
                {
                    if (TdFunc.all_full_name_exist_user.Count < TdFunc.count_data)
                    {
                        var go_add = false;
                        if (((Telegram.Td.Api.User)(@object)).FirstName != "")
                        {
                            TdFunc.all_full_name_exist_user.Add(((Telegram.Td.Api.User)(@object)).FirstName);
                            go_add = true;
                        }
                        if (((Telegram.Td.Api.User)(@object)).LastName != "")
                        {
                            if (go_add)
                                TdFunc.all_full_name_exist_user[TdFunc.all_full_name_exist_user.Count - 1] += " " + ((Telegram.Td.Api.User)(@object)).LastName;
                            else
                                TdFunc.all_full_name_exist_user.Add(((Telegram.Td.Api.User)(@object)).LastName);
                            go_add = true;
                        }
                        if (!go_add)
                            TdFunc.all_full_name_exist_user.Add("");
                        go_add = false;
                        if (((Telegram.Td.Api.User)(@object)).Usernames == null)
                        {
                            TdFunc.all_link_exist_user.Add(MainWindow.name_channel);
                            go_add = true;
                        }
                        else
                        {
                            TdFunc.all_link_exist_user.Add("https://t.me/" + ((Telegram.Td.Api.User)(@object)).Usernames.EditableUsername);
                            go_add = true;
                        }
                        if (!go_add)
                            TdFunc.all_link_exist_user.Add("");
                    }
                }
                catch
                {
                }
                TdFunc._isResultReceived = true;
            }
        }
        public class OldMessagesHandler : Td.ClientResultHandler
        {
            void Td.ClientResultHandler.OnResult(TdApi.BaseObject @object)
            {
                if (@object.GetType() != typeof(Telegram.Td.Api.Messages))
                {
                    TdFunc._isResultReceived = true;
                    return;
                }
                try
                {
                    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Date);
                    DateTime message_dateTime = dateTimeOffset.LocalDateTime;
                    TimeSpan timeElapsed = DateTime.Now.Subtract(message_dateTime);
                    if (timeElapsed.TotalHours > MainWindow.time)
                    {
                        TdFunc.result = "";
                        TdFunc._isResultReceived = true;
                        return;
                    }
                    if (!TdFunc.all_id_exist_message.Contains(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Id))
                    {
                        if (((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Content.GetType() == typeof(Telegram.Td.Api.MessageText))
                        {
                            string text = ((Telegram.Td.Api.MessageText)((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Content).Text.Text.ToString();
                            //            ((Telegram.Td.Api.MessageText)((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Content).Text.Text
                            if (MainWindow.keywords.Any(text.ToLower().Contains) && text != "")
                            {
                                TdFunc.all_id_exist_user.Add(((Telegram.Td.Api.MessageSenderUser)((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].SenderId).UserId);
                                TdFunc.all_id_exist_chat.Add(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].ChatId);
                                TdFunc.all_id_exist_message.Add(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Id);
                                TdFunc.all_id_exist_message_text.Add(text);
                                TdFunc.is_exist = true;
                            }
                        }
                        else if (((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Content.GetType() == typeof(Telegram.Td.Api.MessagePhoto))
                        {
                            string text = ((Telegram.Td.Api.MessagePhoto)((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Content).Caption.Text.ToString();
                            if (MainWindow.keywords.Any(text.ToLower().Contains) && text != "")
                            {
                                TdFunc.all_id_exist_user.Add(((Telegram.Td.Api.MessageSenderUser)((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].SenderId).UserId);
                                TdFunc.all_id_exist_chat.Add(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].ChatId);
                                TdFunc.all_id_exist_message.Add(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Id);
                                TdFunc.all_id_exist_message_text.Add(text);
                                TdFunc.is_exist = true;
                            }
                        }
                        else if (((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Content.GetType() == typeof(Telegram.Td.Api.MessageDocument))
                        {
                            string text = ((Telegram.Td.Api.MessageDocument)((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Content).Caption.Text.ToString();
                            if (MainWindow.keywords.Any(text.ToLower().Contains) && text != "")
                            {
                                TdFunc.all_id_exist_user.Add(((Telegram.Td.Api.MessageSenderUser)((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].SenderId).UserId);
                                TdFunc.all_id_exist_chat.Add(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].ChatId);
                                TdFunc.all_id_exist_message.Add(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Id);
                                TdFunc.all_id_exist_message_text.Add(text);
                                TdFunc.is_exist = true;
                            }
                        }
                        else if (((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Content.GetType() == typeof(Telegram.Td.Api.MessageVideo))
                        {
                            string text = ((Telegram.Td.Api.MessageVideo)((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Content).Caption.Text.ToString();
                            if (MainWindow.keywords.Any(text.ToLower().Contains) && text != "")
                            {
                                TdFunc.all_id_exist_user.Add(((Telegram.Td.Api.MessageSenderUser)((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].SenderId).UserId);
                                TdFunc.all_id_exist_chat.Add(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].ChatId);
                                TdFunc.all_id_exist_message.Add(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Id);
                                TdFunc.all_id_exist_message_text.Add(text);
                                TdFunc.is_exist = true;
                            }
                        }
                    }
                }
                catch
                {
                    TdFunc.result = "";
                }
                TdFunc.all_messages_id.Add(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Id);
                TdFunc._isResultReceived = true;
            }
        }
        public class NewMessagesHandler : Td.ClientResultHandler
        {
            void Td.ClientResultHandler.OnResult(TdApi.BaseObject @object)
            {
                if (@object.GetType() != typeof(Telegram.Td.Api.Messages))
                {
                    TdFunc._isResultReceived = true;
                    return;
                }
                try
                {
                    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Date);
                    DateTime message_dateTime = dateTimeOffset.LocalDateTime;
                    TimeSpan timeElapsed = DateTime.Now.Subtract(message_dateTime);
                    if (timeElapsed.TotalMinutes > 30)
                    {
                        TdFunc.result = "";
                        TdFunc._isResultReceived = true;
                        return;
                    }
                    if (!TdFunc.all_id_exist_message.Contains(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Id))
                    {
                        if (((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Content.GetType() == typeof(Telegram.Td.Api.MessageText))
                        {
                            string text = ((Telegram.Td.Api.MessageText)((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Content).Text.Text.ToString();
                            //            ((Telegram.Td.Api.MessageText)((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Content).Text.Text
                            if (MainWindow.keywords.Any(text.ToLower().Contains) && text != "")
                            {
                                TdFunc.all_id_exist_user.Add(((Telegram.Td.Api.MessageSenderUser)((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].SenderId).UserId);
                                TdFunc.all_id_exist_chat.Add(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].ChatId);
                                TdFunc.all_id_exist_message.Add(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Id);
                                TdFunc.all_id_exist_message_text.Add(text);
                                TdFunc.is_exist = true;
                            }
                        }
                        else if (((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Content.GetType() == typeof(Telegram.Td.Api.MessagePhoto))
                        {
                            string text = ((Telegram.Td.Api.MessagePhoto)((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Content).Caption.Text.ToString();
                            if (MainWindow.keywords.Any(text.ToLower().Contains) && text != "")
                            {
                                TdFunc.all_id_exist_user.Add(((Telegram.Td.Api.MessageSenderUser)((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].SenderId).UserId);
                                TdFunc.all_id_exist_chat.Add(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].ChatId);
                                TdFunc.all_id_exist_message.Add(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Id);
                                TdFunc.all_id_exist_message_text.Add(text);
                                TdFunc.is_exist = true;
                            }
                        }
                        else if (((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Content.GetType() == typeof(Telegram.Td.Api.MessageDocument))
                        {
                            string text = ((Telegram.Td.Api.MessageDocument)((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Content).Caption.Text.ToString();
                            if (MainWindow.keywords.Any(text.ToLower().Contains) && text != "")
                            {
                                TdFunc.all_id_exist_user.Add(((Telegram.Td.Api.MessageSenderUser)((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].SenderId).UserId);
                                TdFunc.all_id_exist_chat.Add(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].ChatId);
                                TdFunc.all_id_exist_message.Add(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Id);
                                TdFunc.all_id_exist_message_text.Add(text);
                                TdFunc.is_exist = true;
                            }
                        }
                        else if (((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Content.GetType() == typeof(Telegram.Td.Api.MessageVideo))
                        {
                            string text = ((Telegram.Td.Api.MessageVideo)((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Content).Caption.Text.ToString();
                            if (MainWindow.keywords.Any(text.ToLower().Contains) && text != "")
                            {
                                TdFunc.all_id_exist_user.Add(((Telegram.Td.Api.MessageSenderUser)((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].SenderId).UserId);
                                TdFunc.all_id_exist_chat.Add(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].ChatId);
                                TdFunc.all_id_exist_message.Add(((Telegram.Td.Api.Messages)(@object)).MessagesValue[0].Id);
                                TdFunc.all_id_exist_message_text.Add(text);
                                TdFunc.is_exist = true;
                            }
                        }
                    }
                }
                catch
                {
                    TdFunc.result = "";
                }
                TdFunc._isResultReceived = true;
            }
        }
        public class NameAllChatsHandler : Td.ClientResultHandler
        {
            void Td.ClientResultHandler.OnResult(TdApi.BaseObject @object)
            {
                if (@object.GetType() != typeof(Telegram.Td.Api.Chat))
                {
                    TdFunc._isResultReceived = true;
                    return;
                }
                try
                {
                    TdFunc.dict_chats.Add(((Telegram.Td.Api.Chat)(@object)).Id, ((Telegram.Td.Api.Chat)(@object)).Title);
                }
                catch { }
                TdFunc._isResultReceived = true;
            }
        }
        public class AllChatsIdsHandler : Td.ClientResultHandler
        {
            void Td.ClientResultHandler.OnResult(TdApi.BaseObject @object)
            {
                if (@object.GetType() != typeof(TdApi.Chats))
                {
                    TdFunc._isResultReceived = true;
                    return;
                }
                try
                {
                    TdFunc.all_chats_id = ((Telegram.Td.Api.Chats)(@object)).ChatIds.ToList();
                }
                catch { }
                TdFunc._isResultReceived = true;
            }
        }
        public class UpdateHandler : Td.ClientResultHandler
        {
            void Td.ClientResultHandler.OnResult(TdApi.BaseObject @object)
            {
                if (@object is TdApi.UpdateAuthorizationState)
                {
                    TdFunc.OnAuthorizationStateUpdated((@object as TdApi.UpdateAuthorizationState).AuthorizationState);
                }
                else
                {
                    //Console.WriteLine(@object.ToString());
                    // Print("Unsupported update: " + @object);
                }
            }
        }

        public class AuthorizationRequestHandler : Td.ClientResultHandler
        {
            void Td.ClientResultHandler.OnResult(TdApi.BaseObject @object)
            {
                if (@object is TdApi.Error)
                {
                    if (((Telegram.Td.Api.Error)(@object)).Code != 500)
                        MessageBox.Show("Receive an error:" + TdFunc._newLine + @object);
                    TdFunc.OnAuthorizationStateUpdated(null); // repeat last action
                }
                else
                {
                    // result is already received through UpdateAuthorizationState, nothing to do
                }
            }
        }
    }
}
