using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DgBar.Application.Interfaces;
using DgBar.Application.ViewModels;
using DgBar.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DgBar.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaApplicationService _comandaApplicationService;
        public ComandaController(IComandaApplicationService comandaApplicationService)
        {
            _comandaApplicationService = comandaApplicationService;
        }

        [HttpGet]
        public IQueryable<Comanda> GetAll()
        {
            return _comandaApplicationService.GetAllComandas();
        }
        [HttpPost("{id}")]
        public void RegistrarItem([FromBody] List<ProdutoViewModel> dto, int id)
        {
            _comandaApplicationService.RegistrarItens(dto, id);
        }

        [HttpPost("FecharComanda")]
        public ComandaViewModel FecharComanda([FromBody] int numeroComanda)
        {
            return _comandaApplicationService.FecharComanda(numeroComanda);
        }

        [HttpPost("AbrirComanda")]
        public ComandaViewModel AbrirComanda()
        {
            return _comandaApplicationService.AbrirComanda();
        }

        [HttpPost("ResetarComanda")]
        public void ResetarComanda([FromBody] int numeroComanda)
        {
            _comandaApplicationService.ResetarComanda(numeroComanda);
        }
    }
}
