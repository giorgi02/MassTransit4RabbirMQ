using Contracts;
using ITA.NCDC.EntityFramework;
using MassTransit;
using System.Threading.Tasks;

namespace ITA.NCDC.Consumers
{
    public class BeneficiaryDeletedConsumer : IConsumer<BeneficiaryDeleted>
    {
        private readonly DataContext db;

        public BeneficiaryDeletedConsumer(DataContext db)
        {
            this.db = db;
        }

        public async Task Consume(ConsumeContext<BeneficiaryDeleted> context)
        {
            var message = context.Message;
            var item = db._Beneficiaries.Find(message.Id);
            db._Beneficiaries.Remove(item);

            await db.SaveChangesAsync();
        }
    }
}