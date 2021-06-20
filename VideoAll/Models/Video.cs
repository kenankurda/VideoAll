using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VideoAll.Models
{
    public class Video
    {
        public int VideoId { get; set; }
        public string Name { get; set; }
       
        //[Display(Name = "Choose the photo for your video")]

        //[Required]
        //public IFormFile CoverPhoto { get; set; }
        public string ImagePath { get; set; }

        public int GenreId { get; set; }
        public Genre Genres { get; set; }

        public IList<Actor> Actors { get; set; }

    }
}
