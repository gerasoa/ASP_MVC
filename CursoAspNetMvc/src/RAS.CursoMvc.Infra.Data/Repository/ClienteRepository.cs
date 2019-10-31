using RAS.CursoMvc.Domain.Interfaces.Repository;
using RAS.CursoMvc.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RAS.CursoMvc.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClientRepository
    {
        public IEnumerable<Cliente> ObterAtivos()
        {
            return Buscar(c => c.Ativo && !c.Excluido).ToList();
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.Ativo = false;
            cliente.Excluido = true;

            Atualizar(cliente);
        }
    }
}
