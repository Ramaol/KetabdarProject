using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManageMent.Application.Contract.BookCategury;

namespace ShopManageMent.Application.Contract.Book
{
    public class CreateBook
    {
        public string Name { get;set; }
        public string Writer { get;set; }
        public string Translator { get;set; }
        public string PublisherName { get;set; }
        public string ShortDescription { get;set; }
        public string Description { get;set; }
        public string ISBN { get;set; }
        public double UnitPrice { get;set; }
        public string PublishDate { get;set; }
        public double Weight { get;set; }
        public string Picture { get;set; }
        public string PictureAlt{ get;set; }
        public string PictureTitle { get;set; }
        public int PageCount { get;set; }
        public string CoverKind { get;set; }
        public string BookCut { get;set; }
        public long CateguryId { get;set; }
        public string Slug { get;set; }
        public string Keywords { get;set; }
        public string MetaDescription { get;set; }
        public List<BookCateguryViewModel> Categuries { get; set; }
    }
}
