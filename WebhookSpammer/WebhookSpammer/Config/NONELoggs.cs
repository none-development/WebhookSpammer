using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;

namespace WebhookSpammer.Config
{
    public static class NONELoggs
    {
        private static List<string> LogsQury = new List<string>();
        private static Thread _Logs = new Thread(_WriteItThread);
        private static bool StopThread = true;
        private static bool StopFinnished = true;
        
        // Write Log
        public static void WriteState(string Log)
        {
            WriteLogToFile(Log);
        } 
      
        
        // Init Logging
        public static void InitLogging() =>  _Logs.Start();
      
        
        // End Logging
        public static void Dispose_InitLogging()
        {
            StopThread = false;
            while (StopFinnished)
            {
                
            }
            
        }

        private static void WriteLogToFile(string data)
        {
            string log = $"[{DateTime.Now.ToString("HH:m:s")}] Output: {data} {Environment.NewLine}";
            LogsQury.Add(log);
        }

        // Thread to write the Log
        private static void _WriteItThread()
        {
            string time = DateTime.Now.ToString("t"); // Current Day 
            if (!File.Exists($"./logs.txt"))
            {
                File.Create($"./logs.txt"); // Create File
                File.WriteAllText($"./logs.txt", "TT");
            }
            while (StopThread == true)
            {
                try
                {
                    Thread.Sleep(500);
                    // Look for if Log Exist
                    if (LogsQury.Count > 0) // Check how many Logs in Cash
                    {
                        foreach (string log in LogsQury) //Write All
                        {
                            File.AppendAllText($"./logs.txt", log);
                        }
                        LogsQury.Clear();
                    }
                }
                catch
                {
                    Console.WriteLine("ERROR LOGS");
                    Thread.Sleep(100);
                }
                Thread.Sleep(50); // Wait to Finish
            }
            foreach (string log in LogsQury)
            {
                File.AppendAllText($"./logs_{time}", log);
            }
        }
    }
}