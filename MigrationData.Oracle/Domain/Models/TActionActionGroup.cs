using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class TActionActionGroup
    {
        public int ActionActionGroupId { get; set; }
        public int ActionId { get; set; }
        public int ActionGroupId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TAction Action { get; set; }
        public virtual TActionGroup ActionGroup { get; set; }
    }
}
