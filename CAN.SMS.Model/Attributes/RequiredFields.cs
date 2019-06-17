using System;

namespace CAN.SMS.Model.Attributes
{
    public class RequiredFields : Attribute
    {
        public string _description { get; set; }
        public string _controlName { get; set; }

        public RequiredFields(string description, string controlName)
        {
            _controlName = controlName;
            _description = description;
        }
    }
}