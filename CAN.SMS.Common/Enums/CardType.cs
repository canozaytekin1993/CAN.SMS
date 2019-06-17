using System.ComponentModel;

namespace CAN.SMS.Common.Enums
{
    public enum CardType : byte
    {
        [Description("School Card")] School = 1,
        [Description("Country Card")] Country = 2,
        [Description("County Card")] County = 3,
        [Description("Filter Card")] Filter = 4
    }
}