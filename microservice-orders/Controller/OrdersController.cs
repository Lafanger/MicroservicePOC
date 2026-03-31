using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly ServiceBusClient _client;

    public OrdersController(IServiceProvider serviceProvider)
    {
        _client = serviceProvider.GetService<ServiceBusClient>();
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder()
    {
        if (_client != null)
        {
            var sender = _client.CreateSender("orders-queue");
            await sender.SendMessageAsync(new ServiceBusMessage("Order Created"));
        }
        else
        {
            Console.WriteLine("Order Created (LOCAL)");
        }

        return Ok("Order queued");
    }
}