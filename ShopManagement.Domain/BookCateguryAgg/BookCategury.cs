﻿using System;

using Zero_Framework.Domain;

namespace ShopManagement.Domain.BookCateguryAgg
{
    public class BookCategury : EntityBase
    {
        public String Name { get; private set; }
        public bool IsDeleted { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        
        protected BookCategury()
        {
            
        }
       
        public BookCategury(string name , string keywords , string mertadescription , string slug)
        {
            Name = name; 
            KeyWords = keywords;
            MetaDescription = MetaDescription;
            Slug = slug;            
        }

        public void Edit(string name , string keywords , string metadescription , string slug)
        {
            Name = name;
            KeyWords = keywords;
            MetaDescription = metadescription;
            Slug = slug;
        }
    }
}