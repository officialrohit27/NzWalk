using System;
using Microsoft.EntityFrameworkCore;
using NzWalkApi.Models.Domain;

namespace NzWalkApi.Data
{
	public class NZWalksDBContext : DbContext
	{
		public NZWalksDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
		{

		}

		public DbSet<Difficulty> Difficulties {get; set;}

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var diffulcitiies = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id= Guid.Parse("b9565e95-ce9a-4d0e-9fc3-679f3d37b70b"),
                    Name= "Easy"
                },
                new Difficulty()
                {
                    Id= Guid.Parse("08420fab-39c1-4af2-a7d3-566f22d0937c"),
                    Name= "Medium"
                },
                new Difficulty()
                {
                    Id= Guid.Parse("e4426939-7f46-49d7-a867-f98f34431475"),
                    Name= "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(diffulcitiies);

            var regions = new List<Region>()
            {
                new Region()
                {
                    Id=Guid.Parse("760b8e00-296a-4377-b7e2-2994636c744d"),
                    Name = "Auckland",
                    Code= "AKL",
                    RegionImageURL = "https://fastly.picsum.photos/id/11/2500/1667.jpg?hmac=xxjFJtAPgshYkysU_aqx2sZir-kIOjNR9vx0te7GycQ"
                },
                new Region()
                {
                    Id=Guid.Parse("5ff6a69c-e3c5-4b68-8d0e-b7606c8fb06c"),
                    Name = "Wellington",
                    Code= "WGN",
                    RegionImageURL = "https://fastly.picsum.photos/id/14/2500/1667.jpg?hmac=ssQyTcZRRumHXVbQAVlXTx-MGBxm6NHWD3SryQ48G-o"
                },
                new Region()
                {
                    Id=Guid.Parse("24f6e360-cad2-4434-8243-efc362f40bf6"),
                    Name = "Nelson",
                    Code= "NSN",
                    RegionImageURL = "https://fastly.picsum.photos/id/17/2500/1667.jpg?hmac=HD-JrnNUZjFiP2UZQvWcKrgLoC_pc_ouUSWv8kHsJJY"
                },
                new Region()
                {
                    Id=Guid.Parse("edb31812-6be2-48c8-82f6-bd824433ea31"),
                    Name = "Nelson",
                    Code= "NSN",
                    RegionImageURL = "https://fastly.picsum.photos/id/15/2500/1667.jpg?hmac=Lv03D1Y3AsZ9L2tMMC1KQZekBVaQSDc1waqJ54IHvo4"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }

    }
}

