using Microsoft.AspNetCore.Mvc;
using MvcSegundaPracticaAWS.Models;
using MvcSegundaPracticaAWS.Services;

namespace MvcSegundaPracticaAWS.Controllers
{
    public class EventosController : Controller
    {
        private ServiceApiEventos service;
        private ServiceStorageAWS serviceStorage;
        public EventosController
            (ServiceApiEventos service, ServiceStorageAWS serviceStorage)
        {
            this.service = service;
            this.serviceStorage = serviceStorage;
        }

        public async Task<IActionResult> Index()
        {
            List<Evento> eventos = await this.service.GetEventosAsync();
            return View(eventos);
        }

        // Acción para mostrar todas las categorías
        public async Task<IActionResult> Categorias()
        {
            List<CategoriaEvento> categorias = await this.service.GetCategoriasAsync();
            return View(categorias);
        }

        // Acción GET para mostrar el formulario de selección de categoría
        [HttpGet]
        public async Task<IActionResult> EventosCategoria()
        {
            List<CategoriaEvento> categorias = await this.service.GetCategoriasAsync();
            ViewData["Categorias"] = categorias;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EventosCategoria(int idCategoria)
        {
            List<Evento> eventos = await this.service.GetEventosCategoriaAsync(idCategoria);
            ViewData["Categorias"] = await this.service.GetCategoriasAsync();
            return View(eventos);
        }






    }
}
