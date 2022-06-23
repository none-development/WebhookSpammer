using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json.Serialization;
using WebhookSpammer.Config;
using static WebhookSpammer.Config.configuration;
using static WebhookSpammer.Config.NONELoggs;


namespace WebhookSpammer.functions.webhookprotector.ProxyScraper
{
    public class Srcaper
    {
        private static string DefaultAdress = "https://api.proxyscrape.com/v2/";

        private static string[] RequestproxyType =
        {
            "?request=displayproxies&protocol=HTTP&timeout=10000&country=all&ssl=all&anonymity=all",
            "?request=displayproxies&protocol=SOCKS4&timeout=10000&country=all&ssl=all&anonymity=all",
            "?request=displayproxies&protocol=SOCKS5&timeout=10000&country=all&ssl=all&anonymity=all"
        };
        
        
        public Srcaper()
        {
            
        }
        
        public void StartScrape()
        {
            WriteState("Start Scrape");
            using (WebClient bc = new WebClient())
            {
                WriteState("Init Webclient");
                try
                {
                    // Read All Proxys
                    foreach (string CurrentEndPoint in RequestproxyType)
                    {
                        WriteState("Start Request");
                        string data = bc.DownloadString(DefaultAdress + CurrentEndPoint);
                        var _IPAdress = data.Split(new[] { '\n', '\r' });
                        foreach (string ipadress in _IPAdress)
                        {
                            if(String.IsNullOrEmpty(ipadress) || !ipadress.Contains(":"))
                                continue;
                            
                            ListSafer.Proxys.Add(ipadress);
                        }
                    }
                }
                catch
                {
                    WriteState("Error while Scaping");
                }
            }
        }
    }

    public static class ListSafer
    {
        public static List<string> Proxys = new List<string>();
    }
}