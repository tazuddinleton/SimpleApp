using SimpleApp.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.Persistence.Exceptions
{
    public class RecordNotFoundException : DomainException
    {
        public RecordNotFoundException(string msg) : base(msg)
        { }
    }
}
