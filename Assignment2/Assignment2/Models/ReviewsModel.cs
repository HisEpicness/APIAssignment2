using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class ReviewsModel
    {
        public decimal rId { get; set; }
        public decimal sId { get; set; }
        public decimal sRating { get; set; }
        public string textReview { get; set; }
    }
}