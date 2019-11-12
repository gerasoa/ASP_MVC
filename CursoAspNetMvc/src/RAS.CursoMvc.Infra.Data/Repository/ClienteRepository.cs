using Dapper;
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

        //Dapper
        public override IEnumerable<Cliente> ObterTodos()
        {
            var sql = @"SELECT * FROM Clientes c" +
                       "WHERE c.Excluido == 0 AND c.Ativo = 1"; // 0=false 1=true
            return Db.Database.Connection.Query<Cliente>(sql);
        }

        public override Cliente ObterPorId(Guid id)
        {
            var sql = @"SELECT * FROM Clientes c " +
                       "LEFT JOIN Enderecos e " +
                       "ON c.Id = e.ClienteId " +
                       "WHERE c.Id = @uid";

            //throw new Exception("THE TRETA HAS BEEN PLANTED!!!");

            return Db.Database.Connection.Query<Cliente, Endereco, Cliente>(sql, 
                (c, e) =>
                {
                    c.Enderecos.Add(e);
                    return c;
                },
                new { uid = id }).FirstOrDefault();
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
