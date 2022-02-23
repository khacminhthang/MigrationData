using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.PostgreSql.Domain.Models
{
    public partial class TScope
    {
        public TScope()
        {
            TUserAdminScopes = new HashSet<TUserAdminScope>();
        }

        public Guid ScopeId { get; set; }
        public int Status { get; set; }
        public bool IsSystem { get; set; }
        public string Note { get; set; }
        public string ScopeName { get; set; }
        public string ScopeCode { get; set; }
        public int ScopeType { get; set; }
        public string Path { get; set; }
        public Guid? ParentScopeId { get; set; }
        public Guid? ImportedParentScopeId { get; set; }
        public short ScopeLevel { get; set; }
        public int CustomerId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string Discriminator { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string OriginCategoryId { get; set; }
        public string AppCode { get; set; }
        public string MaTinh { get; set; }
        public string MaHuyen { get; set; }
        public string MaXa { get; set; }

        public virtual ICollection<TUserAdminScope> TUserAdminScopes { get; set; }
    }
}
