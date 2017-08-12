using Microsoft.AspNet.Identity;
using pktexiservice.Models;
using pktexiservice.Models.dynamic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pktexiservice.Controllers
{
    [Authorize(Roles ="Driver")]
    public class DriverOnlineStatusController : ApiController
    {
        /// <summary>
        /// -get/set driver status..
        /// -create driver status.
        /// -delete status.
        /// </summary>
        ApplicationDbContext db = new ApplicationDbContext();
        TexiDbContext texiDb = new TexiDbContext();

        // GET: api/Template
        //public IHttpActionResult Get()
        //{

        //    return Json("");
        //}

        // GET: api/Template/5
        public IHttpActionResult Get()
        {
            var DriverId = User.Identity.GetUserId();
            try
            {
                if (texiDb.DriverStatus.Any(o=>o.DriverId==DriverId))
                {
                    var driverStatusObject = texiDb.DriverStatus.FirstOrDefault(o=>o.DriverId==DriverId);
                    return Ok(driverStatusObject);

                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
           
        }

        // POST: api/Template
        public IHttpActionResult Post(DriverStatus driverStatusUpdate)
        {
            var DriverId = User.Identity.GetUserId();
            driverStatusUpdate.DriverId = DriverId;
            
            if (texiDb.DriverStatus.Any(o=>o.DriverId==DriverId))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                DriverStatus driverStatus = texiDb.DriverStatus.FirstOrDefault(o => o.DriverId == DriverId);
                driverStatus.isOnline = driverStatusUpdate.isOnline;
                driverStatus.lastSeen = DateTime.UtcNow;
                driverStatus.Lat = driverStatusUpdate.Lat;
                driverStatus.Lng = driverStatusUpdate.Lng;



                texiDb.Entry(driverStatus).State = EntityState.Modified;
                try
                {
                    texiDb.SaveChanges();
                    return Ok(driverStatus);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            else
            {
                DriverStatus driverStatus = new DriverStatus();
                driverStatus.isOnline = driverStatusUpdate.isOnline;
                driverStatus.lastSeen = DateTime.UtcNow;
                driverStatus.Lat = driverStatusUpdate.Lat;
                driverStatus.Lng = driverStatusUpdate.Lng;
                driverStatus.DriverId = DriverId;
                texiDb.DriverStatus.Add(driverStatus);
                try
                {
                    texiDb.SaveChanges();
                    return Ok(driverStatus);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        // PUT: api/Template/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return Json("");

        }

        // DELETE: api/Template/5
        [Authorize (Roles ="Admin")]
        public IHttpActionResult Delete(int id)
        {
            return Json("");

        }

        /*
          //var driverStatusObject = texiDb.DriverStatus.Where(O => O.DriverId == DriverId).FirstOrDefault();
            //if drive status not found...
            if (texiDb.DriverStatus.Where(O => O.DriverId == driverStatusUpdate.DriverId).FirstOrDefault() == null)
            {
                return NotFound();
            }
            //if driver status found or already exists...
            else
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (DriverId != driverStatusUpdate.DriverId)
                {
                    return BadRequest();
                }
                db.Entry(driverStatusUpdate).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    return Ok(driverStatusUpdate);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
         
         */
    }
}
