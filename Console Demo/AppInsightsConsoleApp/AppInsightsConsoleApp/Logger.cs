using System;
using System.Collections.Generic;
using System.Threading;

using Microsoft.ApplicationInsights;

namespace AppInsightsConsoleApp
{
    public class Logger
    {
        private readonly TelemetryClient tc;
        public Logger()
        {
            //Create a new telementry client with the app insights key you wish to target.
            tc = new TelemetryClient();
            tc.InstrumentationKey = "c04b54fd-429a-4359-8cfe-77c53c90175e";
            tc.Context.Session.Id = Guid.NewGuid().ToString();
            tc.Context.Device.OperatingSystem = Environment.OSVersion.ToString();
        }

        internal void Flush()
        {
            tc.Flush();
            Thread.Sleep(1000);
        }

        public void LogInfo(string message)
        {
            tc.TrackTrace(message);
        }

        public void LogInfo(string message, IDictionary<string, string> properties)
        {
            tc.TrackTrace(message, properties);
        }

        public void LogError(Exception ex)
        {
            tc.TrackException(ex);
        }

        public void LogError(Exception ex, IDictionary<string, string> properties)
        {
            tc.TrackException(ex, properties);
        }
    }
}
