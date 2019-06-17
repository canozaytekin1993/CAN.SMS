using System;

namespace CAN.SMS.Model.Attributes
{
    public class Code : Attribute
    {
        public string _controlName;
        public string _description;

        public Code(string description, string controlName)
        {

        }
    }
}