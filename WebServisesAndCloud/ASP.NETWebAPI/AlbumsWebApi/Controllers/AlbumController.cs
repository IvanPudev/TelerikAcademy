﻿using System;
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
    public class AlbumController : ApiController
    {
        private readonly AlbumsDatabaseContext db = new AlbumsDatabaseContext();

        // GET api/Album
        public IEnumerable<AlbumModel> GetAlbums()
        {
            var albums = db.Albums;

            IList<AlbumModel> result = new List<AlbumModel>();
            foreach (var album in albums)
            {
                result.Add(new AlbumModel(album));
            }

            return result;
        }

        // GET api/Album/5
        public AlbumModel GetAlbum(int id)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new AlbumModel(album);
        }

        // PUT api/Album/5
        public HttpResponseMessage PutAlbum(int id, Album album)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != album.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(album).State = EntityState.Modified;

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

        // POST api/Album
        public HttpResponseMessage PostAlbum(Album album)
        {
            if (ModelState.IsValid)
            {    
                GetOrCreateArtist(album);
                db.Albums.Add(album);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, album);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = album.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Album/5
        public HttpResponseMessage DeleteAlbum(int id)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Albums.Remove(album);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, album);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private void GetOrCreateArtist(Album album)
        {
            foreach (var artist in album.Artists)
            {
                var artistToFind = db.Artists.Find(artist.Name);
                if (artistToFind == null)
                {
                    artistToFind = new Artist { Name = artistToFind.Name };
                }
                artistToFind = artist;
            }
        }
    }
}