﻿using DgBar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Application.ViewModels
{
    public class ComandaProdutosViewModel
    {
        public ComandaProdutosViewModel()
        {
            Id = Guid.NewGuid();
            Produtos = new List<Produto>();
        }

        public Guid Id { get; set; }
        public int NumeroComanda { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
