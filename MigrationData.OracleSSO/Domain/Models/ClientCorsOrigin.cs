using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.OracleSSO.Domain.Models
{
    public partial class ClientCorsOrigin
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
