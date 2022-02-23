using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.PostgreSql.Domain.Models
{
    public partial class TUserGroup
    {
        public int UserGroupId { get; set; }
        public int Status { get; set; }
        public bool IsSystem { get; set; }
        public string Note { get; set; }
        public string UserGroupName { get; set; }
        public string UserGroupCode { get; set; }
        public int CustomerId { get; set; }
        public Guid AdminByScopeId { get; set; }
        public int AdminByAppId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
