using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Zero_Framework.Domain;

namespace ShopManagement.Domain.BookCateguryAgg
{
    public interface IBookCateguryRepository : IRepository<long , BookCategury>
    {
        List<BookCategury> Search(string name); 
        // void DeleteAll();
    
    }
}
