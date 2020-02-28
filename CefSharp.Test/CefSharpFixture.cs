// Copyright © 2017 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using CefSharp.OffScreen;

namespace CefSharp.Test
{
    public class CefSharpFixture : IDisposable
    {
        private readonly TaskScheduler scheduler;
        private readonly Thread thread;

        public CefSharpFixture()
        {
            // CefSharp requires a default AppDomain which means that xunit is not able
            // to provide the correct binding redirects defined in the app.config
            // so we have to provide them manually via AssemblyResolve
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainAssemblyResolve;

            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());

            scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            thread = Thread.CurrentThread;

            if (!Cef.IsInitialized)
            {
                var isDefault = AppDomain.CurrentDomain.IsDefaultAppDomain();
                if (!isDefault)
                {
                    throw new Exception(@"Add <add key=""xunit.appDomain"" value=""denied""/> to your app.config to disable appdomains");
                }

                var settings = new CefSettings();

                //The location where cache data will be stored on disk. If empty an in-memory cache will be used for some features and a temporary disk cache for others.
                //HTML5 databases such as localStorage will only persist across sessions if a cache path is specified. 
                settings.CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Tests\\Cache");

                Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);
            }
        }

        public void Dispose()
        {
            var factory = new TaskFactory(scheduler);

            if (thread.IsAlive)
            {
                factory.StartNew(() =>
                {
                    if (Cef.IsInitialized)
                    {
                        Cef.Shutdown();
                    }
                });
            }

            AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomainAssemblyResolve;
        }

        private Assembly CurrentDomainAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var asemblyName = new AssemblyName(args.Name);
            var path = Path.Combine(Environment.CurrentDirectory, asemblyName.Name + ".dll");
            if (File.Exists(path))
            {
                return Assembly.LoadFrom(path);
            }
            return null;
        }
    }
}
