using DgBar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Domain.Commands
{
    public class CadastrarNovaComandaCommand : ComandaCommand
    {
        public CadastrarNovaComandaCommand(List<Produto> produto)
        {
            Produtos = produto;
        }
    }
}
