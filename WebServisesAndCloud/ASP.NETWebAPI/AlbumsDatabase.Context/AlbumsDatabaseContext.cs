using System;
using System.Data.Entity;
using System.Linq;
using AlbumsDatabase.Model;

namespace AlbumsDatabase.Context
{
    public class AlbumsDatabaseContext : DbContext
    {
        public AlbumsDatabaseContext()
            : base("AlbumsDatabase")
        {

        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}
