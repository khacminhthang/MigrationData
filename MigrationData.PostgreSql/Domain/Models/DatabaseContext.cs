using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MigrationData.PostgreSql.Domain.Models
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

        public virtual DbSet<ApiClaim> ApiClaims { get; set; }
        public virtual DbSet<ApiProperty> ApiProperties { get; set; }
        public virtual DbSet<ApiResource> ApiResources { get; set; }
        public virtual DbSet<ApiScope> ApiScopes { get; set; }
        public virtual DbSet<ApiScopeClaim> ApiScopeClaims { get; set; }
        public virtual DbSet<ApiSecret> ApiSecrets { get; set; }
        public virtual DbSet<ApplicationConfiguration> ApplicationConfigurations { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientClaim> ClientClaims { get; set; }
        public virtual DbSet<ClientCorsOrigin> ClientCorsOrigins { get; set; }
        public virtual DbSet<ClientGrantType> ClientGrantTypes { get; set; }
        public virtual DbSet<ClientIdPrestriction> ClientIdPrestrictions { get; set; }
        public virtual DbSet<ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris { get; set; }
        public virtual DbSet<ClientProperty> ClientProperties { get; set; }
        public virtual DbSet<ClientRedirectUri> ClientRedirectUris { get; set; }
        public virtual DbSet<ClientScope> ClientScopes { get; set; }
        public virtual DbSet<ClientSecret> ClientSecrets { get; set; }
        public virtual DbSet<Culture> Cultures { get; set; }
        public virtual DbSet<DeviceCode> DeviceCodes { get; set; }
        public virtual DbSet<IdentityClaim> IdentityClaims { get; set; }
        public virtual DbSet<IdentityProperty> IdentityProperties { get; set; }
        public virtual DbSet<IdentityResource> IdentityResources { get; set; }
        public virtual DbSet<OtpUser> OtpUsers { get; set; }
        public virtual DbSet<PersistedGrant> PersistedGrants { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<TAction> TActions { get; set; }
        public virtual DbSet<TActionActionGroup> TActionActionGroups { get; set; }
        public virtual DbSet<TActionGroup> TActionGroups { get; set; }
        public virtual DbSet<TApp> TApps { get; set; }
        public virtual DbSet<TAppModule> TAppModules { get; set; }
        public virtual DbSet<TCatalog> TCatalogs { get; set; }
        public virtual DbSet<TCatalogType> TCatalogTypes { get; set; }
        public virtual DbSet<TCustomer> TCustomers { get; set; }
        public virtual DbSet<TLog> TLogs { get; set; }
        public virtual DbSet<TModule> TModules { get; set; }
        public virtual DbSet<TPrefixUrl> TPrefixUrls { get; set; }
        public virtual DbSet<TScope> TScopes { get; set; }
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
                optionsBuilder.UseNpgsql("Host=10.163.15.220;Port=5432;Database=inres_sys_manager;Username=postgres;Password=admin@123", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<ApiClaim>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId, "IX_ApiClaims_ApiResourceId");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiClaims)
                    .HasForeignKey(d => d.ApiResourceId);
            });

            modelBuilder.Entity<ApiProperty>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId, "IX_ApiProperties_ApiResourceId");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiProperties)
                    .HasForeignKey(d => d.ApiResourceId);
            });

            modelBuilder.Entity<ApiResource>(entity =>
            {
                entity.HasIndex(e => e.Name, "IX_ApiResources_Name")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DisplayName).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ApiScope>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId, "IX_ApiScopes_ApiResourceId");

                entity.HasIndex(e => e.Name, "IX_ApiScopes_Name")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DisplayName).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiScopes)
                    .HasForeignKey(d => d.ApiResourceId);
            });

            modelBuilder.Entity<ApiScopeClaim>(entity =>
            {
                entity.HasIndex(e => e.ApiScopeId, "IX_ApiScopeClaims_ApiScopeId");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.ApiScope)
                    .WithMany(p => p.ApiScopeClaims)
                    .HasForeignKey(d => d.ApiScopeId);
            });

            modelBuilder.Entity<ApiSecret>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId, "IX_ApiSecrets_ApiResourceId");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiSecrets)
                    .HasForeignKey(d => d.ApiResourceId);
            });

            modelBuilder.Entity<ApplicationConfiguration>(entity =>
            {
                entity.HasKey(e => e.Key);
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.CustomerId, "IX_AspNetUsers_CUSTOMER_ID");

                entity.HasIndex(e => e.DeptId, "IX_AspNetUsers_DEPT_ID");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.DeptId).HasColumnName("DEPT_ID");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasMaxLength(250);

                entity.Property(e => e.LastName).HasMaxLength(250);

                entity.Property(e => e.LockoutEnd).HasColumnType("timestamp with time zone");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.TechnicalId)
                    .HasMaxLength(36)
                    .HasColumnName("TECHNICAL_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.UserCode)
                    .HasMaxLength(32)
                    .HasColumnName("USER_CODE");

                entity.Property(e => e.UserLevel).HasColumnName("USER_LEVEL");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_Clients_ClientId")
                    .IsUnique();

                entity.Property(e => e.BackChannelLogoutUri).HasMaxLength(2000);

                entity.Property(e => e.ClientClaimsPrefix).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ClientName).HasMaxLength(200);

                entity.Property(e => e.ClientUri).HasMaxLength(2000);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.FrontChannelLogoutUri).HasMaxLength(2000);

                entity.Property(e => e.LogoUri).HasMaxLength(2000);

                entity.Property(e => e.PairWiseSubjectSalt).HasMaxLength(200);

                entity.Property(e => e.ProtocolType)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UserCodeType).HasMaxLength(100);
            });

            modelBuilder.Entity<ClientClaim>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientClaims_ClientId");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientClaims)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientCorsOrigin>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientCorsOrigins_ClientId");

                entity.Property(e => e.Origin)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientCorsOrigins)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientGrantType>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientGrantTypes_ClientId");

                entity.Property(e => e.GrantType)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientGrantTypes)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientIdPrestriction>(entity =>
            {
                entity.ToTable("ClientIdPRestrictions");

                entity.HasIndex(e => e.ClientId, "IX_ClientIdPRestrictions_ClientId");

                entity.Property(e => e.Provider)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientIdPrestrictions)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientPostLogoutRedirectUri>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientPostLogoutRedirectUris_ClientId");

                entity.Property(e => e.PostLogoutRedirectUri)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientPostLogoutRedirectUris)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientProperty>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientProperties_ClientId");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientProperties)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientRedirectUri>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientRedirectUris_ClientId");

                entity.Property(e => e.RedirectUri)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientRedirectUris)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientScope>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientScopes_ClientId");

                entity.Property(e => e.Scope)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientScopes)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientSecret>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientSecrets_ClientId");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientSecrets)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<Culture>(entity =>
            {
                entity.ToTable("CULTURE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasColumnName("NAME");
            });

            modelBuilder.Entity<DeviceCode>(entity =>
            {
                entity.HasKey(e => e.UserCode);

                entity.HasIndex(e => e.DeviceCode1, "IX_DeviceCodes_DeviceCode")
                    .IsUnique();

                entity.HasIndex(e => e.Expiration, "IX_DeviceCodes_Expiration");

                entity.Property(e => e.UserCode).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasMaxLength(50000);

                entity.Property(e => e.DeviceCode1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("DeviceCode");

                entity.Property(e => e.SubjectId).HasMaxLength(200);
            });

            modelBuilder.Entity<IdentityClaim>(entity =>
            {
                entity.HasIndex(e => e.IdentityResourceId, "IX_IdentityClaims_IdentityResourceId");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdentityResource)
                    .WithMany(p => p.IdentityClaims)
                    .HasForeignKey(d => d.IdentityResourceId);
            });

            modelBuilder.Entity<IdentityProperty>(entity =>
            {
                entity.HasIndex(e => e.IdentityResourceId, "IX_IdentityProperties_IdentityResourceId");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.IdentityResource)
                    .WithMany(p => p.IdentityProperties)
                    .HasForeignKey(d => d.IdentityResourceId);
            });

            modelBuilder.Entity<IdentityResource>(entity =>
            {
                entity.HasIndex(e => e.Name, "IX_IdentityResources_Name")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DisplayName).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<OtpUser>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_OtpUsers_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Otp).HasMaxLength(15);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OtpUsers)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<PersistedGrant>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.HasIndex(e => new { e.SubjectId, e.ClientId, e.Type, e.Expiration }, "IX_PersistedGrants_SubjectId_ClientId_Type_Expiration");

                entity.Property(e => e.Key).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasMaxLength(50000);

                entity.Property(e => e.SubjectId).HasMaxLength(200);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.ToTable("RESOURCE");

                entity.HasIndex(e => e.CultureId, "IX_RESOURCE_CultureId");

                entity.Property(e => e.Id).HasColumnName("ID");

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
                    .HasColumnName("ACTION_ID")
                    .HasDefaultValueSql("nextval('seq_action_id'::regclass)");

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

                entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.HttpMethod)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("HTTP_METHOD");

                entity.Property(e => e.IsScopeRequired).HasColumnName("IS_SCOPE_REQUIRED");

                entity.Property(e => e.IsSystem).HasColumnName("IS_SYSTEM");

                entity.Property(e => e.ModuleId).HasColumnName("MODULE_ID");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .HasColumnName("NOTE");

                entity.Property(e => e.SecurityLevel).HasColumnName("SECURITY_LEVEL");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt).HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.Url)
                    .HasMaxLength(1024)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<TActionActionGroup>(entity =>
            {
                entity.HasKey(e => e.ActionActionGroupId);

                entity.ToTable("T_ACTION_ACTION_GROUP");

                entity.HasIndex(e => new { e.ActionId, e.ActionGroupId }, "AK_T_ACT_ACTGRP")
                    .IsUnique();

                entity.HasIndex(e => e.ActionGroupId, "IX_T_ACT_ACTGRP_ACTGRP_ID");

                entity.Property(e => e.ActionActionGroupId)
                    .HasColumnName("ACTION_ACTION_GROUP_ID")
                    .HasDefaultValueSql("nextval('seq_actionactiongroup_id'::regclass)");

                entity.Property(e => e.ActionGroupId).HasColumnName("ACTION_GROUP_ID");

                entity.Property(e => e.ActionId).HasColumnName("ACTION_ID");

                entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.UpdatedAt).HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");
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
                    .HasColumnName("ACTION_GROUP_ID")
                    .HasDefaultValueSql("nextval('seq_actiongroup_id'::regclass)");

                entity.Property(e => e.ActionGroupCode)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("ACTION_GROUP_CODE");

                entity.Property(e => e.ActionGroupName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("ACTION_GROUP_NAME");

                entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.IsSystem).HasColumnName("IS_SYSTEM");

                entity.Property(e => e.ModuleId).HasColumnName("MODULE_ID");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .HasColumnName("NOTE");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt).HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");
            });

            modelBuilder.Entity<TApp>(entity =>
            {
                entity.HasKey(e => e.AppId);

                entity.ToTable("T_APP");

                entity.Property(e => e.AppId)
                    .HasColumnName("APP_ID")
                    .HasDefaultValueSql("nextval('seq_app_id'::regclass)");

                entity.Property(e => e.AppCode)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("APP_CODE");

                entity.Property(e => e.AppName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("APP_NAME");

                entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.IsSystem).HasColumnName("IS_SYSTEM");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .HasColumnName("NOTE");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt).HasColumnName("UPDATED_AT");

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
                    .HasColumnName("APP_MODULE_ID")
                    .HasDefaultValueSql("nextval('seq_appmodule_id'::regclass)");

                entity.Property(e => e.AppId).HasColumnName("APP_ID");

                entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.ModuleId).HasColumnName("MODULE_ID");

                entity.Property(e => e.UpdatedAt).HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");
            });

            modelBuilder.Entity<TCatalog>(entity =>
            {
                entity.HasKey(e => e.CatalogId);

                entity.ToTable("T_CATALOG");

                entity.HasIndex(e => e.CatalogTypeId, "IX_T_CATALOG_CATALOG_TYPE_ID");

                entity.Property(e => e.CatalogId).HasColumnName("CATALOG_ID");

                entity.Property(e => e.CatalogName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("CATALOG_NAME");

                entity.Property(e => e.CatalogTypeId).HasColumnName("CATALOG_TYPE_ID");

                entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.IsSystem).HasColumnName("IS_SYSTEM");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .HasColumnName("NOTE");

                entity.Property(e => e.OrderHint).HasColumnName("ORDER_HINT");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt).HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.HasOne(d => d.CatalogType)
                    .WithMany(p => p.TCatalogs)
                    .HasForeignKey(d => d.CatalogTypeId);
            });

            modelBuilder.Entity<TCatalogType>(entity =>
            {
                entity.HasKey(e => e.CatalogTypeId);

                entity.ToTable("T_CATALOG_TYPE");

                entity.Property(e => e.CatalogTypeId).HasColumnName("CATALOG_TYPE_ID");

                entity.Property(e => e.CatalogName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("CATALOG_NAME");

                entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.UpdatedAt).HasColumnName("UPDATED_AT");

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

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");

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

                entity.Property(e => e.IsSystem).HasColumnName("IS_SYSTEM");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .HasColumnName("NOTE");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt).HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");
            });

            modelBuilder.Entity<TLog>(entity =>
            {
                entity.ToTable("T_LOGS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AfterValue)
                    .HasColumnType("character varying")
                    .HasColumnName("AFTER_VALUE");

                entity.Property(e => e.AppCode)
                    .HasMaxLength(100)
                    .HasColumnName("APP_CODE");

                entity.Property(e => e.Application)
                    .HasMaxLength(100)
                    .HasColumnName("APPLICATION");

                entity.Property(e => e.BeforeValue)
                    .HasColumnType("character varying")
                    .HasColumnName("BEFORE_VALUE");

                entity.Property(e => e.Callsite)
                    .HasMaxLength(8000)
                    .HasColumnName("CALLSITE");

                entity.Property(e => e.Exception)
                    .HasMaxLength(8000)
                    .HasColumnName("EXCEPTION");

                entity.Property(e => e.FunctionName)
                    .HasMaxLength(100)
                    .HasColumnName("FUNCTION_NAME");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(100)
                    .HasColumnName("IP_ADDRESS");

                entity.Property(e => e.Level)
                    .HasMaxLength(100)
                    .HasColumnName("LEVEL");

                entity.Property(e => e.Logged).HasColumnName("LOGGED");

                entity.Property(e => e.Logger)
                    .HasMaxLength(8000)
                    .HasColumnName("LOGGER");

                entity.Property(e => e.Message)
                    .HasMaxLength(8000)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(100)
                    .HasColumnName("SERVICE_NAME");

                entity.Property(e => e.SiteId)
                    .HasMaxLength(100)
                    .HasColumnName("SITE_ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .HasColumnName("USER_NAME");
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
                    .HasColumnName("MODULE_ID")
                    .HasDefaultValueSql("nextval('seq_module_id'::regclass)");

                entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.IsSystem).HasColumnName("IS_SYSTEM");

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

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt).HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");
            });

            modelBuilder.Entity<TPrefixUrl>(entity =>
            {
                entity.HasKey(e => e.PrefixUrlId);

                entity.ToTable("T_PREFIX_URL");

                entity.HasIndex(e => e.ModuleId, "IX_T_PREFIX_URL_MODULE_ID");

                entity.Property(e => e.PrefixUrlId).HasColumnName("PREFIX_URL_ID");

                entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.ModuleId).HasColumnName("MODULE_ID");

                entity.Property(e => e.PrefixUrl)
                    .IsRequired()
                    .HasColumnName("PREFIX_URL");

                entity.Property(e => e.UpdatedAt).HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");
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
                    .ValueGeneratedNever()
                    .HasColumnName("SCOPE_ID");

                entity.Property(e => e.AppCode)
                    .HasMaxLength(32)
                    .HasColumnName("APP_CODE");

                entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.Discriminator).IsRequired();

                entity.Property(e => e.ImportedParentScopeId).HasColumnName("IMPORTED_PARENT_SCOPE_ID");

                entity.Property(e => e.IsSystem).HasColumnName("IS_SYSTEM");

                entity.Property(e => e.MaHuyen)
                    .HasMaxLength(16)
                    .HasColumnName("MA_HUYEN");

                entity.Property(e => e.MaTinh)
                    .HasMaxLength(16)
                    .HasColumnName("MA_TINH");

                entity.Property(e => e.MaXa)
                    .HasMaxLength(16)
                    .HasColumnName("MA_XA");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .HasColumnName("NOTE");

                entity.Property(e => e.OriginCategoryId)
                    .HasMaxLength(32)
                    .HasColumnName("ORIGIN_CATEGORY_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.ParentScopeId).HasColumnName("PARENT_SCOPE_ID");

                entity.Property(e => e.Path)
                    .HasMaxLength(512)
                    .HasColumnName("PATH");

                entity.Property(e => e.ScopeCode)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("SCOPE_CODE");

                entity.Property(e => e.ScopeLevel).HasColumnName("SCOPE_LEVEL");

                entity.Property(e => e.ScopeName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("SCOPE_NAME");

                entity.Property(e => e.ScopeType).HasColumnName("SCOPE_TYPE");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt).HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");
            });

            modelBuilder.Entity<TUserAdminApp>(entity =>
            {
                entity.HasKey(e => e.UserAdminAppId);

                entity.ToTable("T_USER_ADMIN_APP");

                entity.HasIndex(e => e.AppId, "IX_T_USER_ADMIN_APP_APP_ID");

                entity.HasIndex(e => e.UserId, "IX_T_USER_ADMIN_APP_UserId");

                entity.Property(e => e.UserAdminAppId)
                    .HasColumnName("USER_ADMIN_APP_ID")
                    .HasDefaultValueSql("nextval('seq_useradminapp_id'::regclass)");

                entity.Property(e => e.AppId).HasColumnName("APP_ID");

                entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.UpdatedAt).HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.HasOne(d => d.App)
                    .WithMany(p => p.TUserAdminApps)
                    .HasForeignKey(d => d.AppId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TUserAdminApps)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<TUserAdminScope>(entity =>
            {
                entity.HasKey(e => e.UserAdminScopeId);

                entity.ToTable("T_USER_ADMIN_SCOPE");

                entity.HasIndex(e => new { e.UserId, e.ScopeId }, "AK_T_USER_ADMIN_SCOPE")
                    .IsUnique();

                entity.HasIndex(e => e.ScopeId, "IX_T_USER_AD_SCOPE_SCOPE_ID");

                entity.HasIndex(e => e.UserId, "IX_T_USER_AD_SCOPE_USER_ID");

                entity.Property(e => e.UserAdminScopeId).HasColumnName("USER_ADMIN_SCOPE_ID");

                entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.ScopeId).HasColumnName("SCOPE_ID");

                entity.Property(e => e.UpdatedAt).HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Scope)
                    .WithMany(p => p.TUserAdminScopes)
                    .HasForeignKey(d => d.ScopeId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TUserAdminScopes)
                    .HasForeignKey(d => d.UserId);
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
                    .HasColumnName("USER_GROUP_ID")
                    .HasDefaultValueSql("nextval('seq_usergroup_id'::regclass)");

                entity.Property(e => e.AdminByAppId).HasColumnName("ADMIN_BY_APP_ID");

                entity.Property(e => e.AdminByScopeId).HasColumnName("ADMIN_BY_SCOPE_ID");

                entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.IsSystem).HasColumnName("IS_SYSTEM");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .HasColumnName("NOTE");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt).HasColumnName("UPDATED_AT");

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
            });

            modelBuilder.Entity<TUserGroupActionGroup>(entity =>
            {
                entity.HasKey(e => e.UserGroupActionGroupId);

                entity.ToTable("T_USER_GROUP_ACTION_GROUP");

                entity.HasIndex(e => new { e.UserGroupId, e.ActionGroupId }, "AK_T_USRGRP_ACTGRP")
                    .IsUnique();

                entity.HasIndex(e => e.ActionGroupId, "IX_T_USRGRP_ACTGRP_ACTGRP_ID");

                entity.Property(e => e.UserGroupActionGroupId)
                    .HasColumnName("USER_GROUP_ACTION_GROUP_ID")
                    .HasDefaultValueSql("nextval('seq_usergroupactiongroup_id'::regclass)");

                entity.Property(e => e.ActionGroupId).HasColumnName("ACTION_GROUP_ID");

                entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.IsAllowToGrant).HasColumnName("IS_ALLOW_TO_GRANT");

                entity.Property(e => e.UpdatedAt).HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UserGroupId).HasColumnName("USER_GROUP_ID");
            });

            modelBuilder.Entity<TUserGroupScope>(entity =>
            {
                entity.HasKey(e => e.UserGroupScopeId);

                entity.ToTable("T_USER_GROUP_SCOPE");

                entity.HasIndex(e => new { e.UserGroupId, e.ScopeId }, "AK_T_USRGRP_SCOPE")
                    .IsUnique();

                entity.HasIndex(e => e.ScopeId, "IX_T_USER_GROUP_SCOPE_SCOPE_ID");

                entity.Property(e => e.UserGroupScopeId)
                    .HasColumnName("USER_GROUP_SCOPE_ID")
                    .HasDefaultValueSql("nextval('seq_usergroupscope_id'::regclass)");

                entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.ScopeId).HasColumnName("SCOPE_ID");

                entity.Property(e => e.UpdatedAt).HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UserGroupId).HasColumnName("USER_GROUP_ID");
            });

            modelBuilder.Entity<TUserUserGroup>(entity =>
            {
                entity.HasKey(e => e.UserUserGroupId);

                entity.ToTable("T_USER_USER_GROUP");

                entity.HasIndex(e => new { e.UserId, e.UserGroupId }, "AK_T_USR_USRGRP")
                    .IsUnique();

                entity.HasIndex(e => e.UserGroupId, "IX_T_USR_USRGRP_USRGRP_ID");

                entity.Property(e => e.UserUserGroupId)
                    .HasColumnName("USER_USER_GROUP_ID")
                    .HasDefaultValueSql("nextval('seq_userusergroup_id'::regclass)");

                entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.UpdatedAt).HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UserGroupId).HasColumnName("USER_GROUP_ID");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");
            });

            modelBuilder.HasSequence<int>("seq_action_id");

            modelBuilder.HasSequence<int>("seq_actionactiongroup_id").StartsAt(5724);

            modelBuilder.HasSequence<int>("seq_actiongroup_id");

            modelBuilder.HasSequence<int>("seq_app_id");

            modelBuilder.HasSequence<int>("seq_appmodule_id");

            modelBuilder.HasSequence<int>("seq_module_id");

            modelBuilder.HasSequence<int>("seq_useradminapp_id");

            modelBuilder.HasSequence<int>("seq_usergroup_id");

            modelBuilder.HasSequence<int>("seq_usergroupactiongroup_id");

            modelBuilder.HasSequence<int>("seq_usergroupscope_id");

            modelBuilder.HasSequence<int>("seq_userusergroup_id");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
