using System;
using System.Collections.Generic;
using System.Text;

namespace IB.CSharpApiClient
{
    public class IBClientParameters
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public int ClientId { get; set; }

        public int interval { get; set; } = 60 * 1000;

        public int Delay { get; set; } = 5000;
    }
}
