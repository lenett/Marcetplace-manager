using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MM.Areas.Goods.ViewModels
{
    public class ProductsModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано название")]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не заполнен текст книги")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Текст")]
        public string Text { get; set; }
        public int UserId { get; set; }
        [Display(Name = "Автор")]
        public string Author { get; set; }
        [Display(Name = "Активность")]
        public bool IsActive { get; set; }
        [Display(Name = "Обложка hhhhhhhhhhhhhhhhh")]
        public IFormFile Picture { get; set; }
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
