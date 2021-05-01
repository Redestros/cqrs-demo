using System;
using System.Collections.Generic;
using System.Text;

namespace cqrs_demo.Data
{
    public partial class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
