using PharmaCare.DAL.Enums;

namespace PharmaCare.DAL.Models.UserAddress
{
    public abstract class Address : Base
    {
        public string Country { get; set; }
        public string City { get; set; }
        public short streetNumber { get; set; }
        public UserType UserType { get; set; }
    }
}
