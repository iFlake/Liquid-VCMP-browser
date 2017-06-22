using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Liquid_VCMP_browser
{
    public class Configuration
    {
        public MasterlistConfiguration masterlist = new MasterlistConfiguration();
        public UpdaterConfiguration updater = new UpdaterConfiguration();
        public DownloadmirrorConfiguration downloadmirror = new DownloadmirrorConfiguration();
        public DirectoryConfiguration directories = new DirectoryConfiguration();
        public InternationalizationConfiguration internationalization = new InternationalizationConfiguration();
        public DefaultIdentityConfiguration defaultidentity = new DefaultIdentityConfiguration();
        public string[] favorites = new string[0];
        public PlatformdependentidentityConfiguration[] platformdependentidentity = new PlatformdependentidentityConfiguration[0];
    }

    public class MasterlistConfiguration
    {
        public string url = "http://vcmp.master.cloudwards.es:10732";
    }

    public class UpdaterConfiguration
    {
        public string url = "https://updater.liquid.iceflake.cloudwards.es";
        public string password = "";
        public bool check = true;
    }

    public class DownloadmirrorConfiguration
    {
        public string url = "https://mirror.liquid.iceflake.cloudwards.es";
        public bool check = true;
    }

    public class DirectoryConfiguration
    {
        public string vicecity = "";
        public string downloads = "";
    }

    public class InternationalizationConfiguration
    {
        public string language = "ENUS";
    }

    public class DefaultIdentityConfiguration
    {
        public string nickname = "";
        public string welcomemessage = "";
    }

    public class PlatformdependentidentityConfiguration
    {
        public string platform = "0.0.0.0:0";
        public string nickname = "";
        public string password = "";
        public string welcomemessage = "";
        public bool suppressdefaultwelcomemessage = false;
    }

    public static class ConfigurationManager
    {
        public static Configuration configuration = new Configuration();

        public static void Save()
        {
            JsonIndenter indenter = new JsonIndenter();
            string serial = indenter.Indent(Newtonsoft.Json.JsonConvert.SerializeObject(configuration, Newtonsoft.Json.Formatting.None));

            System.IO.File.WriteAllText(Application.StartupPath + "/vcmp-config.json", serial);
        }
        
        public static void Load()
        {
            string serial = System.IO.File.ReadAllText(Application.StartupPath + "/vcmp-config.json");
            configuration = Newtonsoft.Json.JsonConvert.DeserializeObject<Configuration>(serial);
        }
    }
}
