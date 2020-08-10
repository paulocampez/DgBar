using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Application.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public string Descricao { get; set; }
        public string img { get; set; }
        public string tipo { get; set; }
        public int valor { get; set; }
    }
}
