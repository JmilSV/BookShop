using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webNew3.Models
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Вкажіть, будь ласка, ім'я отримувача")]
        [Display(Name = "Ім'я")]
        [StringLength(50, ErrorMessage="Багато тексту, введіть менше знаків")]
        public string FirstName { get; set; }

        [Display(Name = "Фамілія")]
        [Required(ErrorMessage = "Вкажіть, будь ласка, фамілію отримувача")]
        [StringLength(50, ErrorMessage = "Багато тексту, введіть менше знаків")]
        public string LastName { get; set; }

        [Display(Name = "Країна")]
        [Required(ErrorMessage = "Вкажіть, будь ласка, країну")]
        [StringLength(100, ErrorMessage = "Багато тексту, введіть менше знаків")]
        public string Country { get; set; }

        [Display(Name = "Місто/село")]
        [Required(ErrorMessage = "Вкажіть, будь ласка, місто чи село")]
        [StringLength(100, ErrorMessage = "Багато тексту, введіть менше знаків")]
        public string CityOrVillage { get; set; }

        [Display(Name = "Вулиця")]
        [Required(ErrorMessage = "Вкажіть, будь ласка, вулицю")]
        [StringLength(100, ErrorMessage = "Багато тексту, введіть менше знаків")]
        public string Street { get; set; }

        [Display(Name = "Будинок")]
        [Required(ErrorMessage = "Вкажіть, будь ласка, будинок")]
        [StringLength(100, ErrorMessage = "Багато тексту, введіть менше знаків")]
        public string House { get; set; }

        [Display(Name = "Квартира")]
        [Range(1, int.MaxValue)]
        public int? Appartment { get; set; }

        [Display(Name = "Номер телефону")]
        [Required(ErrorMessage = "Вкажіть, будь ласка, контактний телефон")]
        [MinLength(5, ErrorMessage="Невірно вказаний номер")]
        [StringLength(15, ErrorMessage = "Багато тексту, введіть менше знаків")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Елекронна пошта")]
        [Required(ErrorMessage = "Вкажіть, будь ласка, Ваш E-mail")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "Багато тексту, введіть менше знаків")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "Ви ввели некоректний E-mail")]
        public string Email { get; set; }

        public List<CustomerOrder> customerOrders { get; set; }
        public List<Book> books { get; set; }
        public decimal cost { get; set; }
    }
}