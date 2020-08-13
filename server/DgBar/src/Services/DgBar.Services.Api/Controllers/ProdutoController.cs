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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoApplicationService _produtoApplicationService;
        public ProdutoController(IProdutoApplicationService produtoApplicationService)
        {
            _produtoApplicationService = produtoApplicationService;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<ProdutoViewModel> GetAll()
        {
            return _produtoApplicationService.GetAll();
        }

        [HttpPost]
        public void Post([FromBody] ProdutoViewModel produtoVm)
        {
            _produtoApplicationService.Create(produtoVm);
        }
    }
}
