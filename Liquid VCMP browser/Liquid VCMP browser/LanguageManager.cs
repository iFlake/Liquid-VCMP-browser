using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Liquid_VCMP_browser
{
    public class Language
    {
        public string name = "";
        public bool ltr = true;
        public Phrases phrases = new Phrases();
    }
    
    public class Phrases
    {
        public string servers = "";
        public string favorites = "";
        public string internet = "";
        public string official = "";
        public string normal = "";
        public string settings = "";
        public string nickname = "";
    }

    public static class LanguageManager
    {
        public static Language language = new Language();
        
        public static void Load()
        {
            Load(ConfigurationManager.configuration.internationalization.language);
        }

        public static void Load(string ilanguage)
        {
            string serial = System.IO.File.ReadAllText(Application.StartupPath + "/internationalization/" + ilanguage + ".json");
            language = Newtonsoft.Json.JsonConvert.DeserializeObject<Language>(serial);
        }
    }
}
