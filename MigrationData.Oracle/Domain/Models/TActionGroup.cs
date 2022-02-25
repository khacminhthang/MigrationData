using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class TActionGroup
    {
        public TActionGroup()
        {
            TActionActionGroups = new HashSet<TActionActionGroup>();
            TUserGroupActionGroups = new HashSet<TUserGroupActionGroup>();
        }

        public int ActionGroupId { get; set; }
        public int Status { get; set; }
        public bool IsSystem { get; set; }
        public string Note { get; set; }
        public string ActionGroupName { get; set; }
        public string ActionGroupCode { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public int ModuleId { get; set; }

        public virtual TModule Module { get; set; }
        public virtual ICollection<TActionActionGroup> TActionActionGroups { get; set; }
        public virtual ICollection<TUserGroupActionGroup> TUserGroupActionGroups { get; set; }
    }
}
