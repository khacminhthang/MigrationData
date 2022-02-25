using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class TUserGroupActionGroup
    {
        public int UserGroupActionGroupId { get; set; }
        public int UserGroupId { get; set; }
        public int ActionGroupId { get; set; }
        public bool? IsAllowToGrant { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TActionGroup ActionGroup { get; set; }
        public virtual TUserGroup UserGroup { get; set; }
    }
}
