using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAN.SMS.Model.Attributes;
using CAN.SMS.Model.Entities.Base;

namespace CAN.SMS.Model.Entities
{
    public class Country : BaseEntityStatu
    {
        [Index("IX_Code", IsUnique = true)]
        public override string Code { get; set; }

        [Required]
        [StringLength(50)]
        [RequiredFields("Country Name", "txtCountryName")]
        public string CountryName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}