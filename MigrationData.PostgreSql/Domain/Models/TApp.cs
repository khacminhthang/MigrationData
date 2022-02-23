using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.PostgreSql.Domain.Models
{
    public partial class TApp
    {
        public TApp()
        {
            TUserAdminApps = new HashSet<TUserAdminApp>();
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

        public virtual ICollection<TUserAdminApp> TUserAdminApps { get; set; }
    }
}
