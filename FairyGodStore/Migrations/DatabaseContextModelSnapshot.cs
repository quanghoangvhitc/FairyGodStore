﻿// <auto-generated />
using System;
using FairyGodStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FairyGodStore.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FairyGodStore.Models.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("author");

                    b.Property<int>("Chapter")
                        .HasColumnType("int")
                        .HasColumnName("chapter");

                    b.Property<long>("ChapterDate")
                        .HasColumnType("bigint")
                        .HasColumnName("chapterdate");

                    b.Property<long?>("Created")
                        .HasColumnType("bigint")
                        .HasColumnName("created");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("createdby");

                    b.Property<long?>("Modified")
                        .HasColumnType("bigint")
                        .HasColumnName("modified");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("modifiedby");

                    b.Property<long>("Point")
                        .HasColumnType("bigint")
                        .HasColumnName("point");

                    b.Property<int>("PublicationDate")
                        .HasColumnType("int")
                        .HasColumnName("publicationdate");

                    b.Property<string>("SortDescription")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("sortdescription");

                    b.Property<string>("Thumbnail")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("thumbnail");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.Property<long>("Views")
                        .HasColumnType("bigint")
                        .HasColumnName("views");

                    b.Property<long?>("bookCategoryId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("bookCategoryId");

                    b.ToTable("book");
                });

            modelBuilder.Entity("FairyGodStore.Models.BookCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("Created")
                        .HasColumnType("bigint")
                        .HasColumnName("created");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("createdby");

                    b.Property<long?>("Modified")
                        .HasColumnType("bigint")
                        .HasColumnName("modified");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("modifiedby");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("bookcategory");
                });

            modelBuilder.Entity("FairyGodStore.Models.BookComment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BookId")
                        .HasColumnType("bigint")
                        .HasColumnName("bookid");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("content");

                    b.Property<long?>("Created")
                        .HasColumnType("bigint")
                        .HasColumnName("created");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("createdby");

                    b.Property<long>("DisLikeCount")
                        .HasColumnType("bigint")
                        .HasColumnName("dislikecount");

                    b.Property<long>("LikeCount")
                        .HasColumnType("bigint")
                        .HasColumnName("likecount");

                    b.Property<long?>("Modified")
                        .HasColumnType("bigint")
                        .HasColumnName("modified");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("modifiedby");

                    b.Property<long>("ParentId")
                        .HasColumnType("bigint")
                        .HasColumnName("parentid");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("userid");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("bookcomment");
                });

            modelBuilder.Entity("FairyGodStore.Models.BookContent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BookId")
                        .HasColumnType("bigint")
                        .HasColumnName("bookid");

                    b.Property<int>("Chapter")
                        .HasColumnType("int")
                        .HasColumnName("chapter");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("content");

                    b.Property<long?>("Created")
                        .HasColumnType("bigint")
                        .HasColumnName("created");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("createdby");

                    b.Property<long?>("Modified")
                        .HasColumnType("bigint")
                        .HasColumnName("modified");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("modifiedby");

                    b.Property<long>("ReleaseDate")
                        .HasColumnType("bigint")
                        .HasColumnName("releasedate");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("bookcontent");
                });

            modelBuilder.Entity("FairyGodStore.Models.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("content");

                    b.Property<long?>("Created")
                        .HasColumnType("bigint")
                        .HasColumnName("created");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("createdby");

                    b.Property<long>("DisLikeCount")
                        .HasColumnType("bigint")
                        .HasColumnName("dislikecount");

                    b.Property<long>("LikeCount")
                        .HasColumnType("bigint")
                        .HasColumnName("likecount");

                    b.Property<long?>("Modified")
                        .HasColumnType("bigint")
                        .HasColumnName("modified");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("modifiedby");

                    b.Property<long>("ParentId")
                        .HasColumnType("bigint")
                        .HasColumnName("parentid");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("userid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("comment");
                });

            modelBuilder.Entity("FairyGodStore.Models.Favorite", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BookId")
                        .HasColumnType("bigint")
                        .HasColumnName("bookid");

                    b.Property<long?>("Created")
                        .HasColumnType("bigint")
                        .HasColumnName("created");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("createdby");

                    b.Property<long?>("Modified")
                        .HasColumnType("bigint")
                        .HasColumnName("modified");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("modifiedby");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("favorite");
                });

            modelBuilder.Entity("FairyGodStore.Models.Rating", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BookId")
                        .HasColumnType("bigint")
                        .HasColumnName("bookid");

                    b.Property<long?>("Created")
                        .HasColumnType("bigint")
                        .HasColumnName("created");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("createdby");

                    b.Property<long?>("Modified")
                        .HasColumnType("bigint")
                        .HasColumnName("modified");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("modifiedby");

                    b.Property<double>("Point")
                        .HasColumnType("float")
                        .HasColumnName("point");

                    b.Property<long?>("userId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("userId");

                    b.ToTable("rating");
                });

            modelBuilder.Entity("FairyGodStore.Models.Report", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BookId")
                        .HasColumnType("bigint")
                        .HasColumnName("bookid");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("content");

                    b.Property<long?>("Created")
                        .HasColumnType("bigint")
                        .HasColumnName("created");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("createdby");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<long?>("Modified")
                        .HasColumnType("bigint")
                        .HasColumnName("modified");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("modifiedby");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("report");
                });

            modelBuilder.Entity("FairyGodStore.Models.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("Created")
                        .HasColumnType("bigint")
                        .HasColumnName("created");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("createdby");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<long?>("Modified")
                        .HasColumnType("bigint")
                        .HasColumnName("modified");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("modifiedby");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("FairyGodStore.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("avatar");

                    b.Property<long?>("Created")
                        .HasColumnType("bigint")
                        .HasColumnName("created");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("createdby");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("fullname");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("gender");

                    b.Property<string>("IdentityCard")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("identitycard");

                    b.Property<long?>("Modified")
                        .HasColumnType("bigint")
                        .HasColumnName("modified");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("modifiedby");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phonenumber");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<long>("RolesId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsersId")
                        .HasColumnType("bigint");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("FairyGodStore.Models.Book", b =>
                {
                    b.HasOne("FairyGodStore.Models.BookCategory", "bookCategory")
                        .WithMany("books")
                        .HasForeignKey("bookCategoryId");

                    b.Navigation("bookCategory");
                });

            modelBuilder.Entity("FairyGodStore.Models.BookComment", b =>
                {
                    b.HasOne("FairyGodStore.Models.Book", "book")
                        .WithMany("BookComments")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book");
                });

            modelBuilder.Entity("FairyGodStore.Models.BookContent", b =>
                {
                    b.HasOne("FairyGodStore.Models.Book", "book")
                        .WithMany("BookContents")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book");
                });

            modelBuilder.Entity("FairyGodStore.Models.Comment", b =>
                {
                    b.HasOne("FairyGodStore.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FairyGodStore.Models.Favorite", b =>
                {
                    b.HasOne("FairyGodStore.Models.Book", "book")
                        .WithMany("Favorites")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FairyGodStore.Models.User", null)
                        .WithMany("Favorites")
                        .HasForeignKey("UserId");

                    b.Navigation("book");
                });

            modelBuilder.Entity("FairyGodStore.Models.Rating", b =>
                {
                    b.HasOne("FairyGodStore.Models.Book", "book")
                        .WithMany("Ratings")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FairyGodStore.Models.User", "user")
                        .WithMany("Ratings")
                        .HasForeignKey("userId");

                    b.Navigation("book");

                    b.Navigation("user");
                });

            modelBuilder.Entity("FairyGodStore.Models.Report", b =>
                {
                    b.HasOne("FairyGodStore.Models.Book", "book")
                        .WithMany("Reports")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FairyGodStore.Models.User", null)
                        .WithMany("Reports")
                        .HasForeignKey("UserId");

                    b.Navigation("book");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("FairyGodStore.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FairyGodStore.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FairyGodStore.Models.Book", b =>
                {
                    b.Navigation("BookComments");

                    b.Navigation("BookContents");

                    b.Navigation("Favorites");

                    b.Navigation("Ratings");

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("FairyGodStore.Models.BookCategory", b =>
                {
                    b.Navigation("books");
                });

            modelBuilder.Entity("FairyGodStore.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Favorites");

                    b.Navigation("Ratings");

                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
