using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace webNew3.Models
{
    [DisplayColumn("FirstName")]
    [MetadataType(typeof(AuthorMetaData))]
    public partial class Author
    {
        
    }

    public class AuthorMetaData
    {
        public int AuthorId { get; set; }

        [Display(Name="Ім'я автора")]
        public string FirstName { get; set; }

        [Display(Name = "Фамілія автора")]
        public string LastName { get; set; }

        [Display(Name = "По батькові автора")]
        public string MiddleName { get; set; }

        [Display(Name = "Наявність")]
        public bool InStock { get; set; }
    }
    public struct AdministraterEmail
    {
        static string administratorEmail= "jmil.sv@gmail.com";
        public static string AdministratorEmail 
        {
            get { return administratorEmail; }
        }
    }
}