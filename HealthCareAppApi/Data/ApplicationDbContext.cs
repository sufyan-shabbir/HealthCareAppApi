using HealthCareAppApi.API.Entities;
//using Kutiyana_Memon_Hospital_Api.API.Entities;
//using Kutiyana_Memon_Hospital_Api.API.Services.GetCurrentUser;
//using Kutiyana_Memon_Hospital_Api.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Reflection;
using System.Security.Claims;

namespace HealthCareAppApi.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
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

                        // ======== CompanyId Block (Structured like TenantId block) ========
                        var companyIdProp = entityType.GetProperty("CompanyId");
                        if (companyIdProp != null && companyIdProp.CanWrite)
                        {
                            int companyIdToSet = companyId;

                            // Special case: if RoleId == 1 and entity is User => skip setting companyId
                            if (roleId == 1 &&
                             (entityName.Contains("User", StringComparison.OrdinalIgnoreCase) ||
                              entityName.Contains("Role", StringComparison.OrdinalIgnoreCase)))
                            {
                                // Skip assigning CompanyId for User entity when RoleId == 1
                            }
                            else
                            {
                                companyIdProp.SetValue(entry.Entity, companyIdToSet);
                            }
                        }
                        // ================================================================

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
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("sub")?.Value
                              ?? _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                              ?? _httpContextAccessor.HttpContext?.User?.FindFirst("Id")?.Value;

            return int.TryParse(userIdClaim, out var userId) ? userId : 0;
        }

        private int GetCompanyId()
        {
            var companyIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("CompanyId")?.Value;
            return int.TryParse(companyIdClaim, out var companyId) ? companyId : 0;
        }

        private int GetRoleId() 
        {
            var roleIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("RoleId")?.Value;
            return int.TryParse(roleIdClaim, out var roleId) ? roleId : 0;
        }


        //public DbSet<Company> company { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<RoleModuleAccess> roleModuleAccess { get; set; }
        public DbSet<User> ApplicationUser { get; set; }
       



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🚫 Ignore System.Reflection.CustomAttributeData conflict
            modelBuilder.Ignore<CustomAttributeData>();

            // User -> Role (Restrict delete behavior)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict); 
            //modelBuilder.Entity<Role>()
                //.HasOne(r => r.Company)
                //.WithMany(c => c.Roles)
                //.HasForeignKey(r => r.CompanyId)
                //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Role>()
               .HasMany(r => r.ModuleAccesses)
               .WithOne(ma => ma.Role)
               .HasForeignKey(ma => ma.RoleId)
               .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
