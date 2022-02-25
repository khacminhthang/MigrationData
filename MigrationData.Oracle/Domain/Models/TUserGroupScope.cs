using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class TUserGroupScope
    {
        public int UserGroupScopeId { get; set; }
        public int UserGroupId { get; set; }
        public string ScopeId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TScope Scope { get; set; }
        public virtual TUserGroup UserGroup { get; set; }
    }
}
