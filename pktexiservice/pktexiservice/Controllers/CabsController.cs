﻿using pktexiservice.Models;
using pktexiservice.Models.Level1;
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
    public class CabsController : ApiController
    {
        /// <summary>
        /// -get all cabs.
        /// -add new cab.
        /// -edit cab data.
        /// -delete cab.
        /// ----sample cab req----
        /* {
	          "id":2,
              "RegNo": 0,
              "RegNo": 0,
              "Name": "swift desire",
              "SeatCapacity": 4,
              "Color": "white",
              "Model": "desire",
              "Type": 1
            }   
        */
        /// </summary>
    TexiDbContext db = new TexiDbContext();
        // GET: api/Template
        public IHttpActionResult Get()
        {
            List<Cab> cabs = db.Cabs.ToList();
            if (cabs == null)
            {
                return NotFound();
            }

            return Ok(cabs);
        }

        // GET: api/Template/5
        public IHttpActionResult Get(int id)
        {

            Cab cab = db.Cabs.Find(id);
            if (cab == null)
            {
                return NotFound();
            }

            return Ok(cab);
        }

        // POST: api/Template
        public IHttpActionResult Post(Cab cab)
        {
            try
            {
                if (cab != null)
                {
                    db.Cabs.Add(cab);
                    db.SaveChanges();
                }

                return Json("Cab Added");
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
           

        }

        // PUT: api/Template/5
        public IHttpActionResult Put(int id,Cab cab)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cab.id)
            {
                return BadRequest();
            }

            db.Entry(cab).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                return Ok(cab);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CabExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            

        }

        private bool CabExists(int id)
        {
            return db.Cabs.Count(e => e.id == id) > 0;
        }

        // DELETE: api/Template/5
        public IHttpActionResult Delete(int id)
        {
            Cab cab = db.Cabs.Find(id);
            if (cab == null)
            {
                return NotFound();
            }

            db.Cabs.Remove(cab);
            db.SaveChanges();

            return Ok(cab);

        }
    }
}
