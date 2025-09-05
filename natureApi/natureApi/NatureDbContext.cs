using Microsoft.EntityFrameworkCore;
using StoreApi.Models.Entities;

namespace NatureApi;

public class NatureDbContext : DbContext
{

    public DbSet<Place> Place { get; set; }
    public DbSet<Trail> Trail { get; set; }
    public DbSet<Photo> Photo { get; set; }
    public DbSet<Review> Review { get; set; }
    public DbSet<Amenity> Amenity { get; set; }
    public DbSet<PlaceAmenity> PlaceAmenity { get; set; }

    public NatureDbContext(DbContextOptions<NatureDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<PlaceAmenity>()
            .HasKey(pa => new { pa.PlaceId, pa.AmenityId });


        modelBuilder.Entity<Amenity>().HasData(
            new Amenity { Id = 1, Name = "Baños" },
            new Amenity { Id = 2, Name = "Estacionamiento" },
            new Amenity { Id = 3, Name = "Mirador" },
            new Amenity { Id = 4, Name = "Área de comida" },
            new Amenity { Id = 5, Name = "Zona de campamento" }
        );

        modelBuilder.Entity<Place>().HasData(
            new Place
            {
                Id = 1,
                Name = "Reserva de la Biósfera Mariposa Monarca",
                Description = "Santuario natural en Michoacán, hábitat invernal de la mariposa monarca.",
                Category = "reserva",
                Latitude = 19.631, Longitude = -100.283,
                ElevationMeters = 3000, Accessible = true,
                EntryFee = 70, OpeningHours = "09:00-17:00",
                CreatedAt = new DateTime(2024, 06, 05)
            },
            new Place
            {
                Id = 2,
                Name = "Sótano de las Golondrinas",
                Description = "Cueva vertical en San Luis Potosí famosa por el vuelo de miles de aves.",
                Category = "cueva",
                Latitude = 21.597, Longitude = -99.098,
                ElevationMeters = 900, Accessible = true,
                EntryFee = 100, OpeningHours = "07:00-18:00",
                CreatedAt = new DateTime(2024, 03, 25)
            },
            new Place
            {
                Id = 3,
                Name = "Cráteres de El Pinacate",
                Description = "Campo volcánico con cráteres impresionantes en Sonora.",
                Category = "volcán",
                Latitude = 31.783, Longitude = -113.533,
                ElevationMeters = 1200, Accessible = true,
                EntryFee = 70, OpeningHours = "08:00-17:00",
                CreatedAt = new DateTime(2024, 02, 26)
            },
            new Place
            {
                Id = 4,
                Name = "Prismas Basálticos",
                Description = "Formaciones geométricas de basalto en Hidalgo.",
                Category = "formación geológica",
                Latitude = 20.211, Longitude = -98.581,
                ElevationMeters = 2100, Accessible = true,
                EntryFee = 80, OpeningHours = "09:00-18:00",
                CreatedAt = new DateTime(2024, 03, 14)
            },
            new Place
            {
                Id = 5,
                Name = "Sima de las Cotorras",
                Description = "Hundimiento natural en Chiapas con selva en el interior.",
                Category = "sima",
                Latitude = 16.726, Longitude = -93.368,
                ElevationMeters = 900, Accessible = true,
                EntryFee = 60, OpeningHours = "07:00-17:00",
                CreatedAt = new DateTime(2024, 01, 01)
            }
        );

        modelBuilder.Entity<Trail>().HasData(
            new Trail
            {
                Id = 1, PlaceId = 1, Name = "Sendero Mariposas",
                DistanceKm = 2.5, EstimatedTimeMinutes = 60, Difficulty = "easy", IsLoop = true,
                Path = "[[19.6305,-100.2825],[19.6312,-100.2835],[19.632,-100.284]]"
            },
            new Trail
            {
                Id = 2, PlaceId = 2, Name = "Descenso al sótano",
                DistanceKm = 1.2, EstimatedTimeMinutes = 90, Difficulty = "hard", IsLoop = false,
                Path = "[[21.597,-99.098],[21.5975,-99.097],[21.598,-99.096]]"
            },
            new Trail
            {
                Id = 3, PlaceId = 3, Name = "Ruta cráter El Elegante",
                DistanceKm = 3.5, EstimatedTimeMinutes = 120, Difficulty = "moderate", IsLoop = true,
                Path = "[[31.783,-113.533],[31.784,-113.532],[31.785,-113.531]]"
            },
            new Trail
            {
                Id = 4, PlaceId = 4, Name = "Sendero Prismas",
                DistanceKm = 1.0, EstimatedTimeMinutes = 30, Difficulty = "easy", IsLoop = true,
                Path = "[[20.211,-98.581],[20.212,-98.5805],[20.2125,-98.580]]"
            },
            new Trail
            {
                Id = 5, PlaceId = 5, Name = "Sendero Sima",
                DistanceKm = 2.0, EstimatedTimeMinutes = 60, Difficulty = "moderate", IsLoop = false,
                Path = "[[16.726,-93.368],[16.727,-93.367],[16.728,-93.366]]"
            }
        );

        modelBuilder.Entity<Photo>().HasData(
            new Photo
            {
                Id = 1, PlaceId = 1,
                Url = "https://cdn.milenio.com/uploads/media/2015/10/23/tala-ilegal-reserva-biosfera-mariposa.jpeg",
                Description = "Reserva de la Biósfera Mariposa Monarca"
            },
            new Photo
            {
                Id = 2, PlaceId = 2,
                Url = "https://transpais.com.mx/wp-content/uploads/2023/04/golondrinas.jpg",
                Description = "Sótano de las Golondrinas"
            },
            new Photo
            {
                Id = 3, PlaceId = 3,
                Url = "https://rocateca.unison.mx/wp-content/uploads/2020/09/el-elegante.jpg",
                Description = "Cráteres de El Pinacate"
            },
            new Photo
            {
                Id = 4, PlaceId = 4,
                Url = "https://www.huascaguiaturistica.com/huasca-imagenes/1-prismas-basalticos.jpg",
                Description = "Prismas Basálticos"
            },
            new Photo
            {
                Id = 5, PlaceId = 5,
                Url = "https://mxc.com.mx/wp-content/uploads/2021/02/sima-de-las-cotorras-1024x576.jpg",
                Description = "Sima de las Cotorras"
            }
        );

        modelBuilder.Entity<PlaceAmenity>().HasData(
            new PlaceAmenity { PlaceId = 1, AmenityId = 1 },
            new PlaceAmenity { PlaceId = 1, AmenityId = 2 },
            new PlaceAmenity { PlaceId = 2, AmenityId = 3 },
            new PlaceAmenity { PlaceId = 3, AmenityId = 2 },
            new PlaceAmenity { PlaceId = 3, AmenityId = 5 },
            new PlaceAmenity { PlaceId = 4, AmenityId = 1 },
            new PlaceAmenity { PlaceId = 4, AmenityId = 4 },
            new PlaceAmenity { PlaceId = 5, AmenityId = 2 },
            new PlaceAmenity { PlaceId = 5, AmenityId = 3 }
        );
    }
}
