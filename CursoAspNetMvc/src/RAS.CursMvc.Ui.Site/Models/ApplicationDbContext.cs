using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAS.CursMvc.Ui.Site.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<RAS.CursoMvc.Application.ViewModels.ClienteViewModel> ClienteViewModels { get; set; }

        public System.Data.Entity.DbSet<RAS.CursoMvc.Application.ViewModels.EnderecoViewModel> EnderecoViewModels { get; set; }
    }
}