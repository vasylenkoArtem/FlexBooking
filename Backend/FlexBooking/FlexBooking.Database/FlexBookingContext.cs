using FlexBooking.Domain.Data;
using FlexBooking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FlexBooking.Domain;

public interface IFlexBookingContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<OfferLocation> OfferLocations { get; set; }    
    public DbSet<BookingOffer> BookingOffers { get; set; }
    public DbSet<HotelOffer> HotelOffers { get; set; }
    public DbSet<CarOffer> CarOffers { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    
    public int SaveChanges();
    public Task<int> SaveChangesAsync();
    public DbSet<TEntity> Set<TEntity>() where TEntity : class;
    public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
}

public class FlexBookingContext: DbContext, IFlexBookingContext
{
    public FlexBookingContext()
    {
        
    }
    
    public FlexBookingContext(DbContextOptions<FlexBookingContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<User>? Users { get; set; }
    public DbSet<OfferLocation> OfferLocations { get; set; }    
    public DbSet<BookingOffer> BookingOffers { get; set; }
    public DbSet<HotelOffer> HotelOffers { get; set; }
    public DbSet<CarOffer> CarOffers { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //TODO: Move connection string to config
        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=FlexBooking; Trusted_Connection=True;Encrypt = false;");
        //TODO: Enable logging only in development
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.LogTo(Console.WriteLine);
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        PrePopulatedData.Populate(modelBuilder);
    }
    
    public int SaveChanges()
    {
        return base.SaveChanges();
    }
    
    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }

    public DbSet<TEntity> Set<TEntity>() where TEntity : class
    {
        return base.Set<TEntity>();
    }

    public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
    {
        return base.Entry(entity);
    }
}