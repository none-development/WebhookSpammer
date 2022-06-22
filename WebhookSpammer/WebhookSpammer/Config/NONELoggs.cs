using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;

namespace WebhookSpammer.Config
{
    public class NONELoggs
    {
        private static List<string> LogsQury = new List<string>();
        private static Thread Logs = new Thread(_WriteItThread);
        private static bool StopThread = true;
        private static bool StopFinnished = true;
        
        // Write Log
        public static void WriteState(string Log)
        {
            WriteLogToFile(Log);
        }
        
        // Init Logging
        public static void InitLogging()
        {
            Logs.Start();
        }
        
        // End Logging
        public static void Dispose_InitLogging()
        {
            Logs.Start();
            while (StopFinnished)
            {
                
            }
        }

        private static void WriteLogToFile(string data)
        {
            string log = $"[{DateTime.Now.ToString("hh:mm:ss t z")}] Output: {data} {Environment.NewLine}";
            LogsQury.Add(log);
        }

        // Thread to write the Log
        private static void _WriteItThread()
        {
            string time = DateTime.Now.ToString("t"); // Current Day 
            while (StopThread)
            {
                try
                {
                    // Look for if Log Exist
                    if (!File.Exists($"./logs_{time}"))
                    {
                        File.Create($"./logs_{time}"); // Create File
                        Thread.Sleep(500); // Sleep Thread 
                    }

                    if (LogsQury.Count > 0) // Check how many Logs in Cash
                    {
                        foreach (string log in LogsQury) //Write All
                        {
                            File.AppendAllText($"./logs_{time}", log);
                        }
                    
                    }
                }
                catch
                {
                    Thread.Sleep(100);
                    continue;
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