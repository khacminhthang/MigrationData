using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.PostgreSql.Domain.Models
{
    public partial class ApplicationConfiguration
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
