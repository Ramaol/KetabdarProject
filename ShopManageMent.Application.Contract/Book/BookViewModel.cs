using System;

namespace ShopManageMent.Application.Contract.Book
{
    public class BookViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public double UnitPrice { get; set; }
        public string Categury { get; set; }
        public string Picture { get; set; }
    }
}
