using System;
using System.Collections.Generic;
using Zero_Framework.Domain;

namespace ShopManagement.Domain.BookAgg
{
    public interface IBookRepository : IRepository<long , Book>
    {
        List<Book> Search(string Name , string ISBN, long CategryId);
    }
}
