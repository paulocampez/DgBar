using DgBar.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Application.Interfaces
{
    public interface IComandaApplicationService : IDisposable
    {
        void ResetarComanda(int id);
        void RegistrarItem(RegistrarPedidosViewModel dto);
        void FecharComanda(int id);
        ComandaViewModel AbrirComanda();
    }
}
