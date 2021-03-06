using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace XYZ.BL.ViewModels
{
    public class AdminVM
    {
       
        public  string Email { get; set; }
      
        public  string PhoneNumber { get; set; }
       
        public  string UserName { get; set; }
        [JsonIgnore]

        public string Id { get; set; }
        public bool? Active { get; set; }

        [Required(ErrorMessage = "Kindly, enter the mobile number.")]
        [Display(Name = "Mobile Number")]
        [Phone]
        public string MobileNumber { get; set; }
    
    }
}
