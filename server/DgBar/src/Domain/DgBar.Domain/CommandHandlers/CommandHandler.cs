using DgBar.Domain.Core.Bus;
using DgBar.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IBusHandler _bus;
        public CommandHandler(IUnitOfWork uow, IBusHandler bus)
        {
            _uow = uow;
            _bus = bus;
        }


        public bool Commit()
        {
            if (_uow.Commit()) return true;

            return false;
        }
    }
}
