using BinaryDatabase.ExampleWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryDatabase.ExampleWeb.Controllers
{
    public class SongController : Controller
    {
        // GET: SongController
        public ActionResult Index()
        {
            return View(SongTreeRepository.SongTree.AsEnumerable());
        }

        // GET: SongController/Get?songName=
        [HttpGet]
        public ActionResult Get([FromQuery]string songName)
        {
            if (songName == null)
            {
                return Json("");
            }
            Song song = new Song()
            {
                Id = 0,
                AlbumName = "not found",
                Author = "not found",
                Length = 0,
                Name = "not found",
                ReleaseDate = DateTime.MinValue
            };
            try
            {
                song = SongTreeRepository.SongTree.Find(songName);
            } catch (Exception ex)
            {
                
            }
            return Json(song);
        }
    }
}
