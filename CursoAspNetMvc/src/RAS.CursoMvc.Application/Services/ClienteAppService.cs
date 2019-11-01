using RAS.CursoMvc.Application.Interfaces;
using RAS.CursoMvc.Application.ViewModels;
using RAS.CursoMvc.Domain.Interfaces.Repository;
using RAS.CursoMvc.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAS.CursoMvc.Application.Services
{
    class ClienteAppService : IClienteAppService
    {
        private readonly IClientRepository _clienteRepository;

        public ClienteAppService()
        {
            _clienteRepository = new ClienteRepository();
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel obj)
        {
            //return _clienteRepository.Adicionar();
        }

        public ClienteViewModel Atualizar(ClienteViewModel obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClienteViewModel> ObterAtivos()
        {
            throw new NotImplementedException();
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
