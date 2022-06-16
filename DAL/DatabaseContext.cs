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
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //veritaban�nda olu�acak tablolar�n sonuna s tak�s� gelmemesi i�in
            base.OnModelCreating(modelBuilder);
        }

        public class DatabaseInitializer:CreateDatabaseIfNotExists<DatabaseContext> // e�er veri taban� yoksa olu�tur databasecontex deki dbsetlere g�re 
        {
            protected override void Seed(DatabaseContext context)//seed metodu veri taban� ol�utuktan sonra devreye girip i�lem yapmam�z� sa�lar
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