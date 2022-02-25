using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class TUser
    {
        public TUser()
        {
            TUserAdminApps = new HashSet<TUserAdminApp>();
            TUserAdminScopes = new HashSet<TUserAdminScope>();
            TUserUserGroups = new HashSet<TUserUserGroup>();
        }

        public string UserId { get; set; }
        public int Status { get; set; }
        public bool IsSystem { get; set; }
        public string Note { get; set; }
        public string UserName { get; set; }
        public string UserCode { get; set; }
        public int UserLevel { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DeptId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public int? IdDichVuCong { get; set; }
        public string TechnicalId { get; set; }
        public string Title { get; set; }
        public int? Maketnoi { get; set; }

        public virtual TCustomer Customer { get; set; }
        public virtual TScope Dept { get; set; }
        public virtual ICollection<TUserAdminApp> TUserAdminApps { get; set; }
        public virtual ICollection<TUserAdminScope> TUserAdminScopes { get; set; }
        public virtual ICollection<TUserUserGroup> TUserUserGroups { get; set; }
    }
}
