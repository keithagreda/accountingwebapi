using accountingwebapi.Enum;
using accountingwebapi.Models.App;

namespace accountingwebapi.Dtos.IndividualAccount
{
    public class CreateOrEditIndividualAccount
    {
        public Ulid? Id { get; set; }
        public string Description { get; set; }
        public Ulid SubAccountId { get; set; }
    }
}
