using RAS.CursoMvc.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace RAS.CursoMvc.Infra.Data.EntityConfig
{
    // Sobescreve as definições sobescritas no arquivo de Contexto (CursoMmcContexto)
    class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.Id);
            //HasKey(c => new { c.Id, c.CPF }); chave composta

            //Fluent API - Pesquisar na documentação mais detalhes

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation( // Cria um index
                    new IndexAttribute("IX_CPF") {
                        IsUnique = true // Bloqueio a possibilidade de ter dois index iguais 
                    }));

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.DataNascimento)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();

            Property(c => c.Excluido)
                .IsRequired();

            ToTable("Clientes");
            //ToTable("Clientes", "Sistema"); Caso não queria gerar a tabela no schema dbo informa o schema, no caso Sistema
        }
    }
}
