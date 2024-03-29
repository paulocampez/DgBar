﻿using DgBar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Application.ViewModels
{
    public class ComandaViewModel
    {
        public ComandaViewModel()
        {
            Id = Guid.NewGuid();
            Produtos = new List<Produto>();
        }

        public Guid Id { get; set; }
        public int NumeroComanda { get; set; }
        public List<Produto> Produtos { get; set; }

        public int Total { get; set; }
        public int Desconto { get; set; }
        public string Observacao { get; set; }

    }
}
