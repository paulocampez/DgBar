using DgBar.Domain.Interfaces;
using DgBar.Domain.Models;
using DgBar.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Infra.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DgBarContext db) : base(db)
        {
        }
    }
}
