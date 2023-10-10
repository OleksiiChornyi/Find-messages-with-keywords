using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace Find_messages_with_keywords
{
    internal class Settings_json
    {
        public static void SaveDictionaryToJson(Dictionary<string, string> dictionary)
        {
            string filePath = "settings.json";
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            string json = JsonConvert.SerializeObject(dictionary);
            File.WriteAllText(filePath, json);
        }

        public static Dictionary<string, string> LoadDictionaryFromJson()
        {
            string filePath = "settings.json";
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                dictionary.Add("Is_autorization", "False");
                string dictionary_json = JsonConvert.SerializeObject(dictionary);
                File.WriteAllText(filePath, dictionary_json);
            }
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }
        public static Dictionary<long, string> ReadAllChannels()
        {
            string allChannels = "all_channels.json";
            if (!File.Exists(allChannels))
            {
                File.Create(allChannels).Close();
            }
            string json = File.ReadAllText(allChannels);
            var result = JsonConvert.DeserializeObject<Dictionary<long, string>>(json);
            if (result == null)
                result = new Dictionary<long, string>();
            return result;
        }
        public static void WriteAllChannels(Dictionary<long, string> dictionary)
        {
            string allChannels = "all_channels.json";
            if (!File.Exists(allChannels))
            {
                File.Create(allChannels).Close();
            }
            string dictionary_json = JsonConvert.SerializeObject(dictionary);
            File.WriteAllText(allChannels, dictionary_json);
        }
    }
}
