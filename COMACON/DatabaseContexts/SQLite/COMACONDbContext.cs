using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace COMACON.DatabaseContexts.SQLite
{
    public class COMACONSqliteDbContext : DbContext
    {
        public COMACONSqliteDbContext(DbContextOptions<COMACONSqliteDbContext> options)
        : base(options)
        {
        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleXPermission> RoleXPermissions { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<SecurityLog> SecurityLogs { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SystemTable> SystemTable { get; set; }
        public DbSet<PasswordPolicy> PasswordPolicies { get; set; }
        public DbSet<PasswordRule> PasswordRules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.PermissionId);
                entity.Property(e => e.PermissionName).IsRequired();
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.CreationDate).IsRequired();
                entity.Property(e => e.LastUpdatedDate).IsRequired();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId);
                entity.Property(e => e.RoleName).IsRequired();
            });
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1,
                    RoleName = "Admin",
                    RoleDescription = "Admin Role"
                }
            );

            modelBuilder.Entity<RoleXPermission>(entity =>
            {
                entity.HasKey(e => new { e.PermissionId, e.RoleId });
                entity.HasOne(e => e.Role)
                    .WithMany(r => r.RoleXPermissions)
                    .HasForeignKey(e => e.RoleId);
                entity.HasOne(e => e.Permission)
                    .WithMany(p => p.RoleXPermissions)
                    .HasForeignKey(e => e.PermissionId);
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.UserNum);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(250);
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.PasswordResetOnNextLogin).IsRequired();
                entity.Property(e => e.AuthMethod).IsRequired();
                entity.Property(e => e.CreationDate).IsRequired();
                entity.HasOne(e => e.Role)
                    .WithMany(r => r.UserAccounts)
                    .HasForeignKey(e => e.RoleId);
                entity.HasOne(e => e.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(e => e.CreatedBy);
                entity.HasOne(e => e.LastEditedByUser)
                    .WithMany()
                    .HasForeignKey(e => e.LastEditedBy);
            });
            modelBuilder.Entity<UserAccount>().HasData(
                new UserAccount
                {
                    UserNum = 1,
                    Username = "admin",
                    FirstName = "admin",
                    LastName = "admin",
                    Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                    EmailAddress = "admin@dummy.com",
                    Status = true,
                    PasswordResetOnNextLogin = false,
                    PasswordLastChanged = DateTimeOffset.Now.ToString(),
                    AuthMethod = 1,
                    CreationDate = DateTimeOffset.Now.ToString(),
                    CreatedBy = 1,
                    LastEditedDate = DateTimeOffset.Now.ToString(),
                    LastEditedBy = 1,
                    RoleId = 1
                }
            );

            modelBuilder.Entity<SecurityLog>(entity =>
            {
                entity.HasKey(e => e.SecurityLogId);
                entity.Property(e => e.EventId).IsRequired();
                entity.Property(e => e.EventDescription).IsRequired();
                entity.Property(e => e.LogDate).IsRequired();
                entity.HasOne(e => e.User)
                    .WithMany(u => u.SecurityLogs)
                    .HasForeignKey(e => e.UserNum);
                entity.HasOne(e => e.AffectedUser)
                    .WithMany()
                    .HasForeignKey(e => e.AffectedUserNum);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(e => e.AccessToken);
                entity.Property(e => e.TokenType).IsRequired();
                entity.Property(e => e.CreationDate).IsRequired();
                entity.Property(e => e.ExpirationDate).IsRequired();
                entity.HasOne(e => e.User)
                    .WithMany(u => u.Sessions)
                    .HasForeignKey(e => e.UserNum);
            });

            modelBuilder.Entity<SystemTable>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DatabaseVersion).IsRequired();
                entity.HasCheckConstraint("CK_SystemTable_Id", "[Id] = 1");
            });
            modelBuilder.Entity<SystemTable>().HasData(
                new SystemTable {
                    Id = 1,
                    DatabaseVersion = "1.0.0" 
                }
            );

            modelBuilder.Entity<PasswordPolicy>(entity =>
            {
                entity.HasKey(e => e.PswdPolicyId);
                entity.Property(e => e.PolicyType).IsRequired();
                entity.Property(e => e.PolicyName).IsRequired();
                entity.Property(e => e.PolicyDescription).IsRequired();
                entity.Property(e => e.PolicyEnabled).IsRequired();
            });
            modelBuilder.Entity<PasswordPolicy>().HasData(
                new PasswordPolicy
                {
                    PswdPolicyId = 1,
                    PolicyType = 1,
                    PolicyName = "Global Password Policy",
                    PolicyDescription = "",
                    PolicyEnabled = true
                }
            );

            modelBuilder.Entity<PasswordRule>(entity =>
            {
                entity.HasKey(e => e.PswdRuleId);
                entity.Property(e => e.RuleType).IsRequired();
                entity.Property(e => e.RuleEnabled).IsRequired();
                entity.HasOne(e => e.PasswordPolicy)
                    .WithMany(p => p.PasswordRules)
                    .HasForeignKey(e => e.PswdPolicyId);
            });
        }
    }

    public class Permission
    {
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public string Description { get; set; }
        public string CreationDate { get; set; }
        public string LastUpdatedDate { get; set; }
        public ICollection<RoleXPermission> RoleXPermissions { get; set; }
    }

    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public ICollection<UserAccount> UserAccounts { get; set; }
        public ICollection<RoleXPermission> RoleXPermissions { get; set; }
    }

    public class RoleXPermission
    {
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }

    public class UserAccount
    {
        public int UserNum { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public bool Status { get; set; }
        public bool PasswordResetOnNextLogin { get; set; }
        public string PasswordLastChanged { get; set; }
        public byte AuthMethod { get; set; }
        public string CreationDate { get; set; }
        public int CreatedBy { get; set; }
        //[JsonIgnore]
        public UserAccount CreatedByUser { get; set; }
        public string LastEditedDate { get; set; }
        public int LastEditedBy { get; set; }
        //[JsonIgnore]
        public UserAccount LastEditedByUser { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<SecurityLog> SecurityLogs { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }

    public class SecurityLog
    {
        public long SecurityLogId { get; set; }
        public short EventId { get; set; }
        public int UserNum { get; set; }
        public UserAccount User { get; set; }
        public string EventDescription { get; set; }
        public int? AffectedUserNum { get; set; }
        public UserAccount AffectedUser { get; set; }
        public string LogDate { get; set; }
    }

    public class Session
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public string CreationDate { get; set; }
        public string ExpirationDate { get; set; }
        public int UserNum { get; set; }
        public UserAccount User { get; set; }
    }

    public class SystemTable
    {
        public int Id { get; set; }
        public string DatabaseVersion { get; set; }
    }

    public class PasswordPolicy
    {
        public long PswdPolicyId { get; set; }
        public byte PolicyType { get; set; }
        public string PolicyName { get; set; }
        public string PolicyDescription { get; set; }
        public bool PolicyEnabled { get; set; }
        public ICollection<PasswordRule> PasswordRules { get; set; }
    }

    public class PasswordRule
    {
        public long PswdRuleId { get; set; }
        public long PswdPolicyId { get; set; }
        public PasswordPolicy PasswordPolicy { get; set; }
        public byte RuleType { get; set; }
        public short? RuleValue { get; set; }
        public bool RuleEnabled { get; set; }
    }
}
