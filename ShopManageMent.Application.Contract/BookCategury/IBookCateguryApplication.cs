using System.Collections.Generic;
using ShopManagement.Domain.BookCateguryAgg;
using Zero_Framework.Application;

namespace ShopManageMent.Application.Contract.BookCategury
{
    public interface IBookCateguryApplication
    {
        OperationResult Create(CreateBookCategury command);
        OperationResult  Edit(EditBookCategury command);
        ShopManagement.Domain.BookCateguryAgg.BookCategury GetBookCateguryBy(long id);
        EditBookCategury GetDatails(long id);
        List<BookCateguryViewModel> Search(BookCategurySearchModel SearchModel); 
    }
}
