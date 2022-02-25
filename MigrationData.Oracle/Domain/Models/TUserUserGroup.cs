using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class TUserUserGroup
    {
        public int UserUserGroupId { get; set; }
        public string UserId { get; set; }
        public int UserGroupId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TUser User { get; set; }
        public virtual TUserGroup UserGroup { get; set; }
    }
}
