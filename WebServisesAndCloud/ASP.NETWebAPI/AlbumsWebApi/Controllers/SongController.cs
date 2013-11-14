using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AlbumsDatabase.Model;
using AlbumsDatabase.Context;
using AlbumsWebApi.Models;

namespace AlbumsWebApi.Controllers
{
    public class SongController : ApiController
    {
        private readonly AlbumsDatabaseContext db = new AlbumsDatabaseContext();

        // GET api/Song
        public IEnumerable<SongModel> GetSongs()
        {
            var songs = db.Songs.Include("Artist").Include("Album");

            IList<SongModel> result = new List<SongModel>();
            foreach (var song in songs)
            {
                result.Add(new SongModel(song));
            }

            return result;
        }
        
        // GET api/Song/5
        public SongModel GetSong(int id)
        {
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new SongModel(song);
        }

        // PUT api/Song/5
        public HttpResponseMessage PutSong(int id, Song song)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != song.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(song).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Song
        public HttpResponseMessage PostSong(Song song)
        {
            if (ModelState.IsValid)
            {
                GetOrCreateAlbum(song);
                GetOrCreateArtist(song);

                db.Songs.Add(song);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, song);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = song.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Song/5
        public HttpResponseMessage DeleteSong(int id)
        {
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Songs.Remove(song);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, song);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private void GetOrCreateArtist(Song song)
        {
            var artist = db.Artists.SingleOrDefault(a => a.Name == song.Artist.Name);

            if (artist == null)
            {
                artist = new Artist { Name = song.Artist.Name };
            }
            song.Artist = artist;
        }

        private void GetOrCreateAlbum(Song song)
        {
            var album = db.Albums.SingleOrDefault(a => a.Title == song.Album.Title);

            if (album == null)
            {
                album = new Album { Title = song.Album.Title };
            }
            song.Album = album;
        }
    }
}