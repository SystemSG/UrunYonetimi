using Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
     
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public virtual DbSet<Kategori> Kategoriler { get; set; }
        public virtual DbSet<Kullanici> Kullanicilar { get; set; }
        public virtual DbSet<Marka> Markalar { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //veritabanýnda oluþacak tablolarýn sonuna s takýsý gelmemesi için
            base.OnModelCreating(modelBuilder);
        }

        public class DatabaseInitializer:CreateDatabaseIfNotExists<DatabaseContext> // eðer veri tabaný yoksa oluþtur databasecontex deki dbsetlere göre 
        {
            protected override void Seed(DatabaseContext context)//seed metodu veri tabaný olþutuktan sonra devreye girip iþlem yapmamýzý saðlar
            {
                if (context.Kullanicilar.Any())
                {
                    context.Kullanicilar.Add(
                        new Kullanici()
                        {
                            Aktif=true,
                            KullaniciAdi="Admin",
                            Sifre="123456"
                        }
                        );
                    context.SaveChanges();
                }
                base.Seed(context);
            }
        }
    }

}