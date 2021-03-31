using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace music.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {

        private List<Song> songs = new List<Song>()
        {
               new Song(){Id = 0, Title="Cabeça de Gelo", Language = "Português" } ,
               new Song(){Id = 1, Title="Estilo Cachorro", Language = "Português" } ,
           
        };
    }
}
