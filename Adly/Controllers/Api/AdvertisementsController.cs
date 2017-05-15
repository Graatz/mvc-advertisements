using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Adly.Models;
using Adly.Dtos;
using AutoMapper;

namespace Adly.Controllers.Api
{
    public class AdvertisementsController : ApiController
    {
        private ApplicationDbContext db;

        public AdvertisementsController()
        {
            db = new ApplicationDbContext();
        }

        // GET /api/advertisements
        public IHttpActionResult GetAdvertisements()
        {
            return Ok(db.Advertisements.ToList().Select(Mapper.Map<Advertisement, AdvertisementDto>));
        }

        // GET /api/advertisements/1
        public IHttpActionResult GetAdvertisement(int id)
        {
            var advertisement = db.Advertisements.SingleOrDefault(a => a.Id == id);

            if (advertisement == null)
                return NotFound();

            return Ok(Mapper.Map<Advertisement, AdvertisementDto>(advertisement));
        }

        // POST /api/advertisements
        [HttpPost]
        public IHttpActionResult CreateAdvertisement(AdvertisementDto advertisementDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var advertisement = Mapper.Map<AdvertisementDto, Advertisement>(advertisementDto);
            advertisement.Date = DateTime.Now;
            advertisement.Views = 0;
            db.Advertisements.Add(advertisement);
            db.SaveChanges();

            advertisementDto.Id = advertisement.Id;

            return Created(new Uri(Request.RequestUri + "/" + advertisement.Id), advertisementDto);
        }

        // PUT /api/advertisements/1
        [HttpPut]
        public IHttpActionResult UpdateAdvertisement(int id, AdvertisementDto advertisementDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var advertisementInDb = db.Advertisements.SingleOrDefault(a => a.Id == id);

            if (advertisementInDb == null)
                return NotFound();

            Mapper.Map(advertisementDto, advertisementInDb);

            db.SaveChanges();

            return Ok();
        }


        // DELETE /api/advertisements/1
        [HttpDelete]
        public IHttpActionResult DeleteAdvertisement(int id)
        {
            var advertisement = db.Advertisements.SingleOrDefault(a => a.Id == id);

            if (advertisement == null)
                return NotFound();

            db.Advertisements.Remove(advertisement);
            db.SaveChanges();

            return Ok();
        }
    }
}
