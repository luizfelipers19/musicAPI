﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace music.Models
{
    public class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Duration { get; set; }

        public DateTime UploadedDate { get; set; }

        public bool IsFeatured { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }

        public string SongUrl { get; set; }

        public int ArtistId { get; set; }

        public int? AlbumId { get; set; }


    }
}
