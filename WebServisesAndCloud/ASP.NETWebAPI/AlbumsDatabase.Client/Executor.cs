using System;
using System.Linq;
using AlbumsDatabase.Context;
using AlbumsDatabase.Model;

//To add all NuGet Packages - goto

namespace AlbumsDatabase.Client
{
    class Executor
    {
        static void Main(string[] args)
        {
            var context = new AlbumsDatabaseContext();

            //FillDB(context);

            //Album album = new Album()
            //{
            //    Title = "asg",
            //    Year = 2010,
            //    Producer = "Misho"
            //};

            //context.Albums.Add(album);
            Artist artist = new Artist()
            {
                Name = "Ramstein",
                Country = "Germany",
                BirthYear = 1994
            };

            context.Artists.Add(artist);
            context.SaveChanges();
        }

        private static void FillDB(AlbumsDatabaseContext context)
        {
            var metallica = new Artist
            {
                Name = "Metallica",
                Country = "USA",
                BirthYear = 1981
            };

            var blackAlbum = new Album
            {
                Title = "Black ALbum",
                Year = 1991,
                Producer = "Bob Rock"
            };

            blackAlbum.Songs.Add(new Song
            {
                Title = "Nothing Else Matters",
                Genre = "Metal",
                Artist = metallica
            });
            blackAlbum.Songs.Add(new Song
            {
                Title = "Enter Sadman",
                Genre = "Metal",
                Artist = metallica
            });
            blackAlbum.Songs.Add(new Song
            {
                Title = "Sad But True",
                Genre = "Metal",
                Artist = metallica
            });
            blackAlbum.Songs.Add(new Song
            {
                Title = "The Unforgiven",
                Genre = "Metal",
                Artist = metallica
            });

            context.Albums.Add(blackAlbum);
            context.SaveChanges();
        }
    }
}
