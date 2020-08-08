using DgBar.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Domain.Commands
{
    public abstract class ProdutoCommand : Command
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}
