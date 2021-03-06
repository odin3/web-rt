﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRT.Platform.Extensions;

namespace WebRT.Platform.Integration
{
    class RequestDispatcherProvider
    {
        private static RequestDispatcherProvider Instance;

        private static RequestController[] Controllers = {
            new PackageManagerController(),
            new StorageController(),
            new LauncherController()
        };

        public static RequestDispatcherProvider GetInstance()
        {
            if (Instance == null)
            {
                Instance = new RequestDispatcherProvider();
            }

            return Instance;
        }

        private RequestDispatcher Dispatcher;

        public void CreateDispatcher()
        {
            Dispatcher = new RequestDispatcher();

            Dispatcher.AddControllers(Controllers);
        }

        public RequestDispatcher GetMainRequestDispatcher()
        {
            if (Dispatcher == null)
            {
                CreateDispatcher();
            }

            return Dispatcher;
        }
    }
}
