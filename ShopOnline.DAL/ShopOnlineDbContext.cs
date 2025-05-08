using Microsoft.EntityFrameworkCore;
using ShopOnline.DAL.Entities;


namespace ShopOnline.DAL
{
    public class ShopOnlineDbContext : DbContext
    {
        public DbSet<UserEntity> User { get { return Set<UserEntity>(); } }
        public DbSet<ProductEntity> Product { get { return Set<ProductEntity>(); } }
        public DbSet<CategoryEntity> Category { get { return Set<CategoryEntity>(); } }

        public ShopOnlineDbContext(DbContextOptions<ShopOnlineDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-HIDB0PS\SQLEXPRESS;Initial Catalog=ShopOnline;Integrated Security=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
