using CAN.SMS.Model.Entities;
using CAN.SMS.Model.Entities.Base;

namespace CAN.SMS.Model.Dto
{
    // Attribute
    public class SchoolS : School
    {
        public string CountryName { get; set; }
        public string CountyName { get; set; }
    }

    public class SchoolL : BaseEntity
    {
        public string SchoolName { get; set; }
        public string CountryName { get; set; }
        public string CountyName { get; set; }
        public string Description { get; set; }
    }
}