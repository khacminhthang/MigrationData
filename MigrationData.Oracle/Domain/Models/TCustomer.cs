using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class TCustomer
    {
        public TCustomer()
        {
            TScopes = new HashSet<TScope>();
            TUserGroups = new HashSet<TUserGroup>();
            TUsers = new HashSet<TUser>();
        }

        public int CustomerId { get; set; }
        public int Status { get; set; }
        public bool IsSystem { get; set; }
        public string Note { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<TScope> TScopes { get; set; }
        public virtual ICollection<TUserGroup> TUserGroups { get; set; }
        public virtual ICollection<TUser> TUsers { get; set; }
    }
}
