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

            _logger.LogInformation(@$"Cliente recebido: Nome: {context.Message.nome} | CPF: {context.Message.cpf} | E-mail: {context.Message.email}");

        }

    }
}
