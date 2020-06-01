using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.Persistence.Services
{
    public interface ICurrentUserService
    {
        string UserId { get; }

    }
}
