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
    public class ArtistController : ApiController
    {
        private readonly AlbumsDatabaseContext db = new AlbumsDatabaseContext();

        // GET api/Artist
        public IEnumerable<ArtistModel> GetArtists()
        {
            var artists = db.Artists;

            IList<ArtistModel> result = new List<ArtistModel>();
            foreach (var artist in artists)
            {
                result.Add(new ArtistModel(artist));
            }

            return result;
        }

        // GET api/Artist/5
        public ArtistModel GetArtist(int id)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new ArtistModel(artist);
        }

        // PUT api/Artist/5
        public HttpResponseMessage PutArtist(int id, Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != artist.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(artist).State = EntityState.Modified;

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

        // POST api/Artist
        public HttpResponseMessage PostArtist(Artist artist)
        {
            if (ModelState.IsValid)
            {
                GetOrCreateAlbum(artist);
                db.Artists.Add(artist);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, artist);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = artist.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Artist/5
        public HttpResponseMessage DeleteArtist(int id)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Artists.Remove(artist);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, artist);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private void GetOrCreateAlbum(Artist artist)
        {
            foreach (var album in artist.Albums)
            {
                var albumtToFind = db.Albums.Find(album.Title);
                if (albumtToFind == null)
                {
                    albumtToFind = new Album { Title = albumtToFind.Title };
                }
                albumtToFind = album;
            }
        }
    }
}