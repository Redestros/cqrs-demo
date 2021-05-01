using AutoMapper;
using cqrs_demo.Data.Abstractions;
using cqrs_demo.Domain.Common;
using cqrs_demo.Domain.Customers;
using cqrs_demo.Models;
using cqrs_demo.Services.Customers;
using cqrs_demo.Services.Customers.Commands;
using cqrs_demo.Services.Customers.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rammus.Services.Customers
{
    public class ClientService : IClientService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ClientService(IMapper mapper)
        {
            unitOfWork = new UnitOfWork();
            this.mapper = mapper;
        }
        public Guid RegisterClient(RegisterClientCommand command)
        {
            var client = mapper.Map<RegisterClientCommand, Client>(command);
            
            unitOfWork.ClientRepository.Insert(client);
            
            unitOfWork.Save();

            return client.Id;
        }
        public void DeleteClient(DeleteClientCommand command)
        {
            var client = unitOfWork.ClientRepository.GetByID(command.ClientId);
            if (client != null)
            {
                unitOfWork.ClientRepository.Delete(command.ClientId);
                unitOfWork.Save();
            }
        }

        public ICollection<ClientModel> SearchClients(SearchClientsQuery query)
        {
            var users = unitOfWork.ClientRepository.Get().ToList();

            return mapper.Map<List<Client>, List<ClientModel>>(users);
        }

        public ClientModel GetClientById(Guid guid)
        {
            return mapper.Map<Client, ClientModel>(unitOfWork.ClientRepository.GetByID(guid));
        }

        public ClientModel UpdateClientInfo(UpdateClientInfoCommand command)
        {
            if (command.Id == null)
            {
                throw new Exception();
            }
            var client = unitOfWork.ClientRepository.GetByID(command.Id);
            client.Name = command.Name;
            client.RegistrationNumber = command.Name;
            client.Address = mapper.Map<AddressModel, Address>(command.Address);

            unitOfWork.ClientRepository.Update(client);
            unitOfWork.Save();

            return mapper.Map<Client, ClientModel>(client);
        }
    }
}
