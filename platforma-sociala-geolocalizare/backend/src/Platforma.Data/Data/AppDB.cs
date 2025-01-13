using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Location> Locations { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed Users
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Email = "user1@example.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("password") },
            new User { Id = 2, Email = "user2@example.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("password") }
        );

        // Seed Locations
        modelBuilder.Entity<Location>().HasData(
            new Location { Id = 1, Name = "Eiffel Tower", Latitude = 48.858844, Longitude = 2.294351 },
            new Location { Id = 2, Name = "Great Wall of China", Latitude = 40.431908, Longitude = 116.570374 }
        );

        // Seed Reviews
        modelBuilder.Entity<Review>().HasData(
            new Review { Id = 1, Content = "Amazing experience!", Rating = 5, LocationId = 1, UserId = 1 },
            new Review { Id = 2, Content = "A must-visit landmark.", Rating = 5, LocationId = 1, UserId = 2 },
            new Review { Id = 3, Content = "Breathtaking views.", Rating = 4, LocationId = 2, UserId = 1 }
        );
    }
}
