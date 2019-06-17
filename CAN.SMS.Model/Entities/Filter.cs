using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAN.SMS.Common.Enums;
using CAN.SMS.Model.Attributes;
using CAN.SMS.Model.Entities.Base;

namespace CAN.SMS.Model.Entities
{
    public class Filter : BaseEntity
    {
        [Index("IX_Code", IsUnique = true)] public override string Code { get; set; }

        [Required]
        [StringLength(100)]
        [RequiredFields("Filter Name", "txtFilterName")]
        public string FilterName { get; set; }

        [Required]
        [StringLength(1000)]
        [RequiredFields("Filter Text", "txtFilterText")]
        public string FilterText { get; set; }

        [Required] public CardType CardType { get; set; }
    }
}