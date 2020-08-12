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


        [HttpPost("{id}")]
        public void RegistrarItem([FromBody] List<ProdutoViewModel> dto, int id)
        {
            _comandaApplicationService.RegistrarItens(dto);
        }

        [HttpPost("FecharComanda")]
        public List<Produto> FecharComanda([FromBody] int numeroComanda)
        {
            List<Produto> lst = _comandaApplicationService.GetAllProdutos(numeroComanda);
            _comandaApplicationService.FecharComanda(numeroComanda);
            return lst;
        }

        [HttpPost("AbrirComanda")]
        public ComandaViewModel AbrirComanda()
        {
            return _comandaApplicationService.AbrirComanda();
        }

        [HttpPut("{id}")]
        public void ResetarComanda(int id)
        {
            _comandaApplicationService.ResetarComanda(id);
        }
    }
}
