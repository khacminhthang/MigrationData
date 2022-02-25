using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class Dvhc
    {
        public string Iddvhc { get; set; }
        public string Tendvhc { get; set; }
        public string Parentid { get; set; }
        public byte? Status { get; set; }
        public string Matinh { get; set; }
        public string Mahuyen { get; set; }
        public string Maxa { get; set; }
    }
}
