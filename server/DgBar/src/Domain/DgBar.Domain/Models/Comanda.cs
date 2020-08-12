using DgBar.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Domain.Models
{
    public class Comanda : Entity
    {
        public Comanda(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public List<Produto> Produtos { get; }
        public int NumeroComanda { get; set; }
    }
}
