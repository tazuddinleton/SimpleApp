using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.Domain.Common
{
    public class AuditableEntity
    {
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
