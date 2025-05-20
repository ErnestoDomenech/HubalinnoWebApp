using Microsoft.EntityFrameworkCore;
using BaseLibrary.Entities;
using Microsoft.Identity.Client;
namespace ServerLibrary.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Tutor> Tutors => Set<Tutor>();
        public DbSet<Inspector> Inspectors => Set<Inspector>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<StudentEnrollment> StudentEnrollments => Set<StudentEnrollment>();
        public DbSet<StudentProfile> StudentProfiles => Set<StudentProfile>();
        public DbSet<TutorProfile> TutorProfiles => Set<TutorProfile>();
        public DbSet<Administrator> Administrators => Set<Administrator>();
        public DbSet<AdminProfile> AdminProfiles => Set<AdminProfile>();
        public DbSet<SystemRole> SystemRoles => Set<SystemRole>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // BaseEntity configuration (Student, Tutor, Inspector)
           // modelBuilder.Entity<BaseEntity>().HasKey(e => e.Id);

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(s => s.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(s => s.LastName).IsRequired().HasMaxLength(100);
                entity.Property(s => s.UserName).IsRequired().HasMaxLength(50);
                entity.Property(s => s.Created).IsRequired();

                entity.HasOne(s => s.Profile)
                      .WithOne(p => p.Student)
                      .HasForeignKey<StudentProfile>(p => p.StudentId);
            });

            modelBuilder.Entity<Tutor>(entity =>
            {
                entity.Property(t => t.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(t => t.LastName).IsRequired().HasMaxLength(100);
                entity.Property(t => t.UserName).IsRequired().HasMaxLength(50);

                entity.HasOne(t => t.Profile)
                      .WithOne(c => c.Tutor)
                      .HasForeignKey<TutorProfile>(tp => tp.TutorId);

                entity.HasOne(t => t.Course)
                      .WithMany(c => c.Tutors)
                      .HasForeignKey(t => t.CourseId);
            });

            modelBuilder.Entity<Inspector>(entity =>
            {
                entity.Property(i => i.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(i => i.LastName).IsRequired().HasMaxLength(100);
                entity.Property(i => i.UserName).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<StudentEnrollment>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Progress).IsRequired();
                entity.Property(e => e.Score).IsRequired();
                entity.Property(e => e.FirstAccess).IsRequired();
                entity.Property(e => e.LastAccess).IsRequired();

                entity.HasOne(e => e.Student)
                      .WithMany()
                      .HasForeignKey(e => e.StudentId);

                entity.HasOne(e => e.Course)
                      .WithMany(c => c.Enrollments)
                      .HasForeignKey(e => e.CourseId);
            });

            modelBuilder.Entity<StudentProfile>(entity =>
            {
                entity.Property(p => p.Email).HasMaxLength(100);
                entity.Property(p => p.PhoneNumber).HasMaxLength(20);
                entity.Property(p => p.Address).HasMaxLength(200);
                entity.Property(p => p.CivilId).HasMaxLength(50);
            });

            modelBuilder.Entity<TutorProfile>(entity =>
            {
                entity.Property(p => p.Email).HasMaxLength(100);
                entity.Property(p => p.PhoneNumber).HasMaxLength(20);
                entity.Property(p => p.Address).HasMaxLength(200);
                entity.Property(p => p.CivilId).HasMaxLength(50);
            });

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.Property(a => a.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(a => a.LastName).IsRequired().HasMaxLength(100);
                entity.Property(a => a.UserName).IsRequired().HasMaxLength(50);
                entity.HasOne(a => a.Profile)
                      .WithOne(p => p.Administrator)
                      .HasForeignKey<AdminProfile>(p => p.AdministratorId);
            });
            modelBuilder.Entity<AdminProfile>(entity =>
            {
                entity.Property(p => p.Email).HasMaxLength(100);
                entity.Property(p => p.PhoneNumber).HasMaxLength(20);
                entity.Property(p => p.CivilId).HasMaxLength(50);
            });
        }
    }
}