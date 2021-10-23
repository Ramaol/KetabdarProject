using System;
using ShopManagement.Domain.BookCateguryAgg;
using Zero_Framework.Domain;

namespace ShopManagement.Domain.BookAgg
{
    public class Book  : EntityBase
    {
        public string Name { get; private set; }
        public string Writer { get; private set; }
        public string Translator { get; private set; }
        public string PublisherName { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string ISBN { get; private set; }
        public double UnitPrice { get; private set; }
        public string PublishDate { get; private set; }
        public double Weight { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt{ get; private set; }
        public string PictureTitle { get; private set; }
        public int PageCount { get; private set; }
        public string CoverKind { get; private set; }
        public string BookCut { get; private set; }
        public bool IsInStock { get; private set; }
        public long CateguryId { get; private set; }
        public BookCategury Categury { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public bool IsDeleted { get; private set; }
       
        protected Book()
        {
            
        }
        public Book(string name , string writer , string translator ,string publishername ,
                    string shortdescription , string description , string isbn ,double unitprice,
                    string publishdate , double weight ,string picture , string picturealt , 
                    string picturetitle , int pagecount , string coverkind , string bookcut , 
                    string slug , string keywords , string metadescription, long categuryid )
        {
            Name = name; 
            Writer = writer ; 
            Translator = translator;
            PublisherName = publishername;
            ShortDescription = shortdescription;
            Description = description;
            ISBN = isbn;
            UnitPrice = unitprice;
            PublishDate = publishdate;
            Weight = weight;
            Picture = picture;
            PictureAlt = picturealt;
            PictureTitle = picturetitle;
            PageCount = pagecount;
            CoverKind = coverkind;
            BookCut = bookcut;
            CateguryId = categuryid;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metadescription;
            IsDeleted = false;
            IsInStock= true;
        }
        public void Edit(string name , string writer , string translator ,string publishername ,
                    string shortdescription , string description , string isbn ,double unitprice,
                    string publishdate , double weight ,string picture , string picturealt , 
                    string picturetitle , int pagecount , string coverkind , string bookcut , 
                    string slug , string keywords , string metadescription, long categuryid)

        {
            Name = name; 
            Writer = writer ; 
            Translator = translator;
            PublisherName = publishername;
            ShortDescription = shortdescription;
            Description = description;
            ISBN = isbn;
            UnitPrice = unitprice;
            PublishDate = publishdate;
            Weight = weight;
            Picture = picture;
            PictureAlt = picturealt;
            PictureTitle = picturetitle;
            PageCount = pagecount;
            CoverKind = coverkind;
            BookCut = bookcut;
            CateguryId = categuryid;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metadescription;
        }

        public void InStock()
        {
            IsInStock = true;
        }

        public void NotInStock()
        {
            IsInStock = false;
        }

        public void Activate()
        {
            IsDeleted = false;
        }
        public void Delete()
        {
            IsDeleted = true;
        }

    }

    
}
