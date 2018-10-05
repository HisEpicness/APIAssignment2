using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class ReviewsController : ApiController
    {

        // GET: api/Songs
        public IHttpActionResult GetAllReviews()
        {
            IList<ReviewsModel> reviewList = null;

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
                return NotFound();
            }

            return Ok(reviewList);
        }

        // GET: api/Reviews/{id}
        public IHttpActionResult GetReviewById(string id)
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
                return NotFound();
            }

            return Ok(selReview);
        }

        // POST: api/Reviews
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Reviews/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Reviews/5
        public void Delete(int id)
        {
        }
    }
}
