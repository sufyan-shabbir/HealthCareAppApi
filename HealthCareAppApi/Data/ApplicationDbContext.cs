using HealthCareAppApi.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.Design;
using System.Reflection;
using System.Security.Claims;

namespace HealthCareAppApi.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IHttpContextAccessor? _httpContextAccessor;

        // Runtime constructor
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IHttpContextAccessor httpContextAccessor
        ) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        } 
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var entries = ChangeTracker.Entries<BaseEntity>();

                foreach (var entry in entries)
                {
                    var now = DateTime.UtcNow;
                    var userId = GetUserId();
                    var companyId = GetCompanyId();
                    var roleId = GetRoleId();

                    if (entry.State == EntityState.Added)
                    {
                        entry.Entity.CreatedOn = now;
                        entry.Entity.CreatedBy = userId;

                        var entityType = entry.Entity.GetType();
                        var entityName = entityType.Name;

                        var companyIdProp = entityType.GetProperty("CompanyId");
                        if (companyIdProp != null && companyIdProp.CanWrite)
                        {
                            int companyIdToSet = companyId;

                            // Skip assigning CompanyId for User/Role if RoleId == 1
                            if (!(roleId == 1 &&
                                  (entityName.Contains("User", StringComparison.OrdinalIgnoreCase) ||
                                   entityName.Contains("Role", StringComparison.OrdinalIgnoreCase))))
                            {
                                companyIdProp.SetValue(entry.Entity, companyIdToSet);
                            }
                        }
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        entry.Entity.ModifiedOn = now;
                        entry.Entity.ModifiedBy = userId;
                    }
                }

                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while saving changes.", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("A database update error occurred while saving changes.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while saving changes.", ex);
            }
        }

        private int GetUserId()
        {
            var userIdClaim = _httpContextAccessor?.HttpContext?.User?.FindFirst("sub")?.Value
                              ?? _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                              ?? _httpContextAccessor?.HttpContext?.User?.FindFirst("Id")?.Value;

            return int.TryParse(userIdClaim, out var userId) ? userId : 0;
        }

        private int GetCompanyId()
        {
            var companyIdClaim = _httpContextAccessor?.HttpContext?.User?.FindFirst("CompanyId")?.Value;
            return int.TryParse(companyIdClaim, out var companyId) ? companyId : 0;
        }

        private int GetRoleId()
        {
            var roleIdClaim = _httpContextAccessor?.HttpContext?.User?.FindFirst("RoleId")?.Value;
            return int.TryParse(roleIdClaim, out var roleId) ? roleId : 0;
        }

        // Register Entities
        public DbSet<Role> role { get; set; }
        public DbSet<RoleModuleAccess> roleModuleAccess { get; set; }
        public DbSet<User> ApplicationUser { get; set; }
        public DbSet<Company> company { get; set; }
        public DbSet<Lookup> lookup { get; set; }
        public DbSet<FormName> formName { get; set; }
        public DbSet<Entities.Module> Modules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ignore System.Reflection.CustomAttributeData conflicts
            modelBuilder.Ignore<CustomAttributeData>();

            // User -> Role (Restrict delete)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.ModuleAccesses)
                .WithOne(ma => ma.Role)
                .HasForeignKey(ma => ma.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
