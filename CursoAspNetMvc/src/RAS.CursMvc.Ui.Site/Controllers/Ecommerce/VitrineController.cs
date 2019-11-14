using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RAS.CursMvc.Ui.Site.Controllers.Ecommerce
{
    // Por estar vazio é aceita a rota compatíel com a estrutura de rota da action
    [RoutePrefix("")]
    public class VitrineController : Controller
    {
        //Recebe oa parametros e redireciona para o departamento 
        [Route("{departamento:maxlength(10)}/{chave:maxlength(100)}/{produtoId:maxlength(8)}")]
        public ActionResult Index(string departamento, string chave, string produtoId)
        {
            return View("");
        }
    }
}