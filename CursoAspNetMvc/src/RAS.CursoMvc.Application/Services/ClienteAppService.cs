using AutoMapper;
using RAS.CursoMvc.Application.Interfaces;
using RAS.CursoMvc.Application.ViewModels;
using RAS.CursoMvc.Domain.Interfaces.Repository;
using RAS.CursoMvc.Domain.Model;
using RAS.CursoMvc.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAS.CursoMvc.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClientRepository _clienteRepository;

        public ClienteAppService()
        {
            _clienteRepository = new ClienteRepository();
        }

        //Aqui será utilizado o AutoMapper
        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel obj)
        {
            var cliente = Mapper.Map<Cliente>(obj.Cliente);
            var endereco = Mapper.Map<Endereco>(obj.Endereco);

            cliente.Enderecos.Add(endereco);
            var ClienteReturn = _clienteRepository.Adicionar(cliente);

            obj.Cliente = Mapper.Map<ClienteViewModel>(ClienteReturn);
            return obj;
        }

        public ClienteViewModel Atualizar(ClienteViewModel obj)
        {
            var cliente = Mapper.Map<Cliente>(obj);
            var clienteReturn = _clienteRepository.Atualizar(cliente);

            obj = Mapper.Map<ClienteViewModel>(clienteReturn);
            return obj;
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }

        public IEnumerable<ClienteViewModel> ObterAtivos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterAtivos());
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorEmail(email));
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }
    }
}
