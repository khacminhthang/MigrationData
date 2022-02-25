using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class TCustomerConfig
    {
        public int CustomerConfigId { get; set; }
        public string MaTinh { get; set; }
        public int AppId { get; set; }
        public string GiaTri { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TApp App { get; set; }
    }
}
