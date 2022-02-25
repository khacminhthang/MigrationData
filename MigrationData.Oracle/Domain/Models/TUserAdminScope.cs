using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class TUserAdminScope
    {
        public int UserAdminScopeId { get; set; }
        public string UserId { get; set; }
        public string ScopeId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TScope Scope { get; set; }
        public virtual TUser User { get; set; }
    }
}
