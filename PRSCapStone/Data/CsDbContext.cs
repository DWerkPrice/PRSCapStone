using Microsoft.EntityFrameworkCore;
using PRSCapStone.Models;

namespace PRSCapStone.Data
{
    public class CsDb : DbContext
    {
        public CsDb (DbContextOptions<CsDb> options)
            : base(options) {}

        public CsDb() {
        }

        protected override void OnModelCreating(ModelBuilder model) {
            model.Entity<User>(e => {
                e.ToTable("Users");
                e.HasKey(x => x.Id);
                e.Property(x => x.Username).HasMaxLength(30).IsRequired();
                e.Property(x => x.Password).HasMaxLength(30).IsRequired();
                e.Property(x => x.Firstname).HasMaxLength(30).IsRequired();
                e.Property(x => x.Lastname).HasMaxLength(30).IsRequired();
                e.Property(x => x.Phone).HasMaxLength(12);
                e.Property(x => x.Email).HasMaxLength(255);
                e.Property(x => x.IsReviewer).IsRequired().HasDefaultValue(false);
                e.Property(x => x.IsAdmin).IsRequired().HasDefaultValue(false);
                e.HasIndex(x => x.Username).IsUnique();

            });

            model.Entity<Vendor>(e => {
                e.ToTable("Vendors");
                e.HasKey(x => x.Id);
                e.Property(x => x.Code).HasMaxLength(30).IsRequired();
                e.Property(x => x.Name).HasMaxLength(30).IsRequired();
                e.Property(x => x.Address).HasMaxLength(30).IsRequired();
                e.Property(x => x.City).HasMaxLength(30).IsRequired();
                e.Property(x => x.State).HasMaxLength(2).IsRequired();
                e.Property(x => x.Zip).HasMaxLength(5).IsRequired();
                e.Property(x => x.Phone).HasMaxLength(12);
                e.Property(x => x.Email).HasMaxLength(255);
                e.HasIndex(x => x.Code).IsUnique();
            });

            model.Entity<Product>(e => {
                e.ToTable("Products");
                e.HasKey(x => x.Id);
                e.Property(x => x.PartNbr).HasMaxLength(30).IsRequired();
                e.Property(x => x.Name).HasMaxLength(30).IsRequired();
                e.Property(x => x.Unit).HasMaxLength(30).IsRequired();
                e.Property(x => x.Price).HasColumnType("decimal(11,2)").IsRequired();
                e.Property(x => x.PhotoPath).HasMaxLength(255);
                e.Property(x => x.PartNbr).IsRequired();
                e.HasIndex(x => x.PartNbr).IsUnique();
            });

            model.Entity<Request>(e => {
                e.ToTable("Requests");
                e.HasKey(x => x.Id);
                e.Property(x => x.Description).HasMaxLength(80).IsRequired();
                e.Property(x => x.Justification).HasMaxLength(80).IsRequired();
                e.Property(x => x.RejectionReason).HasMaxLength(80);
                e.Property(x => x.DeliveryMode).HasMaxLength(20).HasDefaultValue("Pickup").IsRequired();
                e.Property(x => x.Status).HasMaxLength(10).HasDefaultValue("New").IsRequired();
                e.Property(x => x.Total).HasColumnType("decimal(11,2)").HasDefaultValue("0").IsRequired();
            });
            model.Entity<RequestLine>(e => {
                e.ToTable("RequestLines");
                e.HasKey(x => x.Id);
                e.Property(x => x.Quantity).HasDefaultValue(1);
                e.HasOne(x => x.Request).WithMany(x => x.RequestLines).HasForeignKey(x => x.RequestId);
                e.HasOne(x => x.Product).WithMany(x => x.Requestlines).HasForeignKey(x => x.ProductId);
            });



        }
        public DbSet<PRSCapStone.Models.User> User { get; set; }
        public DbSet<PRSCapStone.Models.Vendor> Vendor { get; set; }
        public DbSet<PRSCapStone.Models.Product> Product { get; set; }
        public DbSet<PRSCapStone.Models.Request> Request { get; set; }
        public DbSet<PRSCapStone.Models.RequestLine> RequestLine { get; set; }
    }
}
