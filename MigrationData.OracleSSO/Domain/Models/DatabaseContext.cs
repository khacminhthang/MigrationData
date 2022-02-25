using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MigrationData.OracleSSO.Domain.Models
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
        public virtual DbSet<DeviceCode> DeviceCodes { get; set; }
        public virtual DbSet<IdentityClaim> IdentityClaims { get; set; }
        public virtual DbSet<IdentityProperty> IdentityProperties { get; set; }
        public virtual DbSet<IdentityResource> IdentityResources { get; set; }
        public virtual DbSet<OtpUser> OtpUsers { get; set; }
        public virtual DbSet<PersistedGrant> PersistedGrants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=113.160.187.187)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=ILIS)));User Id=ILIS_SSO;Password=vnlissts#125;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ILIS_SSO")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<ApiClaim>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId, "IX_ApiClaims_ApiResourceId");

                entity.Property(e => e.Id).HasPrecision(10);

                entity.Property(e => e.ApiResourceId).HasPrecision(10);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiClaims)
                    .HasForeignKey(d => d.ApiResourceId)
                    .HasConstraintName("FK_ApiClaims_ApiRes_ApiResId");
            });

            modelBuilder.Entity<ApiProperty>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId, "IX_ApiProperties_ApiResourceId");

                entity.Property(e => e.Id).HasPrecision(10);

                entity.Property(e => e.ApiResourceId).HasPrecision(10);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value).IsRequired();

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiProperties)
                    .HasForeignKey(d => d.ApiResourceId)
                    .HasConstraintName("FK_ApiProp_ApiRes_ApiResId");
            });

            modelBuilder.Entity<ApiResource>(entity =>
            {
                entity.HasIndex(e => e.Name, "IX_ApiResources_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasPrecision(10);

                entity.Property(e => e.Created).HasPrecision(7);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DisplayName).HasMaxLength(200);

                entity.Property(e => e.Enabled).HasPrecision(1);

                entity.Property(e => e.LastAccessed).HasPrecision(7);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.NonEditable).HasPrecision(1);

                entity.Property(e => e.Updated).HasPrecision(7);
            });

            modelBuilder.Entity<ApiScope>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId, "IX_ApiScopes_ApiResourceId");

                entity.HasIndex(e => e.Name, "IX_ApiScopes_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasPrecision(10);

                entity.Property(e => e.ApiResourceId).HasPrecision(10);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DisplayName).HasMaxLength(200);

                entity.Property(e => e.Emphasize).HasPrecision(1);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Required).HasPrecision(1);

                entity.Property(e => e.ShowInDiscoveryDocument).HasPrecision(1);

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiScopes)
                    .HasForeignKey(d => d.ApiResourceId)
                    .HasConstraintName("FK_ApiScopes_ApiRes_ApiResId");
            });

            modelBuilder.Entity<ApiScopeClaim>(entity =>
            {
                entity.HasIndex(e => e.ApiScopeId, "IX_ApiScopeClaims_ApiScopeId");

                entity.Property(e => e.Id).HasPrecision(10);

                entity.Property(e => e.ApiScopeId).HasPrecision(10);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.ApiScope)
                    .WithMany(p => p.ApiScopeClaims)
                    .HasForeignKey(d => d.ApiScopeId)
                    .HasConstraintName("FK_ScopeClaims_Scopes_ScopeId");
            });

            modelBuilder.Entity<ApiSecret>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId, "IX_ApiSecrets_ApiResourceId");

                entity.Property(e => e.Id).HasPrecision(10);

                entity.Property(e => e.ApiResourceId).HasPrecision(10);

                entity.Property(e => e.Created).HasPrecision(7);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Expiration).HasPrecision(7);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnType("NCLOB");

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiSecrets)
                    .HasForeignKey(d => d.ApiResourceId)
                    .HasConstraintName("FK_ApiSecrets_ApiRes_ApiResId");
            });

            modelBuilder.Entity<ApplicationConfiguration>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.Property(e => e.Value).HasColumnType("CLOB");
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

                entity.Property(e => e.Id).HasPrecision(10);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_RoleClaims_Roles");
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccessFailedCount).HasPrecision(10);

                entity.Property(e => e.CreatedDate).HasPrecision(7);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.EmailConfirmed).HasPrecision(1);

                entity.Property(e => e.FirstName).HasMaxLength(250);

                entity.Property(e => e.IsAdmin).HasPrecision(1);

                entity.Property(e => e.IsEnabled).HasPrecision(1);

                entity.Property(e => e.LastLoginTime).HasPrecision(7);

                entity.Property(e => e.LastName).HasMaxLength(250);

                entity.Property(e => e.LastPasswordChanged).HasPrecision(7);

                entity.Property(e => e.LockoutEnabled).HasPrecision(1);

                entity.Property(e => e.LockoutEnd).HasColumnType("TIMESTAMP(3) WITH TIME ZONE");

                entity.Property(e => e.MaTinh).HasMaxLength(100);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.PhoneNumberConfirmed).HasPrecision(1);

                entity.Property(e => e.RequiredOtpSms)
                    .IsRequired()
                    .HasPrecision(1)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TwoFactorEnabled).HasPrecision(1);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id).HasPrecision(10);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserClaims_Users");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserLogins_Users");
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRoles_Roles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRoles_Users");
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserTokens_Users");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_Clients_ClientId")
                    .IsUnique();

                entity.Property(e => e.Id).HasPrecision(10);

                entity.Property(e => e.AbsoluteRefreshTokenLifetime).HasPrecision(10);

                entity.Property(e => e.AccessTokenLifetime).HasPrecision(10);

                entity.Property(e => e.AccessTokenType).HasPrecision(10);

                entity.Property(e => e.AllowAccessTokensViaBrowser).HasPrecision(1);

                entity.Property(e => e.AllowOfflineAccess).HasPrecision(1);

                entity.Property(e => e.AllowPlainTextPkce).HasPrecision(1);

                entity.Property(e => e.AllowRememberConsent).HasPrecision(1);

                entity.Property(e => e.AlwaysInclUsrClaimsInIdToken).HasPrecision(1);

                entity.Property(e => e.AlwaysSendClientClaims).HasPrecision(1);

                entity.Property(e => e.AuthorizationCodeLifetime).HasPrecision(10);

                entity.Property(e => e.BackChannelLogoutSesRequired).HasPrecision(1);

                entity.Property(e => e.ClientClaimsPrefix).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ClientName).HasMaxLength(200);

                entity.Property(e => e.ConsentLifetime).HasPrecision(10);

                entity.Property(e => e.Created).HasPrecision(7);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DeviceCodeLifetime).HasPrecision(10);

                entity.Property(e => e.EnableLocalLogin).HasPrecision(1);

                entity.Property(e => e.Enabled).HasPrecision(1);

                entity.Property(e => e.FrontChannelLogoutSesRequired).HasPrecision(1);

                entity.Property(e => e.IdentityTokenLifetime).HasPrecision(10);

                entity.Property(e => e.IncludeJwtId).HasPrecision(1);

                entity.Property(e => e.LastAccessed).HasPrecision(7);

                entity.Property(e => e.NonEditable).HasPrecision(1);

                entity.Property(e => e.PairWiseSubjectSalt).HasMaxLength(200);

                entity.Property(e => e.ProtocolType)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.RefreshTokenExpiration).HasPrecision(10);

                entity.Property(e => e.RefreshTokenUsage).HasPrecision(10);

                entity.Property(e => e.RequireClientSecret).HasPrecision(1);

                entity.Property(e => e.RequireConsent).HasPrecision(1);

                entity.Property(e => e.RequirePkce).HasPrecision(1);

                entity.Property(e => e.SlidingRefreshTokenLifetime).HasPrecision(10);

                entity.Property(e => e.UpdAccessTokenClaimsOnRefresh).HasPrecision(1);

                entity.Property(e => e.Updated).HasPrecision(7);

                entity.Property(e => e.UserCodeType).HasMaxLength(100);

                entity.Property(e => e.UserSsoLifetime).HasPrecision(10);
            });

            modelBuilder.Entity<ClientClaim>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientClaims_ClientId");

                entity.Property(e => e.Id).HasPrecision(10);

                entity.Property(e => e.ClientId).HasPrecision(10);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientClaims)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_CClaims_C_CId");
            });

            modelBuilder.Entity<ClientCorsOrigin>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientCorsOrigins_ClientId");

                entity.Property(e => e.Id).HasPrecision(10);

                entity.Property(e => e.ClientId).HasPrecision(10);

                entity.Property(e => e.Origin)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientCorsOrigins)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_CCorsOrigins_C_CId");
            });

            modelBuilder.Entity<ClientGrantType>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientGrantTypes_ClientId");

                entity.Property(e => e.Id).HasPrecision(10);

                entity.Property(e => e.ClientId).HasPrecision(10);

                entity.Property(e => e.GrantType)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientGrantTypes)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_CGrantTypes_C_CId");
            });

            modelBuilder.Entity<ClientIdPrestriction>(entity =>
            {
                entity.ToTable("ClientIdPRestrictions");

                entity.HasIndex(e => e.ClientId, "IX_CIdPRestrictions_CId");

                entity.Property(e => e.Id).HasPrecision(10);

                entity.Property(e => e.ClientId).HasPrecision(10);

                entity.Property(e => e.Provider)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientIdPrestrictions)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_CIdPRestrictions_C_CId");
            });

            modelBuilder.Entity<ClientPostLogoutRedirectUri>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_CPostLogoutRedirectUris_Cid");

                entity.Property(e => e.Id).HasPrecision(10);

                entity.Property(e => e.ClientId).HasPrecision(10);

                entity.Property(e => e.PostLogoutRedirectUri).IsRequired();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientPostLogoutRedirectUris)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_CPostLogoutRdirectUri_C_CId");
            });

            modelBuilder.Entity<ClientProperty>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientProperties_ClientId");

                entity.Property(e => e.Id).HasPrecision(10);

                entity.Property(e => e.ClientId).HasPrecision(10);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value).IsRequired();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientProperties)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_CProperties_C_CId");
            });

            modelBuilder.Entity<ClientRedirectUri>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientRedirectUris_ClientId");

                entity.Property(e => e.Id).HasPrecision(10);

                entity.Property(e => e.ClientId).HasPrecision(10);

                entity.Property(e => e.RedirectUri).IsRequired();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientRedirectUris)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_CRedirectUri_C_CId");
            });

            modelBuilder.Entity<ClientScope>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientScopes_ClientId");

                entity.Property(e => e.Id).HasPrecision(10);

                entity.Property(e => e.ClientId).HasPrecision(10);

                entity.Property(e => e.Scope)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientScopes)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_CScopes_C_CId");
            });

            modelBuilder.Entity<ClientSecret>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientSecrets_ClientId");

                entity.Property(e => e.Id).HasPrecision(10);

                entity.Property(e => e.ClientId).HasPrecision(10);

                entity.Property(e => e.Created).HasPrecision(7);

                entity.Property(e => e.Expiration).HasPrecision(7);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value).HasColumnType("NCLOB");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientSecrets)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_CSecrets_C_CId");
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

                entity.Property(e => e.CreationTime).HasPrecision(7);

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnType("NCLOB");

                entity.Property(e => e.DeviceCode1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("DeviceCode");

                entity.Property(e => e.Expiration).HasPrecision(7);

                entity.Property(e => e.SubjectId).HasMaxLength(200);
            });

            modelBuilder.Entity<IdentityClaim>(entity =>
            {
                entity.HasIndex(e => e.IdentityResourceId, "IX_IdenClaims_IdenResId");

                entity.Property(e => e.Id).HasPrecision(10);

                entity.Property(e => e.IdentityResourceId).HasPrecision(10);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdentityResource)
                    .WithMany(p => p.IdentityClaims)
                    .HasForeignKey(d => d.IdentityResourceId)
                    .HasConstraintName("FK_IdenClaim_IdenRes_IdenResId");
            });

            modelBuilder.Entity<IdentityProperty>(entity =>
            {
                entity.HasIndex(e => e.IdentityResourceId, "IX_IdenProp_IdenResId");

                entity.Property(e => e.Id).HasPrecision(10);

                entity.Property(e => e.IdentityResourceId).HasPrecision(10);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value).IsRequired();

                entity.HasOne(d => d.IdentityResource)
                    .WithMany(p => p.IdentityProperties)
                    .HasForeignKey(d => d.IdentityResourceId)
                    .HasConstraintName("FK_IdenProp_IdenRes_IdenResId");
            });

            modelBuilder.Entity<IdentityResource>(entity =>
            {
                entity.HasIndex(e => e.Name, "IX_IdentityResources_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasPrecision(10);

                entity.Property(e => e.Created).HasPrecision(7);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DisplayName).HasMaxLength(200);

                entity.Property(e => e.Emphasize).HasPrecision(1);

                entity.Property(e => e.Enabled).HasPrecision(1);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.NonEditable).HasPrecision(1);

                entity.Property(e => e.Required).HasPrecision(1);

                entity.Property(e => e.ShowInDiscoveryDocument).HasPrecision(1);

                entity.Property(e => e.Updated).HasPrecision(7);
            });

            modelBuilder.Entity<OtpUser>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_OtpUsers_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasPrecision(7);

                entity.Property(e => e.Otp).HasMaxLength(15);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OtpUsers)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<PersistedGrant>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.HasIndex(e => new { e.SubjectId, e.ClientId, e.Type, e.Expiration }, "IX_Persist_SubId_CId_Type_Exp");

                entity.Property(e => e.Key).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.CreationTime).HasPrecision(7);

                entity.Property(e => e.Data).HasColumnType("NCLOB");

                entity.Property(e => e.Expiration).HasPrecision(7);

                entity.Property(e => e.SubjectId).HasMaxLength(200);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.HasSequence("ISEQ$$_99417");

            modelBuilder.HasSequence("ISEQ$$_99419");

            modelBuilder.HasSequence("ISEQ$$_99424");

            modelBuilder.HasSequence("ISEQ$$_99426");

            modelBuilder.HasSequence("ISEQ$$_99431");

            modelBuilder.HasSequence("ISEQ$$_99433");

            modelBuilder.HasSequence("ISEQ$$_99435");

            modelBuilder.HasSequence("ISEQ$$_99437");

            modelBuilder.HasSequence("ISEQ$$_99439");

            modelBuilder.HasSequence("ISEQ$$_99441");

            modelBuilder.HasSequence("ISEQ$$_99443");

            modelBuilder.HasSequence("ISEQ$$_99445");

            modelBuilder.HasSequence("ISEQ$$_99447");

            modelBuilder.HasSequence("ISEQ$$_99449");

            modelBuilder.HasSequence("ISEQ$$_99451");

            modelBuilder.HasSequence("ISEQ$$_99453");

            modelBuilder.HasSequence("ISEQ$$_99455");

            modelBuilder.HasSequence("ISEQ$$_99457");

            modelBuilder.HasSequence("ISEQ$$_99459");

            modelBuilder.HasSequence("ISEQ$$_99471");

            modelBuilder.HasSequence("ISEQ$$_99475");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
