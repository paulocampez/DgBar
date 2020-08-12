using DgBar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Domain.Commands
{
    public class FecharComandaCommand : ComandaCommand
    {
        public FecharComandaCommand(List<Produto> produto)
        {
            Produtos = produto;
        }
    }
}
