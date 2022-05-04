using MassTransit;
using Microsoft.Extensions.Logging;
using RabbitMQ.Net.Domain;
using System;
using System.Threading.Tasks;

namespace RabbitMQ.Net.Consumer.Cosumers
{
    public class ClienteConsumers : IConsumer<Cliente>
    {
        private readonly ILogger<ClienteConsumers> _logger;
        
        public ClienteConsumers(ILogger<ClienteConsumers> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<Cliente> context)
        {
            await Console.Out.WriteLineAsync(context.Message.nome);

            _logger.LogInformation(@$"Nova mensagem recebida: {context.Message.nome} - {context.Message.cpf} - {context.Message.email}");

        }

    }
}
