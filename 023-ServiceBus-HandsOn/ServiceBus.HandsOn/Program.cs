using Azure.Messaging.ServiceBus;

// More information about this sample in:
// https://github.com/Azure/azure-sdk-for-net/blob/Azure.Messaging.ServiceBus_7.12.0/sdk/servicebus/Azure.Messaging.ServiceBus/README.md

// Function to set Message with Color
var syncLock = new object();
void WriteConsole(string message, ConsoleColor color = ConsoleColor.White)
{
    lock (syncLock)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}

// Introduction
WriteConsole("Hello, Service Bus World !!!");
WriteConsole("Let's produce some data! Any key to start.");
Console.ReadKey(true);
Console.WriteLine();

// Setup local variables and constants
var exit = false;
const string SERVICEBUS_QUEUE = "ping";
var SERVICEBUS_ACCESSKEY = Environment.GetEnvironmentVariable("ServiceBusKey") ??
    throw new Exception("Environment Variable 'ServiceBusKey' is not defined.");

// Create the service bus client to be used
await using var client = new ServiceBusClient(SERVICEBUS_ACCESSKEY);

// Create the "Sender" and "Receiver" to produce and consume messages
var sender = client.CreateSender(SERVICEBUS_QUEUE);

// Create the producer Task
var producer = new Task(async () =>
{
    var random = new Random();
    while (!exit)
    {
        var information = $"Message {Guid.NewGuid()} created at {DateTime.Now:yyyy-MM-dd HH:mm:ss}";

        // Create and send the message to be stored
        var message = new ServiceBusMessage(information);
        await sender.SendMessageAsync(message);

        // Show the message on the service and wait next round
        WriteConsole(information, ConsoleColor.Green);
        Thread.Sleep(random.Next(100, 2000));
    }
});

// Start tasks
producer.Start();

// Control exit
while (!exit)
{
    var key = Console.ReadKey(true);
    if (key.Key == ConsoleKey.Escape)
    {
        exit = true;

        producer.Wait();
    }
};

Console.WriteLine();
WriteConsole("Finish!!!");
