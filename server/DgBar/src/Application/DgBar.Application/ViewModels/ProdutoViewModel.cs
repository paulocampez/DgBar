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

        public string Nome { get; set; }
    }
}
