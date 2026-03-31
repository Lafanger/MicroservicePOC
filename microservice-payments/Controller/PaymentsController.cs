using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/payments")]
public class PaymentsController : ControllerBase
{
    private readonly ServiceBusClient _client;

    public PaymentsController(IServiceProvider serviceProvider)
    {
        _client = serviceProvider.GetService<ServiceBusClient>();
    }

    [HttpPost]
    public async Task<IActionResult> ProcessPayment()
    {
        if (_client != null)
        {
            var sender = _client.CreateSender("payments-queue");
            await sender.SendMessageAsync(new ServiceBusMessage("Payment Created"));
        }
        else
        {
            Console.WriteLine("Payment Created (LOCAL)");
        }

        return Ok("Payment queued");
    }
}