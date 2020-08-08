using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Application.ViewModels
{
    public class RegistrarPedidosViewModel
    {
        public List<ProdutoViewModel> Proodutos { get; set; }
        public Guid IdComanda { get; set; }
    }
}
