using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class TAppModule
    {
        public int AppModuleId { get; set; }
        public int AppId { get; set; }
        public int ModuleId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TApp App { get; set; }
        public virtual TModule Module { get; set; }
    }
}
