using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.OracleSSO.Domain.Models
{
    public partial class ClientRedirectUri
    {
        public int Id { get; set; }
        public string RedirectUri { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
