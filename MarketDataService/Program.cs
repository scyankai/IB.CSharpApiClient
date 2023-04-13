using IB.CSharpApiClient;

var client = IBClientFactory.CreateNew();
client.Parameters = new IBClientParameters { Host = "127.0.0.1", Port = 7497, ClientId = 5 };

client.CurrentTime += Client_CurrentTime;

void Client_CurrentTime(IB.CSharpApiClient.Messages.CurrentTimeMessage obj)
{
    Console.WriteLine(obj.Time.ToString());
}

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
}