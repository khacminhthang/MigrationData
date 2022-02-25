using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class EfmigrationsHistoryBak
    {
        public string MigrationId { get; set; }
        public string ProductVersion { get; set; }
    }
}
