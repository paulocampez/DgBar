using DgBar.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Domain.Models
{
    public class Produto : Entity
    {
        public Produto(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
