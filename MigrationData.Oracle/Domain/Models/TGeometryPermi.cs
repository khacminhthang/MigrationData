using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class TGeometryPermi
    {
        public decimal IdGeoPermission { get; set; }
        public string QuanHuyen { get; set; }
        public string PhuongXa { get; set; }
        public string TinhThanhpho { get; set; }
        public string Wkt { get; set; }
        public string IdVung { get; set; }
        public string Matinh { get; set; }
        public string Mahuyen { get; set; }
        public string Maxa { get; set; }
        public string Tenhuyenkodau { get; set; }
    }
}
