using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTest.Controllers
{
    using System.Web.Http;

    using Data;

    public class CarsController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (var context = new CarContext())
            {
                return this.Ok(context.Cars.Select(car => car.Model).ToList());
            }
            Console.WriteLine("asdasda");
            //Console.WriteLine();
        }
    }
}