using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.PostgreSql.Domain.Models
{
    public partial class ApiClaim
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int ApiResourceId { get; set; }

        public virtual ApiResource ApiResource { get; set; }
    }
}
