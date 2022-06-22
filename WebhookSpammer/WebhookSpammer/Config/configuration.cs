using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace WebhookSpammer.Config
{
    public class configuration
    {
        private static INISystem ini = new INISystem("./config.ini");
        
        // Path System for Needed Files.
        public static string WebAgentPath => UserAgents();  // Create File if not Exist
        public static string ConfigPath => PathINIConfig(); // Create file if not Exist
        public static string ProxyListPath => ProxyList();  // Create file if not Exist

        // Config after Read the INI
        public static string WebhookURL { get; set; }
        public static bool CheckProxyBeforeRequest { get; set; }
        
        
        
        /*
        This is only there to bypass the Webkkok Protector.
        Spam it!
        https://github.com/Rdimo/Discord-Webhook-Protector 
        */
        public static bool isWebhookprotector { get; set; }         // Code Information ignore that!
        public static string Password         { get; set; }         // Base64 Encoded Password from it.
        public static int ChangeAfterRequest  { get; set; }         // After Request Nr. X the Proxy will Change. No Rate Limit anymore
        public static int Port                { get; set; }
        
        
        
        
        
        // Functions
        
        // Create UserAgents file if not Exist and Return it.
        private static string UserAgents()
        {
            if (!File.Exists("./user_agent.txt"))
            {
                File.Create("./user_agent.txt");
            }

            return "./user_agent.txt";
        }

        // Create INI file if not Exist and Return it.
        private static string PathINIConfig()
        {
            if (!File.Exists("./config.ini"))
            {
                File.Create("./config.ini");
            }

            return "./config.ini";
        }
        
        // Create Proxy List file if not Exist and Return it.
        private static string ProxyList()
        {
            if (!File.Exists("./proxy.list"))
            {
                File.Create("./proxy.list");
            }

            return "./proxy.list";
        }

        private static string GetWebhookURL()
        {
            
            return "";
        }
    }
}