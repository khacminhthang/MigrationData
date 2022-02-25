using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class TUserGroup
    {
        public TUserGroup()
        {
            TUserGroupActionGroups = new HashSet<TUserGroupActionGroup>();
            TUserGroupScopes = new HashSet<TUserGroupScope>();
            TUserUserGroups = new HashSet<TUserUserGroup>();
        }

        public int UserGroupId { get; set; }
        public int Status { get; set; }
        public bool IsSystem { get; set; }
        public string Note { get; set; }
        public string UserGroupName { get; set; }
        public string UserGroupCode { get; set; }
        public int CustomerId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string AdminByScopeId { get; set; }
        public int? AdminByAppId { get; set; }

        public virtual TApp AdminByApp { get; set; }
        public virtual TScope AdminByScope { get; set; }
        public virtual TCustomer Customer { get; set; }
        public virtual ICollection<TUserGroupActionGroup> TUserGroupActionGroups { get; set; }
        public virtual ICollection<TUserGroupScope> TUserGroupScopes { get; set; }
        public virtual ICollection<TUserUserGroup> TUserUserGroups { get; set; }
    }
}
