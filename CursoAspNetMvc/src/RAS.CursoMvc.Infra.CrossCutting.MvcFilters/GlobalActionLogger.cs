using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RAS.CursoMvc.Infra.CrossCutting.MvcFilters
{
    public class GlobalActionLogger : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)

        {
            /*
             * TODAS AS CHAMADAS AS CONTROLLERS PASSARÁ AQUI
             * NORMALMENTE SEMPRE PASSA POR AQUI, MAS ESTAMOS INTERFERINDO NO PROCESSO E 
             * IMPLEMENTANDO ALGUMA AÇÃO
             * 
             * Log de auditoria
             * Tal usuário fez tal coisa etc...
             */

            if(filterContext.Exception != null)
            {
                /* Manipular a Exception
                 * Injetar alguma LIB de tratamento de erro 
                 * -> Gravar log do erro no DB
                 * -> Email para o administrador
                 * -> Retornar cod de erro amigável
                 * 
                 * Log4net
                 * Elmah.IO
                 * Custon Logger
                 * 
                 * SEMPRE DA FORMA ASYNC
                 */

                //Assim não será tratado como erro.
                //Ou seja, já está tranquilo, tudo resolvido
                filterContext.ExceptionHandled = true;
                //Porém preciso informar a aplicação que está com status 500 para 
                //que possa ser tratado como exception
                filterContext.Result = new HttpStatusCodeResult(500);
            }

            base.OnActionExecuted(filterContext);   
        }
    }
}
