using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nether.Data.MySql.Identity.Migrations
{
    [DbContext(typeof(MySqlIdentityContext))]
    [Migration("20170314100203_InitialIdentityContextMigration")]
    partial class InitialIdentityContextMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Nether.Data.EntityFramework.Identity.LoginEntity", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(50);

                    b.Property<string>("ProviderType")
                        .HasMaxLength(50);

                    b.Property<string>("ProviderId")
                        .HasMaxLength(50);

                    b.Property<string>("ProviderData");

                    b.HasKey("UserId", "ProviderType", "ProviderId");

                    b.ToTable("Logins");

                    b.HasAnnotation("MySql:TableName", "UserLogins");
                });

            modelBuilder.Entity("Nether.Data.EntityFramework.Identity.UserEntity", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasAnnotation("MySql:TableName", "Users");
                });

            modelBuilder.Entity("Nether.Data.EntityFramework.Identity.LoginEntity", b =>
                {
                    b.HasOne("Nether.Data.EntityFramework.Identity.UserEntity", "User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
