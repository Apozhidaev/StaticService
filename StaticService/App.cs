﻿using System;
using Microsoft.Owin.Hosting;
using StaticService.Configuration;

namespace StaticService
{
    public class App
    {
        private IDisposable _webApp;

        public void Start()
        {
            var startOptions = new StartOptions();
            foreach (var url in AppSettings.Urls)
            {
                startOptions.Urls.Add(url);
            }
            _webApp = WebApp.Start<Startup>(startOptions);
        }

        public void Stop()
        {
            if (_webApp != null)
            {
                _webApp.Dispose();
                _webApp = null;
            }
        }
    }
}