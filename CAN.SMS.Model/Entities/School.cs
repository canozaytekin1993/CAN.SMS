using CAN.SMS.Model.Entities.Base;

namespace CAN.SMS.Model.Entities
{
    public class School : BaseEntityStatu
    {
        public string SchoolName { get; set; }
        public long CountryId { get; set; }
        public long CountyId { get; set; }
        public string Description { get; set; }
    }
}