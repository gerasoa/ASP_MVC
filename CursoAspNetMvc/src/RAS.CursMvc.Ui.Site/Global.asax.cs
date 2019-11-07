using RAS.CursoMvc.Application.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RAS.CursMvc.Ui.Site
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            /*
             * AutoMapper informado no Global.asax para que quando a aplicação for inicializada pelo IIS
             * já carregar suas dependências e resolve o mapeamento das coleções feitas. Quando for solicitado 
             * o mapeamento já tem elas em memória, cso contrário seria bem lento.
             */
            AutoMapperConfig.RegisterMappings(); 
        }
    }
}
