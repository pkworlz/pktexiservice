using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using pktexiservice.HelperClasses;
using pktexiservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pktexiservice.Controllers
{
    public class CustomersController : ApiController
    {

        ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Customers
        public IHttpActionResult Get()
        {
            try
            {
                var Drivers = Helper.GetUsersInRole("Customer");
                List<string> driverNames = new List<string>();
                foreach (var item in Drivers)
                {
                    driverNames.Add(item.Email);
                }
                return Json(driverNames);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        // GET: api/Customers/5
        //public IHttpActionResult Get(string email)
        //{
        //    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        //    var User = UserManager.FindByEmail(email);
        //    UserManager.AddToRole(User.Id, "Customer");

        //    return Json(User.Email + " : Customer Added");
        //}

        // POST: api/Customers
        public IHttpActionResult Post(string email)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var User = UserManager.FindByEmail(email);
            UserManager.AddToRole(User.Id, "Customer");

            return Json(User.Email + " : Customer Added");
        }

        

        // DELETE: api/Customers/5
        public IHttpActionResult Delete(string email)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var User = UserManager.FindByEmail(email);
            UserManager.RemoveFromRole(User.Id, "Customer");
            
            return Json(User.Email + ": Customer Removed");
        }
    }
}
