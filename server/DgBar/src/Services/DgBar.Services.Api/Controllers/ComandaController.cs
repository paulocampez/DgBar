using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DgBar.Application.Interfaces;
using DgBar.Application.ViewModels;
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
        public ComandaController(IComandaApplicationService  comandaApplicationService)
        {
            _comandaApplicationService = comandaApplicationService;
        }


        [HttpPost("{id}")]
        public void RegistrarItem([FromBody] List<ProdutoViewModel> dto, int id)
        {
            _comandaApplicationService.RegistrarItens(dto);
        }

        //[HttpPost("{id}")]
        //public void FecharComanda(int id)
        //{
        //    _comandaApplicationService.FecharComanda(id);
        //}



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
