using DgBar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Domain.Commands
{
    public class RegistrarPedidoCommand : ComandaCommand
    {
        public RegistrarPedidoCommand(List<Produto> produto)
        {
           
            Produtos = produto;
        }
    }
}
