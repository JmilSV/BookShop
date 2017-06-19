﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace webNew3.Models
{
    [MetadataType(typeof(BookMetadata))]
    [DisplayColumn("BookTitle")]
    public partial class Book
    {
        
    }
    public class BookMetadata
    {
        [Display(Name="Id книги")]
        public int BookId { get; set; }

        [Display(Name = "Id автора книги")]
        public int AuthorId { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Display(Name = "Категорія")]
        public string Category { get; set; }

        [Display(Name = "Ціна")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Назва")]
        public string BookTitle { get; set; }

        [Display(Name = "Шлях до обкладинки")]
        public string BookCover { get; set; }

        [Display(Name = "Наявність")]
        public bool InStock { get; set; }
    }
}