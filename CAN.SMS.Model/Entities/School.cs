using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAN.SMS.Model.Attributes;
using CAN.SMS.Model.Entities.Base;

namespace CAN.SMS.Model.Entities
{
    public class School : BaseEntityStatu
    {
        [Index("IX_Code", IsUnique = true)] public override string Code { get; set; }

        [Required] [StringLength(50)] [RequiredFields("School Name", "txtSchoolName")] public string SchoolName { get; set; }

        [RequiredFields("Country Name", "txtCountry")]
        public long CountryId { get; set; }
        [RequiredFields("County Name", "txtCounty")]
        public long CountyId { get; set; }

        [StringLength(500)] public string Description { get; set; }

        public Country Country { get; set; }
        public County County { get; set; }
    }
}