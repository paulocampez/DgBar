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
        public int NumeroComanda { get; set; }
        public int Quantidade { get; set; }
        public int Valor { get; set; }
        public int Desconto { get; set; }

        public string Observacao { get; set; }
        
    }
}
