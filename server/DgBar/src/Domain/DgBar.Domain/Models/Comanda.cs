using DgBar.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Domain.Models
{
    public class Comanda : Entity
    {
        public Comanda(Guid id, int numeroComanda)
        {
            Id = id;
            NumeroComanda = numeroComanda;
            //Produtos = produtos;
        }

        public Guid Id { get; set; }
        public List<Produto> Produtos { get; } = new List<Produto>();
        public int NumeroComanda { get; set; } 
    }
}
