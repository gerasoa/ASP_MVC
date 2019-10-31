using RAS.CursoMvc.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAS.CursoMvc.Infra.Data.EntityConfig
{
    class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(e => e.Id);

            Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.CEP)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();

            Property(e => e.Cidade)
                .IsRequired();

            Property(e => e.Complemento)
                .IsRequired()
                .HasMaxLength(100);

            Property(e => e.Estado)
                .IsRequired();

            Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(150);

            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(20);

            // Relacionamento Requirido ou Opcional
            // Requirido
            HasRequired(e => e.Cliente)
                .WithMany(c => c.Enderecos) //São vários endereços para cada cliente
                .HasForeignKey(e => e.ClienteId);

            //Opcional
            //HasOptional(e => e.Cliente)
            //    .WithMany(c => c.Enderecos)
            //    .HasForeignKey(e => e.ClienteId);

            // ONE TO OEN OR ZERO
            // ONE TO ONE
            // ONE TO MANY
            // MANY TO MANY

            ToTable("Enderecos");
        }
    }
}
