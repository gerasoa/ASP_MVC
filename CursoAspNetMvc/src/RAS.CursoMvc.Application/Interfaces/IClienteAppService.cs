using RAS.CursoMvc.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RAS.CursoMvc.Application.Interfaces
{
    public interface IClienteAppService : IDisposable 
    {
        ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel obj);

        ClienteViewModel ObterPorId(Guid id);

        IEnumerable<ClienteViewModel> ObterTodos();        

        void Remover(Guid id);

        ClienteViewModel ObterPorCpf(string cpf);

        ClienteViewModel ObterPorEmail(string email);

        ClienteViewModel Atualizar(ClienteViewModel obj);

        IEnumerable<ClienteViewModel> ObterAtivos();
    }
}
