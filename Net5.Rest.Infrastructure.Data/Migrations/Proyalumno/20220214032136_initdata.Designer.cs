﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Net5.Rest.Infrastructure.Data.Contexts;

namespace Net5.Rest.Infrastructure.Data.Migrations.Proyalumno
{
    [DbContext(typeof(ProyalumnoContext))]
    [Migration("20220214032136_initdata")]
    partial class initdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Net5.Rest.Infrastructure.Data.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("CourseID");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("DepartmentID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CourseId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Net5.Rest.Infrastructure.Data.Entities.CourseInstructor", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("CourseID");

                    b.Property<int>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("PersonID");

                    b.HasKey("CourseId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("CourseInstructor");
                });

            modelBuilder.Entity("Net5.Rest.Infrastructure.Data.Entities.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("DepartmentID");

                    b.Property<int?>("Administrator")
                        .HasColumnType("int");

                    b.Property<decimal>("Budget")
                        .HasColumnType("money");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Net5.Rest.Infrastructure.Data.Entities.OfficeAssignment", b =>
                {
                    b.Property<int>("InstructorId")
                        .HasColumnType("int")
                        .HasColumnName("InstructorID");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("InstructorId");

                    b.ToTable("OfficeAssignment");
                });

            modelBuilder.Entity("Net5.Rest.Infrastructure.Data.Entities.OnlineCourse", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("CourseID");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("URL");

                    b.HasKey("CourseId");

                    b.ToTable("OnlineCourse");
                });

            modelBuilder.Entity("Net5.Rest.Infrastructure.Data.Entities.OnsiteCourse", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("CourseID");

                    b.Property<string>("Days")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("smalldatetime");

                    b.HasKey("CourseId");

                    b.ToTable("OnsiteCourse");
                });

            modelBuilder.Entity("Net5.Rest.Infrastructure.Data.Entities.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PersonID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("EnrollmentDate")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PersonId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Net5.Rest.Infrastructure.Data.Entities.StudentGrade", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EnrollmentID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("CourseID");

                    b.Property<decimal?>("Grade")
                        .HasColumnType("decimal(3,2)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("StudentID");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentGrade");
                });

            modelBuilder.Entity("Net5.Rest.Infrastructure.Data.Entities.Course", b =>
                {
                    b.HasOne("Net5.Rest.Infrastructure.Data.Entities.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK_Course_Department")
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Net5.Rest.Infrastructure.Data.Entities.CourseInstructor", b =>
                {
                    b.HasOne("Net5.Rest.Infrastructure.Data.Entities.Course", "Course")
                        .WithMany("CourseInstructors")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK_CourseInstructor_Course")
                        .IsRequired();

                    b.HasOne("Net5.Rest.Infrastructure.Data.Entities.Person", "Person")
                        .WithMany("CourseInstructors")
                        .HasForeignKey("PersonId")
                        .HasConstraintName("FK_CourseInstructor_Person")
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Net5.Rest.Infrastructure.Data.Entities.OfficeAssignment", b =>
                {
                    b.HasOne("Net5.Rest.Infrastructure.Data.Entities.Person", "Instructor")
                        .WithOne("OfficeAssignment")
                        .HasForeignKey("Net5.Rest.Infrastructure.Data.Entities.OfficeAssignment", "InstructorId")
                        .HasConstraintName("FK_OfficeAssignment_Person")
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Net5.Rest.Infrastructure.Data.Entities.OnlineCourse", b =>
                {
                    b.HasOne("Net5.Rest.Infrastructure.Data.Entities.Course", "Course")
                        .WithOne("OnlineCourse")
                        .HasForeignKey("Net5.Rest.Infrastructure.Data.Entities.OnlineCourse", "CourseId")
                        .HasConstraintName("FK_OnlineCourse_Course")
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Net5.Rest.Infrastructure.Data.Entities.OnsiteCourse", b =>
                {
                    b.HasOne("Net5.Rest.Infrastructure.Data.Entities.Course", "Course")
                        .WithOne("OnsiteCourse")
                        .HasForeignKey("Net5.Rest.Infrastructure.Data.Entities.OnsiteCourse", "CourseId")
                        .HasConstraintName("FK_OnsiteCourse_Course")
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Net5.Rest.Infrastructure.Data.Entities.StudentGrade", b =>
                {
                    b.HasOne("Net5.Rest.Infrastructure.Data.Entities.Course", "Course")
                        .WithMany("StudentGrades")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK_StudentGrade_Course")
                        .IsRequired();

                    b.HasOne("Net5.Rest.Infrastructure.Data.Entities.Person", "Student")
                        .WithMany("StudentGrades")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK_StudentGrade_Student")
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Net5.Rest.Infrastructure.Data.Entities.Course", b =>
                {
                    b.Navigation("CourseInstructors");

                    b.Navigation("OnlineCourse");

                    b.Navigation("OnsiteCourse");

                    b.Navigation("StudentGrades");
                });

            modelBuilder.Entity("Net5.Rest.Infrastructure.Data.Entities.Department", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Net5.Rest.Infrastructure.Data.Entities.Person", b =>
                {
                    b.Navigation("CourseInstructors");

                    b.Navigation("OfficeAssignment");

                    b.Navigation("StudentGrades");
                });
#pragma warning restore 612, 618
        }
    }
}
