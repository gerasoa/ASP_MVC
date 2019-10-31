using RAS.CursoMvc.Domain.Model;
using RAS.CursoMvc.Infra.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RAS.CursoMvc.Infra.Data.Context
{
    //Onde serao mapeados os objetos de banco
     
    public class CursoMvcContexto : DbContext
    {
        // O EF toma como base o provider da connection string para gerar o script do banco de dados 
        public CursoMvcContexto() : base("DefaultConnection")
        {

        }


        // Não esquecer de antes de no PackageManager Console executar enabale-migrations para criar a pasta Migrations no projeto Infra.Data
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }


        // Sobescrever o método de criação do modelo 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<String>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<String>().Configure(p => p.HasMaxLength(100));

            // Aponta para as configurações feitas no ClientConfig
            modelBuilder.Configurations.Add(new ClienteConfig());

            modelBuilder.Configurations.Add(new EnderecoConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
