﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PizzaPlace.BlazorServer.Data;

#nullable disable

namespace PizzaPlace.BlazorServer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231130092012_addedFullAddressToOrder")]
    partial class addedFullAddressToOrder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PizzaPlace.BlazorServer.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("PizzaPlace.BlazorServer.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("PizzaPlace.BlazorServer.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("PizzaPlace.BlazorServer.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ChefId")
                        .HasColumnType("text");

                    b.Property<string>("DeliveryId")
                        .HasColumnType("text");

                    b.Property<float>("DiscountedPrice")
                        .HasColumnType("real");

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("TimeDelivered")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("TimeOrdered")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("TimeProduced")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChefId");

                    b.HasIndex("DeliveryId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaPlace.BlazorServer.Models.OrderProduct", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("PizzaPlace.BlazorServer.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("DiscountedPrice")
                        .HasColumnType("real");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1877),
                            DiscountedPrice = 0f,
                            Ingredients = "Tomato, Mozzarella, Basil",
                            IsArchived = false,
                            IsDeleted = false,
                            Name = "Margherita",
                            Price = 10f
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1887),
                            DiscountedPrice = 0f,
                            Ingredients = "Tomato, Mozzarella, Pepperoni",
                            IsArchived = false,
                            IsDeleted = false,
                            Name = "Pepperoni",
                            Price = 12f
                        },
                        new
                        {
                            Id = 3,
                            DateCreated = new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1889),
                            DiscountedPrice = 0f,
                            Ingredients = "Tomato, Mozzarella, Ham, Pineapple",
                            IsArchived = false,
                            IsDeleted = false,
                            Name = "Hawaiian",
                            Price = 13f
                        },
                        new
                        {
                            Id = 4,
                            DateCreated = new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1890),
                            DiscountedPrice = 0f,
                            Ingredients = "BBQ Sauce, Mozzarella, Chicken, Red Onion",
                            IsArchived = false,
                            IsDeleted = false,
                            Name = "BBQ Chicken",
                            Price = 14f
                        },
                        new
                        {
                            Id = 5,
                            DateCreated = new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1891),
                            DiscountedPrice = 0f,
                            Ingredients = "Tomato, Mozzarella, Pepperoni, Ham, Bacon, Sausage",
                            IsArchived = false,
                            IsDeleted = false,
                            Name = "Meat Lover",
                            Price = 15f
                        },
                        new
                        {
                            Id = 6,
                            DateCreated = new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1894),
                            DiscountedPrice = 0f,
                            Ingredients = "Tomato, Mozzarella, Bell Pepper, Onion, Mushroom, Olives",
                            IsArchived = false,
                            IsDeleted = false,
                            Name = "Veggie",
                            Price = 13f
                        },
                        new
                        {
                            Id = 7,
                            DateCreated = new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1895),
                            DiscountedPrice = 0f,
                            Ingredients = "Tomato, Mozzarella, Mushroom",
                            IsArchived = false,
                            IsDeleted = false,
                            Name = "Mushroom",
                            Price = 12f
                        },
                        new
                        {
                            Id = 8,
                            DateCreated = new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1896),
                            DiscountedPrice = 0f,
                            Ingredients = "Tomato, Mozzarella, Cheddar, Feta, Parmesan",
                            IsArchived = false,
                            IsDeleted = false,
                            Name = "Four Cheese",
                            Price = 14f
                        },
                        new
                        {
                            Id = 9,
                            DateCreated = new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1897),
                            DiscountedPrice = 0f,
                            Ingredients = "Buffalo Sauce, Mozzarella, Chicken, Celery",
                            IsArchived = false,
                            IsDeleted = false,
                            Name = "Buffalo Chicken",
                            Price = 14f
                        },
                        new
                        {
                            Id = 10,
                            DateCreated = new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1898),
                            DiscountedPrice = 0f,
                            Ingredients = "Tomato, Mozzarella, Pepperoni, Bell Pepper, Onion, Mushroom, Olives, Sausage",
                            IsArchived = false,
                            IsDeleted = false,
                            Name = "Supreme",
                            Price = 16f
                        },
                        new
                        {
                            Id = 11,
                            DateCreated = new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1900),
                            DiscountedPrice = 0f,
                            Ingredients = "Alfredo Sauce, Mozzarella, Chicken",
                            IsArchived = false,
                            IsDeleted = false,
                            Name = "Chicken Alfredo",
                            Price = 14f
                        },
                        new
                        {
                            Id = 12,
                            DateCreated = new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1901),
                            DiscountedPrice = 0f,
                            Ingredients = "Olive Oil, Mozzarella, Tomato, Basil",
                            IsArchived = false,
                            IsDeleted = false,
                            Name = "White Pizza",
                            Price = 13f
                        },
                        new
                        {
                            Id = 13,
                            DateCreated = new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1902),
                            DiscountedPrice = 0f,
                            Ingredients = "Olive Oil, Mozzarella, Shrimp, Garlic",
                            IsArchived = false,
                            IsDeleted = false,
                            Name = "Shrimp Scampi",
                            Price = 16f
                        },
                        new
                        {
                            Id = 14,
                            DateCreated = new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1903),
                            DiscountedPrice = 0f,
                            Ingredients = "Tomato, Mozzarella, Steak, Bell Pepper, Onion",
                            IsArchived = false,
                            IsDeleted = false,
                            Name = "Philly Cheesesteak",
                            Price = 15f
                        },
                        new
                        {
                            Id = 15,
                            DateCreated = new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1904),
                            DiscountedPrice = 0f,
                            Ingredients = "Tomato, Mozzarella, Ground Beef, Tomato, Lettuce, Cheddar",
                            IsArchived = false,
                            IsDeleted = false,
                            Name = "Taco Pizza",
                            Price = 14f
                        },
                        new
                        {
                            Id = 16,
                            DateCreated = new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1905),
                            DiscountedPrice = 0f,
                            Ingredients = "Tomato, Mozzarella, Sausage",
                            IsArchived = false,
                            IsDeleted = false,
                            Name = "Sausage",
                            Price = 12f
                        },
                        new
                        {
                            Id = 17,
                            DateCreated = new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1949),
                            DiscountedPrice = 0f,
                            Ingredients = "Tomato, Mozzarella, Chicken, Garlic",
                            IsArchived = false,
                            IsDeleted = false,
                            Name = "Garlic Chicken",
                            Price = 14f
                        },
                        new
                        {
                            Id = 18,
                            DateCreated = new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1951),
                            DiscountedPrice = 0f,
                            Ingredients = "Tomato, Mozzarella, Spinach, Feta",
                            IsArchived = false,
                            IsDeleted = false,
                            Name = "Spinach and Feta",
                            Price = 13f
                        },
                        new
                        {
                            Id = 19,
                            DateCreated = new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1952),
                            DiscountedPrice = 0f,
                            Ingredients = "Pesto Sauce, Mozzarella, Bell Pepper, Onion, Mushroom, Olives",
                            IsArchived = false,
                            IsDeleted = false,
                            Name = "Pesto Veggie",
                            Price = 14f
                        },
                        new
                        {
                            Id = 20,
                            DateCreated = new DateTime(2023, 11, 30, 9, 20, 11, 908, DateTimeKind.Utc).AddTicks(1954),
                            DiscountedPrice = 0f,
                            Ingredients = "Ranch Sauce, Mozzarella, Bacon, Chicken",
                            IsArchived = false,
                            IsDeleted = false,
                            Name = "Bacon Ranch",
                            Price = 14f
                        });
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
                    b.HasOne("PizzaPlace.BlazorServer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PizzaPlace.BlazorServer.Models.ApplicationUser", null)
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

                    b.HasOne("PizzaPlace.BlazorServer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PizzaPlace.BlazorServer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaPlace.BlazorServer.Models.Address", b =>
                {
                    b.HasOne("PizzaPlace.BlazorServer.Models.ApplicationUser", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PizzaPlace.BlazorServer.Models.Feedback", b =>
                {
                    b.HasOne("PizzaPlace.BlazorServer.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("PizzaPlace.BlazorServer.Models.Order", b =>
                {
                    b.HasOne("PizzaPlace.BlazorServer.Models.ApplicationUser", "Chef")
                        .WithMany("ChefOrders")
                        .HasForeignKey("ChefId");

                    b.HasOne("PizzaPlace.BlazorServer.Models.ApplicationUser", "Delivery")
                        .WithMany("DeliveryOrders")
                        .HasForeignKey("DeliveryId");

                    b.HasOne("PizzaPlace.BlazorServer.Models.ApplicationUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chef");

                    b.Navigation("Delivery");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PizzaPlace.BlazorServer.Models.OrderProduct", b =>
                {
                    b.HasOne("PizzaPlace.BlazorServer.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaPlace.BlazorServer.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PizzaPlace.BlazorServer.Models.ApplicationUser", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("ChefOrders");

                    b.Navigation("DeliveryOrders");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PizzaPlace.BlazorServer.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("PizzaPlace.BlazorServer.Models.Product", b =>
                {
                    b.Navigation("OrderProducts");
                });
#pragma warning restore 612, 618
        }
    }
}