using RAS.CursoMvc.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RAS.CursoMvc.Domain.Interfaces.Repository
{
    // Repositorio generico para qualquer tipo de entidade TEntity
    // Where = TEntity é de um tipo específico do tipo Entity, pode ser tambem uma classe que herda de Entity
    // A implementação do repositório ficará na 
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity Adicionar(TEntity obj);

        TEntity ObterPorId(Guid id);

        IEnumerable<TEntity> ObterTodos();

        TEntity Atualizar(TEntity obj);

        void Remover(Guid id);

        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);

        int SaveChanges();

    }
}
