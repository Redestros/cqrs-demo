using cqrs_demo.CQRS;
using System;

namespace cqrs_demo.Services.Customers.Commands
{
    public class DeleteClientCommand : ICommand
    {
        public Guid ClientId { get; }

        public DeleteClientCommand(Guid clientId)
        {
            ClientId = clientId;
        }
    }
}
