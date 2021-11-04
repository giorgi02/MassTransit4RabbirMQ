using ITA.JESI.EntityFramework;
using ITA.JESI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ITA.JESI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmaciesController : ControllerBase
    {
        private readonly DataContext db;

        public PharmaciesController(DataContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Pharmacies.ToList());
        }

        [HttpPost]
        public IActionResult Add(Pharmacy item)
        {
            db.Pharmacies.Add(item);
            db.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Pharmacy item)
        {
            db.Pharmacies.Update(item);
            db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var v = db.Pharmacies.Find(id);
            db.Pharmacies.Remove(v);
            db.SaveChanges();

            return Ok();
        }
    }
}