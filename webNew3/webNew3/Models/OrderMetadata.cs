using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace webNew3.Models
{
    [MetadataType(typeof(CustomerMetaData))]
    public partial class Customer
    {
    }

    [MetadataType(typeof(CustomerAdressMetadata))]
    public partial class CustomerAdress
    {
    }

    [MetadataType(typeof(CustomerOrderMetadata))]
    public partial class CustomerOrder
    {
    }

    [MetadataType(typeof(CustomerContactDataMetadata))]
    public partial class CustomerContactData
    {
    }

    public class CustomerMetaData
    {
        
        [Required(ErrorMessage = "Вкажіть, будь ласка, ім'я отримувача")]
        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }

        [Display(Name = "Фамілія")]
        [Required(ErrorMessage = "Вкажіть, будь ласка, фамілію отримувача")]
        public string LastName { get; set; }
    }

    public class CustomerAdressMetadata
    {
        [Display(Name = "Країна")]
        [Required(ErrorMessage = "Вкажіть, будь ласка, країну")]
        public string Country { get; set; }

        [Display(Name = "Місто/село")]
        [Required(ErrorMessage = "Вкажіть, будь ласка, місто чи село")]
        public string CityOrVillage { get; set; }

        [Display(Name = "Вулиця")]
        [Required(ErrorMessage = "Вкажіть, будь ласка, вулицю")]
        public string Street { get; set; }

        [Display(Name = "Будинок")]
        [Required(ErrorMessage = "Вкажіть, будь ласка, будинок")]
        public string House { get; set; }

        [Display(Name = "Квартира")]
        public int? Appartment { get; set; }
    }
    public class CustomerOrderMetadata
    {

        public decimal Price { get; set; }


        public int Quantity { get; set; }
    }

    public class CustomerContactDataMetadata
    {
        [Display(Name = "Номер телефону")]
        [Required(ErrorMessage = "Вкажіть, будь ласка, контактний телефон")]
        [DataType(DataType.PhoneNumber, ErrorMessage="Телефон некоректний")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Елекронна пошта")]
        [Required(ErrorMessage = "Вкажіть, будь ласка, Ваш E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage="E-mail некоректний")]
        public string Email { get; set; }
    }
}