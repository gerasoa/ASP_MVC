using RAS.CursoMvc.Application.Interfaces;
using RAS.CursoMvc.Application.Services;
using RAS.CursoMvc.Application.ViewModels;
using RAS.CursoMvc.Infra.CrossCutting.MvcFilters;
using System;
using System.Net;
using System.Web.Mvc;


namespace RAS.CursMvc.Ui.Site.Controllers
{
    [Authorize]
    [RoutePrefix("gestao/crm")] // Só funcionará se ativar as rotas por atributo no RouteConfig
    public class ClientesController : Controller
    {
        // private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IClienteAppService _clienteAppService;

        public ClientesController()
        {
            _clienteAppService = new ClienteAppService();
        }

        [Route("listar-clientes")]
        [ClaimsAuthorize("Cliente", "LT")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterAtivos());
        }

        // nome do parÃmetro"id" do tipo "guid" e caso seja informado algo diferente de 
        // um guid será retornado erro 404
        [Route("{id:guid}/detalhe-cliente")]
        [ClaimsAuthorize("Cliente", "VI")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [Route("novo-cliente")]
        [ClaimsAuthorize("Cliente", "IN")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("novo-cliente")]
        [ClaimsAuthorize("Cliente", "ED")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Adicionar(clienteEnderecoViewModel);
                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }

        [Route("{id:guid}/editar-cliente")]
        [ClaimsAuthorize("Cliente", "ED")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [Route("{id:guid}/editar-cliente")]
        [ClaimsAuthorize("Cliente", "ED")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Atualizar(clienteViewModel);

                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        [Route("{id:guid}/excluir-cliente")]
        [ClaimsAuthorize("Cliente", "EX")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }
        // Cliente = "LT,IN, VI, ED, EX"

        [Route("{id:guid}/excluir-cliente")]
        [ClaimsAuthorize("Cliente", "EX")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
