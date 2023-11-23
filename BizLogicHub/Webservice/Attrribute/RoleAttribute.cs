using Model.Enum;

namespace Webservice.Attrribute
{
    public class RoleAttribute : Attribute
    {
        public RoleEnum Role { get; set; }

        public RoleAttribute(RoleEnum role)
        {
            Role = role;
        }
    }
}
