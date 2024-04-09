using Microsoft.EntityFrameworkCore;

namespace Cornell_WebAPI.Models;
public partial class CornellDbContext : DbContext
{
    public  CornellDbContext()
    {

    }

    public CornellDbContext(DbContextOptions<CornellDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clientdetails> Clientdetails { get; set; }

    public virtual DbSet<Enumeratorsdetails> Enumeratorsdetails { get; set; }

    public virtual DbSet<Countriesdetails> Countriesdetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clientdetails>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientd__3214EC07C352B717");

            entity.Property(e => e.FirstName)
             .HasMaxLength(10)
             .IsFixedLength();

            entity.Property(e => e.LastName)
             .HasMaxLength(10)
             .IsFixedLength();

            entity.Property(e => e.Gender)
             .HasMaxLength(10)
             .IsFixedLength();

            entity.Property(e => e.Address)
             .HasMaxLength(10)
             .IsFixedLength();

            entity.Property(e => e.NIN_No)
             .HasMaxLength(10)
             .IsFixedLength();

            entity.Property(e => e.TelephoneNo)
             .HasMaxLength(10)
             .IsFixedLength()
             .HasColumnType("int");

            entity.Property(e => e.CountryPlacement)
             .HasMaxLength(10)
             .IsFixedLength();


            entity.Property(e => e.ProfilePic)
             .HasMaxLength(10)
             .IsFixedLength();


            entity.Property(e => e.Description)
             .HasMaxLength(10)
             .IsFixedLength();

            entity.Property(e => e.DateRegistered)
             .HasColumnType("date");

            entity.Property(e => e.DateOfBirth)
             .HasColumnType("date");

            entity.Property(e => e.DatePlacement)
             .HasColumnType("date");

        });

        modelBuilder.Entity<Countriesdetails>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Countriesd__3214EC07C352B718");

            entity.Property(e => e.Flag)
             .HasMaxLength(10)
             .IsFixedLength();

            entity.Property(e => e.CountryCode)
             .HasMaxLength(10)
             .IsFixedLength();

            entity.Property(e => e.Flag)
             .HasMaxLength(10)
             .IsFixedLength();

            entity.Property(e => e.CountryName)
             .HasMaxLength(10)
             .IsFixedLength();

            entity.Property(e => e.Status)
             .HasMaxLength(10)
             .IsFixedLength();

        });


        modelBuilder.Entity<Enumeratorsdetails>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Enumeratorsd__3214EC07C352B719");

            entity.Property(e => e.FirstName)
             .HasMaxLength(10)
             .IsFixedLength();

            entity.Property(e => e.LastName)
             .HasMaxLength(10)
             .IsFixedLength();

            entity.Property(e => e.Gender)
             .HasMaxLength(10)
             .IsFixedLength();

            entity.Property(e => e.Address)
             .HasMaxLength(10)
             .IsFixedLength();

            entity.Property(e => e.NIN_No)
             .HasMaxLength(10)
             .IsFixedLength();

            entity.Property(e => e.Email)
             .HasMaxLength(10)
             .IsFixedLength()
             .HasColumnType("char");

            entity.Property(e => e.Department)
             .HasMaxLength(10)
             .IsFixedLength();


            entity.Property(e => e.ProfilePic)
             .HasMaxLength(10)
             .IsFixedLength()
             .HasColumnType("varbinary");

            entity.Property(e => e.Description)
             .HasMaxLength(10)
             .IsFixedLength();

            entity.Property(e => e.DateRegistered)
             .HasColumnType("date");

        });

        OnModelCreatingPartial(modelBuilder);


    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<Cornell_WebAPI.Models.Clientdetails>? Clientsdetails { get; set; }

    public DbSet<Cornell_WebAPI.Models.Countriesdetails>? Countriesdetail { get; set; }

    public DbSet<Cornell_WebAPI.Models.Enumeratorsdetails>? EnumeratordetailS { get; set; }



}
