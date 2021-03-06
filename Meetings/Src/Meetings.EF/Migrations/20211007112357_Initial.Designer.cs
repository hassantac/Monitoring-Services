// <auto-generated />
using System;
using Meetings.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Meetings.EF.Migrations
{
    [DbContext(typeof(MeetingsContext))]
    [Migration("20211007112357_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Meetings.DTO.DbModels.CalenderEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BodyContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExtendedClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExtendedGrade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExtendedSchool")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExtendedSubject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("CalenderEvents");
                });

            modelBuilder.Entity("Meetings.DTO.DbModels.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Meetings.DTO.DbModels.UserEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Event_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("User_Id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Event_Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("User_Id");

                    b.ToTable("UserEvents");
                });

            modelBuilder.Entity("Meetings.DTO.DbModels.UserEvent", b =>
                {
                    b.HasOne("Meetings.DTO.DbModels.CalenderEvent", "CalenderEvent")
                        .WithMany("UserEvents")
                        .HasForeignKey("Event_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Meetings.DTO.DbModels.User", "User")
                        .WithMany("UserEvents")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CalenderEvent");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Meetings.DTO.DbModels.CalenderEvent", b =>
                {
                    b.Navigation("UserEvents");
                });

            modelBuilder.Entity("Meetings.DTO.DbModels.User", b =>
                {
                    b.Navigation("UserEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
