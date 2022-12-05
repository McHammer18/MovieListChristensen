using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MovieListChristensen.Models
{
    public class MovieContext : IdentityDbContext<User>
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = "A", Name = "Action" },
                new Genre { GenreId = "C", Name = "Comedy" },
                new Genre { GenreId = "D", Name = "Drama" },
                new Genre { GenreId = "H", Name = "Horror" },
                new Genre { GenreId = "M", Name = "Musical" },
                new Genre { GenreId = "R", Name = "RomCom" },
                new Genre { GenreId = "S", Name = "SciFi" }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    Name = "Casablanca",
                    Year = 1943,
                    Rating = 5,
                    GenreId = "D"
                },
                new Movie
                {
                    MovieId = 2,
                    Name = "Wonder Woman",
                    Year = 2017,
                    Rating = 3,
                    GenreId = "A"
                },
                new Movie
                {
                    MovieId = 3,
                    Name = "Moonstruck",
                    Year = 1988,
                    Rating = 4,
                    GenreId = "R"
                }
            );
        }

        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            using (var scoped = serviceProvider.CreateScope())
            {
                UserManager<User> userManager = scoped.ServiceProvider.GetRequiredService<UserManager<User>>();
                RoleManager<IdentityRole> roleManager = scoped.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                string username = "admin";
                string pwd = "admin";
                string roleName = "Admin";

                if (await roleManager.FindByIdAsync(roleName) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
                if (await userManager.FindByIdAsync(username) == null)
                {
                    User user = new User() { UserName = username };
                    var result = await userManager.CreateAsync(user, pwd);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, roleName);
                    }
                }
            }

        }
    }
}
