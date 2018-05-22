﻿namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MicroServiceNet;
    using Microsoft.Extensions.Logging;
    using Pivotal.Discovery.Client;

    public class MsProductService : MicroServiceGeneric<MsProductService>, IMsProductService
    {
        public MsProductService(IDiscoveryClient client, ILoggerFactory logFactory)
                : base(client, logFactory)
        {}

        public Task<HttpResponseMessage> GetAll(List<KeyValuePair<string, string>> parameters = null)
        {
            return Execute(GetAll, parameters);
        }
    }
}