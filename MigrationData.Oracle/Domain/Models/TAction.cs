using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class TAction
    {
        public TAction()
        {
            TActionActionGroups = new HashSet<TActionActionGroup>();
        }

        public int ActionId { get; set; }
        public int Status { get; set; }
        public bool IsSystem { get; set; }
        public string Note { get; set; }
        public string ActionName { get; set; }
        public string ActionCode { get; set; }
        public string ControllerName { get; set; }
        public bool IsScopeRequired { get; set; }
        public int SecurityLevel { get; set; }
        public int ModuleId { get; set; }
        public string HttpMethod { get; set; }
        public string Url { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TModule Module { get; set; }
        public virtual ICollection<TActionActionGroup> TActionActionGroups { get; set; }
    }
}
