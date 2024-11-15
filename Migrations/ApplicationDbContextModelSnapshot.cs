﻿// <auto-generated />
using System;
using FPT_JOBPORTAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASM2_FPTJobMatch.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FPT_JOBPORTAL.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("FPT_JOBPORTAL.CategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CategoryModel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A Back End Developer is responsible for server-side application logic and integration of the work front-end developers do.",
                            Name = "Back-End Developer",
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            Description = "A Front End Developer is focused on the user interface and user experience of a website or application.",
                            Name = "Front-End Developer",
                            Status = 0
                        },
                        new
                        {
                            Id = 3,
                            Description = "A Full Stack Developer is capable of working on both the front-end and back-end portions of an application.",
                            Name = "Full Stack Developer",
                            Status = 0
                        },
                        new
                        {
                            Id = 4,
                            Description = "A Mobile Apps Developer is specialized in creating applications for mobile devices, such as smartphones and tablets.",
                            Name = "Mobile Apps Developer",
                            Status = 0
                        },
                        new
                        {
                            Id = 5,
                            Description = "A Product Manager is responsible for the strategy, roadmap, and feature definition of a product.",
                            Name = "Product Manager",
                            Status = 0
                        },
                        new
                        {
                            Id = 6,
                            Description = "A Python Developer uses the Python programming language for developing software solutions.",
                            Name = "Python Developer",
                            Status = 0
                        },
                        new
                        {
                            Id = 7,
                            Description = "A System Administrator manages and maintains the operations of computer systems and networks.",
                            Name = "System Administrator",
                            Status = 0
                        },
                        new
                        {
                            Id = 8,
                            Description = "A Tester tests software to ensure it meets requirements and is free of bugs and defects.",
                            Name = "Tester",
                            Status = 0
                        },
                        new
                        {
                            Id = 9,
                            Description = "A C++ Developer uses the C++ programming language for developing software solutions.",
                            Name = "C++ Developer",
                            Status = 0
                        },
                        new
                        {
                            Id = 10,
                            Description = "A Software Architect designs and creates the overall structure of a software system.",
                            Name = "Software Architect",
                            Status = 0
                        });
                });

            modelBuilder.Entity("FPT_JOBPORTAL.JobModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatePost")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescriptionJob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameJob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Requirement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Salary")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("JobModel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 4,
                            Company = "MegaTechnology",
                            DatePost = new DateTime(2024, 8, 23, 0, 0, 0, 0, DateTimeKind.Utc),
                            DescriptionJob = "Join our mobile development team to create innovative and user-friendly mobile applications for iOS and Android platforms.",
                            NameJob = "Mobile Apps Developer",
                            Requirement = "Experience in mobile app development using Swift or Kotlin, familiarity with mobile UI/UX principles, ability to adapt to new technologies.",
                            Salary = 95000.0,
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            Company = "MegaTechnology",
                            DatePost = new DateTime(2024, 8, 23, 0, 0, 0, 0, DateTimeKind.Utc),
                            DescriptionJob = "We're seeking a Full Stack Developer to work on both front-end and back-end components of our applications.",
                            NameJob = "Full Stack Developer",
                            Requirement = "Proficiency in both front-end and back-end technologies, experience with frameworks such as React and Node.js, ability to work in a fast-paced environment.",
                            Salary = 95000.0,
                            Status = 0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Company = "MegaTechnology",
                            DatePost = new DateTime(2024, 8, 23, 0, 0, 0, 0, DateTimeKind.Utc),
                            DescriptionJob = "Exciting opportunity for a Front End Developer Intern to gain hands-on experience in building user interfaces and enhancing user experiences.",
                            NameJob = "Front End Developer Intern",
                            Requirement = "Basic understanding of HTML, CSS, and JavaScript, eager to learn and contribute to front-end development projects.",
                            Salary = 25000.0,
                            Status = 0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Company = "MegaTechnology",
                            DatePost = new DateTime(2024, 8, 23, 0, 0, 0, 0, DateTimeKind.Utc),
                            DescriptionJob = "Join our team as a Senior Back End Developer to lead server-side application logic and integration efforts.",
                            NameJob = "Senior Back End Developer",
                            Requirement = "5+ years of experience in back-end development, proficiency in relevant technologies such as Node.js, Python, or Java, strong understanding of databases and API design.",
                            Salary = 95000.0,
                            Status = 0
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 5,
                            Company = "MegaTechnology",
                            DatePost = new DateTime(2024, 8, 23, 0, 0, 0, 0, DateTimeKind.Utc),
                            DescriptionJob = "We're looking for a Product Manager to drive the strategy and development of our product offerings.",
                            NameJob = "Product Manager",
                            Requirement = "Strong leadership and communication skills, experience in product management, ability to prioritize and manage multiple projects.",
                            Salary = 110000.0,
                            Status = 0
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FPT_JOBPORTAL.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("FPT_JOBPORTAL.Application", b =>
                {
                    b.HasOne("FPT_JOBPORTAL.JobModel", "Job")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("FPT_JOBPORTAL.JobModel", b =>
                {
                    b.HasOne("FPT_JOBPORTAL.CategoryModel", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
