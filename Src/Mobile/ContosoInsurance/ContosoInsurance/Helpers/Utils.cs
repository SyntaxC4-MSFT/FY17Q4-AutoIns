﻿using System;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices.Eventing;
using ContosoInsurance.Models;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;
using HockeyApp;


namespace ContosoInsurance.Helpers
{
    public class ImageDownloadEvent : MobileServiceEvent
    {
        public string Id { get; set; }

        public ImageDownloadEvent(string id) : base(id)
        {
            this.Id = id;
        }        
    }

    public class ActivityIndicatorScope : IDisposable
    {
        private ActivityIndicator indicator;
        private Grid indicatorPanel;

        public ActivityIndicatorScope(ActivityIndicator indicator, Grid indicatorPanel, bool showIndicator)
        {
            this.indicator = indicator;
            this.indicatorPanel = indicatorPanel;

            SetIndicatorActivity(showIndicator);
        }

        private void SetIndicatorActivity(bool isActive)
        {
            this.indicator.IsVisible = isActive;
            this.indicator.IsRunning = isActive;
            this.indicatorPanel.IsVisible = isActive;
        }

        public void Dispose()
        {
            SetIndicatorActivity(false);
        }
    }
    public static class Utils
    {       
        public static void TraceException(string logEvent, Exception ex)
        {
            Debug.WriteLine(logEvent + ex.Message);
            Trace.WriteLine(logEvent + ex);


            Dictionary<string, string> properties = new Dictionary<string, string>()
            {
                { "LogType", "Error Log"},
                { "Version", Assembly.GetCallingAssembly().GetName().Version.ToString()},
                { "Description", logEvent + ex.Message}
            };
            /*Hockey APP*/
            try
            {
                MetricsManager.TrackEvent("Failure", properties, null);
            }
            catch(Exception e)
            {
                Debug.WriteLine(logEvent + e);
            }
        }
        public static void TraceStatus(string logEvent)
        {
            Debug.WriteLine(logEvent);
            Trace.WriteLine(logEvent);

            Dictionary<string, string> properties = new Dictionary<string, string>()
            {
                { "LogType", "Status Log"},
                { "Version", Assembly.GetCallingAssembly().GetName().Version.ToString()},
                { "Description", logEvent},
                { "Status", "Success"}
            };
            try
            {
                /*Hockey APP*/
                MetricsManager.TrackEvent(logEvent, properties, null);
            }

            catch (Exception e)
            {
                Debug.WriteLine(logEvent + e);
            }
        }
    }
}
