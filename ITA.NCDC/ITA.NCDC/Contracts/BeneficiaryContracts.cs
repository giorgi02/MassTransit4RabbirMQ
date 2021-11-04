namespace Contracts
{
    public record BeneficiaryCreated(int Id, string FirstName, string LastName);
    public record BeneficiaryUpdated(int Id, string FirstName, string LastName);
    public record BeneficiaryDeleted(int Id);
}
