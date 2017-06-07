using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace webNew3.Models
{
    public enum Category
    {
        forSoul,
        horrors,
        brainLiterature,
        romance,
        detective,
        forChildren
    }
    public class Categories
    {
        public static string forSoul = "Для душі";
        public static string brainLiterature = "Для розуму";
        public static string horrors = "Жахи";
        public static string romance = "Романтика";
        public static string detective = "Детектив";
        public static string forChildren = "Для дітей";

        public static List<SelectListItem> categories = new List<SelectListItem> 
        { new SelectListItem{ Text = Categories.forSoul, Value = Category.forSoul.ToString()}, 
            new SelectListItem{ Text = Categories.brainLiterature, Value = Category.brainLiterature.ToString()},
            new SelectListItem{ Text = Categories.horrors, Value = Category.horrors.ToString()},
            new SelectListItem{ Text = Categories.romance, Value = Category.romance.ToString()},
            new SelectListItem{ Text = Categories.detective, Value = Category.detective.ToString()},
            new SelectListItem{ Text = Categories.forChildren, Value = Category.forChildren.ToString()},
        };

        public static Category? category { get; set; }

    }
}