using RAS.CursoMvc.Domain.Interfaces.Repository;
using RAS.CursoMvc.Domain.Model;
using RAS.CursoMvc.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace RAS.CursoMvc.Infra.Data.Repository
{
    // abstrata, não pode ser instanciada, sempre ser instanciada por uma classe 
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected CursoMvcContexto Db;
        protected DbSet<TEntity> DbSet;
        public Repository()
        {
            Db = new CursoMvcContexto();
            DbSet = Db.Set<TEntity>();
        }

        public TEntity Adicionar(TEntity obj)
        {
            var objRet = DbSet.Add(obj);
            SaveChanges();
            return objRet;
        }

        public TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);          // Cria uma entrada de dados
            DbSet.Attach(obj);                  // Atachar o objeto na memoria do contexto. O obj já existe com esta chave 
            entry.State = EntityState.Modified; // O estado é modificado
            SaveChanges();                   // Salva no banco

            return obj;
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id); // O find é um método que sempre buscará pela chave primária
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        //Exemplo de paginação
        public IEnumerable<TEntity> ObterTodosPaginado(int s, int t) //take/skip 
        {
            return DbSet.Skip(s).Take(t).ToList();
        }

        public virtual void Remover(Guid id)
        {
            // mais simples porém vai ao banco duas vezes 
            //DbSet.Remove(DbSet.Find(id));

            // Para poder instanciar TEntity é necessário dar new na classe, para isso precisa dizer que 
            // é possível dar new na classe para dizer que aclasse pode ser construída (new())
            // com isso economiza um hit ao banco
            // Aqui está sendo removido definitivamente
            var obj = new TEntity() { Id = id };
            DbSet.Remove(obj);
            SaveChanges();
        }

        public int SaveChanges()
        {
            //retorna o numero de linhas afetadas
            // posso fazer um tratamento try catch
            return Db.SaveChanges();
        }
    }
}
