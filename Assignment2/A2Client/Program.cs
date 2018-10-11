using Assignment2;
using Assignment2.Controllers;
using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace A2Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice = "";
            while (choice != "3")
            {
                Console.WriteLine("");
                Console.WriteLine("Which API do you wish to call?");
                Console.WriteLine("1: songs");
                Console.WriteLine("2: reviews");
                Console.WriteLine("3: exit");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        APICall("songs");
                        break;
                    case "2":
                        APICall("reviews");
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        Console.WriteLine("");
                        break;
                }
            }
        }

        
        /// <summary>
        /// chooses which API method to call for the songs API
        /// </summary>
        private static void APICall(string table)
        {
            Console.WriteLine("");
            Console.WriteLine("Which method do you wish to call?");
            Console.WriteLine("1: Get");
            Console.WriteLine("2: Post");
            Console.WriteLine("3: Put");
            Console.WriteLine("4: Delete");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    getAPICall(table);
                    break;
                case "2":
                    postAPICall(table);
                    break;
                case "3":
                    putAPICall(table);
                    break;
                case "4":
                    delAPICall(table);
                    break;
                default:
                    Console.WriteLine("invlid choice");
                    break;
            }
        }

        /// <summary>
        /// delete option for API
        /// </summary>
        /// <param name="table">the table(API)</param>
        private static void delAPICall(string table)
        {
            if (table.Equals("songs"))
            {
                Console.WriteLine("");
                Console.WriteLine("Input Id of song to delete:");
                string choice = Console.ReadLine();
                SongsController cont = new SongsController();
                string result = cont.DeleteSong(choice);
                Console.WriteLine(result);
            }
            else if (table.Equals("reviews"))
            {
                Console.WriteLine("");
                Console.WriteLine("Input Id of review to delete:");
                string choice = Console.ReadLine();
                ReviewsController cont = new ReviewsController();
                string result = cont.DeleteReview(choice);
                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// call the PUT method
        /// </summary>
        /// <param name="table">the table(API)</param>
        private static void putAPICall(string table)
        {
            if (table.Equals("songs"))
            {
                Assignment2.song s = getSongPutInfo();
                SongsController cont = new SongsController();
                string result = cont.PutSong(s);
                Console.WriteLine(result);
            }
            else if (table.Equals("reviews"))
            {
                Assignment2.review r = getReviewPutInfo();
                ReviewsController cont = new ReviewsController();
                string result = cont.PutReview(r);
                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// updates a review
        /// </summary>
        /// <returns>status</returns>
        private static Assignment2.review getReviewPutInfo()
        {
            Assignment2.review s = new Assignment2.review();
            Console.WriteLine("");
            Console.WriteLine("Input review Id:");
            s.reviewId = Decimal.Parse(Console.ReadLine());
            Console.WriteLine("Input new song id:");
            s.songId = Decimal.Parse(Console.ReadLine());
            Console.WriteLine("Input new rating(1-5):");
            s.rating = Decimal.Parse(Console.ReadLine());
            Console.WriteLine("Input new text review:");
            s.review1 = Console.ReadLine();

            return s;
        }

        /// <summary>
        /// updates a song
        /// </summary>
        /// <returns>status</returns>
        private static Assignment2.song getSongPutInfo()
        {
            Assignment2.song s = new Assignment2.song();
            Console.WriteLine("");
            Console.WriteLine("Input song Id:");
            s.id = Decimal.Parse(Console.ReadLine());
            Console.WriteLine("Input new song name:");
            s.songName = Console.ReadLine();
            Console.WriteLine("Input new artist name:");
            s.artistName = Console.ReadLine();
            Console.WriteLine("Input new year published:");
            s.yearPublished = int.Parse(Console.ReadLine());

            return s;
        }

        /// <summary>
        /// does the pot action for the table specified
        /// </summary>
        /// <param name="table">the table(API)</param>
        private static void postAPICall(string table)
        {
            if (table.Equals("songs"))
            {
                Assignment2.song s = getSongPostInfo();
                SongsController cont = new SongsController();
                string result = cont.PostSong(s);
                Console.WriteLine(result);
            }
            else if (table.Equals("reviews"))
            {
                Assignment2.review r = getReviewPostInfo();
                ReviewsController cont = new ReviewsController();
                string result = cont.PostReview(r);
                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// gets all info required to post a review
        /// </summary>
        /// <returns>success/failure message</returns>
        private static Assignment2.review getReviewPostInfo()
        {
            Assignment2.review s = new Assignment2.review();
            Console.WriteLine("");
            Console.WriteLine("Input review Id:");
            s.reviewId = Decimal.Parse(Console.ReadLine());
            Console.WriteLine("Input song id:");
            s.songId = Decimal.Parse(Console.ReadLine());
            Console.WriteLine("Input rating(1-5):");
            s.rating = Decimal.Parse(Console.ReadLine());
            Console.WriteLine("Input text review:");
            s.review1 = Console.ReadLine();

            return s;
        }

        /// <summary>
        /// gets all info required to post a song
        /// </summary>
        /// <returns>success/failure message</returns>
        private static Assignment2.song getSongPostInfo()
        {
            Assignment2.song s = new Assignment2.song();
            Console.WriteLine("");
            Console.WriteLine("Input song Id:");
            s.id = Decimal.Parse(Console.ReadLine());
            Console.WriteLine("Input song name:");
            s.songName = Console.ReadLine();
            Console.WriteLine("Input artist name:");
            s.artistName = Console.ReadLine();
            Console.WriteLine("Input year published:");
            s.yearPublished = int.Parse(Console.ReadLine());

            return s;
        }

        /// <summary>
        /// uses the Get mehod to retreive information from an API
        /// </summary>
        /// <param name="table"> the table who's API is being called</param>
        private static void getAPICall(string table)
        {
            Console.WriteLine("");
            Console.WriteLine("Which " + table + " do you wish to view?");
            Console.WriteLine("(enter '0' to view all)");
            string choice = Console.ReadLine();

            if (table.Equals("songs"))
            {
                SongsController cont = new SongsController();
                if (choice.Equals("0"))
                {
                    List<SongsModel> songs = cont.GetAllSongs();
                    foreach (SongsModel song in songs)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(song.sId);
                        Console.WriteLine(song.sName);
                        Console.WriteLine(song.aName);
                        Console.WriteLine(song.year);
                    }
                }
                else
                {
                    SongsModel song = cont.GetSongById(choice);
                    if (song != null)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(song.sId);
                        Console.WriteLine(song.sName);
                        Console.WriteLine(song.aName);
                        Console.WriteLine(song.year);
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Not Found.");
                    }
                }
            }
            else if (table.Equals("reviews"))
            {
                ReviewsController cont = new ReviewsController();
                if (choice.Equals("0"))
                {
                    List<ReviewsModel> revs = cont.GetAllReviews();
                    foreach (ReviewsModel rev in revs)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(rev.rId);
                        Console.WriteLine(rev.sId);
                        Console.WriteLine(rev.sRating);
                        Console.WriteLine(rev.textReview);
                    }
                }
                else
                {
                    ReviewsModel rev = cont.GetReviewById(choice);

                    if (rev != null)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(rev.rId);
                        Console.WriteLine(rev.sId);
                        Console.WriteLine(rev.sRating);
                        Console.WriteLine(rev.textReview);
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Not Found.");
                    }
                }
            }
        }
    }
}
