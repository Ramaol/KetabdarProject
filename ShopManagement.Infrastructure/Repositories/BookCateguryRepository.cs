using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopManagement.Domain.BookCateguryAgg;
using System.Linq;
using Zero_Framework.Infrastructure;

namespace ShopManagement.Infrastructure.Repositories
{
    public class BookCateguryRepository : Repository<long ,BookCategury > , IBookCateguryRepository
    {
        private readonly ShopContext _Context;

        public BookCateguryRepository(ShopContext context) : base(context)
        {
            _Context = context;
        }

        public List<BookCategury> Search(string name)
        {
            
            if(!String.IsNullOrWhiteSpace(name))
                return _Context.BookCateguries.Where( x=> x.Name.Contains(name)).OrderByDescending( x => x.Id).ToList();

            return null;
        }   

    }
}
