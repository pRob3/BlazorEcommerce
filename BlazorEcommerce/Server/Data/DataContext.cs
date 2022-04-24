namespace BlazorEcommerce.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "The Hitchhiker's Guide to the Galaxy",
                    Description = "The Hitchhiker's Guide to the Galaxy[note 1] (sometimes referred to as HG2G,[1] HHGTTG,[2] H2G2,[3] or tHGttG) is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including stage shows, novels, comic books, a 1981 TV series, a 1984 text-based computer game, and 2005 feature film.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
                    Price = 3.99m
                },
                new Product
                {
                    Id = 2,
                    Title = "Notes of a Dirty Old Man",
                    Description = "Along with the series Notes of a Dirty Old Man, Portions from a Wine-Stained Notebook includes another deep look into Charles Bukowski's life. It is a lengthened version of Notes of a Dirty Old Man that is more of an autobiography about him becoming a writer than a short story. It is called A Dirty Old Man Confesses.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/dd/NotesOfADirtyOldMan.jpg",
                    Price = 6.99m
                },
                new Product
                {
                    Id = 3,
                    Title = "Red Rising",
                    Description = "Red Rising is a 2014 dystopian science fiction novel by American author Pierce Brown, and the first book and eponym of a series. The novel, set on a future planet Mars, follows lowborn miner Darrow as he infiltrates the ranks of the elite Golds.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/9/9b/Red_Rising_%282014%29.jpg",
                    Price = 5.99m
                }
            );
        }

        public DbSet<Product> Products { get; set; }
    }
}
