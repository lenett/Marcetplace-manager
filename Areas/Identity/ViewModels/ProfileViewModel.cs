using MM.Areas.Identity.Models;
using System.ComponentModel.DataAnnotations;

namespace MM.Areas.Identity.ViewModels
{
    public class ProfileViewModel
    {
        [Display(Name = "Организации")]
        public List<Companies> Companies { get; set; }
        [Display(Name ="e-mail")]
        public string Email { get; set; }    

    }
}
