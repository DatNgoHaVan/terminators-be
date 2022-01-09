namespace Terminator.Infrastructure.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Terminator.Core.Models;
    using Terminator.Infrastructure.Data.EntityConfigurations;

    /// <summary>
    /// The EF Core data context
    /// </summary>
    public partial class AppDbContext : DbContext
    {
        public virtual DbSet<User> Users => Set<User>();

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class
        /// </summary>
        /// <remarks>The constructor is marked as internal and only for unit testing</remarks>
        public AppDbContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class
        /// </summary>
        /// <param name="options">the database context options</param>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        /// <summary>
        /// Configures the database context
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new InvalidOperationException("The connection to database is not configured.");
            }
        }

        /// <summary>
        /// Configures the EF Core model
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityTypeConfigurationBase<>).Assembly);
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Seed();
            //modelBuilder.Entity<Project>().ToTable("Project");
            //modelBuilder.Entity<Project>().HasData(new Project[]{ new Project { Name = "Lumisight"},
            //                                                      new Project { Name = "CAMA" },
            //                                                      new Project { Name = "TIPS" },
            //                                                      new Project { Name = "BPP" }
            //                                            });
            //modelBuilder.Entity<Salary>().ToTable("Salary");
            //modelBuilder.Entity<Department>().ToTable("Department");
            //modelBuilder.Entity<Department>().HasData(new Department[]{  new Department {DepartmentName = "IT" },
            //                                                             new Department {DepartmentName = "HR"},
            //                                                             new Department {DepartmentName = "Accountant"},
            //                                                             new Department {DepartmentName = "Development" },
            //                                                             new Department {DepartmentName = "Customer Service" }
            //                                                             });


            //modelBuilder.Entity<Role>().ToTable("Role");
            //Role managerRole, userRole;
            //modelBuilder.Entity<Role>().HasData(new Role[]{ managerRole = new Role {RoleName = "Manager"},
            //                                                new Role { RoleName = "Moderator" },
            //                                                userRole = new Role { RoleName = "User"},
            //                                            });

            //modelBuilder.Entity<User>().ToTable("User");
            //User admin, user, user1;
            //modelBuilder.Entity<User>().HasData(new User[]{ admin = new User {FirstName = "Huy", LastName = "Nguyen", Password="123456", Email = "huy_nguyen@datahouse.com", Mobile = "09763",
            //                                                                        IsActive = true},
            //                                                user1 = new User {FirstName = "Foo", LastName = "Bar", Password="123456", Email = "user@datahouse.com", Mobile = "5475",
            //                                                                        IsActive = true},
            //                                                user = new User {FirstName = "Nhat", LastName = "Nguyen", Password="123456", Email = "user1@datahouse.com", Mobile = "57476",
            //                                                                        IsActive = true}
            //                                            });
            //modelBuilder.Entity<User>()
            //            .HasMany(p => p.Roles)
            //            .WithMany(p => p.Users)
            //            .UsingEntity(j => j.HasData(new { UsersId = admin.Id, RolesId = managerRole.Id },
            //                                        new { UsersId = user1.Id, RolesId = userRole.Id },
            //                                        new { UsersId = user.Id, RolesId = userRole.Id }));

            //modelBuilder.Entity<UserActivity>().ToTable("UserActivity");
        }
    }
}
