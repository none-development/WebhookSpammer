using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;

namespace WebhookSpammer.Config
{
    public class configuration
    {

        // Path System for Needed Files.
        public static string WebAgentPath => UserAgents();  // Create File if not Exist
        public static string ConfigPath => PathINIConfig(); // Create file if not Exist
        public static string ProxyListPath => ProxyList();  // Create file if not Exist

        // Config after Read the INI
        public static string WebhookURL { get; set; }
        public static bool isDWP { get; set; }
        public static bool CheckProxyBeforeRequest { get; set; }
        
        // Config for the Webhook
        public static string Username { get; set; }
        public static string UserImage { get; set; }
        public static string Content { get; set; }
        public static bool TextToSpeek { get; set; } 


        /*
        This is only there to bypass the Webhook Protector from Rdimo.
        Spam it!
        https://github.com/Rdimo/Discord-Webhook-Protector 
        */
        public static bool isWebhookprotector { get; set; }         // Code Information ignore that!
        public static string Password         { get; set; }         // Base64 Encoded Password from it.
        public static int ChangeAfterRequest  { get; set; }         // After Request Nr. X the Proxy will Change. No Rate Limit anymore
        public static int Port                { get; set; }         // Port to Spam
        
        
        
        
        
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
                Thread.Sleep(500);
            }

            INISystem a_ini = new INISystem("./config.ini");
            // Config`s
            a_ini.Write("WebhookURL", "null", "SYSCONFIG");
            a_ini.Write("isDWP", "true/false", "SYSCONFIG");
            a_ini.Write("CheckProxyBeforeRequest", "true/false", "SYSCONFIG");
            
            // Webhook Content
            a_ini.Write("Username", "null", "WEBHOOK");
            a_ini.Write("UserImage", "null", "WEBHOOK");
            a_ini.Write("Content", "null", "WEBHOOK");
            a_ini.Write("TextToSpeek", "true/false", "WEBHOOK");
            
            // bypass the Webhook Protector
            a_ini.Write("isWebhookprotector", "true/false", "DWHP");
            a_ini.Write("Password", "null base64", "DWHP");
            a_ini.Write("ChangeAfterRequest", "1", "DWHP");
            a_ini.Write("Port", "3000", "DWHP");
            
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
        
    }
}