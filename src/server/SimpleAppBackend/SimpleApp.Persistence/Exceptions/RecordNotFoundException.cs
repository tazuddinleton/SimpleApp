using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.Persistence.Exceptions
{
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException(string msg) : base(msg)
        { }
    }
}
