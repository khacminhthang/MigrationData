using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.PostgreSql.Domain.Models
{
    public partial class TUserAdminScope
    {
        public int UserAdminScopeId { get; set; }
        public Guid UserId { get; set; }
        public Guid ScopeId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TScope Scope { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
