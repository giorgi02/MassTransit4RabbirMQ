﻿using Contracts;
using ITA.JESI.Contracts;
using ITA.JESI.EntityFramework;
using MassTransit;
using System.Threading.Tasks;

namespace ITA.SSA.Consumers
{
    public class BeneficiaryUpdatedConsumer : IConsumer<BeneficiaryUpdated>
    {
        private readonly DataContext db;

        public BeneficiaryUpdatedConsumer(DataContext db)
        {
            this.db = db;
        }

        public async Task Consume(ConsumeContext<BeneficiaryUpdated> context)
        {
            var message = context.Message;

            var item = new Beneficiary
            {
                Id = message.Id,
                FirstName = message.FirstName,
                LastName = message.LastName,
            };

            db._Beneficiaries.Update(item);
            await db.SaveChangesAsync();
        }
    }
}