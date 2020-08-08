using DgBar.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Domain.Models
{
    public class Produto : Entity
    {
        public Produto(Guid id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}
