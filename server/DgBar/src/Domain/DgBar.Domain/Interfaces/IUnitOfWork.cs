﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
