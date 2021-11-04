using Contracts;
using ITA.SSA.EntityFramework;
using ITA.SSA.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ITA.SSA.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiariesController : ControllerBase
    {
        private readonly DataContext db;
        private readonly IPublishEndpoint publishEndpoint;

        public BeneficiariesController(DataContext db, IPublishEndpoint publishEndpoint)
        {
            this.db = db;
            this.publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Beneficiaries.ToList());
        }

        [HttpPost]
        public IActionResult Add(Beneficiary item)
        {
            db.Beneficiaries.Add(item);
            db.SaveChanges();

            publishEndpoint.Publish(new BeneficiaryCreated(item.Id, item.FirstName, item.LastName));

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Beneficiary item)
        {
            db.Beneficiaries.Update(item);
            db.SaveChanges();

            publishEndpoint.Publish(new BeneficiaryUpdated(item.Id, item.FirstName, item.LastName));

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var v = db.Beneficiaries.Find(id);
            db.Beneficiaries.Remove(v);
            db.SaveChanges();

            publishEndpoint.Publish(new BeneficiaryDeleted(id));

            return Ok();
        }
    }
}