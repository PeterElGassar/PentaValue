using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Api.Models.BasicModels;
using Api.Persistence.Repositories.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class MediaController : BaseApiController
    {


        private readonly Context _context;

        public MediaController(Context context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<List<Media>> GetMideas()
        {
            var Medias =  _context.Medias.ToList();

            return Medias;
        }

        [HttpGet("getMedia")]
        public ActionResult<Media> GetMedia(int id)
        {
            var media =  _context.Medias.FirstOrDefault(m => m.Id == id);

            if(media == null)
            return StatusCode(StatusCodes.Status404NotFound);

            return media;

        }





        [HttpPost]
        public ActionResult<Media> CreateMedia(Media mediaDto)
        {

            if (mediaDto == null)
                return StatusCode(StatusCodes.Status404NotFound, new { Status = 500, Message = "Please Enter Full Data" });

            _context.Medias.Add(mediaDto);
            _context.SaveChanges();

            return mediaDto;
        }




        [HttpPut]
        public ActionResult<Media> UpdateMedia(Media mediaDto)
        {

            var mediaInDb = _context.Medias.Find(mediaDto.Id);

            mediaInDb.Image = mediaDto.Image;
            mediaInDb.Video = mediaDto.Video;
            mediaInDb.From_time = mediaDto.From_time;
            mediaInDb.To_time = mediaDto.To_time;


            _context.SaveChanges();

            return mediaDto;
        }
        

        [HttpDelete]
        public ActionResult DeleteMedia(int id)
        {

            var mediaInDb = _context.Medias.Find(id);

            _context.Medias.Remove(mediaInDb);
            _context.SaveChanges();

            return Ok();
        }





    }
}
