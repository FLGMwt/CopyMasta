﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Castle.Windsor;
using CopyMasta.Core;
using Application = System.Windows.Application;

namespace CopyMasta
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IWindsorContainer _container;
        private MainWindow _mainWindow;
        private readonly KeystrokeListenerBase _listener;
        private readonly KeystrokeManager _manager;

        public App()
        {
            _container = new WindsorContainer();
            var installer = new CmWindsorInstaller();
            _container.Install(installer);
            
            _listener = _container.Resolve<KeystrokeListenerBase>();
            _manager = _container.Resolve<KeystrokeManager>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _mainWindow = _container.Resolve<MainWindow>();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _container.Release(_mainWindow);
            _container.Release(_manager);
            _container.Release(_listener);

            base.OnExit(e);
        }
    }
}
