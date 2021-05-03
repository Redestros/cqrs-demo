using cqrs_demo.CQRS;
using cqrs_demo.Services.Customers;
using cqrs_demo.Services.Customers.Commands;

namespace cqrs_demo.Handlers
{
    public interface IRegisterClientCommandHandler : ICommandHandler<RegisterClientCommand, RegisterClientResult>
    {

    }

    public class RegisterClientCommandHandler : IRegisterClientCommandHandler
    {
        private readonly IClientService clientService;

        public RegisterClientCommandHandler(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public RegisterClientResult Handle(RegisterClientCommand command)
        {
            return new RegisterClientResult
            {
                Id = clientService.RegisterClient(command)
            };
        }
    }
}
