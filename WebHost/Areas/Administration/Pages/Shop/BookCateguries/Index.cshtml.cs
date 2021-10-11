using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManageMent.Application.Contract.BookCategury;

namespace WebHost.Areas.Administration.Pages.Shop.BookCateguries
{
    public class Index : PageModel
    {
        public List<BookCateguryViewModel> Items { get; set; }
        private readonly IBookCateguryApplication _bookCateguryApplication;
    
        public Index(IBookCateguryApplication bookcateguryapplication)
        {
            _bookCateguryApplication = bookcateguryapplication;
        }
        public void OnGet(BookCategurySearchModel SearchModel)
        {  
            Items = _bookCateguryApplication.Search(SearchModel);            
        }

        public IActionResult OnGetCreate()
        {    
            
            return Partial("./Create" , new CreateBookCategury());
        }

        public JsonResult OnPostCreate(CreateBookCategury command)
        {
            var result = _bookCateguryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var BookCategury = _bookCateguryApplication.GetDatails(id);
            return Partial("./Edit" , BookCategury);
        }
        
        public JsonResult OnPostEdit(EditBookCategury command)
        {
            var result = _bookCateguryApplication.Edit(command);
            return new JsonResult(result);
        }
    }

}
