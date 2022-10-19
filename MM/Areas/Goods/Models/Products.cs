using System.ComponentModel.DataAnnotations;

namespace MM.Areas.Goods.Models
{
    public class Products
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано название")]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указано описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public bool Is { get; set; }
    }
}
