using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationData.PostgreSql.Domain.Models
{
    public partial class TLog
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string AppCode { get; set; }
        public string SiteId { get; set; }
        public string IpAddress { get; set; }
        public string ServiceName { get; set; }
        public string FunctionName { get; set; }
        public string Application { get; set; }
        public string Logged { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Logger { get; set; }
        public string Callsite { get; set; }
        public string Exception { get; set; }
        public string BeforeValue { get; set; }
        public string AfterValue { get; set; }
    }
}
