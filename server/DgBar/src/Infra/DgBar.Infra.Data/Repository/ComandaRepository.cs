using DgBar.Domain.Interfaces;
using DgBar.Domain.Models;
using DgBar.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Infra.Data.Repository
{
    public class ComandaRepository : Repository<Comanda>, IComandaRepository
    {
        public ComandaRepository(DgBarContext db) : base(db)
        {
        }

        public Comanda GetByNumero(int numeroComanda)
        {
            throw new NotImplementedException();
        }
    }
}
