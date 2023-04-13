using System;
using System.Threading;
using IB.CSharpApiClient.Messages;
using IBApi;

namespace IB.CSharpApiClient
{
    public partial class IBClient : IClient
    {
        public Timer _connect_timer;
        public IBClientParameters Parameters { get; set; }
        public void AutoConnect()
        {
            if (Parameters == null)
            {
                _clientSocket.Wrapper.error("没有设置IBClientParameters");
                return;
            }

            void connect(object state)
            {
                if (IsConnected()) return;

                _clientSocket.Wrapper.error("Try to connect IB API");
                Connect(Parameters.Host, Parameters.Port, Parameters.ClientId);

            }

            connect(null);

            if (_connect_timer != null) return;

            _connect_timer = new Timer(connect, null, Parameters.Delay, Parameters.interval);
        }
    }
}
