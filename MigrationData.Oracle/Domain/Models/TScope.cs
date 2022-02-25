using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class TScope
    {
        public TScope()
        {
            InverseParentScope = new HashSet<TScope>();
            TUserAdminScopes = new HashSet<TUserAdminScope>();
            TUserGroupScopes = new HashSet<TUserGroupScope>();
            TUserGroups = new HashSet<TUserGroup>();
            TUsers = new HashSet<TUser>();
        }

        public string ScopeId { get; set; }
        public int Status { get; set; }
        public bool IsSystem { get; set; }
        public string Note { get; set; }
        public string ScopeName { get; set; }
        public string ScopeCode { get; set; }
        public int ScopeType { get; set; }
        public string ParentScopeId { get; set; }
        public string ImportedParentScopeId { get; set; }
        public byte ScopeLevel { get; set; }
        public int CustomerId { get; set; }
        public string Discriminator { get; set; }
        public string MaTinh { get; set; }
        public string MaHuyen { get; set; }
        public string MaXa { get; set; }
        public string Path { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string AppCode { get; set; }
        public string OriginCategoryId { get; set; }

        public virtual TCustomer Customer { get; set; }
        public virtual TScope ParentScope { get; set; }
        public virtual ICollection<TScope> InverseParentScope { get; set; }
        public virtual ICollection<TUserAdminScope> TUserAdminScopes { get; set; }
        public virtual ICollection<TUserGroupScope> TUserGroupScopes { get; set; }
        public virtual ICollection<TUserGroup> TUserGroups { get; set; }
        public virtual ICollection<TUser> TUsers { get; set; }
    }
}
