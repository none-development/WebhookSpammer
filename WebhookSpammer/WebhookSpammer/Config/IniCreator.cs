using WebhookSpammer.Config;
using static WebhookSpammer.Config.configuration;

namespace WebhookSpammer.Config
{
    public static class IniCreator
    {
        private static INISystem a_ini = new INISystem(configuration.ConfigPath);
        
        public static void InitSystem()
        {
            WebhookURL = a_ini.Read("WebhookURL", "SYSCONFIG");
            
            
            isDWP = a_ini.ReadBool("isDWP", "SYSCONFIG");
            CheckProxyBeforeRequest = a_ini.ReadBool("CheckProxyBeforeRequest", "SYSCONFIG");
            
            // Webhook Content
            Username = a_ini.Read("Username", "WEBHOOK");
            UserImage = a_ini.Read("UserImage", "WEBHOOK");
            Content = a_ini.Read("Content", "WEBHOOK");
            TextToSpeek = a_ini.ReadBool("TextToSpeek",  "WEBHOOK");
            HowManySend = a_ini.ReadInt("SendNumber", "WEBHOOK");
            
            // bypass the Webhook Protector
            WebhookprotectorURL = a_ini.Read("WebhookprotectorURL", "DWHP");
            Password = a_ini.Read("Password", "DWHP");
            ChangeAfterRequest = a_ini.ReadInt("ChangeAfterRequest", "DWHP");
            Port = a_ini.ReadInt("Port", "DWHP");
            SpamAfter = a_ini.ReadInt("StartSpamAfterTotalProxy", "DWHP");
        }
        
    }
}