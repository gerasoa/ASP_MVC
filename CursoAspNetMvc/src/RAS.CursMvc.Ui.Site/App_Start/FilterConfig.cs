using RAS.CursoMvc.Infra.CrossCutting.MvcFilters;
using System.Web;
using System.Web.Mvc;

namespace RAS.CursMvc.Ui.Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //A cada execução de uma action passará por aqui
            filters.Add(new GlobalActionLogger());
        }
    }
}
