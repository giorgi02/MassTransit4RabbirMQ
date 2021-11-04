using ITA.NCDC.EntityFramework;
using ITA.NCDC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ITA.NCDC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboratoriesController : ControllerBase
    {
        private readonly DataContext db;

        public LaboratoriesController(DataContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Laboratories.ToList());
        }

        [HttpPost]
        public IActionResult Add(Laboratory item)
        {
            db.Laboratories.Add(item);
            db.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Laboratory item)
        {
            db.Laboratories.Update(item);
            db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var v = db.Laboratories.Find(id);
            db.Laboratories.Remove(v);
            db.SaveChanges();

            return Ok();
        }
    }
}