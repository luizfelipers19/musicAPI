using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace music.Models
{
    public class Song
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="A propriedade Title precisa receber um valor")]
        public string Title { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public string Duration { get; set; }

        
    }
}
