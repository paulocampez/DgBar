using DgBar.Domain.Core.Commands;
using DgBar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Domain.Commands
{
    public abstract class ComandaCommand : Command
    {
        public Guid Id { get; set; }
        public List<Produto> Produtos { get; set; }
        public int NumeroComanda { get; set; }
    }
}
