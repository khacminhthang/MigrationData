using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.PostgreSql.Domain.Models
{
    public partial class ApiProperty
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int ApiResourceId { get; set; }

        public virtual ApiResource ApiResource { get; set; }
    }
}
