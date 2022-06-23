using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using static WebhookSpammer.Config.NONELoggs;

namespace WebhookSpammer.Config
{
    public static class configuration
    {

        // Path System for Needed Files.
        public static string WebAgentPath => UserAgents();  // Create File if not Exist
        public static string ConfigPath => PathINIConfig(); // Create file if not Exist
        public static string ProxyListPath => ProxyList();  // Create file if not Exist

        // Config after Read the INI
        public static string WebhookURL { get; set; }
        public static bool isDWP { get; set; }                  // Is Discord Webhook Protrctor
        public static bool CheckProxyBeforeRequest { get; set; }
        
        // Config for the Webhook
        public static string Username { get; set; }
        public static string UserImage { get; set; }
        public static string Content { get; set; }
        public static bool TextToSpeek { get; set; } 
        
        public static int HowManySend { get; set; }


        /*
        This is only there to bypass the Webhook Protector from Rdimo.
        Spam it!
        https://github.com/Rdimo/Discord-Webhook-Protector 
        */
        public static string WebhookprotectorURL { get; set; }         // Code Information ignore that!
        public static string Password            { get; set; }         // Base64 Encoded Password from it.
        public static int ChangeAfterRequest     { get; set; }         // After Request Nr. X the Proxy will Change. No Rate Limit anymore
        public static int Port                   { get; set; }         // Port to Spam
        public static int SpamAfter              { get; set; }         // INT Proxys in list to start Spamming
        
        
        
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
            WriteState("Create INI");
            if (!File.Exists("./config.ini"))
            {
                WriteState($"Create Config INI");

                INISystem a_ini = new INISystem("./config.ini");
                // Config`s
                a_ini.Write("WebhookURL", "null", "SYSCONFIG");
                a_ini.Write("isDWP", "true/false", "SYSCONFIG");
                a_ini.Write("CheckProxyBeforeRequest", "true/false", "SYSCONFIG");
            
                // Webhook Content
                a_ini.Write("Username", "null", "WEBHOOK");
                a_ini.Write("UserImage", "null", "WEBHOOK");
                a_ini.Write("Content", "null", "WEBHOOK");
                a_ini.Write("SendNumber", "0", "WEBHOOK");
                a_ini.Write("TextToSpeek", "true/false", "WEBHOOK");
            
                // bypass the Webhook Protector
                a_ini.Write("WebhookprotectorURL", "null", "DWHP");
                a_ini.Write("Password", "null base64", "DWHP");
                a_ini.Write("ChangeAfterRequest", "1", "DWHP");
                a_ini.Write("Port", "3000", "DWHP");
                a_ini.Write("StartSpamAfterTotalProxy", "300", "DWHP");
                
                Console.WriteLine("Created INI. Please Edit the INI and Restart the Programm");
                Thread.Sleep(9000);
                Environment.Exit(0);
            }
            WriteState($"Return Path to INI Config");
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