using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.Domain.Exceptions
{
    // This gives us as change to return multiple error messages
    public class DomainException : Exception
    {
        public List<string> Errors { get; } = new List<string>();
        public DomainException(string msg) : base(msg)
        {
            Errors.Add(msg);
        }

        public DomainException(List<string> messages) : base()
        {
            Errors.AddRange(messages);
        }
    }
}
