using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LanguageCourse.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationUser : User
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class LanguageCourseDBContext : IdentityDbContext<ApplicationUser>
    {
        public LanguageCourseDBContext()
            : base("LanguageCourseDBContext", throwIfV1Schema: false)
        {
        }
        public static LanguageCourseDBContext Create()
        {
            return new LanguageCourseDBContext();
        }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Certificate> Certificate { get; set; }
        public DbSet<Pay> Pay { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<User> Users { get; set; }
    }
}