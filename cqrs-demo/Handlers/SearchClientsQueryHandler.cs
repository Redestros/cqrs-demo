using cqrs_demo.CQRS;
using cqrs_demo.Models;
using cqrs_demo.Services.Customers;
using cqrs_demo.Services.Customers.Queries;
using System.Collections.Generic;

namespace cqrs_demo.Handlers
{
    public interface ISearchClientsQueryHandler : IQueryHandler<SearchClientsQuery, ICollection<ClientModel>> { }
    public class SearchClientsQueryHandler : ISearchClientsQueryHandler
    {
        private readonly IClientService clientService;

        public SearchClientsQueryHandler(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public ICollection<ClientModel> Handle(SearchClientsQuery query)
        {
            return clientService.SearchClients(query);
        }
    }
}
