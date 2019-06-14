using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAN.SMS.Model.Entities.Base;

namespace CAN.SMS.Model.Entities
{
    public class County : BaseEntityStatu
    {
        [Index("IX_Code", IsUnique = true)] public override string Code { get; set; }

        [Required] [StringLength(50)] public string CountyName { get; set; }

        public long CountryId { get; set; }

        [StringLength(500)] public string Description { get; set; }

        public Country Country { get; set; }
    }
}