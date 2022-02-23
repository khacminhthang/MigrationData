﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.PostgreSql.Domain.Models
{
    public partial class ClientScope
    {
        public int Id { get; set; }
        public string Scope { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
