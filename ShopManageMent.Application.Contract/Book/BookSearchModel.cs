using System;

namespace ShopManageMent.Application.Contract.Book
{
    public class BookSearchModel
    {
        public string Name { get; set; }
        public string ISBN { get; set; }
        public long CateguryId { get; set; }
        
    }
}
