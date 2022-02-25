using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class TModule
    {
        public TModule()
        {
            TActionGroups = new HashSet<TActionGroup>();
            TActions = new HashSet<TAction>();
            TAppModules = new HashSet<TAppModule>();
            TPrefixUrls = new HashSet<TPrefixUrl>();
        }

        public int ModuleId { get; set; }
        public int Status { get; set; }
        public bool IsSystem { get; set; }
        public string Note { get; set; }
        public string ModuleName { get; set; }
        public string ModuleCode { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<TActionGroup> TActionGroups { get; set; }
        public virtual ICollection<TAction> TActions { get; set; }
        public virtual ICollection<TAppModule> TAppModules { get; set; }
        public virtual ICollection<TPrefixUrl> TPrefixUrls { get; set; }
    }
}
