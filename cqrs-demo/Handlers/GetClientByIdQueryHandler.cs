using cqrs_demo.CQRS;
using cqrs_demo.Models;
using cqrs_demo.Services.Customers;
using cqrs_demo.Services.Customers.Queries;

namespace cqrs_demo.Handlers
{
    public interface IGetClientByIdQueryHandler : IQueryHandler<GetClientByIdQuery, ClientModel> { }
    public class GetClientByIdQueryHandler : IGetClientByIdQueryHandler
    {
        private readonly IClientService clientService;

        public GetClientByIdQueryHandler(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public ClientModel Handle(GetClientByIdQuery query)
        {
            return clientService.GetClientById(query.Id);
        }
    }
}
