using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.PostgreSql.Domain.Models
{
    public partial class TUserAdminApp
    {
        public int UserAdminAppId { get; set; }
        public Guid UserId { get; set; }
        public int AppId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TApp App { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
