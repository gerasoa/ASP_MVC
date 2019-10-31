namespace RAS.CursoMvc.Infra.Data.Migrations
{
    using RAS.CursoMvc.Infra.Data.Context;
    using System.Data.Entity.Migrations;

    //update-database -Script para criar o script 
    internal sealed class Configuration : DbMigrationsConfiguration<CursoMvcContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RAS.CursoMvc.Infra.Data.Context.CursoMvcContexto context)
        {
           
        }
    }
}
