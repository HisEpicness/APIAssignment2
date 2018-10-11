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
    public class ReviewsController : ApiController
    {

        // GET: api/Songs
        public List<ReviewsModel> GetAllReviews()
        {
            List<ReviewsModel> reviewList = null;

            using (var ctx = new Assignment2Entities())
            {
                reviewList = ctx.reviews
                .Select(r => new ReviewsModel()
                {
                    rId = r.reviewId,
                    sId = r.songId,
                    sRating = r.rating,
                    textReview = r.review1
                }).ToList<ReviewsModel>();
            }

            if (reviewList.Count == 0)
            {
                return null;
            }

            return reviewList;
        }

        // GET: api/Reviews/{id}
        public ReviewsModel GetReviewById(string id)
        {
            ReviewsModel selReview = null;

            using (var ctx = new Assignment2Entities())
            {
                selReview = ctx.reviews
                   .Where(r => (r.reviewId).ToString() == id)
                   .Select(r => new ReviewsModel()
                   {
                       rId = r.reviewId,
                       sId = r.songId,
                       sRating = r.rating,
                       textReview = r.review1
                   }).FirstOrDefault<ReviewsModel>();
            }

            if (selReview == null)
            {
                return null;
            }

            return selReview;
        }

        // POST: api/Reviews
        public string PostReview(review revPost)
        {
            using (var ctx = new Assignment2Entities())
            {
                if (!ModelState.IsValid)
                {
                    return "Post Failed";
                }
                ctx.reviews.Add(revPost);
                ctx.SaveChanges();
                return "Success";
            }
        }

        // PUT: api/Reviews/5
        public string PutReview(review revPut)
        {
            using (var ctx = new Assignment2Entities())
            {
                if (!ModelState.IsValid)
                {
                    return "Put Failed";
                }
                ctx.Entry(revPut).State = EntityState.Modified;

                ctx.SaveChanges();
                return "Success";
            }

        }

        // DELETE: api/Reviews/5
        public string DeleteReview(string id)
        {
            review selRev = null;

            using (var ctx = new Assignment2Entities())
            {
                selRev = ctx.reviews
                   .Where(s => (s.reviewId).ToString() == id)
                   .FirstOrDefault();

                if (selRev == null)
                {
                    return "Not a valid song";
                }
                else
                {
                    ctx.reviews.Remove(selRev);
                    ctx.SaveChanges();
                    return "Success";
                }
            }
        }
    }
}
