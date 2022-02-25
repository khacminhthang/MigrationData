using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class TCatalogType
    {
        public TCatalogType()
        {
            TCatalogs = new HashSet<TCatalog>();
        }

        public int CatalogTypeId { get; set; }
        public string CatalogName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<TCatalog> TCatalogs { get; set; }
    }
}
