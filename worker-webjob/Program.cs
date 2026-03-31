using Azure.Messaging.ServiceBus;

var client = new ServiceBusClient("<connection-string>");

async Task StartProcessor(string queueName)
{
    var processor = client.CreateProcessor(queueName);

    processor.ProcessMessageAsync += async args =>
    {
        Console.WriteLine($"Processing from {queueName}: {args.Message.Body}");
        await args.CompleteMessageAsync(args.Message);
    };

    processor.ProcessErrorAsync += args =>
    {
        Console.WriteLine(args.Exception.ToString());
        return Task.CompletedTask;
    };

    await processor.StartProcessingAsync();
}

await StartProcessor("orders-queue");
await StartProcessor("payments-queue");

Console.WriteLine("Worker running...");
Console.ReadLine();