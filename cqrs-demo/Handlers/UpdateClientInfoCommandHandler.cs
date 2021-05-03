using cqrs_demo.CQRS;
using cqrs_demo.Models;
using cqrs_demo.Services.Customers;
using cqrs_demo.Services.Customers.Commands;

namespace cqrs_demo.Handlers
{
    public interface IUpdateClientInfoCommandHandler : ICommandHandler<UpdateClientInfoCommand, ClientModel> { }

    public class UpdateClientInfoCommandHandler : IUpdateClientInfoCommandHandler
    {
        private readonly IClientService clientService;

        public UpdateClientInfoCommandHandler(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public ClientModel Handle(UpdateClientInfoCommand command)
        {
            return clientService.UpdateClientInfo(command);
        }
    }
}
