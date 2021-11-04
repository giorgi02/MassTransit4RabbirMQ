using Contracts;
using ITA.JESI.Contracts;
using ITA.JESI.EntityFramework;
using MassTransit;
using System.Threading.Tasks;

namespace ITA.SSA.Consumers
{
    public class BeneficiaryCreatedConsumer : IConsumer<BeneficiaryCreated>
    {
        private readonly DataContext db;

        public BeneficiaryCreatedConsumer(DataContext db)
        {
            this.db = db;
        }

        public async Task Consume(ConsumeContext<BeneficiaryCreated> context)
        {

            var message = context.Message;

            var item = new Beneficiary
            {
                Id = message.Id,
                FirstName = message.FirstName,
                LastName = message.LastName,
            };

            db._Beneficiaries.Add(item);
            await db.SaveChangesAsync();
        }
    }
}