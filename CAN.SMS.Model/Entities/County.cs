using CAN.SMS.Model.Entities.Base;

namespace CAN.SMS.Model.Entities
{
    public class County : BaseEntityStatu
    {
        public string CountyName { get; set; }
        public long CountryId { get; set; }
        public string Description { get; set; }

        public Country Country { get; set; }
    }
}