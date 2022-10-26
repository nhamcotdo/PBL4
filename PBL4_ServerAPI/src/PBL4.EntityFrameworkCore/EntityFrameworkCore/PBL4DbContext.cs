using Microsoft.EntityFrameworkCore;
using PBL4.Classes;
using PBL4.Courses;
using PBL4.LessonCompletes;
using PBL4.LessonOfCourses;
using PBL4.Lessons;
using PBL4.Registers;
using PBL4.SessionRegisters;
using PBL4.Sessions;
using PBL4.Students;
using PBL4.TeacherOfSessions;
using PBL4.Teachers;
using PBL4.Terms;
using PBL4.UserLogins;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace PBL4.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(IIdentityDbContext))]
    [ReplaceDbContext(typeof(ITenantManagementDbContext))]
    [ConnectionStringName("Default")]
    public class PBL4DbContext :
        AbpDbContext<PBL4DbContext>,
        IIdentityDbContext,
        ITenantManagementDbContext
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */

        #region Entities from the modules

        /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
         * and replaced them for this DbContext. This allows you to perform JOIN
         * queries for the entities of these modules over the repositories easily. You
         * typically don't need that for other modules. But, if you need, you can
         * implement the DbContext interface of the needed module and use ReplaceDbContext
         * attribute just like IIdentityDbContext and ITenantManagementDbContext.
         *
         * More info: Replacing a DbContext of a module ensures that the related module
         * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
         */

        //Identity
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityClaimType> ClaimTypes { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
        public DbSet<IdentityLinkUser> LinkUsers { get; set; }

        // Tenant Management
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

        // Coure Table
        public DbSet<Class> Classes { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<LessonOfCourse> LessonOfCourses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionRegister> SessionRegisters { get; set; }
        public DbSet<LessonComplete> LessonCompletes { get; set; }
        public DbSet<TeacherOfSession> TeacherOfSessions { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        #endregion

        public PBL4DbContext(DbContextOptions<PBL4DbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();

            /* Configure your own tables/entities inside here */


            builder.Entity<Class>(b =>
            {
                b.ToTable(PBL4Consts.DbTablePrefix + "Classes", PBL4Consts.Class);
                b.HasOne(t => t.Term).WithMany(l => l.Classes).HasForeignKey(t => t.TermId);
                b.HasOne(t => t.Course).WithMany(l => l.Classes).HasForeignKey(t => t.CourseId);
                b.ConfigureByConvention();
            });

            builder.Entity<Term>(b =>
            {
                b.ToTable(PBL4Consts.DbTablePrefix + "Terms", PBL4Consts.Course);
                b.ConfigureByConvention();
            });

            builder.Entity<LessonOfCourse>(b =>
            {
                b.ToTable(PBL4Consts.DbTablePrefix + "LessonOfCourses", PBL4Consts.Course);
                b.HasOne(x => x.Course).WithMany(l => l.LessonOfCourses).HasForeignKey(x => x.CourseId);
                b.HasOne(x => x.Lesson).WithMany(l => l.LessonOfCourses).HasForeignKey(x => x.LessonId);
                b.ConfigureByConvention();
            });

            builder.Entity<Course>(b =>
            {
                b.ToTable(PBL4Consts.DbTablePrefix + "Courses", PBL4Consts.Course);
                b.ConfigureByConvention();
            });

            builder.Entity<Lesson>(b =>
            {
                b.ToTable(PBL4Consts.DbTablePrefix + "Lessons", PBL4Consts.Course);
                b.ConfigureByConvention();
            });

            builder.Entity<Register>(b =>
            {
                b.ToTable(PBL4Consts.DbTablePrefix + "Registers", PBL4Consts.Class);
                b.HasOne(x => x.Class).WithMany(l => l.Registers).HasForeignKey(x => x.ClassId);
                b.HasOne(x => x.Student).WithMany(l => l.Registers).HasForeignKey(x => x.StudentId);
                b.ConfigureByConvention();
            });

            builder.Entity<Session>(b =>
            {
                b.ToTable(PBL4Consts.DbTablePrefix + "Sessions", PBL4Consts.Class);
                b.HasOne(x => x.Class).WithMany(l => l.Sessions).HasForeignKey(x => x.ClassId);
                b.HasOne(x => x.Lesson).WithMany(l => l.Sessions).HasForeignKey(x => x.LessonId);
                b.ConfigureByConvention();
            });

            builder.Entity<SessionRegister>(b =>
            {
                b.ToTable(PBL4Consts.DbTablePrefix + "SessionRegisters", PBL4Consts.Class);
                b.HasOne(x => x.Student).WithMany(l => l.SessionRegisters).HasForeignKey(x => x.StudentId);
                b.HasOne(x => x.Session).WithMany(l => l.SessionRegisters).HasForeignKey(x => x.SessionId);
                b.ConfigureByConvention();
            });

            builder.Entity<LessonComplete>(b =>
            {
                b.ToTable(PBL4Consts.DbTablePrefix + "LessonCompletes", PBL4Consts.Course);
                b.HasOne(x => x.Student).WithMany(l => l.LessonCompletes).HasForeignKey(x => x.StudentId);
                b.HasOne(x => x.Class).WithMany(l => l.LessonCompletes).HasForeignKey(x => x.ClassId);
                b.HasOne(x => x.Lesson).WithMany(l => l.LessonCompletes).HasForeignKey(x => x.LessonId);
                b.HasOne(x => x.Session).WithMany(l => l.LessonCompletes).HasForeignKey(x => x.SessionId);
                b.ConfigureByConvention();
            });

            builder.Entity<TeacherOfSession>(b =>
            {
                b.ToTable(PBL4Consts.DbTablePrefix + "TeacherOfSessions", PBL4Consts.Class);
                b.HasOne(x => x.Teacher).WithMany(l => l.TeacherOfSessions).HasForeignKey(x => x.TeacherId);
                b.ConfigureByConvention();
                b.HasOne(x => x.Session).WithMany(l => l.TeacherOfSessions).HasForeignKey(x => x.SessionId);
            });

            builder.Entity<Teacher>(b =>
            {
                b.ToTable(PBL4Consts.DbTablePrefix + "Teachers", PBL4Consts.Person);
                b.HasOne(x => x.UserLogin).WithMany().HasForeignKey(x => x.UserId);
                b.ConfigureByConvention();
            });

            builder.Entity<Student>(b =>
            {
                b.ToTable(PBL4Consts.DbTablePrefix + "Students", PBL4Consts.Person);
                b.HasOne(x => x.UserLogin).WithMany().HasForeignKey(x => x.UserId);
                b.ConfigureByConvention();
            });
        }
    }
}
