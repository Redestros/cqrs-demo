using cqrs_demo.CQRS;
using System;

namespace cqrs_demo.Services.Customers.Queries
{
    public class SearchClientsQuery : IQuery
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
