using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MigrationData.Oracle.Domain.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BkpDm> BkpDms { get; set; }
        public virtual DbSet<Culture> Cultures { get; set; }
        public virtual DbSet<Dvhc> Dvhcs { get; set; }
        public virtual DbSet<EfmigrationsHistoryBak> EfmigrationsHistoryBaks { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<TAction> TActions { get; set; }
        public virtual DbSet<TActionActionGroup> TActionActionGroups { get; set; }
        public virtual DbSet<TActionGroup> TActionGroups { get; set; }
        public virtual DbSet<TApp> TApps { get; set; }
        public virtual DbSet<TAppModule> TAppModules { get; set; }
        public virtual DbSet<TCatalog> TCatalogs { get; set; }
        public virtual DbSet<TCatalogType> TCatalogTypes { get; set; }
        public virtual DbSet<TCustomer> TCustomers { get; set; }
        public virtual DbSet<TCustomerConfig> TCustomerConfigs { get; set; }
        public virtual DbSet<TGeometryPermi> TGeometryPermis { get; set; }
        public virtual DbSet<TGeometryPermission> TGeometryPermissions { get; set; }
        public virtual DbSet<TGeometryPermission1> TGeometryPermission1s { get; set; }
        public virtual DbSet<TModule> TModules { get; set; }
        public virtual DbSet<TPrefixUrl> TPrefixUrls { get; set; }
        public virtual DbSet<TScope> TScopes { get; set; }
        public virtual DbSet<TScopeBak> TScopeBaks { get; set; }
        public virtual DbSet<TScopeBak2> TScopeBak2s { get; set; }
        public virtual DbSet<TScopeDepartmentBak> TScopeDepartmentBaks { get; set; }
        public virtual DbSet<TUser> TUsers { get; set; }
        public virtual DbSet<TUserAdminApp> TUserAdminApps { get; set; }
        public virtual DbSet<TUserAdminScope> TUserAdminScopes { get; set; }
        public virtual DbSet<TUserGroup> TUserGroups { get; set; }
        public virtual DbSet<TUserGroupActionGroup> TUserGroupActionGroups { get; set; }
        public virtual DbSet<TUserGroupScope> TUserGroupScopes { get; set; }
        public virtual DbSet<TUserUserGroup> TUserUserGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=113.160.187.187)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=ILIS)));User Id=ILIS_SM;Password=vnlissm#125;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ILIS_SM")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<BkpDm>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BKP_DM");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Ma)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MA");

                entity.Property(e => e.Ten)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("TEN");
            });

            modelBuilder.Entity<Culture>(entity =>
            {
                entity.ToTable("CULTURE");

                entity.Property(e => e.Id)
                    .HasPrecision(10)
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasColumnName("NAME");
            });

            modelBuilder.Entity<Dvhc>(entity =>
            {
                entity.HasKey(e => e.Iddvhc)
                    .HasName("DVHC1_PK");

                entity.ToTable("DVHC");

                entity.Property(e => e.Iddvhc)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("IDDVHC")
                    .IsFixedLength(true);

                entity.Property(e => e.Mahuyen)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MAHUYEN");

                entity.Property(e => e.Matinh)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MATINH");

                entity.Property(e => e.Maxa)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MAXA");

                entity.Property(e => e.Parentid)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("PARENTID")
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasPrecision(2)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Tendvhc)
                    .HasMaxLength(150)
                    .HasColumnName("TENDVHC");
            });

            modelBuilder.Entity<EfmigrationsHistoryBak>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("__EFMigrationsHistory_BAK");

                entity.Property(e => e.MigrationId)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.ToTable("RESOURCE");

                entity.HasIndex(e => e.CultureId, "IX_RESOURCE_CultureId");

                entity.Property(e => e.Id)
                    .HasPrecision(10)
                    .HasColumnName("ID");

                entity.Property(e => e.CultureId).HasPrecision(10);

                entity.Property(e => e.Key).HasColumnName("KEY");

                entity.Property(e => e.Value).HasColumnName("VALUE");

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.CultureId);
            });

            modelBuilder.Entity<TAction>(entity =>
            {
                entity.HasKey(e => e.ActionId);

                entity.ToTable("T_ACTION");

                entity.HasIndex(e => new { e.ModuleId, e.ActionName }, "IX_T_ACTION_MODULE_ACT_NAME")
                    .IsUnique();

                entity.HasIndex(e => new { e.ModuleId, e.HttpMethod, e.Url }, "IX_T_ACT_MODID_HTTPMETHOD_URL")
                    .IsUnique();

                entity.Property(e => e.ActionId)
                    .HasPrecision(10)
                    .HasColumnName("ACTION_ID")
                    .HasDefaultValueSql("\"ILIS_SM\".\"SEQ_ACTION_ID\".\"NEXTVAL\"");

                entity.Property(e => e.ActionCode)
                    .HasMaxLength(64)
                    .HasColumnName("ACTION_CODE");

                entity.Property(e => e.ActionName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("ACTION_NAME");

                entity.Property(e => e.ControllerName)
                    .HasMaxLength(128)
                    .HasColumnName("CONTROLLER_NAME");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.HttpMethod)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("HTTP_METHOD");

                entity.Property(e => e.IsScopeRequired)
                    .HasPrecision(1)
                    .HasColumnName("IS_SCOPE_REQUIRED");

                entity.Property(e => e.IsSystem)
                    .HasPrecision(1)
                    .HasColumnName("IS_SYSTEM");

                entity.Property(e => e.ModuleId)
                    .HasPrecision(10)
                    .HasColumnName("MODULE_ID");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .HasColumnName("NOTE");

                entity.Property(e => e.SecurityLevel)
                    .HasPrecision(10)
                    .HasColumnName("SECURITY_LEVEL");

                entity.Property(e => e.Status)
                    .HasPrecision(10)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("URL");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.TActions)
                    .HasForeignKey(d => d.ModuleId);
            });

            modelBuilder.Entity<TActionActionGroup>(entity =>
            {
                entity.HasKey(e => e.ActionActionGroupId);

                entity.ToTable("T_ACTION_ACTION_GROUP");

                entity.HasIndex(e => new { e.ActionId, e.ActionGroupId }, "AK_T_ACT_ACTGRP")
                    .IsUnique();

                entity.HasIndex(e => e.ActionGroupId, "IX_T_ACT_ACTGRP_ACTGRP_ID");

                entity.Property(e => e.ActionActionGroupId)
                    .HasPrecision(10)
                    .HasColumnName("ACTION_ACTION_GROUP_ID")
                    .HasDefaultValueSql("\"ILIS_SM\".\"SEQ_ACTIONACTIONGROUP_ID\".\"NEXTVAL\"");

                entity.Property(e => e.ActionGroupId)
                    .HasPrecision(10)
                    .HasColumnName("ACTION_GROUP_ID");

                entity.Property(e => e.ActionId)
                    .HasPrecision(10)
                    .HasColumnName("ACTION_ID")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.HasOne(d => d.ActionGroup)
                    .WithMany(p => p.TActionActionGroups)
                    .HasForeignKey(d => d.ActionGroupId)
                    .HasConstraintName("FK_T_ACT_ACTGRP_T_ACTGRP");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.TActionActionGroups)
                    .HasForeignKey(d => d.ActionId)
                    .HasConstraintName("FK_T_ACT_ACTGRP_T_ACT");
            });

            modelBuilder.Entity<TActionGroup>(entity =>
            {
                entity.HasKey(e => e.ActionGroupId);

                entity.ToTable("T_ACTION_GROUP");

                entity.HasIndex(e => e.ActionGroupCode, "IX_T_ACTGRP_ACTGRP_CODE")
                    .IsUnique();

                entity.HasIndex(e => e.ActionGroupName, "IX_T_ACTGRP_ACTGRP_NAME")
                    .IsUnique();

                entity.HasIndex(e => e.ModuleId, "IX_T_ACTION_GROUP_MODULE_ID");

                entity.Property(e => e.ActionGroupId)
                    .HasPrecision(10)
                    .HasColumnName("ACTION_GROUP_ID")
                    .HasDefaultValueSql("\"ILIS_SM\".\"SEQ_ACTIONGROUP_ID\".\"NEXTVAL\"");

                entity.Property(e => e.ActionGroupCode)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("ACTION_GROUP_CODE");

                entity.Property(e => e.ActionGroupName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("ACTION_GROUP_NAME");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.IsSystem)
                    .HasPrecision(1)
                    .HasColumnName("IS_SYSTEM");

                entity.Property(e => e.ModuleId)
                    .HasPrecision(10)
                    .HasColumnName("MODULE_ID");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .HasColumnName("NOTE");

                entity.Property(e => e.Status)
                    .HasPrecision(10)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.TActionGroups)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("FK_T_ACTION_GROUP_T_MODULE");
            });

            modelBuilder.Entity<TApp>(entity =>
            {
                entity.HasKey(e => e.AppId);

                entity.ToTable("T_APP");

                entity.Property(e => e.AppId)
                    .HasPrecision(10)
                    .HasColumnName("APP_ID")
                    .HasDefaultValueSql("\"ILIS_SM\".\"SEQ_APP_ID\".\"NEXTVAL\"");

                entity.Property(e => e.AppCode)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("APP_CODE");

                entity.Property(e => e.AppName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("APP_NAME");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.IsSystem)
                    .HasPrecision(1)
                    .HasColumnName("IS_SYSTEM");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .HasColumnName("NOTE");

                entity.Property(e => e.Status)
                    .HasPrecision(10)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");
            });

            modelBuilder.Entity<TAppModule>(entity =>
            {
                entity.HasKey(e => e.AppModuleId);

                entity.ToTable("T_APP_MODULE");

                entity.HasIndex(e => new { e.AppId, e.ModuleId }, "AK_T_APP_MODULE")
                    .IsUnique();

                entity.HasIndex(e => e.ModuleId, "IX_T_APP_MODULE_MODULE_ID");

                entity.Property(e => e.AppModuleId)
                    .HasPrecision(10)
                    .HasColumnName("APP_MODULE_ID")
                    .HasDefaultValueSql("\"ILIS_SM\".\"SEQ_APPMODULE_ID\".\"NEXTVAL\"");

                entity.Property(e => e.AppId)
                    .HasPrecision(10)
                    .HasColumnName("APP_ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.ModuleId)
                    .HasPrecision(10)
                    .HasColumnName("MODULE_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.HasOne(d => d.App)
                    .WithMany(p => p.TAppModules)
                    .HasForeignKey(d => d.AppId);

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.TAppModules)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("FK_T_APP_MODULE_MODULE_ID");
            });

            modelBuilder.Entity<TCatalog>(entity =>
            {
                entity.HasKey(e => e.CatalogId);

                entity.ToTable("T_CATALOG");

                entity.HasIndex(e => e.CatalogTypeId, "IX_T_CATALOG_CATALOG_TYPE_ID");

                entity.Property(e => e.CatalogId)
                    .HasPrecision(10)
                    .HasColumnName("CATALOG_ID");

                entity.Property(e => e.CatalogName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("CATALOG_NAME");

                entity.Property(e => e.CatalogTypeId)
                    .HasPrecision(10)
                    .HasColumnName("CATALOG_TYPE_ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.IsSystem)
                    .HasPrecision(1)
                    .HasColumnName("IS_SYSTEM");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .HasColumnName("NOTE");

                entity.Property(e => e.OrderHint)
                    .HasPrecision(3)
                    .HasColumnName("ORDER_HINT");

                entity.Property(e => e.Status)
                    .HasPrecision(10)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.HasOne(d => d.CatalogType)
                    .WithMany(p => p.TCatalogs)
                    .HasForeignKey(d => d.CatalogTypeId)
                    .HasConstraintName("FK_T_CATALOG_T_CATALOG_TYPE");
            });

            modelBuilder.Entity<TCatalogType>(entity =>
            {
                entity.HasKey(e => e.CatalogTypeId);

                entity.ToTable("T_CATALOG_TYPE");

                entity.Property(e => e.CatalogTypeId)
                    .HasPrecision(10)
                    .HasColumnName("CATALOG_TYPE_ID");

                entity.Property(e => e.CatalogName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("CATALOG_NAME");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");
            });

            modelBuilder.Entity<TCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("T_CUSTOMER");

                entity.HasIndex(e => e.CustomerCode, "IX_T_CUSTOMER_CUSTOMER_CODE")
                    .IsUnique();

                entity.HasIndex(e => e.CustomerName, "IX_T_CUSTOMER_CUSTOMER_NAME")
                    .IsUnique();

                entity.Property(e => e.CustomerId)
                    .HasPrecision(10)
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CustomerCode)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("CUSTOMER_CODE");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("CUSTOMER_NAME");

                entity.Property(e => e.IsSystem)
                    .HasPrecision(1)
                    .HasColumnName("IS_SYSTEM");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .HasColumnName("NOTE");

                entity.Property(e => e.Status)
                    .HasPrecision(10)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");
            });

            modelBuilder.Entity<TCustomerConfig>(entity =>
            {
                entity.HasKey(e => e.CustomerConfigId);

                entity.ToTable("T_CUSTOMER_CONFIG");

                entity.HasIndex(e => e.AppId, "IX_T_CUSTOMER_CONFIG_APP_ID");

                entity.Property(e => e.CustomerConfigId)
                    .HasPrecision(10)
                    .HasColumnName("CUSTOMER_CONFIG_ID")
                    .HasDefaultValueSql("\"ILIS_SM\".\"SEQ_CUSTOMERCONFIG_ID\".\"NEXTVAL\"");

                entity.Property(e => e.AppId)
                    .HasPrecision(10)
                    .HasColumnName("APP_ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.GiaTri)
                    .IsRequired()
                    .HasColumnName("GIA_TRI");

                entity.Property(e => e.MaTinh)
                    .IsRequired()
                    .HasColumnName("MA_TINH");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.HasOne(d => d.App)
                    .WithMany(p => p.TCustomerConfigs)
                    .HasForeignKey(d => d.AppId)
                    .HasConstraintName("FK_T_CUS_CONFIG_T_APP");
            });

            modelBuilder.Entity<TGeometryPermi>(entity =>
            {
                entity.HasKey(e => e.IdGeoPermission)
                    .HasName("SYS_C007624");

                entity.ToTable("T_GEOMETRY_PERMIS");

                entity.Property(e => e.IdGeoPermission)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID_GEO_PERMISSION");

                entity.Property(e => e.IdVung)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ID_VUNG");

                entity.Property(e => e.Mahuyen)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MAHUYEN");

                entity.Property(e => e.Matinh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MATINH");

                entity.Property(e => e.Maxa)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MAXA");

                entity.Property(e => e.PhuongXa)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("PHUONG_XA");

                entity.Property(e => e.QuanHuyen)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("QUAN_HUYEN");

                entity.Property(e => e.Tenhuyenkodau)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TENHUYENKODAU");

                entity.Property(e => e.TinhThanhpho)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("TINH_THANHPHO");

                entity.Property(e => e.Wkt)
                    .HasColumnType("NCLOB")
                    .HasColumnName("WKT");
            });

            modelBuilder.Entity<TGeometryPermission>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_GEOMETRY_PERMISSION");

                entity.HasIndex(e => e.IdGeoPermission, "BIN$u6hiOAeETriwzLFzYtBVqQ==$0")
                    .IsUnique();

                entity.Property(e => e.IdGeoPermission)
                    .HasPrecision(10)
                    .HasColumnName("ID_GEO_PERMISSION")
                    .HasDefaultValueSql("\"ILIS_SM\".\"SEQ_ID_GEO_PERMISSION\".\"NEXTVAL\"");

                entity.Property(e => e.PhuongXa)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("PHUONG_XA");

                entity.Property(e => e.QuanHuyen)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("QUAN_HUYEN");

                entity.Property(e => e.TinhThanhpho)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("TINH_THANHPHO");
            });

            modelBuilder.Entity<TGeometryPermission1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_GEOMETRY_PERMISSION1");

                entity.HasIndex(e => e.IdGeoPermission, "BIN$MSkryH0bRiyQUA8YqcP1Gg==$0")
                    .IsUnique();

                entity.Property(e => e.IdGeoPermission)
                    .HasPrecision(10)
                    .HasColumnName("ID_GEO_PERMISSION")
                    .HasDefaultValueSql("\"ILIS_SM\".\"SEQ_ID_GEO_PERMISSION\".\"NEXTVAL\"");

                entity.Property(e => e.IdVung)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ID_VUNG");

                entity.Property(e => e.Mahuyen)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MAHUYEN");

                entity.Property(e => e.Matinh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MATINH");

                entity.Property(e => e.Maxa)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MAXA");

                entity.Property(e => e.PhuongXa)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("PHUONG_XA");

                entity.Property(e => e.QuanHuyen)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("QUAN_HUYEN");

                entity.Property(e => e.Tenhuyenkodau)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TENHUYENKODAU");

                entity.Property(e => e.TinhThanhpho)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("TINH_THANHPHO");

                entity.Property(e => e.Wkt)
                    .HasColumnType("NCLOB")
                    .HasColumnName("WKT");
            });

            modelBuilder.Entity<TModule>(entity =>
            {
                entity.HasKey(e => e.ModuleId);

                entity.ToTable("T_MODULE");

                entity.HasIndex(e => e.ModuleCode, "IX_T_MODULE_MODULE_CODE")
                    .IsUnique();

                entity.HasIndex(e => e.ModuleName, "IX_T_MODULE_MODULE_NAME")
                    .IsUnique();

                entity.Property(e => e.ModuleId)
                    .HasPrecision(10)
                    .HasColumnName("MODULE_ID")
                    .HasDefaultValueSql("\"ILIS_SM\".\"SEQ_MODULE_ID\".\"NEXTVAL\"");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.IsSystem)
                    .HasPrecision(1)
                    .HasColumnName("IS_SYSTEM");

                entity.Property(e => e.ModuleCode)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("MODULE_CODE");

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("MODULE_NAME");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .HasColumnName("NOTE");

                entity.Property(e => e.Status)
                    .HasPrecision(10)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");
            });

            modelBuilder.Entity<TPrefixUrl>(entity =>
            {
                entity.HasKey(e => e.PrefixUrlId);

                entity.ToTable("T_PREFIX_URL");

                entity.HasIndex(e => e.ModuleId, "IX_T_PREFIX_URL_MODULE_ID");

                entity.Property(e => e.PrefixUrlId)
                    .HasPrecision(10)
                    .HasColumnName("PREFIX_URL_ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.ModuleId)
                    .HasPrecision(10)
                    .HasColumnName("MODULE_ID");

                entity.Property(e => e.PrefixUrl)
                    .IsRequired()
                    .HasColumnName("PREFIX_URL");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.TPrefixUrls)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("FK_T_PREFIX_URL_T_MODULE");
            });

            modelBuilder.Entity<TScope>(entity =>
            {
                entity.HasKey(e => e.ScopeId);

                entity.ToTable("T_SCOPE");

                entity.HasIndex(e => new { e.CustomerId, e.ScopeType, e.ScopeCode }, "IX_T_SCOPE_CUSID_TYPE_CODE")
                    .IsUnique();

                entity.HasIndex(e => new { e.AppCode, e.ScopeLevel, e.OriginCategoryId }, "IX_T_SCOPE_MC_LV_ORG_CAT_ID");

                entity.HasIndex(e => new { e.AppCode, e.ScopeLevel, e.ScopeCode }, "IX_T_SCOPE_MC_LV_SC");

                entity.HasIndex(e => e.ParentScopeId, "IX_T_SCOPE_PARENT_SCOPE_ID");

                entity.Property(e => e.ScopeId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("SCOPE_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.AppCode)
                    .HasMaxLength(32)
                    .HasColumnName("APP_CODE");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CustomerId)
                    .HasPrecision(10)
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.Discriminator).IsRequired();

                entity.Property(e => e.ImportedParentScopeId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("IMPORTED_PARENT_SCOPE_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.IsSystem)
                    .HasPrecision(1)
                    .HasColumnName("IS_SYSTEM");

                entity.Property(e => e.MaHuyen)
                    .HasMaxLength(16)
                    .HasColumnName("MA_HUYEN");

                entity.Property(e => e.MaTinh).HasColumnName("MA_TINH");

                entity.Property(e => e.MaXa).HasColumnName("MA_XA");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .HasColumnName("NOTE");

                entity.Property(e => e.OriginCategoryId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ORIGIN_CATEGORY_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.ParentScopeId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("PARENT_SCOPE_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.Path)
                    .HasMaxLength(512)
                    .HasColumnName("PATH");

                entity.Property(e => e.ScopeCode)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("SCOPE_CODE");

                entity.Property(e => e.ScopeLevel)
                    .HasPrecision(3)
                    .HasColumnName("SCOPE_LEVEL");

                entity.Property(e => e.ScopeName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("SCOPE_NAME");

                entity.Property(e => e.ScopeType)
                    .HasPrecision(10)
                    .HasColumnName("SCOPE_TYPE");

                entity.Property(e => e.Status)
                    .HasPrecision(10)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TScopes)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_T_SCOPE_T_CUSTOMER");

                entity.HasOne(d => d.ParentScope)
                    .WithMany(p => p.InverseParentScope)
                    .HasForeignKey(d => d.ParentScopeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_T_SCOPE_T_SCOPE");
            });

            modelBuilder.Entity<TScopeBak>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_SCOPE_BAK");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CustomerId)
                    .HasPrecision(10)
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.Discriminator).IsRequired();

                entity.Property(e => e.ImportedParentScopeId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("IMPORTED_PARENT_SCOPE_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.IsSystem)
                    .HasPrecision(1)
                    .HasColumnName("IS_SYSTEM");

                entity.Property(e => e.MaHuyen)
                    .HasMaxLength(16)
                    .HasColumnName("MA_HUYEN");

                entity.Property(e => e.MaTinh)
                    .HasMaxLength(16)
                    .HasColumnName("MA_TINH");

                entity.Property(e => e.MaXa)
                    .HasMaxLength(16)
                    .HasColumnName("MA_XA");

                entity.Property(e => e.ModuleCode)
                    .HasMaxLength(32)
                    .HasColumnName("MODULE_CODE");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .HasColumnName("NOTE");

                entity.Property(e => e.OriginCategoryId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ORIGIN_CATEGORY_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.ParentScopeId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("PARENT_SCOPE_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.Path)
                    .HasMaxLength(512)
                    .HasColumnName("PATH");

                entity.Property(e => e.ScopeCode)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("SCOPE_CODE");

                entity.Property(e => e.ScopeId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("SCOPE_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.ScopeLevel)
                    .HasPrecision(3)
                    .HasColumnName("SCOPE_LEVEL");

                entity.Property(e => e.ScopeName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("SCOPE_NAME");

                entity.Property(e => e.ScopeType)
                    .HasPrecision(10)
                    .HasColumnName("SCOPE_TYPE");

                entity.Property(e => e.Status)
                    .HasPrecision(10)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");
            });

            modelBuilder.Entity<TScopeBak2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_SCOPE_BAK2");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CustomerId)
                    .HasPrecision(10)
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.Discriminator).IsRequired();

                entity.Property(e => e.ImportedParentScopeId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("IMPORTED_PARENT_SCOPE_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.IsSystem)
                    .HasPrecision(1)
                    .HasColumnName("IS_SYSTEM");

                entity.Property(e => e.MaHuyen)
                    .HasMaxLength(16)
                    .HasColumnName("MA_HUYEN");

                entity.Property(e => e.MaTinh)
                    .HasMaxLength(16)
                    .HasColumnName("MA_TINH");

                entity.Property(e => e.MaXa)
                    .HasMaxLength(16)
                    .HasColumnName("MA_XA");

                entity.Property(e => e.ModuleCode)
                    .HasMaxLength(32)
                    .HasColumnName("MODULE_CODE");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .HasColumnName("NOTE");

                entity.Property(e => e.OriginCategoryId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ORIGIN_CATEGORY_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.ParentScopeId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("PARENT_SCOPE_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.Path)
                    .HasMaxLength(512)
                    .HasColumnName("PATH");

                entity.Property(e => e.ScopeCode)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("SCOPE_CODE");

                entity.Property(e => e.ScopeId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("SCOPE_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.ScopeLevel)
                    .HasPrecision(3)
                    .HasColumnName("SCOPE_LEVEL");

                entity.Property(e => e.ScopeName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("SCOPE_NAME");

                entity.Property(e => e.ScopeType)
                    .HasPrecision(10)
                    .HasColumnName("SCOPE_TYPE");

                entity.Property(e => e.Status)
                    .HasPrecision(10)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");
            });

            modelBuilder.Entity<TScopeDepartmentBak>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_SCOPE_DEPARTMENT_BAK");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CustomerId)
                    .HasPrecision(10)
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.Discriminator).IsRequired();

                entity.Property(e => e.ImportedParentScopeId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("IMPORTED_PARENT_SCOPE_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.IsSystem)
                    .HasPrecision(1)
                    .HasColumnName("IS_SYSTEM");

                entity.Property(e => e.MaHuyen)
                    .HasMaxLength(16)
                    .HasColumnName("MA_HUYEN");

                entity.Property(e => e.MaTinh)
                    .HasMaxLength(16)
                    .HasColumnName("MA_TINH");

                entity.Property(e => e.MaXa)
                    .HasMaxLength(16)
                    .HasColumnName("MA_XA");

                entity.Property(e => e.ModuleCode)
                    .HasMaxLength(32)
                    .HasColumnName("MODULE_CODE");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .HasColumnName("NOTE");

                entity.Property(e => e.OriginCategoryId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ORIGIN_CATEGORY_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.ParentScopeId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("PARENT_SCOPE_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.Path)
                    .HasMaxLength(512)
                    .HasColumnName("PATH");

                entity.Property(e => e.ScopeCode)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("SCOPE_CODE");

                entity.Property(e => e.ScopeId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("SCOPE_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.ScopeLevel)
                    .HasPrecision(3)
                    .HasColumnName("SCOPE_LEVEL");

                entity.Property(e => e.ScopeName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("SCOPE_NAME");

                entity.Property(e => e.ScopeType)
                    .HasPrecision(10)
                    .HasColumnName("SCOPE_TYPE");

                entity.Property(e => e.Status)
                    .HasPrecision(10)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");
            });

            modelBuilder.Entity<TUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("T_USER");

                entity.HasIndex(e => new { e.CustomerId, e.UserName }, "IX_T_USER_CUSID_USERNAME")
                    .IsUnique();

                entity.HasIndex(e => e.DeptId, "IX_T_USER_DEPT_ID");

                entity.Property(e => e.UserId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("USER_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CustomerId)
                    .HasPrecision(10)
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.DeptId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("DEPT_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(32)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FullName)
                    .HasMaxLength(128)
                    .HasColumnName("FULL_NAME");

                entity.Property(e => e.IdDichVuCong)
                    .HasPrecision(10)
                    .HasColumnName("ID_DICH_VU_CONG");

                entity.Property(e => e.IsSystem)
                    .HasPrecision(1)
                    .HasColumnName("IS_SYSTEM");

                entity.Property(e => e.Maketnoi)
                    .HasPrecision(10)
                    .HasColumnName("MAKETNOI");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .HasColumnName("NOTE");

                entity.Property(e => e.Phone)
                    .HasMaxLength(16)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Status)
                    .HasPrecision(10)
                    .HasColumnName("STATUS");

                entity.Property(e => e.TechnicalId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("TECHNICAL_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.Title)
                    .HasMaxLength(128)
                    .HasColumnName("TITLE");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UserCode)
                    .HasMaxLength(32)
                    .HasColumnName("USER_CODE");

                entity.Property(e => e.UserLevel)
                    .HasPrecision(10)
                    .HasColumnName("USER_LEVEL");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("USER_NAME");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TUsers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_T_USER_T_CUSTOMER");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.TUsers)
                    .HasForeignKey(d => d.DeptId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TUserAdminApp>(entity =>
            {
                entity.HasKey(e => e.UserAdminAppId);

                entity.ToTable("T_USER_ADMIN_APP");

                entity.HasIndex(e => e.AppId, "IX_T_USER_ADMIN_APP_APP_ID");

                entity.HasIndex(e => e.UserId, "IX_T_USER_ADMIN_APP_USER_ID");

                entity.Property(e => e.UserAdminAppId)
                    .HasPrecision(10)
                    .HasColumnName("USER_ADMIN_APP_ID")
                    .HasDefaultValueSql("\"ILIS_SM\".\"SEQ_USERADMINAPP_ID\".\"NEXTVAL\"");

                entity.Property(e => e.AppId)
                    .HasPrecision(10)
                    .HasColumnName("APP_ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("USER_ID")
                    .IsFixedLength(true);

                entity.HasOne(d => d.App)
                    .WithMany(p => p.TUserAdminApps)
                    .HasForeignKey(d => d.AppId)
                    .HasConstraintName("FK_T_USER_ADMIN_APP_APP_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TUserAdminApps)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_T_USER_ADMIN_APP_USER_ID");
            });

            modelBuilder.Entity<TUserAdminScope>(entity =>
            {
                entity.HasKey(e => e.UserAdminScopeId);

                entity.ToTable("T_USER_ADMIN_SCOPE");

                entity.HasIndex(e => new { e.UserId, e.ScopeId }, "AK_T_USER_ADMIN_SCOPE")
                    .IsUnique();

                entity.HasIndex(e => e.ScopeId, "IX_T_USER_AD_SCOPE_SCOPE_ID");

                entity.HasIndex(e => e.UserId, "IX_T_USER_AD_SCOPE_USER_ID");

                entity.Property(e => e.UserAdminScopeId)
                    .HasPrecision(10)
                    .HasColumnName("USER_ADMIN_SCOPE_ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.ScopeId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("SCOPE_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("USER_ID")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Scope)
                    .WithMany(p => p.TUserAdminScopes)
                    .HasForeignKey(d => d.ScopeId)
                    .HasConstraintName("FK_T_USER_ADMIN_SCOPE_T_SCOPE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TUserAdminScopes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_T_USER_ADMIN_SCOPE_T_USER");
            });

            modelBuilder.Entity<TUserGroup>(entity =>
            {
                entity.HasKey(e => e.UserGroupId);

                entity.ToTable("T_USER_GROUP");

                entity.HasIndex(e => e.AdminByAppId, "IX_T_UG_ADMIN_BY_APP_ID");

                entity.HasIndex(e => e.AdminByScopeId, "IX_T_USER_GROUP_SCOPE_ID");

                entity.HasIndex(e => new { e.CustomerId, e.UserGroupCode }, "IX_T_USRGRP_CUSID_USRGRPCODE")
                    .IsUnique();

                entity.HasIndex(e => new { e.CustomerId, e.UserGroupName }, "IX_T_USRGRP_CUSID_USRGRPNAME")
                    .IsUnique();

                entity.Property(e => e.UserGroupId)
                    .HasPrecision(10)
                    .HasColumnName("USER_GROUP_ID")
                    .HasDefaultValueSql("\"ILIS_SM\".\"SEQ_USERGROUP_ID\".\"NEXTVAL\"");

                entity.Property(e => e.AdminByAppId)
                    .HasPrecision(10)
                    .HasColumnName("ADMIN_BY_APP_ID")
                    .HasDefaultValueSql("0\n   ");

                entity.Property(e => e.AdminByScopeId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ADMIN_BY_SCOPE_ID")
                    .HasDefaultValueSql("NULL")
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CustomerId)
                    .HasPrecision(10)
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.IsSystem)
                    .HasPrecision(1)
                    .HasColumnName("IS_SYSTEM");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .HasColumnName("NOTE");

                entity.Property(e => e.Status)
                    .HasPrecision(10)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UserGroupCode)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("USER_GROUP_CODE");

                entity.Property(e => e.UserGroupName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("USER_GROUP_NAME");

                entity.HasOne(d => d.AdminByApp)
                    .WithMany(p => p.TUserGroups)
                    .HasForeignKey(d => d.AdminByAppId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_T_USER_GROUP_APP_ID");

                entity.HasOne(d => d.AdminByScope)
                    .WithMany(p => p.TUserGroups)
                    .HasForeignKey(d => d.AdminByScopeId)
                    .HasConstraintName("FK_T_USER_GROUP_T_SCOPE");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TUserGroups)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_T_USER_GROUP_T_CUSTOMER");
            });

            modelBuilder.Entity<TUserGroupActionGroup>(entity =>
            {
                entity.HasKey(e => e.UserGroupActionGroupId);

                entity.ToTable("T_USER_GROUP_ACTION_GROUP");

                entity.HasIndex(e => new { e.UserGroupId, e.ActionGroupId }, "AK_T_USRGRP_ACTGRP")
                    .IsUnique();

                entity.HasIndex(e => e.ActionGroupId, "IX_T_USRGRP_ACTGRP_ACTGRP_ID");

                entity.Property(e => e.UserGroupActionGroupId)
                    .HasPrecision(10)
                    .HasColumnName("USER_GROUP_ACTION_GROUP_ID")
                    .HasDefaultValueSql("\"ILIS_SM\".\"SEQ_USERGROUPACTIONGROUP_ID\".\"NEXTVAL\"");

                entity.Property(e => e.ActionGroupId)
                    .HasPrecision(10)
                    .HasColumnName("ACTION_GROUP_ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.IsAllowToGrant)
                    .HasPrecision(1)
                    .HasColumnName("IS_ALLOW_TO_GRANT");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UserGroupId)
                    .HasPrecision(10)
                    .HasColumnName("USER_GROUP_ID");

                entity.HasOne(d => d.ActionGroup)
                    .WithMany(p => p.TUserGroupActionGroups)
                    .HasForeignKey(d => d.ActionGroupId)
                    .HasConstraintName("FK_T_USRGRP_ACTGRP_T_ACTGRP");

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.TUserGroupActionGroups)
                    .HasForeignKey(d => d.UserGroupId)
                    .HasConstraintName("FK_T_USRGRP_ACTGRP_T_USRGRP");
            });

            modelBuilder.Entity<TUserGroupScope>(entity =>
            {
                entity.HasKey(e => e.UserGroupScopeId);

                entity.ToTable("T_USER_GROUP_SCOPE");

                entity.HasIndex(e => new { e.UserGroupId, e.ScopeId }, "AK_T_USRGRP_SCOPE")
                    .IsUnique();

                entity.HasIndex(e => e.ScopeId, "IX_T_USER_GROUP_SCOPE_SCOPE_ID");

                entity.Property(e => e.UserGroupScopeId)
                    .HasPrecision(10)
                    .HasColumnName("USER_GROUP_SCOPE_ID")
                    .HasDefaultValueSql("\"ILIS_SM\".\"SEQ_USERGROUPSCOPE_ID\".\"NEXTVAL\"");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.ScopeId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("SCOPE_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UserGroupId)
                    .HasPrecision(10)
                    .HasColumnName("USER_GROUP_ID");

                entity.HasOne(d => d.Scope)
                    .WithMany(p => p.TUserGroupScopes)
                    .HasForeignKey(d => d.ScopeId)
                    .HasConstraintName("FK_T_USRGRP_SCOPE_T_SCOPE");

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.TUserGroupScopes)
                    .HasForeignKey(d => d.UserGroupId)
                    .HasConstraintName("FK_T_USRGRP_SCOPE_T_USRGRP");
            });

            modelBuilder.Entity<TUserUserGroup>(entity =>
            {
                entity.HasKey(e => e.UserUserGroupId);

                entity.ToTable("T_USER_USER_GROUP");

                entity.HasIndex(e => new { e.UserId, e.UserGroupId }, "AK_T_USR_USRGRP")
                    .IsUnique();

                entity.HasIndex(e => e.UserGroupId, "IX_T_USR_USRGRP_USRGRP_ID");

                entity.Property(e => e.UserUserGroupId)
                    .HasPrecision(10)
                    .HasColumnName("USER_USER_GROUP_ID")
                    .HasDefaultValueSql("\"ILIS_SM\".\"SEQ_USERUSERGROUP_ID\".\"NEXTVAL\"");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(7)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(7)
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UserGroupId)
                    .HasPrecision(10)
                    .HasColumnName("USER_GROUP_ID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("USER_ID")
                    .IsFixedLength(true);

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.TUserUserGroups)
                    .HasForeignKey(d => d.UserGroupId)
                    .HasConstraintName("FK_T_USR_USRGRP_T_USRGRP");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TUserUserGroups)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_T_USR_USRGRP_T_USR");
            });

            modelBuilder.HasSequence("ID_GEO_PERMISSION");

            modelBuilder.HasSequence("ILIS_SM.SEQ_T_PREFIX_ID");

            modelBuilder.HasSequence("SEQ_ACTION_ID");

            modelBuilder.HasSequence("SEQ_ACTIONACTIONGROUP_ID");

            modelBuilder.HasSequence("SEQ_ACTIONGROUP_ID");

            modelBuilder.HasSequence("SEQ_APP_ID");

            modelBuilder.HasSequence("SEQ_APPMODULE_ID");

            modelBuilder.HasSequence("SEQ_CUSTOMERCONFIG_ID");

            modelBuilder.HasSequence("SEQ_ID_GEO_PERMISSION");

            modelBuilder.HasSequence("SEQ_MODULE_ID");

            modelBuilder.HasSequence("SEQ_PREFIX_URL");

            modelBuilder.HasSequence("SEQ_USERADMINAPP_ID");

            modelBuilder.HasSequence("SEQ_USERGROUP_ID");

            modelBuilder.HasSequence("SEQ_USERGROUPACTIONGROUP_ID");

            modelBuilder.HasSequence("SEQ_USERGROUPSCOPE_ID");

            modelBuilder.HasSequence("SEQ_USERUSERGROUP_ID");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
