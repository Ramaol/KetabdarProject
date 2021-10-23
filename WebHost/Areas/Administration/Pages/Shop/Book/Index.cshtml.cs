using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManageMent.Application.Contract.Book;
using ShopManageMent.Application.Contract.BookCategury;

namespace WebHost.Areas.Administration.Pages.Shop.Book
{
    public class Index : PageModel
    {
        public List<BookViewModel> Items { get; set; }
        public BookSearchModel SearchModel { get; set; }
        public SelectList BookCateguriesSelectList { get; set; }
        private readonly IBookApplication _bookApplication;
        private readonly IBookCateguryApplication _bookCateguryApplication;
        
        public Index(IBookApplication bookapplication , IBookCateguryApplication bookCateguryApplication)
        {
            
            _bookApplication = bookapplication;
            _bookCateguryApplication = bookCateguryApplication;
        }
        public void OnGet(BookSearchModel SearchModel)
        {   
            BookCateguriesSelectList = new SelectList(_bookCateguryApplication.List() , "Id" , "Name");
            Items = _bookApplication.Search(SearchModel); 
        }

        public IActionResult OnGetCreate()
        {    
            var command = new CreateBook{
                Categuries = _bookCateguryApplication.List()
            };
            return Partial("./Create" , command);
        }

        public JsonResult OnPostCreate(CreateBook command)
        {
            var result = _bookApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var Book = _bookApplication.GetDetails(id);
            Book.Categuries = _bookCateguryApplication.List();
            return Partial("./Edit" , Book);
        }
        
        public JsonResult OnPostEdit(EditBook command)
        {
            var result = _bookApplication.Edit(command);
            return new JsonResult(result);            
        }
    }

}
