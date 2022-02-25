using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class Culture
    {
        public Culture()
        {
            Resources = new HashSet<Resource>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
