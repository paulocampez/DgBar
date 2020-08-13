using DgBar.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Domain.Models
{
    public class Produto : Entity
    {
        public Produto(Guid id, string descricao, int numeroComanda, int valor, int quantidade, int desconto, string observacao)
        {
            Id = id;
            Descricao = descricao;
            NumeroComanda = numeroComanda;
            Quantidade = quantidade;
            Valor = valor;
            Desconto = desconto;
            Observacao = observacao;
        }

        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public int NumeroComanda { get; set; }
        public int Valor { get; set; }
        public int Quantidade { get; set; }
        public int Desconto { get; set; }
        public string Observacao { get; set; }
    }
}
