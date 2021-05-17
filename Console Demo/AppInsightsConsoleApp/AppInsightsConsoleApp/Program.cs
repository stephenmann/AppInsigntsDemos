using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace AppInsightsConsoleApp
{
    class Program
    {
        private static readonly Logger logger = new Logger();

        static void Main(string[] args)
        {
            logger.LogInfo("Hello World!");

            StartLongProcess();

            FailingProcess();

            logger.Flush();
        }

        private static void FailingProcess()
        {
            try
            {
                throw new Exception("Intentional exception");
            }
            catch(Exception ex)
            {
                logger.LogError(ex);
            }
        }

        private static void StartLongProcess()
        {
            var sw = new Stopwatch(); 
            sw.Start();
            logger.LogInfo("Starting my long running task.");
            Thread.Sleep(new Random().Next(1000, 6000));
            sw.Stop();
            var results = new Dictionary<string, string>();
            results.Add("TaskTime", sw.ElapsedMilliseconds.ToString());
            logger.LogInfo("Finished with long running task.", results);
        }
    }
}
