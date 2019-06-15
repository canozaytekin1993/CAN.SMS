using CAN.SMS.Model.Entities.Base;

namespace CAN.SMS.Bll.Interfaces
{
    public interface IBaseGeneralBll
    {
        bool Insert(BaseEntity entity);
        bool Update(BaseEntity oldEntity, BaseEntity currentEntity);
        string NewCodeCreate();
    }
}