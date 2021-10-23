using System;
using System.Collections.Generic;
using ShopManagement.Domain.BookAgg;
using Zero_Framework.Infrastructure;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ShopManagement.Infrastructure.Repositories
{
    public class BookRepository : Repository<long, Book>, IBookRepository
    {
        private readonly ShopContext _Context;

        public BookRepository(ShopContext context) : base(context)
        {
            _Context = context;
        }
        public List<Book> Search(string name, string isbn, long categuryid)
        {
            var Query = new List<Book>();
            
        

            if(!String.IsNullOrWhiteSpace(name))
                Query = _Context.Books.Include(x => x.CateguryId).Where(x => x.Name.Contains(name)).OrderByDescending( x => x.Id).ToList();
            
            if(!String.IsNullOrWhiteSpace(isbn))
                Query = _Context.Books.Where(x => x.ISBN.Contains(isbn)).OrderByDescending(x => x.Id).ToList();

            if (categuryid != 0)
                Query = _Context.Books.Where(x => x.CateguryId == categuryid).OrderByDescending(x => x.Id).ToList();
        
            if(string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(isbn) && categuryid==0)
                Query = _Context.Books.OrderByDescending(x => x.Id).ToList();
            
            return Query;
        }
    }
}
