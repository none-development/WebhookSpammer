using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using OtpNet;
using static WebhookSpammer.functions.webhookprotector.ProxyScraper.ListSafer;
using static WebhookSpammer.Config.configuration;

namespace WebhookSpammer.functions.wehookprotector
{
    public class RequestSpammer
    {
        public static void SendSpam()
        {
           new Thread(() =>
           {
               for (int i = 0; i < Proxys.Count; i++)
               {
                   try
                   {
                       string TestIPAdressBase = Proxys[i];
                       string[] _TestIP = TestIPAdressBase.Split(':');
                       var _IP = _TestIP[0];
                       var Port = _TestIP[1];
                       var _requestClient = new TcpClient();
                       if (_requestClient.ConnectAsync(_IP, Convert.ToInt32(Port)).Wait(200))
                       {
                           for (int j = 0; j < ChangeAfterRequest; j++)
                           {
                               var base32Bytes = Base32Encoding.ToBytes(Password);
                               var hotp = new Hotp(base32Bytes);
                               HttpWebRequest client = (HttpWebRequest)WebRequest.Create(WebhookprotectorURL);
                               client.Proxy = new WebProxy(_IP.ToString(), Convert.ToInt32(Port));
                               client.Headers.Add("Authorization", hotp.ToString());
                               string postdata = "{\"content\":\"" + Content + "\"}";
                               byte[] byteArray = Encoding.UTF8.GetBytes(postdata);
                               client.ContentLength = byteArray.Length;
                               Stream dataStream = client.GetRequestStream();
                               dataStream.Write(byteArray, 0, byteArray.Length);
                               dataStream.Close();
                               WebResponse response = client.GetResponse();
                               dataStream = response.GetResponseStream();
                               StreamReader reader = new StreamReader(dataStream);
                               string responseFromServer = reader.ReadToEnd();
                               dataStream.Close();
                           
                               response.Close();
                           }

                       }
                   }
                   catch (Exception e)
                   {
                       Console.WriteLine(e);
                   }

               }
           }).Start();
        }
    }
}