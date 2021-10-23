using System;
using System.Collections.Generic;
using Zero_Framework.Application;


namespace ShopManageMent.Application.Contract.Book
{
    public interface IBookApplication
    {
        OperationResult Create(CreateBook command);
        OperationResult Edit(EditBook command);
        EditBook GetDetails(long id);
        List<BookViewModel> Search(BookSearchModel command);
        OperationResult InStock(long id);
        OperationResult NotInStock(long id);
    
        

    }
}
