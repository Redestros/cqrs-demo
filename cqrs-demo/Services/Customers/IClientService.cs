using cqrs_demo.Models;
using cqrs_demo.Services.Customers.Commands;
using cqrs_demo.Services.Customers.Queries;
using System;
using System.Collections.Generic;

namespace cqrs_demo.Services.Customers
{
    public interface IClientService
    {
        ClientModel GetClientById(Guid guid);
        ICollection<ClientModel> SearchClients(SearchClientsQuery query);
        Guid RegisterClient(RegisterClientCommand command);

        ClientModel UpdateClientInfo(UpdateClientInfoCommand command);
        void DeleteClient(DeleteClientCommand command);
    }
}
