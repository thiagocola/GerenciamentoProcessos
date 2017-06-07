using Repositorio.Context;
using Repositorio.Repositories;
using System;
using System.Web.Mvc;

namespace GerenciamentoProcessos.Controllers
{
    public class HomeController : Controller
    {
        private GerenciamentoProcessosContext context;
        private ClienteRepositorio repoCli;
        private ProcessoRepositorio repoPro;

        public HomeController()
        {
            context = new GerenciamentoProcessosContext();
            repoCli = new ClienteRepositorio(context);
            repoPro = new ProcessoRepositorio(context);
        }

        public ActionResult Index()
        {
            var listaProcessos = repoCli.ObterTodos();
            ViewBag.SomaProcessosAtivos = string.Format("{0:C}", repoPro.SomaProcessosAtivos());
            ViewBag.MediaPorClienteEstado = string.Format("{0:C}", repoPro.MediaPorClienteEstado("Empresa A", "Rio de Janeiro"));
            ViewBag.NumeroProcessosAcima = repoPro.NumeroProcessosAcima(100000m);
            ViewBag.ListaProcessosPorData = String.Join(", ", repoPro.ListaProcessosPorData(9, 2007));
            ViewBag.ListaProcessosPorClienteEstadoA = String.Join(", ", repoPro.ListaProcessosPorClienteEstado("Empresa A"));
            ViewBag.ListaProcessosPorClienteEstadoB = String.Join(", ", repoPro.ListaProcessosPorClienteEstado("Empresa B"));
            ViewBag.ListaProcessosPorSigla = String.Join(", ", repoPro.ListaProcessosPorSigla("TRAB"));

            return View(listaProcessos);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Perlink - Processo Seletivo";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Thiago Sodré Cola";

            return View();
        }
    }
}