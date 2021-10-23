using System.Linq;
using System.Collections.Generic;
using ShopManagement.Domain.BookCateguryAgg;
using ShopManageMent.Application.Contract.BookCategury;
using Zero_Framework.Application;

namespace ShopManagement.Application
{
    public class BookCateguryApplication : IBookCateguryApplication
    {
        private readonly IBookCateguryRepository _bookCateguryRepository;

        public BookCateguryApplication(IBookCateguryRepository bookCateguryRepository)
        {
            _bookCateguryRepository = bookCateguryRepository;
        }

        public OperationResult Create(CreateBookCategury command)
        {
            var operation = new OperationResult();

            if(_bookCateguryRepository.Exist( x => x.Name == command.Name))
            {
                return operation.Failed(".این رکورد قبلا ثبت شده است");
            } 
            else
            {
                var bookCategury = new BookCategury(command.Name , command.Keywords , command.MetaDescription , command.Slug);
                _bookCateguryRepository.Create(bookCategury);
                _bookCateguryRepository.SaveChanges();
                return operation.Succedded("عملیات با موفقیت انجام شد");
            }
        }

        public OperationResult Edit(EditBookCategury command)
        {
            var operation = new OperationResult();
            var BookCategury = _bookCateguryRepository.Get(command.Id);
            
            if(BookCategury == null)
                return operation.Failed("رکورد با اطلاعات درخواست شده یافت نشد");
            
            if(_bookCateguryRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد مجددا تلاش کنید");

            BookCategury.Edit(command.Name , command.Keywords , command.MetaDescription , command.Slug); 
            _bookCateguryRepository.SaveChanges();
            return operation.Succedded();   
        }

        public BookCategury GetBookCateguryBy(long id)
        {
            return _bookCateguryRepository.Get(id);
        }

        public EditBookCategury GetDetails(long id)
        {   
            var Sample = _bookCateguryRepository.Get(id);
            return new EditBookCategury{
                Name = Sample.Name , 
                MetaDescription = Sample.MetaDescription , 
                Keywords = Sample.KeyWords , 
                Slug = Sample.Slug , 
                Id = Sample.Id,
            };
        }

        public List<BookCateguryViewModel> List()
        {
            var Query = _bookCateguryRepository.GetAll();
            var Result = new List<BookCateguryViewModel>();
            
            foreach (var item in Query)
            {
                Result.Add(new BookCateguryViewModel{
                    Id = item.Id ,
                    Name = item.Name , 
                    CreationDate = item.CreationDate.ToString() 
                    // BookCount = item.Books.g
                });
            }
            return Result;
            
        }

        public List<BookCateguryViewModel> Search(BookCategurySearchModel command)
        {
            var Result = new List<BookCateguryViewModel>();
            var Items = _bookCateguryRepository.Search(command.Name);

            foreach (var item in Items)
            {
                Result.Add(new BookCateguryViewModel{
                    CreationDate = item.CreationDate.ToString(),
                    Name = item.Name,  
                    Id = item.Id,                    
                });
            }

            return Result;
        }
    }
}
