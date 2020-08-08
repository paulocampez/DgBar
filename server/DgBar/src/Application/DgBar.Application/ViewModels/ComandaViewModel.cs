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
        }

        public Guid Id { get; set; }
    }
}
