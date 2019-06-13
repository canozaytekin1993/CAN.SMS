using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAN.SMS.Model.Entities.Base.Interfaces;

namespace CAN.SMS.Model.Entities.Base
{
    public class BaseEntity : IBaseEntity
    {
        [Column(Order = 0), Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long? Id { get; set; }
        [Column(Order = 1), Required, StringLength(20)]
        public virtual string Code { get; set; }
    }
}