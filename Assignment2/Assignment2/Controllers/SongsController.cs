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

            //grabs all songs
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

            //returns null if no songs
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

            //grabs song based on passed id
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

            //return null if no song found
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

                //inserts song into db
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
                //edits song 
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
                //grabs song based on id
                selSong = ctx.songs
                   .Where(s => (s.id).ToString() == id)
                   .FirstOrDefault();

                //returns error if song not found
                if (selSong == null)
                {
                    return "Not a valid song";
                }
                else
                {
                    //deletes song
                    ctx.songs.Remove(selSong);
                    ctx.SaveChanges();
                    return "Success";
                }
            }
        }
    }
}
