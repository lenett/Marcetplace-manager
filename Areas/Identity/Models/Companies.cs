using System.ComponentModel.DataAnnotations;

namespace MM.Areas.Identity.Models
{
    public class Companies
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано название")]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [StringLength(450)]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Не указано название")]
        [Display(Name = "ИНН")]
        public int INN { get; set; }
        [Display(Name = "Статус")]
        public CompanyStatus Status { get; set; }

        
    }

    public enum CompanyStatus
    {
        [Display(Name = "Активный")]
        IsActive,
        [Display(Name = "Скрытный")]
        IsHidden,
    }


}
