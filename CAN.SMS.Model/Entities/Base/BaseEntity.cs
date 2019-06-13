using CAN.SMS.Model.Entities.Base.Interfaces;

namespace CAN.SMS.Model.Entities.Base
{
    public class BaseEntity : IBaseEntity
    {
        public long? Id { get; set; }
        public string Code { get; set; }
    }
}