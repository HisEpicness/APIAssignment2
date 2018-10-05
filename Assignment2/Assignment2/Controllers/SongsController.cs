using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class SongsController : ApiController
    {
        // GET: api/Songs
        public IHttpActionResult GetAllSongs()
        {
            IList<SongsModel> songsList = null;

            using (var ctx = new Assignment2Entities())
            {
                songsList = ctx.songs
                    .Select(s => new SongsModel()
                    {
                        sId = s.id,
                        sName = s.songName,
                        aName = s.artistName,
                        year = s.yearPublished,
                        own = s.owned
                    }).ToList<SongsModel>();
            }

            if (songsList.Count == 0)
            {
                return NotFound();
            }

            return Ok(songsList);
        }

        // GET: api/Songs/{id}
        public IHttpActionResult GetSongById(string id)
        {
            SongsModel selSong = null;

            using (var ctx = new Assignment2Entities())
            {
                selSong = ctx.songs
                   .Where(s => (s.id).ToString() == id)
                   .Select(s => new SongsModel()
                   {
                       sId = s.id,
                       sName = s.songName,
                       aName = s.artistName,
                       year = s.yearPublished,
                       own = s.owned
                   }).FirstOrDefault<SongsModel>();
            }

            if (selSong == null)
            {
                return NotFound();
            }

            return Ok(selSong);
        }


        // POST: api/Songs
        public IHttpActionResult PostSong(song songPost)
        {
            using (var ctx = new Assignment2Entities())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                ctx.songs.Add(songPost);
                ctx.SaveChanges();
                return Ok();
            }
        }

        // PUT: api/Songs/{id}
        public void PutSong(string id, song songPut)
        {
            SongsModel selSong = null;

            using (var ctx = new Assignment2Entities())
            {
                selSong = ctx.songs
                   .Where(s => (s.id).ToString() == id)
                   .Select(s => new SongsModel()
                   {
                       sId = s.id,
                       sName = s.songName,
                       aName = s.artistName,
                       year = s.yearPublished,
                       own = s.owned
                   }).FirstOrDefault<SongsModel>();

                if (songPut.id.ToString() != id)
                {
                    selSong.sId = songPut.id;
                }
                if (songPut.songName != null)
                {
                    selSong.sName = songPut.songName;
                }
                if (songPut.artistName != null)
                {
                    selSong.aName = songPut.artistName;
                }
                if (songPut.yearPublished.ToString() != null)
                {
                    selSong.year = songPut.yearPublished;
                }
                if (songPut.owned != songPut.owned)
                {
                    selSong.own = songPut.owned;
                }
            }

        }

        // DELETE: api/Songs/{id}
        public IHttpActionResult DeleteSong(string id)
        {
            song selSong = null;

            using (var ctx = new Assignment2Entities())
            {
                selSong = ctx.songs
                   .Where(s => (s.id).ToString() == id)
                   .FirstOrDefault();

                if (selSong == null)
                {
                    return BadRequest("Not a valid song");
                }
                else
                {
                    ctx.songs.Remove(selSong);
                    ctx.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}
