using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Domain.Core.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
}
