using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using static System.Console;
using static WebhookSpammer.Config.NONELoggs;
using static WebhookSpammer.Config.IniCreator;
using static WebhookSpammer.Config.configuration;
using WebhookSpammer.functions.webhookprotector.ProxyScraper;
using static System.Console;

namespace WebhookSpammer
{
    internal class Program
    {
        private static string[] StartUp = 
        {
            "            Webhook Spammer by NONE               ",
            "https://github.com/none-development/WebhookSpammer",
            "..................................................."
        };
        public static void Main(string[] args)
        {
            foreach (var VARIABLE in StartUp)
            {
                WriteLine(VARIABLE);   
            }
            // Init Logging
            InitLogging();
            WriteState("Logs Started!");
            WriteLine("Started Logs");
            
            // Read Data in 
            InitSystem();  
            WriteState("Started INI System!");




            if (isDWP == true)
            {
                WriteLine("Scrape for Proxys that can take a while...");
                Srcaper PC = new Srcaper();
                PC.StartScrape();
                
                Write("Wait 1 Sec to get Proxys");
                Thread.Sleep(1000);
                Write("Start Spammer...");
                functions.wehookprotector.RequestSpammer.SendSpam();

            }
            else
            {
                functions.discord.WebhookSpammer.SpamMessage();
            }
        }
    }
}