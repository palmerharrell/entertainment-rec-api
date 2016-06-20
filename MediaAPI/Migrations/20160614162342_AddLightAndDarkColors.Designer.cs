using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MediaAPI.Models;

namespace MediaAPI.Migrations
{
    [DbContext(typeof(MediaDbContext))]
    [Migration("20160614162342_AddLightAndDarkColors")]
    partial class AddLightAndDarkColors
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MediaAPI.Models.AppUser", b =>
                {
                    b.Property<int>("IdAppUser")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Username");

                    b.HasKey("IdAppUser");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("MediaAPI.Models.MediaItem", b =>
                {
                    b.Property<int>("IdMediaItem")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAdded");

                    b.Property<bool>("Favorite");

                    b.Property<bool>("Finished");

                    b.Property<int>("IdAppUser");

                    b.Property<int>("IdMediaType");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<int>("Rating");

                    b.Property<string>("Recommender");

                    b.HasKey("IdMediaItem");

                    b.HasIndex("IdAppUser");

                    b.HasIndex("IdMediaType");

                    b.ToTable("MediaItem");
                });

            modelBuilder.Entity("MediaAPI.Models.MediaType", b =>
                {
                    b.Property<int>("IdMediaType")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ColorDark");

                    b.Property<string>("ColorLight");

                    b.Property<string>("Name");

                    b.HasKey("IdMediaType");

                    b.ToTable("MediaType");
                });

            modelBuilder.Entity("MediaAPI.Models.MediaItem", b =>
                {
                    b.HasOne("MediaAPI.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("IdAppUser")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MediaAPI.Models.MediaType")
                        .WithMany()
                        .HasForeignKey("IdMediaType")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
