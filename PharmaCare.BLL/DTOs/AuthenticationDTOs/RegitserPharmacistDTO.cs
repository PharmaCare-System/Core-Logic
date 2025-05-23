using System.ComponentModel.DataAnnotations;

namespace PharmaCare.BLL.DTOs.AuthenticationDTOs
{


    public class RegitserPharmacistDTO
    {

        [Required(ErrorMessage = "First name is required!")]
        [MaxLength(50, ErrorMessage = "First name can not exceed 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required!")]
        [MaxLength(50, ErrorMessage = "Last name can not exceed 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Birthdate is required!")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string AddressOne { get; set; }

        public string? AddressTwo { get; set; }

        [Required]
        public string HireDate { get; set; }

        [Required]
        public int pharmacyId { get; set; }

    }


}
