using MigrationData.PostgreSql.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationData.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetTCustomer();
            //GetTApp();
            //GetTModule();
            //GetTAppModule();
            //GetTAction();
            //GetTActionGroup();
            //GetTActionActionGroup();
            //GetTScope();
            //GetAspNetUsers();
            //GetTUser();
            //GetAspNetRoles();
            //GetAspNetUserRoles();
            //GetTUserAdminApp();
            //GetTUserAdminScope();
            //GetTUserGroup();
            GetTUserGroupActionGroup();
            //GetTUserGroupScope();
            //GetTUserUserGroup();
        }

        // T_CUSTOMER
        public static void GetTCustomer()
        {
            List<MigrationData.PostgreSql.Domain.Models.TCustomer> data = new List<TCustomer>();
            using (var db = new MigrationData.PostgreSql.Domain.Models.DatabaseContext())
            {
                data = db.TCustomers.ToList();
            }

            var list = new List<MigrationData.Oracle.Domain.Models.TCustomer>();
            using (var db2 = new MigrationData.Oracle.Domain.Models.DatabaseContext())
            {
                foreach (var item in data)
                {
                    var model = new MigrationData.Oracle.Domain.Models.TCustomer
                    {
                        CustomerId = item.CustomerId,
                        CustomerCode = item.CustomerCode,
                        CustomerName = item.CustomerName,
                        Status = item.Status,
                        IsSystem = item.IsSystem,
                        Note = item.Note,
                        CreatedBy = item.CreatedBy,
                        CreatedAt = DateTime.Now
                    };
                    list.Add(model);

                }
                db2.AddRange(list);
                db2.SaveChanges();
            }
        }

        // T_APP 
        public static void GetTApp()
        {
            List<MigrationData.PostgreSql.Domain.Models.TApp> data = new List<MigrationData.PostgreSql.Domain.Models.TApp>();
            List<MigrationData.Oracle.Domain.Models.TApp> data2 = new List<MigrationData.Oracle.Domain.Models.TApp>();
            using (var db = new MigrationData.PostgreSql.Domain.Models.DatabaseContext())
            {
                data = db.TApps.ToList();
            }

            var list = new List<MigrationData.Oracle.Domain.Models.TApp>();
            using (var db2 = new MigrationData.Oracle.Domain.Models.DatabaseContext())
            {
                data2 = db2.TApps.ToList();

                foreach (var item in data)
                {

                    var temp = data2.FirstOrDefault(x => x.AppId == item.AppId);
                    if (temp == null)
                    {
                        var model = new MigrationData.Oracle.Domain.Models.TApp
                        {
                            AppId = item.AppId,
                            AppCode = item.AppCode,
                            AppName = item.AppName,
                            Status = item.Status,
                            IsSystem = item.IsSystem,
                            Note = item.Note,
                            CreatedBy = item.CreatedBy,
                            CreatedAt = DateTime.Now
                        };
                        list.Add(model);
                    }
                }
                db2.AddRange(list);
                db2.SaveChanges();
            }
        }

        // T_MODULE 
        public static void GetTModule()
        {
            List<MigrationData.PostgreSql.Domain.Models.TModule> data = new List<MigrationData.PostgreSql.Domain.Models.TModule>();
            List<MigrationData.Oracle.Domain.Models.TModule> data2 = new List<MigrationData.Oracle.Domain.Models.TModule>();
            using (var db = new MigrationData.PostgreSql.Domain.Models.DatabaseContext())
            {
                data = db.TModules.ToList();
            }

            var list = new List<MigrationData.Oracle.Domain.Models.TModule>();
            using (var db2 = new MigrationData.Oracle.Domain.Models.DatabaseContext())
            {
                data2 = db2.TModules.ToList();
                foreach (var item in data)
                {
                    var temp = data2.FirstOrDefault(x => x.ModuleId == item.ModuleId);
                    if (temp == null)
                    {
                        var model = new MigrationData.Oracle.Domain.Models.TModule
                        {
                            ModuleId = item.ModuleId,
                            ModuleName = item.ModuleName,
                            ModuleCode = item.ModuleCode,
                            Status = item.Status,
                            IsSystem = item.IsSystem,
                            Note = item.Note,
                            CreatedBy = item.CreatedBy,
                            CreatedAt = DateTime.Now
                        };
                        list.Add(model);
                    }
                }
                db2.AddRange(list);
                db2.SaveChanges();
            }
        }

        // T_APP_MODULE 
        public static void GetTAppModule()
        {
            List<MigrationData.PostgreSql.Domain.Models.TAppModule> data = new List<MigrationData.PostgreSql.Domain.Models.TAppModule>();
            List<MigrationData.Oracle.Domain.Models.TAppModule> data2 = new List<MigrationData.Oracle.Domain.Models.TAppModule>();
            using (var db = new MigrationData.PostgreSql.Domain.Models.DatabaseContext())
            {
                data = db.TAppModules.ToList();
            }

            var list = new List<MigrationData.Oracle.Domain.Models.TAppModule>();
            using (var db2 = new MigrationData.Oracle.Domain.Models.DatabaseContext())
            {
                data2 = db2.TAppModules.ToList();

                foreach (var item in data)
                {
                    var temp = data2.FirstOrDefault(x => x.AppId == item.AppId && x.ModuleId == item.ModuleId);
                    if (temp == null)
                    {

                        var model = new MigrationData.Oracle.Domain.Models.TAppModule
                        {
                            AppModuleId = item.AppModuleId,
                            AppId = item.AppId,
                            ModuleId = item.ModuleId,
                            CreatedBy = item.CreatedBy,
                            CreatedAt = DateTime.Now
                        };
                        list.Add(model);
                    }
                }
                db2.AddRange(list);
                db2.SaveChanges();
            }
        }

        // T_ACTION
        public static void GetTAction()
        {
            List<MigrationData.PostgreSql.Domain.Models.TAction> data = new List<MigrationData.PostgreSql.Domain.Models.TAction>();
            List<MigrationData.Oracle.Domain.Models.TAction> data2 = new List<MigrationData.Oracle.Domain.Models.TAction>();
            using (var db = new MigrationData.PostgreSql.Domain.Models.DatabaseContext())
            {
                data = db.TActions.ToList();
            }

            var list = new List<MigrationData.Oracle.Domain.Models.TAction>();
            using (var db2 = new MigrationData.Oracle.Domain.Models.DatabaseContext())
            {

                data2 = db2.TActions.ToList();

                var count = 0;

                foreach (var item in data)
                {
                    var temp = data2.FirstOrDefault(x => x.ActionId == item.ActionId);
                    if (temp == null)
                    {
                        count++;
                        var model = new MigrationData.Oracle.Domain.Models.TAction
                        {
                            ActionId = item.ActionId,
                            ActionName = item.ActionName,
                            ActionCode = item.ActionCode,
                            ModuleId = item.ModuleId,
                            Status = item.Status,
                            IsSystem = item.IsSystem,
                            Note = item.Note,
                            ControllerName = item.ControllerName,
                            IsScopeRequired = item.IsScopeRequired,
                            SecurityLevel = item.SecurityLevel,
                            HttpMethod = item.HttpMethod,
                            Url = item.Url,
                            CreatedAt = DateTime.Now,
                            CreatedBy = item.CreatedBy
                        };
                        list.Add(model);
                        Console.WriteLine(count);
                    }
                }
                db2.AddRange(list);
                db2.SaveChanges();
                Console.WriteLine("Done");
            }
        }

        // T_ACTION_GROUP
        public static void GetTActionGroup()
        {
            List<MigrationData.PostgreSql.Domain.Models.TActionGroup> data = new List<MigrationData.PostgreSql.Domain.Models.TActionGroup>();
            List<MigrationData.Oracle.Domain.Models.TActionGroup> data2 = new List<MigrationData.Oracle.Domain.Models.TActionGroup>();
            using (var db = new MigrationData.PostgreSql.Domain.Models.DatabaseContext())
            {
                data = db.TActionGroups.ToList();
            }

            var list = new List<MigrationData.Oracle.Domain.Models.TActionGroup>();
            using (var db2 = new MigrationData.Oracle.Domain.Models.DatabaseContext())
            {

                data2 = db2.TActionGroups.ToList();

                var count = 0;

                foreach (var item in data)
                {
                    var temp = data2.FirstOrDefault(x => x.ActionGroupId == item.ActionGroupId);
                    if (temp == null)
                    {
                        count++;
                        var model = new MigrationData.Oracle.Domain.Models.TActionGroup
                        {
                            ActionGroupId = item.ActionGroupId,
                            ActionGroupCode = item.ActionGroupCode,
                            ActionGroupName = item.ActionGroupName,
                            Status = item.Status,
                            IsSystem = item.IsSystem,
                            Note = item.Note,
                            ModuleId = item.ModuleId,
                            CreatedBy = item.CreatedBy,
                            CreatedAt = DateTime.Now
                        };
                        list.Add(model);
                        Console.WriteLine(count);
                    }
                }
                db2.AddRange(list);
                db2.SaveChanges();
                Console.WriteLine("Done");
            }
        }

        // T_ACTION_ACTION_GROUP
        public static void GetTActionActionGroup()
        {
            List<MigrationData.Oracle.Domain.Models.TActionActionGroup> data2 = new List<MigrationData.Oracle.Domain.Models.TActionActionGroup>();
            List<MigrationData.PostgreSql.Domain.Models.TActionActionGroup> TActionActionGroups = new List<MigrationData.PostgreSql.Domain.Models.TActionActionGroup>();
            List<MigrationData.Oracle.Domain.Models.TAction> TActions = new List<MigrationData.Oracle.Domain.Models.TAction>();
            List<MigrationData.Oracle.Domain.Models.TActionGroup> TActionGroups = new List<MigrationData.Oracle.Domain.Models.TActionGroup>();

            using (var db = new MigrationData.PostgreSql.Domain.Models.DatabaseContext())
            {
                TActionActionGroups = db.TActionActionGroups.ToList();
            }

            var list = new List<MigrationData.Oracle.Domain.Models.TActionActionGroup>();
            using (var db2 = new MigrationData.Oracle.Domain.Models.DatabaseContext())
            {
                data2 = db2.TActionActionGroups.ToList();
                TActions = db2.TActions.ToList();
                TActionGroups = db2.TActionGroups.ToList();

                var count = 0;
                foreach (var item in TActionActionGroups)
                {
                    var temp = data2.FirstOrDefault(x => x.ActionId == item.ActionId && x.ActionGroupId == item.ActionGroupId);
                    var tempAction = TActions.FirstOrDefault(x => x.ActionId == item.ActionId);
                    var tempActionGroup = TActionGroups.FirstOrDefault(x => x.ActionGroupId == item.ActionGroupId);
                    if (temp == null && tempAction != null && tempActionGroup != null)
                    {
                        count++;
                        var model = new MigrationData.Oracle.Domain.Models.TActionActionGroup
                        {
                            //ActionActionGroupId = item.ActionActionGroupId,
                            ActionId = item.ActionId,
                            ActionGroupId = item.ActionGroupId,
                            CreatedBy = item.CreatedBy,
                            CreatedAt = DateTime.Now
                        };
                        list.Add(model);
                        Console.WriteLine(count);
                    }
                }
                db2.AddRange(list);
                db2.SaveChanges();
                Console.WriteLine("Done");
            }
        }

        // T_SCOPE
        public static void GetTScope()
        {
            List<MigrationData.PostgreSql.Domain.Models.TScope> data = new List<TScope>();
            using (var db = new MigrationData.PostgreSql.Domain.Models.DatabaseContext())
            {
                data = db.TScopes.ToList();
            }

            var list = new List<MigrationData.Oracle.Domain.Models.TScope>();
            using (var db2 = new MigrationData.Oracle.Domain.Models.DatabaseContext())
            {

                foreach (var item in data)
                {
                    var model = new MigrationData.Oracle.Domain.Models.TScope
                    {
                        ScopeId = item.ScopeId.ToString(),
                        ScopeCode = item.ScopeCode,
                        ScopeLevel = (byte)item.ScopeLevel,
                        Status = item.Status,
                        IsSystem = item.IsSystem,
                        Note = item.Note,
                        ScopeName = item.ScopeName,
                        Path = item.Path,
                        ParentScopeId = item.ParentScopeId.ToString(),
                        ImportedParentScopeId = item.ImportedParentScopeId.ToString(),
                        CustomerId = item.CustomerId,
                        CreatedBy = item.CreatedBy,
                        Discriminator = item.Discriminator,
                        OriginCategoryId = item.OriginCategoryId,
                        AppCode = item.AppCode,
                        MaTinh = item.MaTinh,
                        MaHuyen = item.MaHuyen,
                        MaXa = item.MaXa,
                        CreatedAt = DateTime.Now
                    };
                    list.Add(model);

                }
                db2.AddRange(list);
                db2.SaveChanges();
            }
        }

        // AspNetUsers
        public static void GetAspNetUsers()
        {
            List<MigrationData.PostgreSql.Domain.Models.AspNetUser> data = new List<MigrationData.PostgreSql.Domain.Models.AspNetUser>();
            List<MigrationData.OracleSSO.Domain.Models.AspNetUser> data2 = new List<MigrationData.OracleSSO.Domain.Models.AspNetUser>();
            using (var db = new MigrationData.PostgreSql.Domain.Models.DatabaseContext())
            {
                data = db.AspNetUsers.ToList();
            }

            var list = new List<MigrationData.OracleSSO.Domain.Models.AspNetUser>();
            using (var db2 = new MigrationData.OracleSSO.Domain.Models.DatabaseContext())
            {
                data2 = db2.AspNetUsers.ToList();

                var count = 0;
                foreach (var item in data)
                {
                    var temp = data2.FirstOrDefault(x => x.UserName == item.UserName);
                    if (temp == null)
                    {
                        count++;
                        var model = new MigrationData.OracleSSO.Domain.Models.AspNetUser
                        {
                            Id = item.Id,
                            UserName = item.UserName,
                            NormalizedUserName = item.NormalizedUserName,
                            Email = item.Email,
                            NormalizedEmail = item.NormalizedEmail,
                            EmailConfirmed = item.EmailConfirmed,
                            PasswordHash = item.PasswordHash,
                            SecurityStamp = item.SecurityStamp,
                            ConcurrencyStamp = item.ConcurrencyStamp,
                            PhoneNumber = item.PhoneNumber,
                            PhoneNumberConfirmed = item.PhoneNumberConfirmed,
                            TwoFactorEnabled = item.TwoFactorEnabled,
                            LockoutEnabled = item.LockoutEnabled,
                            LockoutEnd = item.LockoutEnd,
                            AccessFailedCount = item.AccessFailedCount,
                            IsEnabled = item.IsEnabled,
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            Mobile = item.Mobile,
                            IsAdmin = item.IsAdmin,
                            RequiredOtpSms = item.RequiredOtpSms,
                            DataEventRecordsRole = item.DataEventRecordsRole,
                            SecuredFilesRole = item.SecuredFilesRole,
                            //UserCode = item.UserCode,
                            //DeptId = item.DeptId,
                            //CustomerId = item.CustomerId,
                            //UserLevel = item.UserLevel,
                            //Status = item.Status,
                            //TechnicalId = item.TechnicalId
                        };
                        list.Add(model);
                        Console.WriteLine(count);
                    }
                }
                db2.AddRange(list);
                db2.SaveChanges();
                Console.WriteLine("Done");
            }
        }

        // T_USER
        public static void GetTUser()
        {
            List<MigrationData.PostgreSql.Domain.Models.AspNetUser> data = new List<MigrationData.PostgreSql.Domain.Models.AspNetUser>();
            List<MigrationData.Oracle.Domain.Models.TUser> data2 = new List<MigrationData.Oracle.Domain.Models.TUser>();
            using (var db = new MigrationData.PostgreSql.Domain.Models.DatabaseContext())
            {
                data = db.AspNetUsers.ToList();
            }

            var list = new List<MigrationData.Oracle.Domain.Models.TUser>();
            using (var db2 = new MigrationData.Oracle.Domain.Models.DatabaseContext())
            {
                data2 = db2.TUsers.ToList();

                var count = 0;
                foreach (var item in data)
                {
                    var temp = data2.FirstOrDefault(x => x.UserName == item.UserName);
                    if (temp == null)
                    {
                        count++;
                        var model = new MigrationData.Oracle.Domain.Models.TUser
                        {
                            UserId = item.Id.ToString().Replace("-", ""),
                            UserName = item.UserName,
                            Email = item.Email,
                            UserCode = item.UserCode,
                            //DeptId = item.DeptId.ToString().Replace("-", ""),
                            CustomerId = item.CustomerId,
                            UserLevel = item.UserLevel,
                            Status = item.Status,
                            FullName = item.FirstName + item.LastName,
                            Phone = item.PhoneNumber,
                            CreatedAt = DateTime.Now
                        };
                        list.Add(model);
                        Console.WriteLine(count);
                    }
                }
                db2.AddRange(list);
                db2.SaveChanges();
                Console.WriteLine("Done");
            }
        }

        // AspNetRoles
        public static void GetAspNetRoles()
        {
            List<MigrationData.PostgreSql.Domain.Models.AspNetRole> data = new List<AspNetRole>();
            using (var db = new MigrationData.PostgreSql.Domain.Models.DatabaseContext())
            {
                data = db.AspNetRoles.ToList();
            }

            var list = new List<MigrationData.OracleSSO.Domain.Models.AspNetRole>();
            using (var db2 = new MigrationData.OracleSSO.Domain.Models.DatabaseContext())
            {
                foreach (var item in data)
                {
                    var model = new MigrationData.OracleSSO.Domain.Models.AspNetRole
                    {
                        Id = item.Id,
                        Name = item.Name,
                        NormalizedName = item.NormalizedName,
                        ConcurrencyStamp = item.ConcurrencyStamp,
                        Description = item.Description,
                    };
                    list.Add(model);

                }
                db2.AddRange(list);
                db2.SaveChanges();
            }
        }

        //AspNetUserRoles
        public static void GetAspNetUserRoles()
        {
            List<MigrationData.PostgreSql.Domain.Models.AspNetUserRole> data = new List<MigrationData.PostgreSql.Domain.Models.AspNetUserRole>();
            List<MigrationData.OracleSSO.Domain.Models.AspNetUserRole> data2 = new List<MigrationData.OracleSSO.Domain.Models.AspNetUserRole>();
            using (var db = new MigrationData.PostgreSql.Domain.Models.DatabaseContext())
            {
                data = db.AspNetUserRoles.ToList();
            }

            var list = new List<MigrationData.OracleSSO.Domain.Models.AspNetUserRole>();
            using (var db2 = new MigrationData.OracleSSO.Domain.Models.DatabaseContext())
            {
                data2 = db2.AspNetUserRoles.ToList();

                var count = 0;
                foreach (var item in data2)
                {
                    var test = item.UserId;
                    count++;
                    //count++;
                    //var temp = data2.FirstOrDefault(x => x.RoleId.ToString() == item.RoleId.ToString() && x.UserId == item.UserId);
                    //if (temp == null)
                    //{
                    //    var model = new MigrationData.OracleSSO.Domain.Models.AspNetUserRole
                    //    {
                    //        UserId = item.UserId,
                    //        RoleId = item.RoleId
                    //    };
                    //    list.Add(model);
                    //    Console.WriteLine(count);
                    //}
                }
                db2.AddRange(list);
                db2.SaveChanges();
                Console.WriteLine("Done");
            }
        }

        //T_USER_ADMIN_APP
        public static void GetTUserAdminApp()
        {
            List<MigrationData.PostgreSql.Domain.Models.TUserAdminApp> data = new List<MigrationData.PostgreSql.Domain.Models.TUserAdminApp>();
            List<MigrationData.Oracle.Domain.Models.TUserAdminApp> data2 = new List<MigrationData.Oracle.Domain.Models.TUserAdminApp>();
            using (var db = new MigrationData.PostgreSql.Domain.Models.DatabaseContext())
            {
                data = db.TUserAdminApps.ToList();
            }

            var list = new List<MigrationData.Oracle.Domain.Models.TUserAdminApp>();
            using (var db2 = new MigrationData.Oracle.Domain.Models.DatabaseContext())
            {
                data2 = db2.TUserAdminApps.ToList();

                var count = 0;
                foreach (var item in data)
                {
                    var temp = data2.FirstOrDefault(x => x.UserId == item.UserId.ToString() && x.AppId == item.AppId);
                    if (temp == null)
                    {
                        count++;
                        var model = new MigrationData.Oracle.Domain.Models.TUserAdminApp
                        {
                            UserAdminAppId = item.UserAdminAppId,
                            UserId = item.UserId.ToString().Replace("-", ""),
                            AppId = item.AppId,
                            CreatedBy = item.CreatedBy,
                            CreatedAt = DateTime.Now
                        };
                        list.Add(model);
                        Console.WriteLine(count);
                    }
                }
                db2.AddRange(list);
                db2.SaveChanges();
                Console.WriteLine("Done");
            }
        }

        //T_USER_ADMIN_SCOPE
        public static void GetTUserAdminScope()
        {
            List<MigrationData.PostgreSql.Domain.Models.TUserAdminScope> data = new List<TUserAdminScope>();
            using (var db = new MigrationData.PostgreSql.Domain.Models.DatabaseContext())
            {
                data = db.TUserAdminScopes.ToList();
            }

            var list = new List<MigrationData.Oracle.Domain.Models.TUserAdminScope>();
            using (var db2 = new MigrationData.Oracle.Domain.Models.DatabaseContext())
            {
                foreach (var item in data)
                {
                    var model = new MigrationData.Oracle.Domain.Models.TUserAdminScope
                    {
                        UserAdminScopeId = item.UserAdminScopeId,
                        UserId = item.UserId.ToString(),
                        ScopeId = item.ScopeId.ToString(),
                        CreatedBy = item.CreatedBy,
                        CreatedAt = DateTime.Now
                    };
                    list.Add(model);

                }
                db2.AddRange(list);
                db2.SaveChanges();
            }
        }

        //T_USER_GROUP
        public static void GetTUserGroup()
        {
            List<MigrationData.PostgreSql.Domain.Models.TUserGroup> data = new List<MigrationData.PostgreSql.Domain.Models.TUserGroup>();
            List<MigrationData.Oracle.Domain.Models.TUserGroup> data2 = new List<MigrationData.Oracle.Domain.Models.TUserGroup>();
            using (var db = new MigrationData.PostgreSql.Domain.Models.DatabaseContext())
            {
                data = db.TUserGroups.ToList();
            }

            var list = new List<MigrationData.Oracle.Domain.Models.TUserGroup>();
            using (var db2 = new MigrationData.Oracle.Domain.Models.DatabaseContext())
            {
                data2 = db2.TUserGroups.ToList();

                var count = 0;
                foreach (var item in data)
                {
                    var temp = data2.FirstOrDefault(x => x.UserGroupId == item.UserGroupId);
                    if (temp == null)
                    {
                        count++;
                        var model = new MigrationData.Oracle.Domain.Models.TUserGroup
                        {
                            UserGroupId = item.UserGroupId,
                            UserGroupName = item.UserGroupName,
                            UserGroupCode = item.UserGroupCode,
                            Status = item.Status,
                            IsSystem = item.IsSystem,
                            Note = item.Note,
                            CustomerId = item.CustomerId,
                            AdminByScopeId = "BD4539DEB30143A29C08F21CEFE21342",
                            AdminByAppId = item.AdminByAppId,
                            CreatedBy = item.CreatedBy,
                            CreatedAt = DateTime.Now
                        };
                        list.Add(model);
                        Console.WriteLine(count);
                    }
                }
                db2.AddRange(list);
                db2.SaveChanges();
                Console.WriteLine("Done");
            }
        }

        //T_USER_GROUP_ACTION_GROUP
        public static void GetTUserGroupActionGroup()
        {
            List<MigrationData.PostgreSql.Domain.Models.TUserGroupActionGroup> data = new List<MigrationData.PostgreSql.Domain.Models.TUserGroupActionGroup>();
            List<MigrationData.Oracle.Domain.Models.TUserGroupActionGroup> data2 = new List<MigrationData.Oracle.Domain.Models.TUserGroupActionGroup>();
            List<MigrationData.Oracle.Domain.Models.TUserGroup> TUserGroups = new List<MigrationData.Oracle.Domain.Models.TUserGroup>();
            List<MigrationData.Oracle.Domain.Models.TActionGroup> TActionGroups = new List<MigrationData.Oracle.Domain.Models.TActionGroup>();
            using (var db = new MigrationData.PostgreSql.Domain.Models.DatabaseContext())
            {
                data = db.TUserGroupActionGroups.ToList();
            }

            var list = new List<MigrationData.Oracle.Domain.Models.TUserGroupActionGroup>();
            using (var db2 = new MigrationData.Oracle.Domain.Models.DatabaseContext())
            {
                data2 = db2.TUserGroupActionGroups.ToList();
                TUserGroups = db2.TUserGroups.ToList();
                TActionGroups = db2.TActionGroups.ToList();

                var count = 0;
                foreach (var item in data)
                {
                    var temp = data2.FirstOrDefault(x => x.UserGroupId == item.UserGroupId && x.ActionGroupId == item.ActionGroupId);
                    var tempUserGroup = TUserGroups.FirstOrDefault(x => x.UserGroupId == item.UserGroupId);
                    var tempActionGroup = TActionGroups.FirstOrDefault(x => x.ActionGroupId == item.ActionGroupId);
                    if (temp == null && tempUserGroup != null && tempActionGroup != null)
                    {
                        count++;
                        var model = new MigrationData.Oracle.Domain.Models.TUserGroupActionGroup
                        {
                            UserGroupActionGroupId = item.UserGroupActionGroupId,
                            UserGroupId = item.UserGroupId,
                            ActionGroupId = item.ActionGroupId,
                            IsAllowToGrant = item.IsAllowToGrant,
                            CreatedBy = item.CreatedBy,
                            CreatedAt = DateTime.Now
                        };
                        list.Add(model);
                        Console.WriteLine(count);
                    }
                }
                db2.AddRange(list);
                db2.SaveChanges();
                Console.WriteLine("Done");
            }
        }

        //T_USER_GROUP_SCOPE
        public static void GetTUserGroupScope()
        {
            List<MigrationData.PostgreSql.Domain.Models.TUserGroupScope> data = new List<TUserGroupScope>();
            using (var db = new MigrationData.PostgreSql.Domain.Models.DatabaseContext())
            {
                data = db.TUserGroupScopes.ToList();
            }

            var list = new List<MigrationData.Oracle.Domain.Models.TUserGroupScope>();
            using (var db2 = new MigrationData.Oracle.Domain.Models.DatabaseContext())
            {
                foreach (var item in data)
                {
                    var model = new MigrationData.Oracle.Domain.Models.TUserGroupScope
                    {
                        UserGroupScopeId = item.UserGroupScopeId,
                        UserGroupId = item.UserGroupId,
                        ScopeId = item.ScopeId.ToString(),
                        CreatedBy = item.CreatedBy,
                        CreatedAt = DateTime.Now
                    };
                    list.Add(model);

                }
                db2.AddRange(list);
                db2.SaveChanges();
            }
        }

        //T_USER_USER_GROUP
        public static void GetTUserUserGroup()
        {
            List<MigrationData.PostgreSql.Domain.Models.TUserUserGroup> data = new List<TUserUserGroup>();
            using (var db = new MigrationData.PostgreSql.Domain.Models.DatabaseContext())
            {
                data = db.TUserUserGroups.ToList();
            }

            var list = new List<MigrationData.Oracle.Domain.Models.TUserUserGroup>();
            using (var db2 = new MigrationData.Oracle.Domain.Models.DatabaseContext())
            {
                foreach (var item in data)
                {
                    var model = new MigrationData.Oracle.Domain.Models.TUserUserGroup
                    {
                        UserUserGroupId = item.UserUserGroupId,
                        UserGroupId = item.UserGroupId,
                        UserId = item.UserId.ToString(),
                        CreatedBy = item.CreatedBy,
                        CreatedAt = DateTime.Now
                    };
                    list.Add(model);

                }
                db2.AddRange(list);
                db2.SaveChanges();
            }
        }
    }
}
