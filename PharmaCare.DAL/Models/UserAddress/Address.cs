using PharmaCare.DAL.Enums;

namespace PharmaCare.DAL.Models.UserAddress
{
    public class Address
    {
        public int Id;
        public short streetNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public int UserId { get; set; }
        public UserType UserType { get; set; }
    }
}
