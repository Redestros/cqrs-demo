using cqrs_demo.CQRS;
using System;

namespace cqrs_demo.Services.Customers.Queries
{
    public class GetClientByIdQuery : IQuery
    {
        public Guid Id { get; set; }
    }
}
