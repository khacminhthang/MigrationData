using MigrationData.PostgreSql.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MigrationData.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            GetTApp();
        }

        public static void GetTApp()
        {
            List<MigrationData.PostgreSql.Domain.Models.TApp> data = new List<TApp>();
            using (var db = new MigrationData.PostgreSql.Domain.Models.DatabaseContext())
            {
                data = db.TApps.ToList();
            }

            //var list = new List<ConsoleApp2.Domain.Models.TAction>();
            //using (var db2 = new ConsoleApp2.Domain.Models.DatabaseContext())
            //{
            //    foreach (var item in data)
            //    {
            //        var model = new ConsoleApp2.Domain.Models.TAction
            //        {
            //            ActionName = item.ActionName,
            //            ActionCode = item.ActionCode,
            //            ModuleId = item.ModuleId,
            //            Status = item.Status,
            //            IsSystem = item.IsSystem,
            //            Note = item.Note,
            //            ControllerName = item.ControllerName,
            //            IsScopeRequired = item.IsScopeRequired,
            //            SecurityLevel = item.SecurityLevel,
            //            HttpMethod = item.HttpMethod,
            //            Url = item.Url,
            //            CreatedAt = DateTime.Now
            //        };
            //        list.Add(model);

            //    }
            //    db2.AddRange(list);
            //    db2.SaveChanges();
            //}
        }

        public static void GetTAction()
        {
            List<MigrationData.PostgreSql.Domain.Models.TAction> data = new List<TAction>();
            using (var db = new MigrationData.PostgreSql.Domain.Models.DatabaseContext())
            {
                data = db.TActions.Where(a => a.ModuleId == 28).ToList();
            }

            //var list = new List<ConsoleApp2.Domain.Models.TAction>();
            //using (var db2 = new ConsoleApp2.Domain.Models.DatabaseContext())
            //{
            //    foreach (var item in data)
            //    {
            //        var model = new ConsoleApp2.Domain.Models.TAction
            //        {
            //            ActionName = item.ActionName,
            //            ActionCode = item.ActionCode,
            //            ModuleId = item.ModuleId,
            //            Status = item.Status,
            //            IsSystem = item.IsSystem,
            //            Note = item.Note,
            //            ControllerName = item.ControllerName,
            //            IsScopeRequired = item.IsScopeRequired,
            //            SecurityLevel = item.SecurityLevel,
            //            HttpMethod = item.HttpMethod,
            //            Url = item.Url,
            //            CreatedAt = DateTime.Now
            //        };
            //        list.Add(model);

            //    }
            //    db2.AddRange(list);
            //    db2.SaveChanges();
            //}
        }
    }
}
