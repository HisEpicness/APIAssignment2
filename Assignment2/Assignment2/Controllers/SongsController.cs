using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class SongsController : ApiController
    {
        // GET: api/Songs
        public List<SongsModel> GetAllSongs()
        {
            List<SongsModel> songsList = null;

            using (var ctx = new Assignment2Entities())
            {
                songsList = ctx.songs
                    .Select(s => new SongsModel()
                    {
                        sId = s.id,
                        sName = s.songName,
                        aName = s.artistName,
                        year = s.yearPublished,
                    }).ToList<SongsModel>();
            }

            if (songsList.Count == 0)
            {
                return null;
            }

            return songsList;
        }

        // GET: api/Songs/{id}
        public SongsModel GetSongById(string id)
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
                   }).FirstOrDefault<SongsModel>();
            }

            if (selSong == null)
            {
                return null;
            }

            return selSong;
        }


        // POST: api/Songs
        public string PostSong(song songPost)
        {
            using (var ctx = new Assignment2Entities())
            {
                if (!ModelState.IsValid)
                {
                    return "Post Failed";
                }
                ctx.songs.Add(songPost);
                ctx.SaveChanges();
                return "Success";
            }
        }

        // PUT: api/Songs/{id}
        public string PutSong(song songPut)
        {
            using (var ctx = new Assignment2Entities())
            {
                if (!ModelState.IsValid)
                {
                    return "Put Failed";
                }
                ctx.Entry(songPut).State = EntityState.Modified;
                
                ctx.SaveChanges();
                return "Success";
            }

        }

        // DELETE: api/Songs/{id}
        public string DeleteSong(string id)
        {
            song selSong = null;

            using (var ctx = new Assignment2Entities())
            {
                selSong = ctx.songs
                   .Where(s => (s.id).ToString() == id)
                   .FirstOrDefault();

                if (selSong == null)
                {
                    return "Not a valid song";
                }
                else
                {
                    ctx.songs.Remove(selSong);
                    ctx.SaveChanges();
                    return "Success";
                }
            }
        }
    }
}
