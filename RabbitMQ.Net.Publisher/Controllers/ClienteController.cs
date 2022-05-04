using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using RabbitMQ.Net.Domain;

namespace RabbitMQ.Net.Consumer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IBus _bus;

        public ClienteController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> CriarCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                Uri uri = new Uri("rabbitmq://localhost/criarClienteQueue5");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(cliente);

                return Ok("Cliente enviado...");
            }

            return BadRequest();

        }
    }
}
