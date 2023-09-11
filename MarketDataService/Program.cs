using IB.CSharpApiClient;
using IBApi;

var client = IBClientFactory.CreateNew();
client.Parameters = new IBClientParameters { Host = "127.0.0.1", Port = 7490, ClientId = 5 };

client.OpenOrder += Client_OpenOrder;
client.NextValidId += HandleConnected;
client.OrderStatus += Client_OrderStatus;

_ = client.AutoConnect();

client.ReqIds(0);

while (true)
{
    Console.ReadLine();
}


void Client_OrderStatus(IB.CSharpApiClient.Messages.OrderStatusMessage obj)
{
    Console.WriteLine("Client_OrderStatus");
}

void Client_OpenOrder(IB.CSharpApiClient.Messages.OpenOrderMessage obj)
{
    Console.WriteLine("Client_OpenOrder");
}

void HandleConnected(IB.CSharpApiClient.Messages.NextValidIdMessage obj)
{

    Console.WriteLine("connected");

    client.ReqAllOpenOrders();

    return;

    while (true)
    {
        client.ReqCurrentTime();
        Console.WriteLine("client.ReqCurrentTime");
        //await Task.Delay(1000);

        var input = Console.ReadLine();

        if (input == "1")
        {
            _ = client.AutoConnect();
            Console.WriteLine("client.Connect");
        }
        if (input == "2")
        {
            client.Disconnect();
            Console.WriteLine("client.Disconnect");
        }
        if (input == "3")
        {
            Console.WriteLine("ReqAllOpenOrders");
            client.ReqAllOpenOrders();
        }
        if (input == "4")
        {
            Console.WriteLine("ReqAllOpenOrders");
            client.ReqAllOpenOrders();
        }
    }
}