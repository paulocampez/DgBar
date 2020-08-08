using DgBar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Application.Services
{
    public class ComandaApplicationService : IComandaApplicationService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
