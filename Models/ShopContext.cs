using Microsoft.EntityFrameworkCore;

namespace TestTask.Models
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>().HasData(
                new Shop[]
                {
                new Shop { Id=1, Name="Honda", WorkHours="8:00 a.m. to 6:00 p.m.", Adress = "Minsk, Menkovsky tract 2"},
                new Shop { Id=2, Name="Ford", WorkHours="9:00 a.m. to 9:00 p.m.", Adress = "Minsk, Nekrasova street, 73, 3rd floor, room. 44"},
                new Shop { Id=3, Name="BMW", WorkHours="8:30 a.m. to 8:00 p.m.", Adress = "Minsk, Matusevich street 42a"},
                new Shop { Id=4, Name="KIA Motors", WorkHours="10:00 a.m. to 7:00 p.m.", Adress = "Minsk, Vaneeva street 42/2"},
                new Shop { Id=5, Name="Bentley", WorkHours="9:00 a.m. to 6:00 p.m.",  Adress = "Minsk, Storozhovskaya street 6"},
                });
            modelBuilder.Entity<Product>().HasData(
                new Product[]
                {
                new Product { Id=1, Name="HR-V", ShopId = 1, Description = "Real Time AWD with Intelligent Control System allows the HR-V to proactively send power to the rear wheels, helping prevent traction loss during inclement weather or on unreliable surfaces. It’s yet another HR-V feature designed to provide confidence and peace of mind"},
                new Product { Id=2, Name="Accord", ShopId = 1, Description = "With a 48 city/48 highway EPA mpg rating and electrifying driving dynamics, the Accord Hybrid is an ingenious fusion of efficiency and performance."},
                new Product { Id=3, Name="Civic Hatchback", ShopId = 1, Description = "With precise handling and powerful acceleration, the Civic Hatchback responds enthusiastically to your driving impulses. Pair the responsive CVT or available 6-speed manual transmission with the available 180-horsepower"},
                new Product { Id=4, Name="Focus", ShopId = 2, Description = "Compact sedan currently marketed in China and Eastern Europe. The previous generations of Focus sedan has been sold globally, including in Europe, the Americas and Asia-Pacific markets."},
                new Product { Id=5, Name="Taurus", ShopId = 2, Description = "Full-size sedan currently only marketed in China. The Taurus nameplate has been used since 1986. The China-only Taurus is available since 2015, while the North American version was discontinued in 2019."},
                new Product { Id=6, Name="GT", ShopId = 2, Description = "Limited production rear-mid-engined sports car inspired by the Ford GT40 from the 1960s."},
                new Product { Id=7, Name="X7", ShopId = 3, Description = "Full-size luxury SUV"},
                new Product { Id=8, Name="X4", ShopId = 3, Description = "Compact luxury SUV"},
                new Product { Id=9, Name="X5", ShopId = 3, Description = "Mid-size luxury SUV"},
                new Product { Id=10, Name="Soul", ShopId = 4, Description = "With high-tech features and available turbocharged engine, the Soul is a marvel of adaptability."},
                new Product { Id=11, Name="Rio", ShopId = 4, Description = "The convention-breaking Rio continues to evolve, packing new technology and smart style into a practical subcompact sedan, all at an affordable price."},
                new Product { Id=12, Name="Stinger", ShopId = 4, Description = "Stand out in the perfect balance of power and refinement. With new standard equipment like a 300 horsepower 2.5L turbocharged engine, a 10.25-inch touch screen console, updated exterior design, and new Stinger Scorpion special edition the Stinger delivers high performance and supreme comfort on the open road."},
                new Product { Id=13, Name="Continental GT", ShopId = 5, Description = "No matter if you choose the hardtop coupe or softtop convertible the 2021 Bentley Continental GT will make you feel like a celebrity."},
                new Product { Id=14, Name="Flying Spur", ShopId = 5, Description = "For some, pulling up in a luxury car is reward enough, but for a lucky few, nothing short of an ultra-exclusive ride like the 2022 Bentley Flying Spur will do."},
                new Product { Id=15, Name="Mulsanne", ShopId = 5, Description = "The Mulsanne rewards those with means with its positively palatial cabin and an aristocratic pedigree that commands unrivaled prestige."},
                });
        }
    }
}
