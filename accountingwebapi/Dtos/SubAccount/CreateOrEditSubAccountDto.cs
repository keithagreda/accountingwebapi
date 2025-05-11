using accountingwebapi.Enum;
using accountingwebapi.Models.App;

namespace accountingwebapi.Dtos.SubAccount
{
    public class CreateOrEditSubAccountDto
    {
        public Ulid? Id { get; set; }
        public AccountCategory AccountCateg { get; set; }
        public string Name { get; set; }
    }
}
