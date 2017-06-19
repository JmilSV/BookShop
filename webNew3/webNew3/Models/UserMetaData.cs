using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webNew3.Models
{
    [MetadataType(typeof(UserMataData))]
    public partial class User
    {
        [Compare("Password", ErrorMessage ="Паролі не зсівпадають")]
        [DataType(DataType.Password)]
        [Display(Name = "Перевірка пароля")]
        public string ConfirmPassword { get; set; }
    }

    public class UserMataData
    {
        [Display(Name="Id користувача")]
        public int UserId { get; set; }

        [Required(ErrorMessage ="Вкажіть, будь ласка, своє їм'я")]
        [Display(Name ="Ім'я")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Вкажіть, будь ласка, свою фамілію")]
        [Display(Name = "Фамілія")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Вкажіть, будь ласка, свій Email")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "Ви ввели некоректний E-mail")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Вкажіть, будь ласка, пароль")]
        [MinLength(6, ErrorMessage ="Пароль повинен бути більше 5 символів")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name="Роль")]
        public string Role { get; set; }

        [Display(Name="Дата та час створення")]
        public DateTime CreatedDateTime { get; set; }
    }
}