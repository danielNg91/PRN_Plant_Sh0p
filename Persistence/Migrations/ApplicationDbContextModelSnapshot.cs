﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Persistence.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("CartId")
                        .HasColumnType("int")
                        .HasColumnName("cart_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("cart_item");
                });

            modelBuilder.Entity("Persistence.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<string>("DeliveryStatus")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("delivery_status")
                        .IsFixedLength(true);

                    b.Property<bool>("PaymentStatus")
                        .HasColumnType("bit")
                        .HasColumnName("payment_status");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("total");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("order");
                });

            modelBuilder.Entity("Persistence.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("order_item");
                });

            modelBuilder.Entity("Persistence.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("description");

                    b.Property<int?>("DiscountId")
                        .HasColumnType("int")
                        .HasColumnName("discount_id");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("modified_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("price");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DiscountId");

                    b.ToTable("product");
                });

            modelBuilder.Entity("Persistence.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("description");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("modified_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("product_category");
                });

            modelBuilder.Entity("Persistence.Models.ProductDiscount", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("active");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("description");

                    b.Property<decimal>("DiscountPercent")
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("discount_percent");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("product_discount");
                });

            modelBuilder.Entity("Persistence.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("address");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .HasColumnName("email")
                        .IsFixedLength(true);

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("fullname")
                        .IsFixedLength(true);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("modified_at");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .HasColumnName("password")
                        .IsFixedLength(true);

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("telephone")
                        .IsFixedLength(true);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .HasColumnName("username")
                        .IsFixedLength(true);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Persistence.Models.UserCart", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("modified_at");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("total");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("user_cart");
                });

            modelBuilder.Entity("Persistence.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .HasColumnName("role")
                        .IsFixedLength(true);

                    b.HasKey("Id");

                    b.ToTable("user_role");
                });

            modelBuilder.Entity("Persistence.Models.CartItem", b =>
                {
                    b.HasOne("Persistence.Models.UserCart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .HasConstraintName("FK_cart_item_user_cart")
                        .IsRequired();

                    b.HasOne("Persistence.Models.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_cart_item_product")
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Persistence.Models.Order", b =>
                {
                    b.HasOne("Persistence.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_order_user")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Persistence.Models.OrderItem", b =>
                {
                    b.HasOne("Persistence.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_order_item_order")
                        .IsRequired();

                    b.HasOne("Persistence.Models.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_order_item_product")
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Persistence.Models.Product", b =>
                {
                    b.HasOne("Persistence.Models.ProductCategory", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_product_product_category")
                        .IsRequired();

                    b.HasOne("Persistence.Models.ProductDiscount", "Discount")
                        .WithMany("Products")
                        .HasForeignKey("DiscountId")
                        .HasConstraintName("FK_product_product_discount");

                    b.Navigation("Category");

                    b.Navigation("Discount");
                });

            modelBuilder.Entity("Persistence.Models.User", b =>
                {
                    b.HasOne("Persistence.Models.UserRole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_user_user_role")
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Persistence.Models.UserCart", b =>
                {
                    b.HasOne("Persistence.Models.User", "User")
                        .WithMany("UserCarts")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_user_cart_user")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Persistence.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Persistence.Models.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Persistence.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Persistence.Models.ProductDiscount", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Persistence.Models.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("UserCarts");
                });

            modelBuilder.Entity("Persistence.Models.UserCart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("Persistence.Models.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
