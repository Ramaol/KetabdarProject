using System;
using System.Collections.Generic;
using ShopManagement.Domain.BookAgg;
using ShopManageMent.Application.Contract.Book;
using Zero_Framework.Application;


namespace ShopManagement.Application
{
    public class BookApplication : IBookApplication
    {
        
        private readonly Domain.BookAgg.IBookRepository _BookRepository;

        public BookApplication(IBookRepository bookRepository)
        {
            _BookRepository = bookRepository;
        }   
        
        
        public OperationResult Create(CreateBook command)
        {
            OperationResult operation = new OperationResult();
            
            if(_BookRepository.Exist(x => x.Name == command.Name))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            } else
            {   
                // var Slug = command.Slug.Slugify();
                var Sample = new Book(command.Name , command.Writer , command.Translator,
                    command.PublisherName , command.ShortDescription , command.Description,
                    command.ISBN , command.UnitPrice , command.PublishDate , command.Weight,
                    command.Picture , command.PictureAlt,command.PictureTitle , command.PageCount,
                    command.CoverKind , command.BookCut , command.Slug , command.Keywords ,
                    command.MetaDescription , command.CateguryId );
                _BookRepository.Create(Sample);
                _BookRepository.SaveChanges();
                return operation.Succedded();
            }
              
        }

        public OperationResult Edit(EditBook command)
        {
            OperationResult operation = new OperationResult();
            var Sample = _BookRepository.Get(command.Id);
            
            if(Sample == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            
            if(_BookRepository.Exist( x => x.Name==command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);


            Sample.Edit(command.Name , command.Writer , command.Translator,
                    command.PublisherName , command.ShortDescription , command.Description,
                    command.ISBN , command.UnitPrice , command.PublishDate , command.Weight,
                    command.Picture , command.PictureAlt,command.PictureTitle , command.PageCount,
                    command.CoverKind , command.BookCut , command.Slug , command.Keywords ,
                    command.MetaDescription , command.CateguryId );
            
            _BookRepository.SaveChanges();        
            return operation.Succedded();         
        }

        public EditBook GetDetails(long id)
        {
            var result = _BookRepository.Get(id);
            return new EditBook {
                Name = result.Name , 
                Writer = result.Writer ,
                Translator = result.Translator , 
                PublisherName = result.PublisherName , 
                ShortDescription = result.ShortDescription, 
                Description = result.Description , 
                ISBN = result.ISBN , 
                UnitPrice = result.UnitPrice , 
                PublishDate = result.PublishDate , 
                Weight = result.Weight , 
                Picture = result.Picture , 
                PictureAlt = result.PictureAlt , 
                PictureTitle = result.PictureTitle , 
                PageCount = result.PageCount , 
                CoverKind = result.CoverKind , 
                BookCut = result.BookCut , 
                Slug = result.Slug , 
                Keywords = result.Keywords,
                MetaDescription = result.MetaDescription ,
                CateguryId = result.CateguryId  
            };
        }

        public OperationResult InStock(long id)
        {   
            var operation = new OperationResult();
            var Sample = _BookRepository.Get(id);
          
            if(Sample == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            Sample.InStock();
            _BookRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult NotInStock(long id)
        {
            var operation = new OperationResult();
            var Sample = _BookRepository.Get(id);
          
            if(Sample == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            Sample.NotInStock();
            _BookRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<BookViewModel> Search(BookSearchModel command)
        {
            var Query = _BookRepository.Search(command.Name , command.ISBN , command.CateguryId);
            var Result = new List<BookViewModel>();
            
            foreach (var item in Query)
            {
                Result.Add(new BookViewModel{
                    Id = item.Id ,
                    Name = item.Name , 
                    ISBN = item.ISBN , 
                    UnitPrice = item.UnitPrice ,
                    Categury = item.Categury.Name , 
                    Picture = item.Picture
                });
            }

            return Result;
        }
    }
}

