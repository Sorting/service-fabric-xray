﻿// ------------------------------------------------------------
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace xray.WebService
{
    using Microsoft.ServiceFabric.Services.Runtime;
    using System.Threading;

    public class Program
    {
        // Entry point for the application.
        public static void Main(string[] args)
        {
#if LOCALSERVER

            using (LocalServer listener = new LocalServer())
            {
                listener.Open();
                Thread.Sleep(Timeout.Infinite);
            }
            
#else

            ServiceRuntime.RegisterServiceAsync("WebServiceType", context => new WebService(context)).GetAwaiter().GetResult();

            Thread.Sleep(Timeout.Infinite);

#endif
        }
    }
}
