using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class TApp
    {
        public TApp()
        {
            TAppModules = new HashSet<TAppModule>();
            TCustomerConfigs = new HashSet<TCustomerConfig>();
            TUserAdminApps = new HashSet<TUserAdminApp>();
            TUserGroups = new HashSet<TUserGroup>();
        }

        public int AppId { get; set; }
        public int Status { get; set; }
        public bool IsSystem { get; set; }
        public string Note { get; set; }
        public string AppName { get; set; }
        public string AppCode { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<TAppModule> TAppModules { get; set; }
        public virtual ICollection<TCustomerConfig> TCustomerConfigs { get; set; }
        public virtual ICollection<TUserAdminApp> TUserAdminApps { get; set; }
        public virtual ICollection<TUserGroup> TUserGroups { get; set; }
    }
}
