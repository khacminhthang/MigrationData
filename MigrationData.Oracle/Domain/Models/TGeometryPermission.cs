using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class TGeometryPermission
    {
        public int? IdGeoPermission { get; set; }
        public string QuanHuyen { get; set; }
        public string PhuongXa { get; set; }
        public string TinhThanhpho { get; set; }
    }
}
